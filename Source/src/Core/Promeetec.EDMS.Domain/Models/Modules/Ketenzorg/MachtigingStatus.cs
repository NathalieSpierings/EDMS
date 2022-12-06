using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Modules.Ketenzorg
{
    public enum MachtigingStatus
    {
        Open,

        [Display(Name = "Verwerkt")]
        Processed,


        [Display(Name = "Verlopen")]
        Expired,

        [Display(Name = "Geannuleerd")]
        Cancelled
    }
}
