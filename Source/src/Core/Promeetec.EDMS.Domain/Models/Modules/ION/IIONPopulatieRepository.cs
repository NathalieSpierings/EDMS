using Promeetec.EDMS.Domain.Modules.ION.Commands;

namespace Promeetec.EDMS.Domain.Modules.ION
{
    public interface IIONPopulatieRepository : IRepository<IONPatientRelatie>
    {
        /// <summary>
        /// Haal de populaties op voor een gekoppelde zorggroep.
        /// </summary>
        /// <param name="zorggroepRelatieId">The zorggroep relatie identifier.</param>
        IEnumerable<IONPopulatieDto> GetZorggroepPopulatie(Guid zorggroepRelatieId);

        /// <summary>
        /// Haal de populaties op voor de organisatie.
        /// </summary>
        /// <param name="isInterneMedewerker">if set to <c>true</c> [is interne medewerker].</param>
        /// <param name="organisatieId">The organisatie identifier.</param>
        /// <param name="medewerkerId">The medewerker identifier.</param>
        IEnumerable<IONPopulatieDto> GetOrganisatiePopulatie(bool isInterneMedewerker, Guid organisatieId, Guid medewerkerId);

        Task<bool> PopulatieExistsAsync(IONZoekOptie zoekoptie, string agbZorgverlener, string agbOnderneming, DateTime peildatum);


        /// <summary>
        /// Gets the records.
        /// </summary>
        /// <param name="zorggroep">if set to <c>true</c> [zorggroep].</param>
        /// <param name="ids">The ids.</param>
        List<IONPatientRelatie> GetRecords(bool zorggroep, string ids);


        /// <summary>
        /// Haal de nog niet verwekte patientrelaties op.
        /// </summary>
        /// <param name="zorggroep">if set to <c>true</c> [zorggroep].</param>
        /// <param name="ids">The ids.</param>
        Task<int> VerwerkRecords(bool zorggroep, string ids);

        /// <summary>
        /// Verwijderd de records.
        /// </summary>
        /// <param name="zorggroep">if set to <c>true</c> [zorggroep].</param>
        /// <param name="ids">The ids.</param>
        Task<int> VerwijderRecords(bool zorggroep, string ids);

        /// <summary>
        /// Gets the distinct records.
        /// </summary>
        /// <param name="zorggroep">if set to <c>true</c> [zorggroep].</param>
        /// <param name="ids">The ids.</param>
        List<SendEmailIONPopulatieVerwerkt> GetDistinctRecordsForMailing(bool zorggroep, string ids);


    }

}
