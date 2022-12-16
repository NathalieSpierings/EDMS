using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;

public class UserProfile : AggregateRoot
{
    /// <summary>
    /// The pagesize of the tables. Default to 25.
    /// </summary>
    public int PageSize { get; set; } = 25;


    /// <summary>
    /// The table layout preferences.
    /// <list type="bullet">
    /// <item>
    /// <description>Standaard: The default table spacing.</description>
    /// </item>
    /// <item>
    /// <description>Compact: The compact table spacing.</description>
    /// </item>
    /// </list>
    /// </summary>
    public TableLayout TableLayout { get; set; } = TableLayout.Standaard;


    /// <summary>
    /// The sidebar layout preferences.
    /// <list type="bullet">
    /// <item>
    /// <description>Uitgeklapt: Sidebar fully displayed. This is the default.</description>
    /// </item>
    /// <item>
    /// <description>Ingeklapt: Sidebar is compact displayed.</description>
    /// </item>
    /// <item>
    /// <description>Verborgen: Sidebar is hidden.</description>
    /// </item>
    /// </list>
    /// </summary>
    public SidebarLayout SidebarLayout { get; set; } = SidebarLayout.Uitgeklapt;


    /// <summary>
    /// The ids of the aanleverstatus enum comma seperated.
    /// </summary>
    [MaxLength(200)]
    public string AanleverstatusIds { get; set; } = "2,3,4,5";


    /// <summary>
    /// The carbon copy addresses comma seperated.
    /// </summary>
    [MaxLength(450)]
    public string? CarbonCopyAdressen { get; set; }


    /// <summary>
    /// The type of email ontvangen. Default to eigen.
    /// </summary>
    public EmailOntvangenType EmailBijAanleverbericht { get; set; } = EmailOntvangenType.Eigen;


    /// <summary>
    /// The type of email when document added. Default to eigen.
    /// </summary>
    public EmailOntvangenType EmailBijToevoegenDocument { get; set; } = EmailOntvangenType.Eigen;


    /// <summary>
    /// Indicator whether to receive emails when a rapportage is added.
    /// </summary>
    public bool EmailBijRapportage { get; set; } = true;



    /// <summary>
    /// Creates an empty user profile.
    /// </summary>
    public UserProfile() { }

    /// <summary>
    /// Creates a user profile.
    /// </summary>
    /// <param name="cmd">The create user profile command.</param>
    public UserProfile(CreateUserProfile cmd)
    {
        Id = cmd.Id;

        PageSize = cmd.PageSize;
        TableLayout = cmd.TableLayout;
        SidebarLayout = cmd.SidebarLayout;
        AanleverstatusIds = cmd.AanleverstatusIds;
        CarbonCopyAdressen = cmd.CarbonCopyAdressen;
        EmailBijAanleverbericht = cmd.EmailBijAanleverbericht;
        EmailBijToevoegenDocument = cmd.EmailBijToevoegenDocument;
        EmailBijRapportage = cmd.EmailBijRapportage;
    }

    public void Update(UpdateUserProfile cmd)
    {
        PageSize = cmd.PageSize;
        TableLayout = cmd.TableLayout;
        SidebarLayout = cmd.SidebarLayout;
        AanleverstatusIds = cmd.AanleverstatusIds;
        EmailBijAanleverbericht = cmd.EmailBijAanleverbericht;
        EmailBijToevoegenDocument = cmd.EmailBijToevoegenDocument;
        EmailBijRapportage = cmd.EmailBijRapportage;
        CarbonCopyAdressen = cmd.CarbonCopyAdressen;
    }

    public void UpdatePageSize(UpdatePageSize cmd)
    {
        PageSize = cmd.PageSize;
    }

    public void UpdateEmailBijRapportage(UpdateEmailBijRapportage cmd)
    {
        EmailBijRapportage = cmd.EmailBijRapportage;
    }
}
