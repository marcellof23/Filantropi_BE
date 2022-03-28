using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace if3250_2022_19_filantropi_backend.Models
{
    public class GalanganDana
    {
        public long Id { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User? User { get; set; }

        public string EventTitle { get; set; } = default!;

        public string Category { get; set; } = default!;

        public int TargetFund { get; set; } = default!;

        public DateTime Deadline { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string? ImageUrl { get; set; }

        //Status galang dana
        public StatusGalang Status { get; set; }
    }
}
