﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promeetec.EDMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresboek",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresboek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Changelog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changelog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EiStandaard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Naam = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    EiBerichtCodes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Versie = table.Column<int>(type: "int", nullable: true),
                    SubVersie = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EiStandaard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    CultureCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NativeName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mededeling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mededeling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PushMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 15000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GroupIds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RedenEindeZorg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedenEindeZorg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Straat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Huisnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Huisnummertoevoeging = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Woonplaats = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefoon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    HaarwerkBedragBasisVerzekeringHaarwerk = table.Column<decimal>(name: "Haarwerk_BedragBasisVerzekeringHaarwerk", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    PageSize = table.Column<int>(type: "int", nullable: false),
                    TableLayout = table.Column<int>(type: "int", nullable: false),
                    SidebarLayout = table.Column<int>(type: "int", nullable: false),
                    AanleverstatusIds = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CarbonCopyAdressen = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    EmailBijAanleverbericht = table.Column<int>(type: "int", nullable: false),
                    EmailBijToevoegenDocument = table.Column<int>(type: "int", nullable: false),
                    EmailBijRapportage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verzekeraar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Uzovi = table.Column<short>(type: "smallint", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verzekeraar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zorgprofiel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ProfielCode = table.Column<int>(type: "int", nullable: false),
                    ProfielStartdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfielEinddatum = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zorgprofiel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zorgstraat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Naam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zorgstraat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Straat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Huisnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Huisnummertoevoeging = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Woonplaats = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LandNaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoonachtigOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WoonachtigTot = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adres_Land_LandId",
                        column: x => x.LandId,
                        principalTable: "Land",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    ClientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tooltip = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    RouteVariables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    MenuItemType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItem_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MenuItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MenuItem_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupRole",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRole", x => new { x.GroupId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_GroupRole_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zorgverzekering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    VerzekerdeNummer = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PatientNummer = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    VerzekerdOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerzekerdTot = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerzekeraarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zorgverzekering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zorgverzekering_Verzekeraar_VerzekeraarId",
                        column: x => x.VerzekeraarId,
                        principalTable: "Verzekeraar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemRole",
                columns: table => new
                {
                    MenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemRole", x => new { x.MenuItemId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_MenuItemRole_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verzekerden",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Bsn = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Lengte = table.Column<double>(type: "float", nullable: true),
                    PersoonGeslacht = table.Column<int>(name: "Persoon_Geslacht", type: "int", nullable: true),
                    PersoonGeboortedatum = table.Column<DateTime>(name: "Persoon_Geboortedatum", type: "datetime2", nullable: true),
                    PersoonVoorletters = table.Column<string>(name: "Persoon_Voorletters", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PersoonTussenvoegsel = table.Column<string>(name: "Persoon_Tussenvoegsel", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PersoonVoornaam = table.Column<string>(name: "Persoon_Voornaam", type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PersoonAchternaam = table.Column<string>(name: "Persoon_Achternaam", type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PersoonTelefoonZakelijk = table.Column<string>(name: "Persoon_TelefoonZakelijk", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersoonTelefoonPrive = table.Column<string>(name: "Persoon_TelefoonPrive", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersoonDoorkiesnummer = table.Column<string>(name: "Persoon_Doorkiesnummer", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersoonEmail = table.Column<string>(name: "Persoon_Email", type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PersoonVolledigeNaam = table.Column<string>(name: "Persoon_VolledigeNaam", type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PersoonFormeleNaam = table.Column<string>(name: "Persoon_FormeleNaam", type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AgbCodeVerwijzer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NaamVerwijzer = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Verwijsdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Shared = table.Column<bool>(type: "bit", nullable: true),
                    AangemaaktOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AangemaaktDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AangemaaktDoor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresboekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ZorgprofielId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ZorgverzekeringId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verzekerden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verzekerden_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Verzekerden_Adresboek_AdresboekId",
                        column: x => x.AdresboekId,
                        principalTable: "Adresboek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verzekerden_Zorgprofiel_ZorgprofielId",
                        column: x => x.ZorgprofielId,
                        principalTable: "Zorgprofiel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Verzekerden_Zorgverzekering_ZorgverzekeringId",
                        column: x => x.ZorgverzekeringId,
                        principalTable: "Zorgverzekering",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VerzekerdeToAdres",
                columns: table => new
                {
                    AdresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzekerdeToAdres", x => new { x.VerzekerdeId, x.AdresId });
                    table.ForeignKey(
                        name: "FK_VerzekerdeToAdres_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerzekerdeToAdres_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerzekerdeToZorgprofiel",
                columns: table => new
                {
                    ZorgprofielId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzekerdeToZorgprofiel", x => new { x.VerzekerdeId, x.ZorgprofielId });
                    table.ForeignKey(
                        name: "FK_VerzekerdeToZorgprofiel_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerzekerdeToZorgprofiel_Zorgprofiel_ZorgprofielId",
                        column: x => x.ZorgprofielId,
                        principalTable: "Zorgprofiel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerzekerdeToZorgverzekering",
                columns: table => new
                {
                    ZorgverzekeringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzekerdeToZorgverzekering", x => new { x.VerzekerdeId, x.ZorgverzekeringId });
                    table.ForeignKey(
                        name: "FK_VerzekerdeToZorgverzekering_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerzekerdeToZorgverzekering_Zorgverzekering_ZorgverzekeringId",
                        column: x => x.ZorgverzekeringId,
                        principalTable: "Zorgverzekering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weegmoment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Gewicht = table.Column<double>(type: "float", nullable: false),
                    Opnamedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weegmoment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weegmoment_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aanleverbericht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Onderwerp = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Bericht = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Volgorde = table.Column<int>(type: "int", nullable: false),
                    Gelezen = table.Column<bool>(type: "bit", nullable: false),
                    GeplaatstOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LaastGelezenOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AanleverberichtStatus = table.Column<int>(type: "int", nullable: false),
                    LaatsteLezerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OntvangerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AfzenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AanleveringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanleverbericht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aanleverbericht_Aanleverbericht_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Aanleverbericht",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aanleverbestand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Periode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Gecontroleerd = table.Column<bool>(type: "bit", nullable: true),
                    ZorgstraatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EiStandaardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AanleveringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanleverbestand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aanleverbestand_EiStandaard_EiStandaardId",
                        column: x => x.EiStandaardId,
                        principalTable: "EiStandaard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aanleverbestand_Zorgstraat_ZorgstraatId",
                        column: x => x.ZorgstraatId,
                        principalTable: "Zorgstraat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AanleverbestandSamenvatting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EiStandaard = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AantalVerzekerdeRecords = table.Column<int>(type: "int", nullable: true),
                    AantalPrestatieRecords = table.Column<int>(type: "int", nullable: true),
                    TotaalDeclaratiebedrag = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ZorgverlenersCode = table.Column<int>(type: "int", nullable: true),
                    Praktijkcode = table.Column<int>(type: "int", nullable: true),
                    Instellingscode = table.Column<int>(type: "int", nullable: true),
                    Processed = table.Column<bool>(type: "bit", nullable: true),
                    OvergeslagenRows = table.Column<int>(type: "int", nullable: true),
                    BestandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AanleverbestandSamenvatting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aanlevering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Jaar = table.Column<int>(type: "int", nullable: false),
                    Referentie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReferentiePromeetec = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Opmerking = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ToevoegenBestand = table.Column<bool>(type: "bit", nullable: false),
                    AanleverStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Aanleverdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AangemaaktOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AangemaaktDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AangemaaktDoor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AangepastOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AangepastDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AangepastDoor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    VerwijderdOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerwijderdDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VerwijderdDoor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EigenaarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BehandelaarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aanlevering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bestand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    FileName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    BestandSoort = table.Column<int>(type: "int", nullable: false),
                    AangemaaktOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AangemaaktDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AangemaaktDoor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AangepastOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AangepastDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AangepastDoor = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    EigenaarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Overigbestand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AanleveringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overigbestand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Overigbestand_Aanlevering_AanleveringId",
                        column: x => x.AanleveringId,
                        principalTable: "Aanlevering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Overigbestand_Bestand_Id",
                        column: x => x.Id,
                        principalTable: "Bestand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownloadActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    GedownloadOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BestandSoort = table.Column<int>(type: "int", nullable: false),
                    AanleveringId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BestandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedewerkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadActivity_Bestand_BestandId",
                        column: x => x.BestandId,
                        principalTable: "Bestand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GliBehandelplan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Startdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Einddatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GliProgramma = table.Column<int>(type: "int", nullable: false),
                    Fase = table.Column<int>(type: "int", nullable: false),
                    Opmerking = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    VoortijdigGestopt = table.Column<bool>(type: "bit", nullable: false),
                    VoortijdigeStopdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Verwerkt = table.Column<bool>(type: "bit", nullable: false),
                    VerwerktOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GliStatus = table.Column<int>(type: "int", nullable: false),
                    RedenEindeZorgId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BehandelaarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntakeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GliBehandelplan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GliBehandelplan_RedenEindeZorg_RedenEindeZorgId",
                        column: x => x.RedenEindeZorgId,
                        principalTable: "RedenEindeZorg",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GliBehandelplan_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GliIntake",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    IntakeDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opmerking = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Verwerkt = table.Column<bool>(type: "bit", nullable: false),
                    VerwerktOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GliStatus = table.Column<int>(type: "int", nullable: false),
                    BehandelaarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GliIntake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GliIntake_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Haarwerk",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Naam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bsn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Verzekeringsnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Machtigingsnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TypeHulpmiddel = table.Column<int>(type: "int", nullable: false),
                    LeveringSoort = table.Column<int>(type: "int", nullable: false),
                    HaarwerkSoort = table.Column<int>(type: "int", nullable: false),
                    Afleverdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumVoorgaandHulpmiddel = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumMedischVoorschrift = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrijsHaarwerk = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BedragBasisVerzekering = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BedragAanvullendeVerzekering = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BedragEigenBijdragen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BedragTeOntvangen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreditType = table.Column<int>(type: "int", nullable: false),
                    ExportedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haarwerk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MedewerkerSoort = table.Column<int>(type: "int", nullable: false),
                    Geslacht = table.Column<int>(type: "int", nullable: true),
                    Geboortedatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Voorletters = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tussenvoegsel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Voornaam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TelefoonZakelijk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TelefoonPrive = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Doorkiesnummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    VolledigeNaam = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    FormeleNaam = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AgbCodeZorgverlener = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AgbCodeOnderneming = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Functie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeactivatieReden = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    LaatstIngelogdOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VorigeLoginOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountState = table.Column<int>(type: "int", nullable: false),
                    GoogleAuthenticatorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    GoogleAuthenticatorSecretKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TempCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PukCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ActivationMailSend = table.Column<bool>(type: "bit", nullable: true),
                    ActivationMailSendOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AangemaaktOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AangemaaktDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AangemaaktDoor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationMailSendById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MedewerkerEmail = table.Column<string>(name: "Medewerker_Email", type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medewerkers_Medewerkers_ActivationMailSendById",
                        column: x => x.ActivationMailSendById,
                        principalTable: "Medewerkers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medewerkers_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedewerkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memo_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificatie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Titel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Bericht = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NotificatieType = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificatieStatus = table.Column<int>(type: "int", nullable: false),
                    GelezenOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedewerkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificatie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificatie_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisaties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Nummer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelefoonZakelijk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TelefoonPrive = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AgbCodeOnderneming = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Zorggroep = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Beperkt = table.Column<bool>(type: "bit", nullable: false),
                    BeperktReden = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AanleverbestandLocatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AanleverStatusNaSchrijvenAanleverbestanden = table.Column<int>(type: "int", nullable: false),
                    VerwijzerInAdresboek = table.Column<int>(type: "int", nullable: false),
                    VerwijderdOp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VerwijderdDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VerwijderdDoor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZorggroepRelatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactpersoonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdresId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdresboekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organisaties_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organisaties_Adresboek_AdresboekId",
                        column: x => x.AdresboekId,
                        principalTable: "Adresboek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organisaties_Medewerkers_ContactpersoonId",
                        column: x => x.ContactpersoonId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organisaties_Organisaties_ZorggroepRelatieId",
                        column: x => x.ZorggroepRelatieId,
                        principalTable: "Organisaties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PushMessageToUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    ReadedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PushMessageToUser", x => new { x.MessageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PushMessageToUser_Medewerkers_UserId",
                        column: x => x.UserId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PushMessageToUser_PushMessage_MessageId",
                        column: x => x.MessageId,
                        principalTable: "PushMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Medewerkers_UserId",
                        column: x => x.UserId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Medewerkers_UserId",
                        column: x => x.UserId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedewerkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Medewerkers_UserId",
                        column: x => x.UserId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Medewerkers_UserId",
                        column: x => x.UserId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerzekerdeToUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerzekerdeToUser", x => new { x.VerzekerdeId, x.UserId });
                    table.ForeignKey(
                        name: "FK_VerzekerdeToUser_Medewerkers_UserId",
                        column: x => x.UserId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerzekerdeToUser_Verzekerden_UserId",
                        column: x => x.UserId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rapportages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Referentie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RapportageSoort = table.Column<int>(type: "int", nullable: false),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapportages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rapportages_Bestand_Id",
                        column: x => x.Id,
                        principalTable: "Bestand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rapportages_Organisaties_OrganisatieId",
                        column: x => x.OrganisatieId,
                        principalTable: "Organisaties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VerbruiksmiddelPrestaties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    AgbCodeOnderneming = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    HulpmiddelenSoort = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProfielCode = table.Column<int>(type: "int", nullable: true),
                    ProfielStartdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfielEinddatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ZIndex = table.Column<int>(type: "int", nullable: true),
                    PrestatieDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hoeveelheid = table.Column<int>(type: "int", nullable: true),
                    AangemaaktOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AangemaaktDoorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AangemaaktDoor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerzekerdeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisatieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbruiksmiddelPrestaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerbruiksmiddelPrestaties_Organisaties_OrganisatieId",
                        column: x => x.OrganisatieId,
                        principalTable: "Organisaties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VerbruiksmiddelPrestaties_Verzekerden_VerzekerdeId",
                        column: x => x.VerzekerdeId,
                        principalTable: "Verzekerden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbericht_AanleveringId",
                table: "Aanleverbericht",
                column: "AanleveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbericht_AfzenderId",
                table: "Aanleverbericht",
                column: "AfzenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbericht_LaatsteLezerId",
                table: "Aanleverbericht",
                column: "LaatsteLezerId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbericht_Onderwerp",
                table: "Aanleverbericht",
                column: "Onderwerp");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbericht_OntvangerId",
                table: "Aanleverbericht",
                column: "OntvangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbericht_ParentId",
                table: "Aanleverbericht",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbestand_AanleveringId",
                table: "Aanleverbestand",
                column: "AanleveringId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbestand_EiStandaardId",
                table: "Aanleverbestand",
                column: "EiStandaardId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanleverbestand_ZorgstraatId",
                table: "Aanleverbestand",
                column: "ZorgstraatId");

            migrationBuilder.CreateIndex(
                name: "IX_AanleverbestandSamenvatting_BestandId",
                table: "AanleverbestandSamenvatting",
                column: "BestandId",
                unique: true,
                filter: "[BestandId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Aanlevering_BehandelaarId",
                table: "Aanlevering",
                column: "BehandelaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanlevering_EigenaarId",
                table: "Aanlevering",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanlevering_OrganisatieId",
                table: "Aanlevering",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Aanlevering_Referentie",
                table: "Aanlevering",
                column: "Referentie");

            migrationBuilder.CreateIndex(
                name: "IX_Aanlevering_ReferentiePromeetec",
                table: "Aanlevering",
                column: "ReferentiePromeetec");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_LandId",
                table: "Adres",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestand_EigenaarId",
                table: "Bestand",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadActivity_BestandId",
                table: "DownloadActivity",
                column: "BestandId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadActivity_MedewerkerId",
                table: "DownloadActivity",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GliBehandelplan_BehandelaarId",
                table: "GliBehandelplan",
                column: "BehandelaarId");

            migrationBuilder.CreateIndex(
                name: "IX_GliBehandelplan_IntakeId",
                table: "GliBehandelplan",
                column: "IntakeId");

            migrationBuilder.CreateIndex(
                name: "IX_GliBehandelplan_OrganisatieId",
                table: "GliBehandelplan",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_GliBehandelplan_RedenEindeZorgId",
                table: "GliBehandelplan",
                column: "RedenEindeZorgId");

            migrationBuilder.CreateIndex(
                name: "IX_GliBehandelplan_VerzekerdeId",
                table: "GliBehandelplan",
                column: "VerzekerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_GliIntake_BehandelaarId",
                table: "GliIntake",
                column: "BehandelaarId");

            migrationBuilder.CreateIndex(
                name: "IX_GliIntake_IntakeDatum",
                table: "GliIntake",
                column: "IntakeDatum");

            migrationBuilder.CreateIndex(
                name: "IX_GliIntake_OrganisatieId",
                table: "GliIntake",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_GliIntake_Verwerkt",
                table: "GliIntake",
                column: "Verwerkt");

            migrationBuilder.CreateIndex(
                name: "IX_GliIntake_VerzekerdeId",
                table: "GliIntake",
                column: "VerzekerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRole_RoleId",
                table: "GroupRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UserId",
                table: "GroupUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Haarwerk_OrganisatieId",
                table: "Haarwerk",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Land_NativeName",
                table: "Land",
                column: "NativeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Medewerkers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_ActivationMailSendById",
                table: "Medewerkers",
                column: "ActivationMailSendById");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_AdresId",
                table: "Medewerkers",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_AgbCodeOnderneming",
                table: "Medewerkers",
                column: "AgbCodeOnderneming");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_AgbCodeZorgverlener",
                table: "Medewerkers",
                column: "AgbCodeZorgverlener");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_OrganisatieId",
                table: "Medewerkers",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_UserName",
                table: "Medewerkers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_UserProfileId",
                table: "Medewerkers",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerkers_VolledigeNaam_FormeleNaam_Achternaam_Email",
                table: "Medewerkers",
                columns: new[] { "VolledigeNaam", "FormeleNaam", "Achternaam", "Email" });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Medewerkers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Memo_MedewerkerId",
                table: "Memo",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuId",
                table: "MenuItem",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ParentId",
                table: "MenuItem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRole_RoleId",
                table: "MenuItemRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificatie_MedewerkerId",
                table: "Notificatie",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_AdresboekId",
                table: "Organisaties",
                column: "AdresboekId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_AdresId",
                table: "Organisaties",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_ContactpersoonId",
                table: "Organisaties",
                column: "ContactpersoonId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_Naam",
                table: "Organisaties",
                column: "Naam");

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_Nummer",
                table: "Organisaties",
                column: "Nummer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organisaties_ZorggroepRelatieId",
                table: "Organisaties",
                column: "ZorggroepRelatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Overigbestand_AanleveringId",
                table: "Overigbestand",
                column: "AanleveringId");

            migrationBuilder.CreateIndex(
                name: "IX_PushMessageToUser_UserId",
                table: "PushMessageToUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rapportages_OrganisatieId",
                table: "Rapportages",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_MedewerkerId",
                table: "UserRoles",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbruiksmiddelPrestaties_OrganisatieId",
                table: "VerbruiksmiddelPrestaties",
                column: "OrganisatieId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbruiksmiddelPrestaties_VerzekerdeId",
                table: "VerbruiksmiddelPrestaties",
                column: "VerzekerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekeraar_Naam",
                table: "Verzekeraar",
                column: "Naam");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekeraar_Uzovi",
                table: "Verzekeraar",
                column: "Uzovi");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_AdresboekId",
                table: "Verzekerden",
                column: "AdresboekId");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_AdresId",
                table: "Verzekerden",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_AgbCodeVerwijzer",
                table: "Verzekerden",
                column: "AgbCodeVerwijzer");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_Bsn",
                table: "Verzekerden",
                column: "Bsn");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_Persoon_VolledigeNaam_Persoon_FormeleNaam_Persoon_Achternaam_Persoon_Email",
                table: "Verzekerden",
                columns: new[] { "Persoon_VolledigeNaam", "Persoon_FormeleNaam", "Persoon_Achternaam", "Persoon_Email" });

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_ZorgprofielId",
                table: "Verzekerden",
                column: "ZorgprofielId");

            migrationBuilder.CreateIndex(
                name: "IX_Verzekerden_ZorgverzekeringId",
                table: "Verzekerden",
                column: "ZorgverzekeringId");

            migrationBuilder.CreateIndex(
                name: "IX_VerzekerdeToAdres_AdresId",
                table: "VerzekerdeToAdres",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_VerzekerdeToUser_UserId",
                table: "VerzekerdeToUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VerzekerdeToZorgprofiel_ZorgprofielId",
                table: "VerzekerdeToZorgprofiel",
                column: "ZorgprofielId");

            migrationBuilder.CreateIndex(
                name: "IX_VerzekerdeToZorgverzekering_ZorgverzekeringId",
                table: "VerzekerdeToZorgverzekering",
                column: "ZorgverzekeringId");

            migrationBuilder.CreateIndex(
                name: "IX_Weegmoment_VerzekerdeId",
                table: "Weegmoment",
                column: "VerzekerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zorgprofiel_ProfielCode",
                table: "Zorgprofiel",
                column: "ProfielCode");

            migrationBuilder.CreateIndex(
                name: "IX_Zorgstraat_Naam",
                table: "Zorgstraat",
                column: "Naam");

            migrationBuilder.CreateIndex(
                name: "IX_Zorgverzekering_PatientNummer",
                table: "Zorgverzekering",
                column: "PatientNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Zorgverzekering_VerzekeraarId",
                table: "Zorgverzekering",
                column: "VerzekeraarId");

            migrationBuilder.CreateIndex(
                name: "IX_Zorgverzekering_VerzekerdeNummer",
                table: "Zorgverzekering",
                column: "VerzekerdeNummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Aanleverbericht_Aanlevering_AanleveringId",
                table: "Aanleverbericht",
                column: "AanleveringId",
                principalTable: "Aanlevering",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanleverbericht_Medewerkers_AfzenderId",
                table: "Aanleverbericht",
                column: "AfzenderId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanleverbericht_Medewerkers_LaatsteLezerId",
                table: "Aanleverbericht",
                column: "LaatsteLezerId",
                principalTable: "Medewerkers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aanleverbericht_Medewerkers_OntvangerId",
                table: "Aanleverbericht",
                column: "OntvangerId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanleverbestand_Aanlevering_AanleveringId",
                table: "Aanleverbestand",
                column: "AanleveringId",
                principalTable: "Aanlevering",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanleverbestand_Bestand_Id",
                table: "Aanleverbestand",
                column: "Id",
                principalTable: "Bestand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AanleverbestandSamenvatting_Bestand_BestandId",
                table: "AanleverbestandSamenvatting",
                column: "BestandId",
                principalTable: "Bestand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanlevering_Medewerkers_BehandelaarId",
                table: "Aanlevering",
                column: "BehandelaarId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanlevering_Medewerkers_EigenaarId",
                table: "Aanlevering",
                column: "EigenaarId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aanlevering_Organisaties_OrganisatieId",
                table: "Aanlevering",
                column: "OrganisatieId",
                principalTable: "Organisaties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bestand_Medewerkers_EigenaarId",
                table: "Bestand",
                column: "EigenaarId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadActivity_Medewerkers_MedewerkerId",
                table: "DownloadActivity",
                column: "MedewerkerId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Medewerkers_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "Medewerkers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GliBehandelplan_GliIntake_IntakeId",
                table: "GliBehandelplan",
                column: "IntakeId",
                principalTable: "GliIntake",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GliBehandelplan_Medewerkers_BehandelaarId",
                table: "GliBehandelplan",
                column: "BehandelaarId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GliBehandelplan_Organisaties_OrganisatieId",
                table: "GliBehandelplan",
                column: "OrganisatieId",
                principalTable: "Organisaties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GliIntake_Medewerkers_BehandelaarId",
                table: "GliIntake",
                column: "BehandelaarId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GliIntake_Organisaties_OrganisatieId",
                table: "GliIntake",
                column: "OrganisatieId",
                principalTable: "Organisaties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Medewerkers_UserId",
                table: "GroupUser",
                column: "UserId",
                principalTable: "Medewerkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Haarwerk_Organisaties_OrganisatieId",
                table: "Haarwerk",
                column: "OrganisatieId",
                principalTable: "Organisaties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medewerkers_Organisaties_OrganisatieId",
                table: "Medewerkers",
                column: "OrganisatieId",
                principalTable: "Organisaties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisaties_Medewerkers_ContactpersoonId",
                table: "Organisaties");

            migrationBuilder.DropTable(
                name: "Aanleverbericht");

            migrationBuilder.DropTable(
                name: "Aanleverbestand");

            migrationBuilder.DropTable(
                name: "AanleverbestandSamenvatting");

            migrationBuilder.DropTable(
                name: "Changelog");

            migrationBuilder.DropTable(
                name: "DownloadActivity");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GliBehandelplan");

            migrationBuilder.DropTable(
                name: "GroupRole");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Haarwerk");

            migrationBuilder.DropTable(
                name: "Mededeling");

            migrationBuilder.DropTable(
                name: "Memo");

            migrationBuilder.DropTable(
                name: "MenuItemRole");

            migrationBuilder.DropTable(
                name: "Notificatie");

            migrationBuilder.DropTable(
                name: "Overigbestand");

            migrationBuilder.DropTable(
                name: "PushMessageToUser");

            migrationBuilder.DropTable(
                name: "Rapportages");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "VerbruiksmiddelPrestaties");

            migrationBuilder.DropTable(
                name: "VerzekerdeToAdres");

            migrationBuilder.DropTable(
                name: "VerzekerdeToUser");

            migrationBuilder.DropTable(
                name: "VerzekerdeToZorgprofiel");

            migrationBuilder.DropTable(
                name: "VerzekerdeToZorgverzekering");

            migrationBuilder.DropTable(
                name: "Weegmoment");

            migrationBuilder.DropTable(
                name: "EiStandaard");

            migrationBuilder.DropTable(
                name: "Zorgstraat");

            migrationBuilder.DropTable(
                name: "GliIntake");

            migrationBuilder.DropTable(
                name: "RedenEindeZorg");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Aanlevering");

            migrationBuilder.DropTable(
                name: "PushMessage");

            migrationBuilder.DropTable(
                name: "Bestand");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Verzekerden");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Zorgprofiel");

            migrationBuilder.DropTable(
                name: "Zorgverzekering");

            migrationBuilder.DropTable(
                name: "Verzekeraar");

            migrationBuilder.DropTable(
                name: "Medewerkers");

            migrationBuilder.DropTable(
                name: "Organisaties");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Adresboek");

            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
