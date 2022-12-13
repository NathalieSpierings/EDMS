namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde
{
    public interface IVerzekerdeRepository : IRepository<Verzekerde>
    {
        /// <summary>
        /// Gets the exisiting verzekerde.
        /// </summary>
        /// <param name="adresboekId">The adresboek identifier.</param>
        /// <param name="voorletters">The voorletters.</param>
        /// <param name="achternaam">The achternaam.</param>
        /// <param name="geboortedatum">The geboortedatum.</param>
        /// <param name="bsn">The BSN.</param>
        /// <returns></returns>
        Task<Verzekerde?> GetPossibleExisitingVerzekerde(Guid adresboekId, string voorletters, string achternaam, DateTime geboortedatum, string bsn);


        /// <summary>
        /// Determines whether [ patient nummer is unique asynchronous] [the specified adresboek identifier].
        /// </summary>
        /// <param name="adresboekId">The adresboek identifier.</param>
        /// <param name="nummer">The nummer.</param>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        Task<bool> IsPatientNummerUniqueAsync(Guid adresboekId, string nummer, Guid? verzekerdeId = default);

        /// <summary>
        /// Gets the verzekerde identifier by patientnummer.
        /// </summary>
        /// <param name="adresboekId">The adresboek identifier.</param>
        /// <param name="nummer">The nummer.</param>
        Task<Guid> GetVerzekerdeIdByPatientNummerAsync(Guid adresboekId, string nummer);

        /// <summary>
        /// Determines whether [is BSN unique asynchronous] [the specified adresboek identifier].
        /// </summary>
        /// <param name="adresboekId">The adresboek identifier.</param>
        /// <param name="bsn">The BSN.</param>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <returns></returns>
        Task<bool> IsBsnUniqueAsync(Guid adresboekId, string bsn, Guid verzekerdeId = new Guid());

        /// <summary>
        /// Gets the verzekerde identifier by BSN.
        /// </summary>
        /// <param name="adresboekId">The adresboek identifier.</param>
        /// <param name="bsn">The BSN.</param>
        /// <returns></returns>
        Task<Guid> GetVerzekerdeIdByBsnAsync(Guid adresboekId, string bsn);


        /// <summary>
        /// Determines whether [is BSN unique] [the specified adresboek identifier].
        /// </summary>
        /// <param name="adresboekId">The adresboek identifier.</param>
        /// <param name="bsn">The BSN.</param>
        /// <param name="id">The verzekerde identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is BSN unique] [the specified adresboek identifier]; otherwise, <c>false</c>.
        /// </returns>
        bool IsBsnUnique(Guid adresboekId, string bsn, Guid id = new Guid());


        /// <summary>
        /// Determines whether zorgprofiel eindatum is greater than the last zorgprofiel einddatum.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="zorgprofielEinddatum">The zorgprofiel einddatum.</param>
        /// <returns>
        ///   <c>true</c> if [zorgprofiel eindatum] is greater than last zorgprofiel eindatum; otherwise, <c>false</c>.
        /// </returns>
        bool IsZorgprofielEindatumValid(Guid verzekerdeId, DateTime zorgprofielEinddatum);

        /// <summary>
        /// Gets the laatste zorgprofiel einddatum.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <returns></returns>
        DateTime GetLaatsteZorgprofielEinddatum(Guid verzekerdeId);


        /// <summary>
        /// Determines whether zorgprofiel startdatum  is greater than the last zorgprofiel startdatum.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="zorgprofielStartdatum">The zorgprofiel startdatum.</param>
        /// <returns>
        ///   <c>true</c> if [zorgprofiel startdatum] is greater than last zorgprofiel startdatum; otherwise, <c>false</c>.
        /// </returns>
        bool IsZorgprofielStartdatumValid(Guid verzekerdeId, DateTime zorgprofielStartdatum);


        /// <summary>
        /// Gets the laatste zorgprofiel startdatum.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <returns></returns>
        DateTime GetLaatsteZorgprofielStartdatum(Guid verzekerdeId);
    }
}