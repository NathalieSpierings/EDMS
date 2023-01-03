using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Models;

public enum Raadpleger
{
    Huisarts,
    DeclaratiemedewerkerNamensHuisarts,
    Zorggroep
}

public class IONRaadplegenViewModel : ModelBase
{
    public MedewerkerViewModel Medewerker { get; set; }
    public Raadpleger Raadpleger { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid? ZorggroepRelatieId { get; set; }


    public IONZoekopdrachtViewModel Zoekopdracht { get; set; }
    public int AantalRelaties { get; set; }
    public List<IONPatient> Relaties { get; set; } = new();
}