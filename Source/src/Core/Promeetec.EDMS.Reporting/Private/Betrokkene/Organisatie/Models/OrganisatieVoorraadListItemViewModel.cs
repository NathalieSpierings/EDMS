using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieVoorraadListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string Extension { get; set; }
    public string FileName { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarFormeleNaam { get; set; }
    public string ZorgstraatNaam { get; set; }
    public string Periode { get; set; }
    public bool Gecontroleerd { get; set; }
    public DateTime AangemaaktOp { get; set; }
}