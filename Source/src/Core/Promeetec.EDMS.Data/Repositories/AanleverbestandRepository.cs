using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Role;

namespace Promeetec.EDMS.Data.Repositories;

public class AanleverbestandRepository : Repository<Aanleverbestand>, IAanleverbestandRepository
{
	public AanleverbestandRepository(EDMSDbContext context)
		: base(context)
	{
	}

	public Aanleverbestand GetAanleverbestandById(Guid id)
	{
		var dbEntity = Query().FirstOrDefault(x => x.Id == id);
		return dbEntity;
	}

	public async Task<Aanleverbestand> GetAanleverbestandByIdAsync(Guid id)
	{
		var dbQuery = await Query().Include(x => x.Samenvatting).FirstOrDefaultAsync(x => x.Id == id);
		return dbQuery;
	}

	public async Task<IList<Aanleverbestand>> GetAanleverbestandenByIdsAsync(List<Guid> ids)
	{
		var dbQuery = Query()
			.Include(x => x.Eigenaar)
			.Include(x => x.Eigenaar.Organisatie)
			.Include(x => x.Samenvatting)
			.Where(x => ids.Contains(x.Id));
		return await dbQuery.ToListAsync();
	}

	/// <summary>
	/// Alle aanleverbestanden voor de aanlevering op basis van aanleveringid.
	/// </summary>
	/// <param name="aanleveringId">The aanlevering identifier.</param>
	/// <param name="user">The user.</param>
	/// <returns>
	///     Alle aanleverbestanden.
	/// </returns>
	public async Task<IList<Aanleverbestand>> GetAanleverbestandenByAanleveringId(Guid aanleveringId, UserPrincipal user)
	{
		var aanleverbestanden = new List<Aanleverbestand>();

		if (user.IsInRole(RoleNames.RaadplegenAanleverbestanden))
		{
			return await Query()
				.Include(i => i.Eigenaar)
				.Include(i => i.Eigenaar.Organisatie)
				.Include(i => i.Zorgstraat)
				.Include(i => i.EiStandaard)
				.Include(i => i.Aanlevering)
				.Where(x => x.AanleveringId == aanleveringId).ToListAsync();
		}

		if (user.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
		{
			return await Query()
				.Include(i => i.Eigenaar)
				.Include(i => i.Eigenaar.Organisatie)
				.Include(i => i.Zorgstraat)
				.Include(i => i.EiStandaard)
				.Include(i => i.Aanlevering)
				.Where(x => x.AanleveringId == aanleveringId && x.EigenaarId == user.Id)
				.ToListAsync();
		}

		return aanleverbestanden;
	}

	public Task<int> AantalAanleverbestandenVanEigenaarAsync(Guid medewerkerId)
	{
		return Query()
			.AsNoTracking()
			.CountAsync(x => x.EigenaarId == medewerkerId);
	}

	/// <summary>
	///     Controleer of bestand al exact bestaat binnen de organisatie.
	/// </summary>
	/// <param name="filesize">The filesize.</param>
	/// <param name="data">The data.</param>
	/// <param name="filename">The filename.</param>
	/// <param name="organisatieId">The organisatie identifier.</param>
	/// <returns>True or false.</returns>
	public bool CheckIfExists(int filesize, byte[] data, string filename, Guid organisatieId)
	{
		try
		{
			var exists = false;

			var dbQuery = Query()
				.Include(i => i.Eigenaar)
				.AsNoTracking()
				.Where(x => x.Eigenaar.Organisatie.Id == organisatieId &&
							x.FileName == filename &&
							x.FileSize == filesize)
				.ToList();

			if (dbQuery.Count >= 1)
				exists = true;

			return exists;
		}
		catch (Exception)
		{
			return false;
		}
	}
}