namespace GQLDemo.GraphQl
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Models.Platform OnPlatformAdded([EventMessage] Models.Platform platform)
        {
            return platform;
        }
    }
}
