﻿using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Role;

namespace Promeetec.EDMS.Data.Repositories;

public class OverigbestandRepository : Repository<Overigbestand>, IOverigbestandRepository
{
	public OverigbestandRepository(EDMSDbContext context)
		: base(context)
	{
	}

	/// <summary>
	/// Returns a true or false if the file already exsists based on the given fileName.
	/// </summary>
	/// <param name="aanleveringId">The aanlevering identifier.</param>
	/// <param name="fileName">Name of the file.</param>
	/// <param name="user">The user.</param>
	/// <returns>
	/// True if exsists, False if unique.
	/// </returns>
	public bool DoesFileByFileNameExist(Guid aanleveringId, string fileName, UserPrincipal user)
	{
		var dbQuery = Query().AsNoTracking();

		if (user.IsInRole(RoleNames.RaadplegenAanleverbestanden))
		{
			dbQuery = dbQuery.Where(x => x.AanleveringId == aanleveringId);
		}
		else if (user.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
		{
			dbQuery = dbQuery.Where(x => x.AanleveringId == aanleveringId && x.EigenaarId == user.Id);
		}

		return dbQuery.Any(x => x.FileName == fileName);
	}

	public async Task<List<Overigbestand>> GetOverigbestandenByFileNameAsync(string fileName, Guid aanleveringId)
	{
		var dbQuery = await Query()
			.AsNoTracking()
			.Where(x => x.AanleveringId == aanleveringId &&
						x.FileName == fileName)
			.ToListAsync();

		return dbQuery;
	}

	public Overigbestand GetOverigbestandByFileName(string fileName)
	{
		var dbQuery = Query()
			.FirstOrDefault(x => x.FileName == fileName);

		return dbQuery;
	}

	public bool CheckIfNameUnique(Guid aanleveringId, string filename, UserPrincipal user)
	{
		var dbQuery = Query();

		if (user.IsInRole(RoleNames.RaadplegenAanleverbestanden))
			dbQuery = dbQuery.Where(x => x.AanleveringId == aanleveringId);
		else if (user.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden)) dbQuery = dbQuery.Where(x => x.AanleveringId == aanleveringId && x.EigenaarId == user.Id);

		if (dbQuery != null)
		{
			var exists = dbQuery.Any(x => x.FileName == filename);
			return exists;
		}

		return false;
	}

	public async Task<IList<Overigbestand>> GetOverigebestandenByIdsAsync(List<Guid> ids)
	{
		var dbQuery = Query()
			.Include(x => x.Eigenaar)
			.Include(x => x.Eigenaar.Organisatie)
			.Where(x => ids.Contains(x.Id));
		return await dbQuery.ToListAsync();
	}

	/// <summary>
	/// Alle overigebestanden voor de aanlevering op basis van workflowstate en aanleveringid.
	/// </summary>
	/// <param name="aanleveringId">The aanlevering identifier.</param>
	/// <param name="user">The user.</param>
	/// <returns>
	/// Alle aanleverbestanden.
	/// </returns>
	public async Task<IList<Overigbestand>> GetOverigebestandenByAanleveringId(Guid aanleveringId, UserPrincipal user)
	{
		var overigebestanden = new List<Overigbestand>();

		if (user.IsInRole(RoleNames.RaadplegenAanleverbestanden))
		{
			return await Query().Where(x => x.AanleveringId == aanleveringId).ToListAsync();
		}

		if (user.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden))
		{
			return await Query().Where(x => x.AanleveringId == aanleveringId && x.EigenaarId == user.Id).ToListAsync();
		}

		return overigebestanden;
	}
}