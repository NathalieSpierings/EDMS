using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Cov;

public enum COVControleProcessType
{
    [Display(Name = "COV Controle stoppen bij uitval")]
    COVProcesStoppenBijUitval = 0,

    [Display(Name = "COV Controle doorzetten bij uitval")]
    COVProcesDoorzettenBijUitval = 1,

    [Display(Name = "COV Controle stoppen/doorzetten bij wijzigingen verzekerdenrecord")]
    COVProcesWijzigingenVerzekerdenRecord = 2
}