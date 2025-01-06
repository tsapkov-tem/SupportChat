using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupportChat.Core.Data.Entities.Models
{
    public class ProblemLog : IEntity
    {
        [Key]
        public string Id { get; set; } = null!;
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string SupportId { get; set; } = null!;
        [JsonIgnore]
        public Support? Support { get; set; }
        [Required]
        public string ProblemId { get; set; } = null!;
        [JsonIgnore]
        public Problem? Problem { get; set; }
    }
}
