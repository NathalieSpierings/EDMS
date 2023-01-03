using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Queries;

public class GetPeriodeSelectList : IQuery<PeriodeSelectList>
{
    public DateTime Datum { get; set; }
    public int AantalTeTonenKwartalen { get; set; } = 7;
}