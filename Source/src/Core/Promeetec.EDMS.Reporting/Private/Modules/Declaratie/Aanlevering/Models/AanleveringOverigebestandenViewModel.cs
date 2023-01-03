using System;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringOverigebestandenViewModel : ModelBase
{
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the laatst ingelogd op datum zodat we bestanden die de gebruiker nog niet gezien heeft sinds hij voor het laatst is ingelogd kunnen highlighten.
    /// </summary>
    /// <value>
    /// The laatst ingelogd op.
    /// </value>
    public DateTime LaatstIngelogdOp { get; set; }
    public OverigbestandenViewModel Overigebestanden { get; set; }
}