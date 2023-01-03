using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models
{
    public class HaarwerkCreateEditViewModel : ModelBase
    {
        public Guid Id { get; set; }
        public Guid OrganisatieId { get; set; }

        [Display(Name = "Cliëntnaam")]
        [Required(ErrorMessage = "Cliëntnaam is verplicht.")]
        [RegularExpression(@"^(?:[u00C0-\u017Fa-zA-Z\-]+\s?)+[u00C0-\u017Fa-zA-Z\-]+$", ErrorMessage = "Alleen letters, spaties en koppeltekens zijn toegestaan.")]
        [StringLength(256, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
        public string Naam { get; set; }

        [UIHint("Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Geboortedatum is verplicht.")]
        [Remote("IsGeboortedatumValid", "Adresboek", ErrorMessage = "{0} kan niet in de toekomst liggen.", HttpMethod = "POST")]
        public DateTime Geboortedatum { get; set; }


        [Display(Name = "Burgerservicenummer")]
        [Required(ErrorMessage = "Burgerservicenummer is verplicht.")]
        [Remote("IsBsnValid", "Haarwerk", ErrorMessage = "{0} is ongeldig!", HttpMethod = "POST")]
        public string Bsn { get; set; }


        public string Verzekeringsnummer { get; set; }
        public string Machtigingsnummer { get; set; }


        [Display(Name = "Type hulpmiddel")]
        public HaarwerkTypeHulpmiddel TypeHulpmiddel { get; set; }


        [Display(Name = "Soort levering")]
        public HaarwerkLeveringSoort LeveringSoort { get; set; }


        [Display(Name = "Soort haarwerk ")]
        public HaarwerkSoort HaarwerkSoort { get; set; }

        public DateTime Today => DateTime.Today;

        [IsDateBefore("Today", true, ErrorMessage = "Afleverdatum mag niet in de toekomst liggen!")]
        [UIHint("Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Afleverdatum is verplicht.")]
        public DateTime Afleverdatum { get; set; }

        /// <summary>
        /// Als je bij soort levering kiest voor vervolg of reserve dan een waarschuwing tonen dat we graag
        /// datum voorgaand hulpmiddel ook gevuld willen hebben.  Het is echter niet verplicht.
        /// </summary>
        [UIHint("Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum voorgaand hulpmiddel")]
        public DateTime? DatumVoorgaandHulpmiddel { get; set; }

        [UIHint("Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum medisch voorschrift")]
        public DateTime? DatumMedischVoorschrift { get; set; }

        [Required(ErrorMessage = "{0} is verplicht!")]


        [Display(Name = "Prijs haarwerk")]
        [RegularExpression(@"^(([1-9]{1}|[\d]{2,})((\.|,)[\d]+)?)$|^(0\.[\d]+)$", ErrorMessage = "Bedrag mag niet negatief of 0 zijn!")]
        public decimal PrijsHaarwerk { get; set; }


        [Display(Name = "Basis verzekering")]
        public decimal BedragBasisVerzekering { get; set; }

        public decimal BasisVerzekering { get; set; }


        [Display(Name = "Aanvullende verzekering")]
        [RegularExpression(@"^(([0-9]{1}|[\d]{2,})((\.|,)[\d]+)?)$|^(0\.[\d]+)$", ErrorMessage = "Bedrag mag niet negatief zijn!")]
        public decimal BedragAanvullendeVerzekering { get; set; }


        [Display(Name = "Eigen bijdragen (door cliënt betaald)")]
        public decimal BedragEigenBijdragen { get; set; }


        [Display(Name = "Bedrag te ontvangen van zorgverzekeraar")]
        public decimal BedragTeOntvangen { get; set; }

        public HaarwerkStatus Status { get; set; }
        public HaarwerkCreditType CreditType { get; set; }
    }
}
