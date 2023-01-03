using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Account.Models;

public class SendCodeViewModel : ModelBase
{
    [Display(Name = "Twee stappen beveiliging")]
    public string SelectedProvider { get; set; }
    public ICollection<SelectListItem> Providers { get; set; }
    public string ReturnUrl { get; set; }
    public bool RememberMe { get; set; }
}