﻿using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

public class GetAanleveringAanleverbestanden : IQuery<AanleveringAanleverbestandenViewModel>
{
    public Guid AanleveringId { get; set; }
    public UserPrincipal User { get; set; }
}