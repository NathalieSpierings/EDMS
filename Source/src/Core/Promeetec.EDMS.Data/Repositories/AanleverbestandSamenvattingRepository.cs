using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Samenvatting;

namespace Promeetec.EDMS.Data.Repositories;

public class AanleverbestandSamenvattingRepository : Repository<AanleverbestandSamenvatting>, IAanleverbestandSamenvattingRepository
{
    public AanleverbestandSamenvattingRepository(EDMSDbContext context)
        : base(context)
    {
    }
}