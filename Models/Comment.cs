using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoBlogForYoutube.Shared.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required, StringLength(1000, MinimumLength =6)]
        public string? Message { get; set; }
        [JsonIgnore]
        public News? News { get; set; }
        public int NewsId { get; set; }
    }
}
