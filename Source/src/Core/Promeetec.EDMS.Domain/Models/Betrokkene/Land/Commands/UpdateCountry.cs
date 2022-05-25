using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;

public class UpdateCountry : CommandBase
{
    public string CultureCode { get; set; }
    public string NativeName { get; set; }
    public Status Status { get; set; }
}