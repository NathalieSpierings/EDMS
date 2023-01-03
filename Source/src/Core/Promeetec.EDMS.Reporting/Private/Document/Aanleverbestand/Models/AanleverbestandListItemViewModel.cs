using System;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class AanleverbestandListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string Extension { get; set; }
    public string FileName { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarFormeleNaam { get; set; }
    public Guid? ZorgstraatId { get; set; }
    public string ZorgstraatNaam { get; set; }
    public string Periode { get; set; }
    public bool Gecontroleerd { get; set; }
    public DateTime AangemaaktOp { get; set; }
    public string EigenaarVolledigeNaam { get; set; }
    public string EigenaarAgbCode { get; set; }
    public string OrganisatieNummer { get; set; }
    public string OrganisatieNaam { get; set; }
    public SelectList Zorgstraten { get; set; }
    public SelectList Periodes { get; set; }
}