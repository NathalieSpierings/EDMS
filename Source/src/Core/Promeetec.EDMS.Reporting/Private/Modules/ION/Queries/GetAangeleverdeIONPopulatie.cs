using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Declaratie.ION.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Queries
{
    public class GetAangeleverdeIONPopulatie : IQuery<AangeleverdeIONPopulatieListItemViewModel>
    {
        public Guid OrganisatieId { get; set; }
        public Guid MedewerkerId { get; set; }
        public DateTime Peildatum { get; set; }
    }
}