namespace if3250_2022_35_cakrawala_backend.Models
{
  public class User
  {
    public long Id { get; set; }
    public string? Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public int DonationAmount { get; set; }
  }
}