using System.ComponentModel.DataAnnotations;

namespace GQLDemo.Models
{
    public class Platform
    {
        public Platform()
        {
            Commands = new List<Command>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LicenseKey { get; set; }

        public virtual ICollection<Command> Commands { get; set; }
    }
}
