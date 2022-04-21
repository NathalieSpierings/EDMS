﻿using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Modules.GLI;

public enum GliStatus
{
    [Display(Name = "Nog niet gestart")]
    NogNietGestart = 0,
    Gestart = 1,
    Gestopt = 2,
    Afgerond = 3,
    Verwijderd = 4,
}