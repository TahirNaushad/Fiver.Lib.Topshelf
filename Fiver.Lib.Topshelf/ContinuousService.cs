using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fiver.Lib.Topshelf
{
    internal class ContinuousService
    {
        private readonly CancellationTokenSource _source;
        private readonly CancellationToken _token;

        public ContinuousService()
        {
            _source = new CancellationTokenSource();
            _token = _source.Token;
        }

        public void Start(int delayInSeconds, Action process)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    process();

                    if (_token.IsCancellationRequested)
                        _token.ThrowIfCancellationRequested();

                    await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
                }
            }, _token);
        }

        public void Stop(Action process)
        {
            _source.Cancel();
            process();
        }
    }
}
