using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class AanleverbestandenExportViewModel : ModelBase
{
    public Guid AanleveringId { get; set; }
    public Guid OrganisatieId { get; set; }

    public IEnumerable<AanleverbestandExportListItemViewModel> Aanleverbestanden { get; set; } = new List<AanleverbestandExportListItemViewModel>();
}

public class AanleverbestandExportListItemViewModel
{
    public string OrganisatieNummer { get; set; }
    public string ReferentiePromeetec { get; set; }
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

public class ExportOverzichtAanleverbestanden
{
    public string Bestandsnaam { get; set; }
    public string ReferentiePromeetec { get; set; }
    public string Eigenaar { get; set; }
    public string VecozoNummer { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AangemaaktOp { get; set; }
}