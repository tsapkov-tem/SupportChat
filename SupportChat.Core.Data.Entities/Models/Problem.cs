using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupportChat.Core.Data.Entities.Models
{
    public class Problem : IEntity
    {
        [Key]
        public string Id { get; set; } = null!;
        [Required]
        public string StartMessage { get; set; } = null!;
        [Required]
        public ProblemStatus ProblemStatus { get; set; } = ProblemStatus.Open;
        [Required]
        public ProblemEvaluation ProblemEvaluation { get; set; } = ProblemEvaluation.None;
        [JsonIgnore]
        public ICollection<ProblemLog>?  ProblemLogs { get; set; }
    }
}
