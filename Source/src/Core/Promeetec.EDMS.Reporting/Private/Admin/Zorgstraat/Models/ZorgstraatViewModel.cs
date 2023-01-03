using System;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;

public class ZorgstraatViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Naam { get; set; }
    public Status Status { get; set; }
    public SelectList Statussen { get; set; }
}