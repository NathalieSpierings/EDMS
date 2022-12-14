using Promeetec.EDMS.Domain.Models.Modules.GLI;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;

public interface IGliBehandelplanRepository : IRepository<GliBehandelplan>
{
    /// <summary>
    /// Checks if an intake exist asynchronous.
    /// </summary>
    /// <param name="verzekerdeId">The verzekerde identifier.</param>
    /// <param name="fase">The behandelfase.</param>
    /// <returns>True or false.</returns>
    Task<bool> BehandelplanExistAsync(Guid verzekerdeId, GliBehandelfase fase);

    /// <summary>
    /// Gets all the behandelplannen for the given intake
    /// </summary>
    /// <param name="intakeId">The intake identifier.</param>
    /// <returns>A list of behandelplannen.</returns>
    Task<List<GliBehandelplan>> GetBehandelplannenVanTraject(Guid intakeId);

    /// <summary>
    /// Sets the status on verwerkt and process the records to the GLi database.
    /// </summary>
    /// <param name="organisatieId">The organisatie identifier.</param>
    /// <param name="ids">A list of intake identifiers.</param>
    Task<List<GliDto>> GetBehandelplanVoorVerwerkingAsync(Guid organisatieId, List<Guid> ids);

    /// <summary>
    /// Gets all behandelplannen where the start or einddatum falls on the date.
    /// </summary>
    /// <param name="date">The given date.</param>
    /// <returns>A list of GliBehandelplannen.</returns>
    Task<List<GliBehandelplan>> GetBehandelplannenVoorAutomatischeVerwerking(DateTime date);
}