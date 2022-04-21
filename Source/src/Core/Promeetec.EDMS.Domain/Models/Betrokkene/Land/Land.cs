using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land;

public class Land : AggregateRoot
{
    /// <summary>
    /// The culture code of the country.
    /// </summary>
    [Required, MaxLength(50)]
    public string CultureCode { get; set; }


    /// <summary>
    /// The native name of the country.
    /// </summary>
    [Required, MaxLength(128)]
    public string NativeName { get; set; }


    /// <summary>
    /// The status of the country.
    /// </summary>
    public Status Status { get; set; }


    /// <summary>
    /// Creates an empty country.
    /// </summary>
    public Land()
    {

    }

    //public Land(CreateLand cmd)
    //{
    //    AddAndApplyEvent(new LandAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Status = Status.Actief.ToString(),
    //        CultureCode = cmd.CultureCode,
    //        NativeName = cmd.NativeName
    //    });
    //}

    //public void Update(UpdateLand cmd)
    //{
    //    AddAndApplyEvent(new LandGewijzigd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        CultureCode = cmd.CultureCode,
    //        NativeName = cmd.NativeName
    //    });
    //}

    //public void Delete(DeleteLand cmd)
    //{
    //    AddAndApplyEvent(new LandVerwijderd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Status = Status.Verwijderd.ToString()
    //    });
    //}

    //public void Activate(ActivateLand cmd)
    //{
    //    AddAndApplyEvent(new LandGeactiveerd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Status = Status.Actief.ToString()
    //    });
    //}

    //public void Deactivate(DeactivateLand cmd)
    //{
    //    AddAndApplyEvent(new LandGedeactiveerd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        // UserDisplayName = cmd.UserDisplayName,

    //        Status = Status.Inactief.ToString()
    //    });
    //}

    //#region Private methods

    //private void Apply(LandAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Status = Status.Actief;
    //    CultureCode = @event.CultureCode;
    //    NativeName = @event.NativeName;
    //}

    //private void Apply(LandGewijzigd @event)
    //{
    //    CultureCode = @event.CultureCode;
    //    NativeName = @event.NativeName;
    //}

    //private void Apply(LandVerwijderd @event)
    //{
    //    Status = Status.Verwijderd;
    //}

    //private void Apply(LandGeactiveerd @event)
    //{
    //    Status = Status.Actief;
    //}

    //private void Apply(LandGedeactiveerd @event)
    //{
    //    Status = Status.Inactief;
    //}

    //#endregion
}
