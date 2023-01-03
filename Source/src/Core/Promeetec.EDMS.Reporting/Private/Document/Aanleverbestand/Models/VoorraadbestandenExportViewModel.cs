using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class VoorraadbestandenExportViewModel : ModelBase
{
    public Guid VoorraadId { get; set; }
    public Guid OrganisatieId { get; set; }

    public IEnumerable<VoorraadbestandExportListItemViewModel> Voorraadbestanden { get; set; } = new List<VoorraadbestandExportListItemViewModel>();
}

public class VoorraadbestandExportListItemViewModel
{
    public string OrganisatieNummer { get; set; }
    public string ZorgstraatNaam { get; set; }
    public string Periode { get; set; }

    // Eigenaar
    public string EigenaarVolledigeNaam { get; set; }
    public string EigenaarVecozoNummer { get; set; }
    public string EigenaarAgbCodeOnderneming { get; set; }
    public string EigenaarAgbCodeZorgverlener { get; set; }

    public string FileName { get; set; }
    public DateTime AangemaaktOp { get; set; }
}

public class ExportOverzichtVoorraadbestanden
{
    public string Bestandsnaam { get; set; }
    public string Eigenaar { get; set; }
    public string Periode { get; set; }
    public string ZorgstraatNaam { get; set; }
    public string VecozoNummer { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AangemaaktOp { get; set; }
}