using System.ComponentModel;
using System.Security.Claims;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;

namespace Promeetec.EDMS.Domain.Models.Identity;

public class UserPrincipal : ClaimsPrincipal
{
	private readonly ClaimsPrincipal _principal;

	public UserPrincipal(ClaimsPrincipal principal)
		: base(principal.Identities)
	{
		_principal = principal;
	}

	public Guid Id => FindFirstValue<Guid>(ClaimTypes.NameIdentifier);
	public string UserName => FindFirstValue<string>(ClaimsIdentity.DefaultNameClaimType);
	public string VolledigeNaam => FindFirstValue<string>(ClaimTypes.GivenName);
	public Geslacht Geslacht => FindFirstValue<Geslacht>("Geslacht");
	public Guid OrganisatieId => FindFirstValue<Guid>("OrganisatieId");
	public string OrganisatieNaam => FindFirstValue<string>("OrganisatieNaam");
	public string OrganisatieNummer => FindFirstValue<string>("OrganisatieNummer");
	public string AgbCodeZorgverlener => FindFirstValue<string>("AgbCodeZorgverlener");
	public string AgbCodeOnderneming => FindFirstValue<string>("AgbCodeOnderneming");
	public string Email => FindFirstValue<string>("Email");
	public bool IsInterneMedewerker => FindFirstValue<bool>("IsInterneMedewerker");
	public bool IsActive => FindFirstValue<bool>("IsActive");
	public bool IsAdmin => FindFirstValue<bool>("IsAdmin");
	public bool IsBeheerder => FindFirstValue<bool>("IsBeheerder");
	public bool IsBlocked => FindFirstValue<bool>("IsBlocked");
	public int PageSize => FindFirstValue<int>("PageSize");
	public TableLayout TableLayout => FindFirstValue<TableLayout>("TableLayout");
	public SidebarLayout SidebarLayout => FindFirstValue<SidebarLayout>("SidebarLayout");


	/// <summary>
	///     https://stackoverflow.com/questions/393731/generic-conversion-function-doesnt-seem-to-work-with-guids
	///     Be careful with using ConvertFromInvariantString.
	///     If your type is a DateTime and you have international date formats, this will blow up.
	/// </summary>
	/// <param name="type">The type.</param>
	private T FindFirstValue<T>(string type)
	{
		var result = Claims.Where(p => p.Type == type)
			.Select(p => (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(p.Value))
			.FirstOrDefault();
		return result;
	}
}
