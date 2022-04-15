using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace if3250_2022_19_filantropi_backend.Models
{
    public class DonasiResponse
    {
        public long Id { get; set; }
        public long GalangDanaId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int Amount { get; set; } = default!;

        public DonasiResponse(Donasi donasi, string username)
        {
            Id = donasi.Id;
            GalangDanaId = donasi.GalangDanaId;
            UserId = donasi.UserId;
            UserName = username;
            Amount = donasi.Amount;
        }
    }
}
