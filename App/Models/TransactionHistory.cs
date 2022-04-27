using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace if3250_2022_19_filantropi_backend.Models
{
  public class TransactionHistory
  {
    public long Id { get; set; }

    [ForeignKey("GalangDana")]
    public string GalanganDanaId { get; set; } = default!;

    [ForeignKey("Donasi")]
    public string DonasiId { get; set; } = default!;

    public string Nominal { get; set; } = default!;

    public string Date { get; set; } = default!;
  }
}