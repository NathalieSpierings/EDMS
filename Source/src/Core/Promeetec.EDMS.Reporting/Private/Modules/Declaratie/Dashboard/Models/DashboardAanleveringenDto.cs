using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Dashboard.Models;

public class DashboardAanleveringenDto
{
    public Guid Id { get; set; }
    public string Referentie { get; set; }
    public string ReferentiePromeetec { get; set; }
    public AanleverStatus AanleverStatus { get; set; }
    public DateTime Aanleverdatum { get; set; }

    public List<AanleverbestandenDto> Aanleverbestanden = new();
}

public class AanleverbestandenDto
{
    public Guid Id { get; set; }
    public Guid EigenaarId { get; set; }
}