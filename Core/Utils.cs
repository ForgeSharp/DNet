using System;
using System.Threading.Tasks;

namespace DNet
{
    public static class Utils
    {
        public static async void SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();
            SetInterval(action, timeout);
        }
    }
}