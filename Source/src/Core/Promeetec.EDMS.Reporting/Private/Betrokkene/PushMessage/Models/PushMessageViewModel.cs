using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

public class PushMessageViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid? MedewerkerId { get; set; }

    [Display(Name = "Titel")]
    public string Title { get; set; }

    [Display(Name = "Bericht")]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; }

    [UIHint("Date")]
    [Display(Name = "Datum")]
    public DateTime Date { get; set; }

    public PushMessageStatus Status { get; set; }

    public IEnumerable<Group> Groups { get; set; }
    public string GroupIds { get; set; }

    public IEnumerable<PushMessageToUser> Users { get; set; } = new List<PushMessageToUser>();

}