using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace if3250_2022_19_filantropi_backend.Models
{
    public class Donasi
    {
        public long Id { get; set; }

        [ForeignKey("GalanganDana")]
        public long GalangDanaId { get; set; } = default!;
        public virtual GalanganDana GalanganDana { get; set; }

        //[Key]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }
        
        public int Amount { get; set; } = default!;
    }
}
