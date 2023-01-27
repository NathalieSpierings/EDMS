using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling;

public class Mededeling : AggregateRoot
{
    /// <summary>
    /// The content for the notice.
    /// </summary>
    [MaxLength(1024)]
    public string? Content { get; set; }



    /// <summary>
    /// Creates an empty mededeling.
    /// </summary>
    public Mededeling()
    {
    }


    public Mededeling(CreateMededeling cmd)
    {
        Id = cmd.Id;
        Content = cmd.Content;
    }

    public void Update(UpdateMededeling cmd)
    {
        Content = cmd.Content;
    }
}
