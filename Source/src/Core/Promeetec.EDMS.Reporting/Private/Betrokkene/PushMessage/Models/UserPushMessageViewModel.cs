﻿using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

public class UserPushMessageViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid MedewerkerId { get; set; }

    [Display(Name = "Titel")]
    public string Title { get; set; }

    [Display(Name = "Bericht")]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; }

    [UIHint("Date")]
    [Display(Name = "Datum")]
    public DateTime Date { get; set; }

    public PushMessageStatus Status { get; set; }

}