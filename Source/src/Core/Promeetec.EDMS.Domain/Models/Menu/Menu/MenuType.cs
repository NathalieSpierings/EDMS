﻿using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu;

public enum MenuType
{
    Menu = 0,

    [Display(Name = "Context menu")]
    ContextMenu = 1
}