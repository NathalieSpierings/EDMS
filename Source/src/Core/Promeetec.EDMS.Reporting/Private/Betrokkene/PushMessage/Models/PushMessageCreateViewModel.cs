using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

public class PushMessageCreateViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Titel")]
    public string Title { get; set; }

    [AllowHtml]
    [Display(Name = "Bericht")]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; }

    [UIHint("Date")]
    [Display(Name = "Datum")]
    public DateTime Date { get; set; }

    public PushMessageStatus Status { get; set; }

    public GroupSelectList GroupSelect { get; set; }

    public IEnumerable<PushMessageToUser> Users { get; set; } = new List<PushMessageToUser>();

}