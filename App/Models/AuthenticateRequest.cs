using System.ComponentModel.DataAnnotations;

namespace if3250_2022_19_filantropi_backend.Models
{
  public class AuthenticateRequest
  {
    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
  }
}
