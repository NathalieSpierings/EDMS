using System;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;

public class RedenEindeZorgViewModel : ModelBase
{
    public Guid Id { get; set; }

    public string Code { get; set; }
    public string Omschrijving { get; set; }

    public Status Status { get; set; }

    public SelectList Statussen { get; set; }
}