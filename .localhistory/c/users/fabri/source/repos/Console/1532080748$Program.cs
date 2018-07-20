using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Assinatura;
using Autofac;

namespace Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("iniciando...");
            var repConstrutor = new ContainerBuilder();

            var caminho = AppDomain.CurrentDomain.BaseDirectory;
            var configs = ConfigurationManager.AppSettings;
            var config = configs.Get("CalculaPrecoMedio");

            Assembly.LoadFile(Path.Combine(caminho, config));
            var tipos = TipoPorInterface(typeof(ICalculaPrecoMedio));
            if (tipos.Count() == 0)
            {
                System.Console.WriteLine($"nao encontrado tipo que implemente a interface {typeof(ICalculaPrecoMedio).Name}");
                System.Console.ReadKey();
                return;
            }

            var tipo = tipos.First();
            var valores = new decimal[] { 54, 55, 51, 49, 63, 57, 54, 129 };
            var instancia = Activator.CreateInstance(tipo);
            var media = ((ICalculaPrecoMedio)instancia).Calcula(valores);
            System.Console.WriteLine($"valor que a rotina do cliente que eu nao conheço encontrou: {media}");
            System.Console.WriteLine("fim");
            System.Console.ReadKey();
        }

        private static IEnumerable<Type> TipoPorInterface(Type tipoInterface)
        {
            var r = new List<Type>();
            foreach (var assemblie in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assemblie.GetTypes())
                {
                    if (type.IsAbstract) continue;
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Length == 0) continue;
                    foreach (var @interface in interfaces)
                    {
                        if (@interface.IsGenericType && @interface.GetGenericTypeDefinition() == tipoInterface)
                        {
                            r.Add(type);
                            break;
                        }

                        if (@interface.IsAssignableFrom(tipoInterface))
                        {
                            r.Add(type);
                            break;
                        }
                    }
                }
            }

            return r;
        }
    }
}