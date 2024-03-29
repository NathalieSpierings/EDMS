﻿namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;

public class VerzekerdeToAdres
{
    public Guid AdresId { get; set; }
    public virtual Adres.Adres Adres { get; set; }

    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }
}