using System.Text.Json.Serialization;

namespace DemoBlogForYoutube.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //relationship : one to many
        [JsonIgnore]
        public List<News>? News { get; set; }
    }
}
