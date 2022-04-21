using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel
{
    public interface IVerbruiksmiddelPrestatieRepository : IRepository<VerbruiksmiddelPrestatie>
    {
        /// <summary>
        /// Determines whether there's a record for the profielstartdatum falling between the 1e day and last day of the processdate.
        /// </summary>
        /// <param name="organisatieId">The organisatie identifier.</param>
        /// <param name="processDate">The process date.</param>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="code">The code.</param>
        /// <param name="profielStartdatum">The profiel startdatum.</param>
        /// <returns></returns>
        Task<bool> HasActiefZorgprofielRecordForProcessMonth(Guid organisatieId, DateTime processDate, Guid verzekerdeId, ProfielCode code, DateTime profielStartdatum);

        /// <summary>
        ///  Determines whether there's a record for the profielstartdatum falling between the startdate and enddate.
        /// </summary>
        /// <param name="organisatieId">The organisatie identifier.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Task<bool> HasActiefZorgprofielRecordForPeriod(Guid organisatieId, DateTime startDate, DateTime endDate, Guid verzekerdeId, ProfielCode code);

        /// <summary>
        /// Gets the ranges between the actieve zorgprofielstartdatum and the processdate.
        /// </summary>
        /// <param name="profielStartdatum">The profiel startdatum.</param>
        /// <param name="processDateLastDay">The process date last day.</param>
        /// <returns></returns>
        Dictionary<DateTime, DateTime> GetActiefZorgprofielPeriods(DateTime profielStartdatum, DateTime processDateLastDay);

        /// <summary>
        /// Gets the ranges between the zorgprofielstartdatum and the processdate.
        /// </summary>
        /// <param name="profielStartdatum">The profiel startdatum.</param>
        /// <param name="profielEinddatum">The profiel einddatum.</param>
        /// <param name="processDateLastDay">The process date last day of month.</param>
        /// <returns></returns>
        Dictionary<DateTime, DateTime> GetHistoryZorgprofielPeriods(DateTime profielStartdatum, DateTime profielEinddatum, DateTime processDateLastDay);


        /// <summary>
        /// Determines whether there's a record for the history zorgprofiel with the given start and end date.
        /// </summary>
        /// <param name="organisatieId">The organisatie identifier.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        Task<bool> HasHistoryZorgprofielRecordForPeriod(Guid organisatieId, DateTime startDate, DateTime endDate, Guid verzekerdeId, ProfielCode code);

        /// <summary>
        /// Determines whether there's a record for the profielstartdatum falling between the 1e day and last day of a month.
        /// </summary>
        /// <param name="organisatieId">The organisatie identifier.</param>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="code">The code.</param>
        /// <param name="profielStartdatum">The profiel startdatum.</param>
        /// <param name="profielEinddatum">The profiel einddatum.</param>
        /// <returns></returns>
        Task<bool> HasHistoryZorgprofielRecordForMonth(Guid organisatieId, Guid verzekerdeId, ProfielCode code, DateTime profielStartdatum, DateTime profielEinddatum);

        /// <summary>
        /// Checks if a  presaties exist asynchronous.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <param name="prestatieDatum">The prestatie datum.</param>
        /// <param name="zIndex">z-i index.</param>
        /// <param name="hoeveelheid">De hoeveelheid.</param>
        /// <returns></returns>
        Task<bool> PresatieExistAsync(Guid verzekerdeId, DateTime prestatieDatum, int zIndex, int hoeveelheid);
    }
}