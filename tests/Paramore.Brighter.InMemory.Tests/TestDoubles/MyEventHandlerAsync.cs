using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Paramore.Brighter.InMemory.Tests.TestDoubles;

public class MyEventHandlerAsync(IDictionary<string, string> receivedMessages) : RequestHandlerAsync<MyEvent>
{
    public override async Task<MyEvent> HandleAsync(MyEvent command, CancellationToken cancellationToken = default)
    {
        receivedMessages.Add(nameof(MyEventHandlerAsync), command.Id);
        return await base.HandleAsync(command, cancellationToken).ConfigureAwait(ContinueOnCapturedContext);
    }
}
