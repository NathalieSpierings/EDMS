using OpenCqrs.Domain;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Admin.Mededeling;

public class Mededeling : AggregateRoot
{
    [StringLength(1024)]
    public string Content { get; set; }

    public Mededeling() { }
}
