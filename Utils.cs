using System;
using System.Threading.Tasks;

namespace DS
{
    public static class Utils
    {
        public static async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            SetInterval(action, timeout);
        }
    }
}