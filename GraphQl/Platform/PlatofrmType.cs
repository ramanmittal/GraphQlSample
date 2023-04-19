using GQLDemo.Data;
using GQLDemo.Models;
namespace GQLDemo.GraphQl.Platform
{
    public class PlatofrmType : ObjectType<GQLDemo.Models.Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Models.Platform> descriptor)
        {
            descriptor.Description("Platform Description");
            descriptor.Field(x => x.LicenseKey).Ignore();
            descriptor.Field(x => x.Commands).
            ResolveWith<CommandResolver>(x => x.GetCommands(default, default))
            .UseDbContext<AppDbContext>()
            .Description("This is the list of Commands with this platform");
        }

        private class CommandResolver
        {
            public IQueryable<Command> GetCommands([Parent] Models.Platform platform, [ScopedService] AppDbContext appDbContext)
            {
                return appDbContext.Commands.Where(x => x.PlatformId == platform.Id);
            }
        }
    }
}
