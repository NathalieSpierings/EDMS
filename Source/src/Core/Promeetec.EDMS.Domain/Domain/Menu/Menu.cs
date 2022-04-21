using OpenCqrs.Domain;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Menu
{
    public class Menu : AggregateRoot
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual IList<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        public Menu()
        {
        }


    }
}