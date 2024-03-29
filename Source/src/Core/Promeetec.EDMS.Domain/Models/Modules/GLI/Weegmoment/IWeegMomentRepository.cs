﻿using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment;

public interface IWeegmomentRepository : IRepository<Weegmoment>
{
    /// <summary>
    /// Gets all weegmomenten for the verzekerde.
    /// </summary>
    /// <param name="verzekerdeId">The verzekerde identifier.</param>
    /// <returns>All weegmomenten of the verzekerde.</returns>
    Task<List<Weegmoment>> GetWeegmomentenVanVerzekerdeAsync(Guid verzekerdeId);

    /// <summary>
    /// Gets the laatste weegmoment for the verzekerde.
    /// </summary>
    /// <param name="verzekerdeId">The verzekerde identifier.</param>
    /// <returns>The laatste weegmoment of the verzekerde.</returns>
    Task<Weegmoment?> GetLaasteWeegmomentVanVerzekerdeAsync(Guid verzekerdeId);
}