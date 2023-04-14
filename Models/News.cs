using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBlogForYoutube.Shared.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Publication { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public bool IsPublic { get; set; } = true;
        public string? Source { get; set; }
        public string? Url { get; set; }
        [Required]
        public string? TitleImage { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        public Writer? Writer { get; set; }
        public int WriterId { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
