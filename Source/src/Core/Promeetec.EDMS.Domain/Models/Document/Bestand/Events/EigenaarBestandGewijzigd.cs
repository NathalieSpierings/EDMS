﻿using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Events
{
    public class EigenaarBestandGewijzigd : EventBase
    {
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}