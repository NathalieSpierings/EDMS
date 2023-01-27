using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Samenvatting;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class AanleverbestandSamenvattingRepository : Repository<AanleverbestandSamenvatting>, IAanleverbestandSamenvattingRepository
{
    public AanleverbestandSamenvattingRepository(EDMSDbContext context)
        : base(context)
    {
    }
}