﻿using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class AssingVerzekerde : CommandBase
    {
        public bool Shared { get; set; }
        public Guid VerzekerdeId { get; set; }
        public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
    }
}