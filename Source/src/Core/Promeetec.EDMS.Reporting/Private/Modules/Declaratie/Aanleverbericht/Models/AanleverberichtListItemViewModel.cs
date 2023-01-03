using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

public class AanleverberichtListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public int SortOrder { get; set; }
    public bool Read { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    public DateTime AangemaaktOp { get; set; }

    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    public DateTime? LaatstGelezenOp { get; set; }

    public AanleverberichtStatus AanleverberichtStatus { get; set; }

    public AanleveringViewModel Aanlevering { get; set; }
    public MedewerkerViewModel Afzender { get; set; }
    public MedewerkerViewModel Ontvanger { get; set; }
    public MedewerkerViewModel LaatsteLezer { get; set; }

    public List<AanleverberichtListItemViewModel> Replies = new();
}