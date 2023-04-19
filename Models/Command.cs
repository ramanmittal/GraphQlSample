using System.ComponentModel.DataAnnotations;

namespace GQLDemo.Models
{
    [GraphQLDescription("Represent Command")]
    public class Command
    {
        public int Id { get; set; }
        [Required]
        public string Howto { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
