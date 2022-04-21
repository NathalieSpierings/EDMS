﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Admin.DownloadActivity;
using Promeetec.EDMS.Domain.Models.Admin.EiStandaard;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Betrokkene.Weegmoment;
using Promeetec.EDMS.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;
using Promeetec.EDMS.Domain.Models.Document.Bestand;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Voorraad;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Intake;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using System.Reflection;
using Promeetec.EDMS.Domain.Models.Event;

namespace Promeetec.EDMS.Data.Context;

public class EDMSDbContext : IdentityDbContext<Medewerker, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
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
    public DbSet<DownloadActivity> DownloadActivities { get; set; }
    public DbSet<EiStandaard> EiStandaarden { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<GliBehandelplan> GliBehandelplannen { get; set; }
    public DbSet<GliIntake> GliIntakes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupRole> GroupRoles { get; set; }
    public DbSet<VerzekerdeToAdres> GroupUsers { get; set; }
    public DbSet<VerbruiksmiddelPrestatie> VerbruiksmiddelPrestaties { get; set; }
    public DbSet<IONPatientRelatie> IONPatientRelaties { get; set; }
    public DbSet<Land> Landen { get; set; }
    public DbSet<Mededeling> Mededelingen { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<MenuItemRole> MenuItemRoles { get; set; }
    public DbSet<Organisatie> Organisaties { get; set; }
    public DbSet<Overigbestand> Overigebestanden { get; set; }
    public DbSet<Rapportage> Rapportages { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Verzekeraar> Verzekeraars { get; set; }
    public DbSet<Verzekerde> Verzekerden { get; set; }
    public DbSet<Voorraad> Voorraad { get; set; }
    public DbSet<Weegmoment> Weegmoment { get; set; }
    public DbSet<Zorgprofiel> Zorgprofielen { get; set; }
    public DbSet<Zorgstraat> Zorgstraten { get; set; }
    public DbSet<Zorgverzekering> Zorgverzekeringen { get; set; }
}