using SampleMEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace SampleMEF.Main
{
    public class Program
    {
        [ImportMany]        
        public IEnumerable<IMessageSender> MessageSenders { get; set; }

        private void Compose()
        {
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(executableLocation), "Plugins");
            var assemblies = Directory
                        .GetFiles(path, "*.dll", SearchOption.AllDirectories)
                        .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                        .ToList();
            var configuration = new ContainerConfiguration()
                .WithAssemblies(assemblies);
            using (var container = configuration.CreateContainer())
            {
                MessageSenders = container.GetExports<IMessageSender>();
            }
        }

        public void Run()
        {
            Compose();
            foreach (var messageSenders in MessageSenders)
            {
                messageSenders.Send("Hello MEF");
            }
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
            Console.ReadKey();
        }        

        

    }
}
