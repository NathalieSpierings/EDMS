using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;

public class UpdateVerbruiksmiddelPrestatieHandler : ICommandHandler<UpdateVerbruiksmiddelPrestatie>
{
    private readonly IVerbruiksmiddelPrestatieRepository _repository;
    private readonly IValidator<UpdateVerbruiksmiddelPrestatie> _validator;

    public UpdateVerbruiksmiddelPrestatieHandler(IVerbruiksmiddelPrestatieRepository repository, IValidator<UpdateVerbruiksmiddelPrestatie> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateVerbruiksmiddelPrestatie command)
    {
        await _validator.ValidateCommand(command);

        var prestatie = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != VerbruiksmiddelPrestatieStatus.Verwerkt);
        if (prestatie == null)
            throw new DataException($"Prestatie met Id {command.Id} niet gevonden.");

        prestatie.Update(command);

        await _repository.UpdateAsync(prestatie);

        return new IEvent[] { };
    }
}