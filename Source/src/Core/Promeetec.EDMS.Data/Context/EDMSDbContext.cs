using System.Reflection;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.DownloadActivity;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.EiStandaard;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Portaal.Domain.Models.Changelog;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Overigbestand;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Portaal.Data.Context;


public class EDMSDbContext : IdentityDbContext<Medewerker, Role, Guid, Domain.Models.Identity.UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public EDMSDbContext(DbContextOptions<EDMSDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Aanleverbericht> Aanleverberichten { get; set; }
    public DbSet<Aanleverbestand> Aanleverbestanden { get; set; }
    public DbSet<Aanlevering> Aanleveringen { get; set; }
    public DbSet<Adres> Adressen { get; set; }
    public DbSet<Adresboek> Adresboeken { get; set; }
    public DbSet<Bestand> Bestanden { get; set; }
    public DbSet<Changelog> Changelogs { get; set; }
    public DbSet<DownloadActivity> DownloadActivities { get; set; }
    public DbSet<EiStandaard> EiStandaarden { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<GliBehandelplan> GliBehandelplannen { get; set; }
    public DbSet<GliIntake> GliIntakes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupRole> GroupRoles { get; set; }
    public DbSet<Haarwerk> Haarwerk { get; set; }
    public DbSet<Land> Landen { get; set; }
    public DbSet<Mededeling> Mededelingen { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Memo> Memos { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuItemRole> MenuItemRoles { get; set; }
    public DbSet<Notificatie> Notificaties { get; set; }
    public DbSet<Organisatie> Organisaties { get; set; }
    public DbSet<Overigbestand> OverigeBestanden { get; set; }
    public DbSet<PushMessage> PushMessages { get; set; }
    public DbSet<Rapportage> Rapportages { get; set; }
    public DbSet<RedenEindeZorg> RedenenEindeZorg { get; set; }
    public DbSet<Domain.Models.Admin.Settings.Settings> Settings { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; }
    public DbSet<Verzekeraar> Verzekeraars { get; set; }
    public DbSet<Verzekerde> Verzekerden { get; set; }
    public DbSet<VerzekerdeToAdres> GroupUsers { get; set; }
    public DbSet<Weegmoment> Weegmomenten { get; set; }
    public DbSet<Zorgprofiel> Zorgprofielen { get; set; }
    public DbSet<Zorgstraat> Zorgstraten { get; set; }
    public DbSet<Zorgverzekering> Zorgverzekeringen { get; set; }
}