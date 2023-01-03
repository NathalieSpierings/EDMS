using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models
{
    public class HaarwerkViewModel : ModelBase
    {
        public Guid Id { get; set; }
        public Guid OrganisatieId { get; set; }

        [Display(Name = "Cliëntnaam")]
        public string Naam { get; set; }


        [UIHint("Date")]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }


        [Display(Name = "Burgerservicenummer")]
        public string Bsn { get; set; }

        public string Verzekeringsnummer { get; set; }
        public string Machtigingsnummer { get; set; }


        [Display(Name = "Type hulpmiddel")]
        public HaarwerkTypeHulpmiddel TypeHulpmiddel { get; set; }


        [Display(Name = "Soort levering")]
        public HaarwerkLeveringSoort LeveringSoort { get; set; }


        [Display(Name = "Soort haarwerk ")]
        public HaarwerkSoort HaarwerkSoort { get; set; }


        [UIHint("Date")]
        [DataType(DataType.Date)]
        public DateTime Afleverdatum { get; set; }


        [UIHint("Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum voorgaand hulpmiddel")]
        public DateTime? DatumVoorgaandHulpmiddel { get; set; }


        [UIHint("Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum medisch voorschrift")]
        public DateTime? DatumMedischVoorschrift { get; set; }

        [UIHint("Currency")]
        [Display(Name = "Prijs haarwerk")]
        public decimal HaarwerkPrijs { get; set; }

        [UIHint("Currency")]
        [Display(Name = "Basis verzekering")]
        public decimal BedragBasisVerzekering { get; set; }

        [UIHint("Currency")]
        [Display(Name = "Aanvullende verzekering")]
        public decimal BedragAanvullendeVerzekering { get; set; }

        [UIHint("Currency")]
        [Display(Name = "Eigen bijdragen (door cliënt betaald)")]
        public decimal BedragEigenBijdragen { get; set; }

        [UIHint("Currency")]
        [Display(Name = "Bedrag te ontvangen van zorgverzekeraar")]
        public decimal BedragTeOntvangen { get; set; }

        public HaarwerkStatus Status { get; set; }
        public HaarwerkCreditType CreditType { get; set; }
    }
}
