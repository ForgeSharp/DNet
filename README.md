#### DNet

DNet is a .NET API wrapper for Discord. It is not based upon any other library, as is completely built from scratch.

#### Usage

Basic example

```cs
using System.Threading.Tasks;
using DNet.ClientStructures;
using DNet.API.Gateway;

public static class Program {
    public static async Task Main() {
        var client = new Client();

        await client.Connect("YOUR BOT'S TOKEN HERE");

        var handle = client.GetHandle();

        // Events
        handle.OnReady += (object sender, ReadyEvent e)
        {
            Console.WriteLine($"Ready | Logged in as {client.User.Value.Tag}");
        };

        // Required for now, to avoid the app from suddenly stopping.
        await Task.Delay(-1);
    }
}
```