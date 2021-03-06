using System.Text.Json.Serialization;
namespace if3250_2022_19_filantropi_backend.Models
{
  public class User
  {
    public long Id { get; set; }
    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    //[JsonIgnore]
    public string Password { get; set; } = default!;

    public Role Role { get; set; } = default!;

    public string? ImageUrl { get; set; }

    public int DonationAmount { get; set; }

    public float Saldo { get; set; }
  }
}