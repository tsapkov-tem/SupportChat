using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SupportChat.Core.Data.Entities.Models
{
    public class Support : IEntity
    {
        [Key]
        public string Id { get; set; } = null!;
        [NotMapped]
        public string SupportName { get; set; } = null!;
        public SupportType SupportType { get; set; } = SupportType.Standard;
        [JsonIgnore]
        public string SupportProfileId { get; set; } = null!;
        public SupportProfile SupportProfile { get; set; } = null!;
        public ICollection<ProblemLog>? ProblemLogs { get; set; }
    }
}
