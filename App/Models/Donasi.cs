using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace if3250_2022_19_filantropi_backend.Models
{
    public class Donasi
    {
        public long Id { get; set; }
        public long GalangDanaId { get; set; } = default!;

        //[Key]
        //[ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        
        public int Amount { get; set; } = default!;
    }
}
