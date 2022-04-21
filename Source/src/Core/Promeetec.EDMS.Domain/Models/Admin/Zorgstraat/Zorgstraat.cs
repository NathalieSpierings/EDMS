using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;

public class Zorgstraat : AggregateRoot
{
    /// <summary>
    /// The name of the zorgstraat.
    /// </summary>
    [Required, MaxLength(200)]
    public string? Naam { get; set; }


    /// <summary>
    /// The status of the zorgstraat.
    /// </summary>
    public Status Status { get; set; }



    /// <summary>
    /// Creates an empty zorgstraat.
    /// </summary>
    public Zorgstraat()
    {

    }

    //public Zorgstraat(CreateZorgstraat cmd)
    //{
    //    AddAndApplyEvent(new ZorgstraatAangemaakt
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        Status = Shared.Status.Actief.ToString(),
    //        Naam = cmd.Naam
    //    });
    //}

    //public void Update(UpdateZorgstraat cmd)
    //{
    //    AddAndApplyEvent(new ZorgstraatGewijzigd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        Naam = cmd.Naam
    //    });
    //}

    //public void Delete(DeleteZorgstraat cmd)
    //{
    //    AddAndApplyEvent(new ZorgstraatVerwijderd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        Status = Shared.Status.Verwijderd.ToString()
    //    });
    //}

    //public void Activate(ActivateZorgstraat cmd)
    //{
    //    AddAndApplyEvent(new ZorgstraatGeactiveerd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        Status = Shared.Status.Actief.ToString()
    //    });
    //}

    //public void Deactivate(DeactivateZorgstraat cmd)
    //{
    //    AddAndApplyEvent(new ZorgstraatGedeactiveerd
    //    {
    //        AggregateRootId = cmd.AggregateRootId,
    //        UserId = cmd.UserId,
    //        //UserDisplayName = cmd.UserDisplayName,

    //        Status = Shared.Status.Inactief.ToString()
    //    });
    //}

    //#region Private methods

    //private void Apply(ZorgstraatAangemaakt @event)
    //{
    //    Id = @event.AggregateRootId;
    //    Status = Shared.Status.Actief;
    //    Naam = @event.Naam;
    //}

    //private void Apply(ZorgstraatGewijzigd @event)
    //{
    //    Naam = @event.Naam;
    //}

    //private void Apply(ZorgstraatVerwijderd @event)
    //{
    //    Status = Shared.Status.Verwijderd;
    //}

    //private void Apply(ZorgstraatGeactiveerd @event)
    //{
    //    Status = Shared.Status.Actief;
    //}

    //private void Apply(ZorgstraatGedeactiveerd @event)
    //{
    //    Status = Shared.Status.Inactief;
    //}

    //#endregion
}
