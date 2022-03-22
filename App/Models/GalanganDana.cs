using System.Text.Json.Serialization;

namespace if3250_2022_19_filantropi_backend.Models
{
    public class GalanganDana
    {
        public long Id { get; set; }
        public string EventTitle { get; set; } = default!;

        public string Category { get; set; } = default!;

        public int TargetFund { get; set; } = default!;

        public DateTime Deadline { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string? ImageUrl { get; set; }
    }
}
