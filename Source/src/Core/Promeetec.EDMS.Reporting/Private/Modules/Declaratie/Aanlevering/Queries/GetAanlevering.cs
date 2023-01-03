﻿using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Queries;

public class GetAanlevering : IQuery<AanleveringViewModel>
{
    public Guid AanleveringId { get; set; }
    public Guid? OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
    public bool IncludeBestanden { get; set; } = false;
}