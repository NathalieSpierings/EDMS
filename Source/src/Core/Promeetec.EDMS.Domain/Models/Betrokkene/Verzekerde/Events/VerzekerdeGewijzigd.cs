﻿using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Events
{
    public class VerzekerdeGewijzigd : EventBase
    {
        public string Bsn { get; set; }
        public string AgbCodeVerwijzer { get; set; }
        public string NaamVerwijzer { get; set; }
        public string Verwijsdatum { get; set; }
        public Persoon.Persoon Persoon { get; set; }
        public virtual Zorgprofiel Zorgprofiel { get; set; }
        public virtual IList<Zorgprofiel> Zorgprofielen { get; set; } = new List<Zorgprofiel>();
    }
}