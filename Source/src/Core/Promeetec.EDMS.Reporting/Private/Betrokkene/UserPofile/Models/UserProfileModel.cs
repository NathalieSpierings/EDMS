using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;
using Promeetec.EDMS.Reporting.Shared.Models;
using Promeetec.EDMS.Settings;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.UserPofile.Models;

public class UserProfileModel : ModelBase
{
    public Guid OrganisatieId { get; set; }


    [Display(Name = "Paginering grootte")]
    public int PageSize { get; set; }


    [Display(Name = "Tabel weergave")]
    public TableLayout TableLayout { get; set; }


    [Display(Name = "Hoofdmenu weergave")]
    public SidebarLayout SidebarLayout { get; set; }


    [HiddenInput(DisplayValue = false)]
    public string AanleverstatusIds { get; set; }


    [Display(Name = "E-mail bij bericht")]
    public EmailOntvangenType EmailBijAanleverbericht { get; set; }


    [Display(Name = "E-mail bij document(en) toegevoegd")]
    public EmailOntvangenType EmailBijToevoegenDocument { get; set; }

    [Display(Name = "E-mail bij rapportage(s) toegevoegd")]
    public bool EmailBijRapportage { get; set; }


    [Display(Name = "Alternatieve e-mailadressen")]
    //[MultiEmail(ErrorMessage = "Voer geldige e-mailadressen in, gescheiden door puntkomma's.")]
    public string CarbonCopyAdressen { get; set; }
    
    public SelectList AvailablePageSizes => new(Options.PageSizes, "Key", "Value");

    public List<AanleverStatusSelectModel> AanleverStatusen { get; set; } = new();

}