﻿using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandGewijzigd : EventBase
    {
        public string Periode { get; set; }
        public string? Zorgstraat { get; set; }
        public string Eigenaar { get; set; }

        public Guid EigenaarId { get; set; }
        public Guid? ZorgstraatId { get; set; }

    }
}