using System.Collections.Generic;
using Promeetec.AGB.Domain;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Vektis.Models;

public class AgbViewModel : ModelBase
{
    public List<AgbZorgverlener> AgbZorgverleners { get; set; } = new();
    public List<AgbOnderneming> AgbOndernemingen { get; set; } = new();
    public List<AgbOnderneming> AgbPraktijken { get; set; } = new();
    public List<AgbVestiging> AgbVestigingen { get; set; } = new();
}

/// <summary>
/// Class voor AGB API zodat we per zorgverlener ook de zorgpartijen erbij hebben
/// </summary>
public class AgbZorgverlener
{
    public Zorgverlener Zorgverlener { get; set; }
    public Zorgpartij Zorgpartij { get; set; }
}

/// <summary>
/// Class voor AGB API zodat we per onderneming ook de zorgpartijen erbij hebben
/// </summary>
public class AgbOnderneming
{
    public Onderneming Onderneming { get; set; }
    public Zorgpartij Zorgpartij { get; set; }
}


/// <summary>
/// Class voor AGB API zodat we per vestiging ook de zorgpartijen erbij hebben
/// </summary>
public class AgbVestiging
{
    public Vestiging Vestiging { get; set; }
    public Zorgpartij Zorgpartij { get; set; }
}