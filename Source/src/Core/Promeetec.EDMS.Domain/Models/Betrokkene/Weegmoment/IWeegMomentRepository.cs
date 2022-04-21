namespace Promeetec.EDMS.Domain.Betrokkene.Weegmoment
{
    public interface IWeegMomentRepository : IRepository<Weegmoment>
    {
        /// <summary>
        /// Gets all weegmomenten for the verzekerde.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <returns>All weegmomenten of the verzekerde.</returns>
        Task<List<Betrokkene.Weegmoment.Weegmoment>> GetWeegmomentenVanVerzekerdeAsync(Guid verzekerdeId);

        /// <summary>
        /// Gets the laatste weegmoment for the verzekerde.
        /// </summary>
        /// <param name="verzekerdeId">The verzekerde identifier.</param>
        /// <returns>The laatste weegmoment of the verzekerde.</returns>
        Task<Betrokkene.Weegmoment.Weegmoment> GetLaasteWeegmomentVanVerzekerdeAsync(Guid verzekerdeId);
    }
}