using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiver.Lib.Topshelf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Topshelf_Default();
            //Topshelf_Continuous();
        }

        private static void Topshelf_Default()
        {
            var name = "fiver.topshelf.default";
            var description = "Default Service";

            Action started = () =>
                Console.WriteLine("Hello at {0}", DateTime.Now.ToString());

            Action stopped = () =>
            {
                Console.WriteLine("Stopped");
                Console.ReadLine();
            };

            TopshelfFactory.RunDefault(
                    name, description, started, stopped);
        }

        private static void Topshelf_Continuous()
        {
            var name = "fiver.topshelf.continuous";
            var description = "Continuous Service";
            var delayInSeconds = 5;

            Action started = () =>
                Console.WriteLine("Hello at {0}", DateTime.Now.ToString());

            Action stopped = () =>
            {
                Console.WriteLine("Stopped");
                Console.ReadLine();
            };

            TopshelfFactory.RunContinuous(
                    name, description, delayInSeconds, started, stopped);
        }
    }
}
