using System;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Models;

// De naar Promeetec verstuurde ION populatie
public class AangeleverdeIONPopulatieListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid MedewerkerId { get; set; }
    public Guid? ZorggroepRelatieId { get; set; }
    public Guid RaadplegerId { get; set; }
    public string RaadplegerNaam { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public DateTime Periode { get; set; }
    public IONZoekOptie IONZoekOptie { get; set; }
    public int AantalPatientRelaties { get; set; } = 0;
    public int Relaties { get; set; } = 0;
    public bool Verwerkt { get; set; }
    public DateTime AangeleverdOp { get; set; }
    public string FormeleNaam { get; set; }
    public bool HeeftAangeleverd
    {
        get
        {
            if (AantalPatientRelaties > 0)
                return true;
            return false;
        }
    }
}