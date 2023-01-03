using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatieHandler : IQueryHandler<GetOrganisatie, OrganisatieModel>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IDispatcher _dispatcher;

    public GetOrganisatieHandler(IDispatcher dispatcher, IOrganisatieRepository repository)
    {
        _dispatcher = dispatcher;
        _repository = repository;
    }

    public async Task<OrganisatieModel> Handle(GetOrganisatie query)
    {

        var dbQuery = await _repository.Query()
            .Include(i => i.Contactpersoon)
            .Include(i => i.ZorggroepRelatie)
            .Include(i => i.Adres)
            .AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id == query.OrganisatieId);

        if (dbQuery == null)
            return new OrganisatieModel
            {
                Id = query.OrganisatieId
            };


        var model = new OrganisatieModel
        {
            Id = dbQuery.Id,
            Nummer = dbQuery.Nummer,
            Naam = dbQuery.Naam,
            TelefoonZakelijk = dbQuery.TelefoonZakelijk,
            TelefoonPrive = dbQuery.TelefoonPrive,
            Email = dbQuery.Email,
            Website = dbQuery.Website,
            AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
            Zorggroep = dbQuery.Zorggroep,
            Status = dbQuery.Status,
            Beperkt = dbQuery.Beperkt,
            BeperktReden = dbQuery.BeperktReden,
            AanleverbestandLocatie = dbQuery.Settings.AanleverbestandLocatie,
            AanleverStatusNaSchrijvenAanleverbestanden = dbQuery.Settings.AanleverStatusNaSchrijvenAanleverbestanden,
            VerwijzerInAdresboek = dbQuery.Settings.VerwijzerInAdresboek,
            VerwijderdOp = dbQuery.VerwijderdOp,
            VerwijderdDoorId = dbQuery.VerwijderdDoorId,
            VerwijderdDoor = dbQuery.VerwijderdDoor,
            ContactpersoonId = dbQuery.ContactpersoonId,
            ContactpersoonVolledigeNaam = dbQuery.Contactpersoon.Persoon.VolledigeNaam,
            ContactpersoonEmail = dbQuery.Contactpersoon.Persoon.Email,
            ContactpersoonTelefoon = dbQuery.Contactpersoon.Persoon.TelefoonZakelijk,
            ZorggroepRelatieId = dbQuery.ZorggroepRelatieId,
            ZorggroepRelatie = dbQuery.ZorggroepRelatie?.DisplayName,
            AdresboekId = dbQuery.AdresboekId,
            Adres = dbQuery.Adres != null ?
                new AdresModel
                {
                    Id = dbQuery.Adres.Id,
                    Straat = dbQuery.Adres.Straat,
                    Huisnummer = dbQuery.Adres.Huisnummer,
                    HuisnummerToevoeging = dbQuery.Adres.Huisnummertoevoeging,
                    Postcode = dbQuery.Adres.Postcode,
                    Woonplaats = dbQuery.Adres.Woonplaats,
                    LandNaam = dbQuery.Adres.LandNaam,
                    LandId = dbQuery.Adres.LandId,
                    Land = dbQuery.Adres.Land != null ?
                        new LandModel
                        {
                            Id = dbQuery.Adres.Land.Id,
                            NativeName = dbQuery.Adres.Land.NativeName
                        } : new LandModel()
                 } : new AdresModel()
        };

        if (query.IncludeGekoppeldeOrganisaties && model.Zorggroep)
        {
        //    var gekoppeldeOrganisaties = await _dispatcher.GetResultAsync(new GetGekoppeldeOrganisaties
        //    {
        //        ZorggroepId = query.OrganisatieId
        //    });

        //    model.GekoppeldeOrganisaties = gekoppeldeOrganisaties;
        }

        return model;
    }
}