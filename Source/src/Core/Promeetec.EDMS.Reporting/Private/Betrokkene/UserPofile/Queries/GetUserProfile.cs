using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.User.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.User.Queries;

public class GetUserProfile : IQuery<UserProfileViewModel>
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }

}