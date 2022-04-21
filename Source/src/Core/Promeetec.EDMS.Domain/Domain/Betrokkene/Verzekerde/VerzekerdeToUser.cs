﻿namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;

public class VerzekerdeToUser
{
    public Guid UserId { get; set; }
    public virtual Medewerker.Medewerker User { get; set; }

    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }
}
