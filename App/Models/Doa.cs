using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace if3250_2022_19_filantropi_backend.Models
{
    public class Doa
    {
        public long Id { get; set; }

        [ForeignKey("GalanganDana")]
        public long GalangDanaId { get; set; }
        public virtual GalanganDana? GalanganDana { get; set; }

        //[Key]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        
        public string Description { get; set; } = default!;
    }
}
