using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Admin.Mededeling.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Admin.Mededeling.Handlers;

public class NieuweMededelingHandlerAsync : ICommandHandler<CreateMededeling>
{
    private readonly EDMSDbContext _dbContext;
    private readonly IValidator<CreateCategory> _validator;
    private readonly ICacheManager _cacheManager;


    public NieuweMededelingHandlerAsync(EDMSDbContext dbContext, 
        IValidator<CreateMededeling> validator, 
        ICacheManager cacheManager)
    {
        _dbContext = dbContext;
        _validator = validator;
        _cacheManager = cacheManager;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateMededeling command)
    {
        await _validator.ValidateCommand(command);
               
        var mededeling = new Mededeling(command);

        _dbContext.Mededelingen.Add(mededeling);

        var @event = new MededelingCreated
        {
            Name = category.Name,
            PermissionSetId = category.PermissionSetId,
            SortOrder = category.SortOrder,
            TargetId = mededeling.Id,
            TargetType = nameof(Mededeling),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId
        };

        _dbContext.Events.Add(@event.ToDbEntity());

        await _dbContext.SaveChangesAsync();

        _cacheManager.Remove(CacheKeys.Categories(command.OrganisatieId));
        _cacheManager.Remove(CacheKeys.CurrentForums(command.OrganisatieId));

        return new IEvent[] { @event };




        var mededeling = new Mededeling(command);
        await _repository.AddAsync(mededeling);

        return new CommandResponse
        {
            Events = mededeling.Events
        };
    }
}