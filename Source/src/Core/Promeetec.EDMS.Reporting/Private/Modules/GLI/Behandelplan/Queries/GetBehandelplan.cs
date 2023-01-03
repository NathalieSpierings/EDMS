using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Registratie.GLI.Behandelplan.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Queries
{
    public class GetBehandelplan : IQuery<BehandelplanViewModel>
    {
        public Guid OrganisatieId { get; set; }
        public Guid BehandelplanId { get; set; }
    }
}