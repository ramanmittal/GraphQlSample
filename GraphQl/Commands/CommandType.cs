using GQLDemo.Data;
using GQLDemo.Models;

namespace GQLDemo.GraphQl.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represent a command.");
            descriptor.Field(x => x.Platform)
                .ResolveWith<CommandResolver>(x => x.GetPlatform(default, default))
                .UseDbContext<AppDbContext>()
                .Description("This Platform can run that command");
            base.Configure(descriptor);
        }

        private class CommandResolver
        {
            public GQLDemo.Models.Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext appDbContext)
            {
                return appDbContext.Platforms.FirstOrDefault(x => x.Id == command.PlatformId);
            }
        }
    }
}
