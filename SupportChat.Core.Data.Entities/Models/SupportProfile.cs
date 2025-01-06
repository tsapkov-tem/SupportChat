using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupportChat.Core.Data.Entities.Models
{
    public class SupportProfile : IEntity
    {
        [Key]
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [JsonIgnore]
        public Support? Support { get; set; } = null!;
    }
}
