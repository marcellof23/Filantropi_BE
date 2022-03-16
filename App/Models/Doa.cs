using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace if3250_2022_19_filantropi_backend.Models
{
    public class Doa
    {
        public long Id { get; set; }

        [ForeignKey("Donasi")]
        public long DonasiId { get; set; }
        public virtual Donasi? Donasi { get; set; }

        //[Key]
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        
        public string Description { get; set; } = default!;
    }
}
