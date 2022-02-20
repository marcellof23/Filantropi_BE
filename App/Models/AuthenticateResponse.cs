namespace if3250_2022_19_filantropi_backend.Models
{
  public class AuthenticateResponse
  {
    public long Id { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
      Id = user.Id;
      Email = user.Email;
      Token = token;
    }
  }
}
