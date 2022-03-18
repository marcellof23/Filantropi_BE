using System.Text.Json.Serialization;
namespace if3250_2022_19_filantropi_backend.Models
{
  public class TransactionHistory
  {
    public long Id { get; set; }
    public string GalanganDanaId { get; set; } = default!;

    public string DonasiId { get; set; } = default!;

    public string Nominal { get; set; } = default!;

    public string Date { get; set; } = default!;
  }
}