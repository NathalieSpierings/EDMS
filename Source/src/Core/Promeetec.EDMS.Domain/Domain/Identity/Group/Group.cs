using OpenCqrs.Domain;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Identity.Group
{
    public class Group : AggregateRoot
    {
        /// <summary>
        /// The name of the group.
        /// </summary>
        [Required, StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// The description of the group.
        /// </summary>
        [StringLength(1024)]
        public string Description { get; set; }


        #region Navigation properties

        public ICollection<GroupRole> Roles { get; set; } = new List<GroupRole>();
        public ICollection<GroupUser> Users { get; set; } = new List<GroupUser>();

        #endregion


        public Group() { }


    }
}