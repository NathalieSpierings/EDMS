﻿using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;

public class UpdateRole : CommandBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}