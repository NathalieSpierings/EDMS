using System;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.User.Queries;

public class GetAvatar : IQuery<byte[]>
{
    public Guid MedewerkerId { get; set; }
}