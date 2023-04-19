using GQLDemo.Data;
using GQLDemo.GraphQl.Commands;
using GQLDemo.GraphQl.Platform;
using GQLDemo.Models;
using HotChocolate.Subscriptions;

namespace GQLDemo.GraphQl
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput addPlatformInput, [ScopedService] AppDbContext appDbContext, [Service] ITopicEventSender topicEventSender, CancellationToken cancellationToken)
        {
            var platform = new Models.Platform
            {
                Name = addPlatformInput.Name,
                LicenseKey = ""
            };
            appDbContext.Platforms.Add(platform);
            await appDbContext.SaveChangesAsync(cancellationToken);

            await topicEventSender.SendAsync(nameof(Subscription.OnPlatformAdded),
                platform, cancellationToken);
            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput addCommandInput, [ScopedService] AppDbContext appDbContext)
        {
            var command = new Command
            {
                CommandLine = addCommandInput.commandLine,
                Howto = addCommandInput.howto,
                PlatformId = addCommandInput.platformId,
            };
            appDbContext.Commands.Add(command);
            await appDbContext.SaveChangesAsync();
            return new AddCommandPayload(command);
        }
    }
}
