﻿using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands
{
    public class RemoveMenuItem : CommandBase
    {
        public Guid MenuId { get; set; }
        public Guid MenuItemId { get; set; }
    }
}
