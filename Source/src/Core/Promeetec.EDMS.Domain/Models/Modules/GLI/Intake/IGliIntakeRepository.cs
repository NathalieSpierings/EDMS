using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;

public interface IGliIntakeRepository : IRepository<GliIntake>
{
    /// <summary>
    /// Checks if an intake exist asynchronous.
    /// </summary>
    /// <param name="verzekerdeId">The verzekerde identifier.</param>
    /// <param name="intakeDatum">The intake date.</param>
    /// <returns>True or false.</returns>
    Task<bool> IntakeExistAsync(Guid verzekerdeId, DateTime intakeDatum);

    /// <summary>
    /// Sets the status on verwerkt and process the records to the GLi database.
    /// </summary>
    /// <param name="organisatieId">The organisatie identifier.</param>
    /// <param name="ids">A list of intake identifiers.</param>
    Task<List<GliDto>> GetIntakeVoorVerwerkingAsync(Guid organisatieId, List<Guid> ids);
}