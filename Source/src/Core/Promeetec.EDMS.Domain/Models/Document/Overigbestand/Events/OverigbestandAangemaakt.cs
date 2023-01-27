﻿using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Overigbestand.Events
{
    public class OverigbestandAangemaakt : EventBase
    {
        public string Bestandsnaam { get; set; }
        public int Bestandsgrootte { get; set; }

        public Guid AanleveringId { get; set; }
        public string ReferentiePromeetec { get; set; }

        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}