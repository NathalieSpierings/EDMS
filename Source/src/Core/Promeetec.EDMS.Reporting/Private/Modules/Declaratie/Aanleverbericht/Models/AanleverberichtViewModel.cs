using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

public class AanleverberichtViewModel : ModelBase
{
    public Guid Id { get; set; }

    public Guid ParentId { get; set; }
    public AanleverberichtType AanleverberichtType { get; set; }

    public bool Gelezen { get; set; }
    public int Volgorde { get; set; }

    [UIHint("DateTime")]
    [Display(Name = "Geplaatst op")]
    [DataType(DataType.DateTime)]
    public DateTime GeplaatstOp { get; set; }

    public string Onderwerp { get; set; }

    [DataType(DataType.MultilineText)]
    public string Bericht { get; set; }


    [Display(Name = "Status")]
    public AanleverberichtStatus AanleverberichtStatus { get; set; }

    // Aanlevering details
    public AanleveringViewModel Aanlevering { get; set; }

    public Guid OntvangerId { get; set; }
    public MedewerkerViewModel Ontvanger { get; set; }

    public Guid AfzenderId { get; set; }
    public MedewerkerViewModel Afzender { get; set; }

    public List<AanleverberichtViewModel> Replies { get; set; } = new();

    public bool ReadOnly { get; set; }

}