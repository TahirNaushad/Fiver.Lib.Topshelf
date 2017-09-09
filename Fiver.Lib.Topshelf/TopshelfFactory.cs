using System;
using Topshelf;

namespace Fiver.Lib.Topshelf
{
    public static class TopshelfFactory
    {
        public static void RunDefault(
            string name, string description,
            Action started,
            Action stopped)
        {
            Run(name, description,
                        () => new DefaultService(),
                        service => service.Start(started),
                        service => service.Stop(stopped));
        }

        public static void RunContinuous(
            string name, string description, int delayInSeconds,
            Action started,
            Action stopped)
        {
            Run(name, description,
                        () => new ContinuousService(),
                        service => service.Start(delayInSeconds, started),
                        service => service.Stop(stopped));
        }

        public static void Run<T>(
            string name, string description,
            Func<T> factory,
            Action<T> started,
            Action<T> stopped
            ) where T : class
        {
            HostFactory.Run(config =>
            {
                config.Service<T>(service =>
                {
                    service.ConstructUsing(factory);
                    service.WhenStarted(started);
                    service.WhenStopped(stopped);
                });
                config.RunAsLocalSystem();

                config.SetDisplayName(name);
                config.SetServiceName(name);
                config.SetDescription(description);
            });
        }
    }
}
