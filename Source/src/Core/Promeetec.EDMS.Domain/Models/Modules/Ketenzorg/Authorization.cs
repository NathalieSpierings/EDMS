using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Ketenzorg
{
    public class Authorization
    {
        public Guid Id { get; set; }
        public string ZDNumber { get; set; }
        public string ReferringPractitionerAGB { get; set; }
        public string ReferringPractitionerName { get; set; }
        public string CustomerNumber { get; set; }
        public string PatientInitials { get; set; }
        public string PatientOwnNamePrefix { get; set; }
        public string PatientOwnName { get; set; }
        public string PatientPartnerNamePrefix { get; set; }
        public string PatientPartnerName { get; set; }
        public DateTime PatientBirthdate { get; set; }
        public string PatientBSN { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public AuthorizationState State { get; set; }
        public int MaxRegistrationRetroPeriodDays { get; set; }


        // optional
        public AuthorizationProduct Product { get; set; }
        public List<Registration> Registrations { get; set; }
    }

    public class AuthorizationProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<ActivityGroup> ActivityGroups { get; set; }
    }

    public class ActivityGroup
    {
        public int Id { get; set; }
        public int MaxQuantity { get; set; }

        public List<ProductActivity> Activities { get; set; }

    }

    public class ProductActivity
    {
        public Guid Id { get; set; }
        public Unit Unit { get; set; }
        public string Name { get; set; }
        public decimal Tariff { get; set; }
        public string Remark { get; set; }
    }


    public class Registration
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime TreatmentDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Quantity { get; set; }
        public bool Processed { get; set; }
        public virtual Guid ActivityId { get; set; }
        public Registration Credit { get; set; }
    }



    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthorizationState
    {
        Open,
        Processed,
        Expired,
        Cancelled
    }


    [JsonConverter(typeof(StringEnumConverter))]
    public enum Unit
    {
        Minutes,
        Piece
    }

}
