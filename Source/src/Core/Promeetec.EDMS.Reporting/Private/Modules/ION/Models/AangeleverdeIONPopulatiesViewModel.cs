using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Models;

// Alle ION populaties voor de organisatie
public class AangeleverdeIONPopulatiesViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public bool InterneMedewerkerMagRaadplegen { get; set; }
    public OrganisatieViewModel Organisatie { get; set; } = new();
    public IEnumerable<IONPopulatieDto> Populaties { get; set; }


    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        if (Organisatie.Zorggroep && User.IsInterneMedewerker)
        {
            gridContextMenu.Add(new GridContextMenu
            {
                ClientName = "cmRaadpleegZorggroep",
                Icon = "pm_icon_healthcare_snake",
                Title = "ION Raadplegen",
                Active = true,
                Key = OrganisatieId.ToString(),
                RouteValues = new { organisatieId = OrganisatieId },
                Type = GridContextMenuItemType.Link,
                Roles = new[] { RoleNames.RaadplegenION }
            });
        }
        else
        {
            if (User.IsInterneMedewerker)
            {
                if (InterneMedewerkerMagRaadplegen)
                {
                    gridContextMenu.Add(new GridContextMenu
                    {
                        ClientName = "cmRaadpleegNamensHuisarts",
                        Icon = "pm_icon_healthcare_snake",
                        Title = "ION Raadplegen",
                        Active = true,
                        Key = OrganisatieId.ToString(),
                        RouteValues = new { organisatieId = OrganisatieId },
                        Type = GridContextMenuItemType.Link,
                        Roles = new[] { RoleNames.RaadplegenION }
                    });
                }
            }
        }
    }
}