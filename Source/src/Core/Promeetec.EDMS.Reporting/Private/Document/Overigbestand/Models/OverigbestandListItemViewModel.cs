using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;

public class OverigbestandListItemViewModel : ModelBase
{
    public Guid Id { get; set; }

    public string FileName { get; set; }
    public string Extension { get; set; }
    public DateTime AangemaaktOp { get; set; }
    public Guid? AangemaaktDoor { get; set; }
    public string AangemaaktDoorNaam { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarFormeleNaam { get; set; }
    public string EigenaarVolledigeNaam { get; set; }
    public string EigenaarAgbCode { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNummer { get; set; }
    public string OrganisatieNaam { get; set; }
}