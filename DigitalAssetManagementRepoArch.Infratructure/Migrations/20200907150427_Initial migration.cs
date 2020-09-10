using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalAssetManagementRepoArch.Infrastructure.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Device = table.Column<string>(maxLength: 30, nullable: false),
                    Dimensions = table.Column<string>(maxLength: 30, nullable: false),
                    CopyRequest = table.Column<string>(maxLength: 30, nullable: false),
                    AspectRatio = table.Column<string>(maxLength: 30, nullable: false),
                    FileTypes = table.Column<string>(maxLength: 30, nullable: false),
                    FileSize = table.Column<string>(maxLength: 30, nullable: false),
                    VideoDuration = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strategies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strategies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhaseStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhaseId = table.Column<int>(nullable: false),
                    StrategyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseStrategies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhaseStrategies_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhaseStrategies_Strategies_StrategyId",
                        column: x => x.StrategyId,
                        principalTable: "Strategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSChannels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelId = table.Column<int>(nullable: false),
                    PhaseStrategyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSChannels_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSChannels_PhaseStrategies_PhaseStrategyId",
                        column: x => x.PhaseStrategyId,
                        principalTable: "PhaseStrategies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSChannelCountries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    PSChannelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSChannelCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSChannelCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSChannelCountries_PSChannels_PSChannelId",
                        column: x => x.PSChannelId,
                        principalTable: "PSChannels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PSChannelCountryAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdId = table.Column<int>(nullable: false),
                    PSChannelCountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSChannelCountryAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSChannelCountryAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSChannelCountryAds_PSChannelCountries_PSChannelCountryId",
                        column: x => x.PSChannelCountryId,
                        principalTable: "PSChannelCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhaseStrategies_PhaseId",
                table: "PhaseStrategies",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseStrategies_StrategyId",
                table: "PhaseStrategies",
                column: "StrategyId");

            migrationBuilder.CreateIndex(
                name: "IX_PSChannelCountries_CountryId",
                table: "PSChannelCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PSChannelCountries_PSChannelId",
                table: "PSChannelCountries",
                column: "PSChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_PSChannelCountryAds_AdId",
                table: "PSChannelCountryAds",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_PSChannelCountryAds_PSChannelCountryId",
                table: "PSChannelCountryAds",
                column: "PSChannelCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PSChannels_ChannelId",
                table: "PSChannels",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_PSChannels_PhaseStrategyId",
                table: "PSChannels",
                column: "PhaseStrategyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PSChannelCountryAds");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "PSChannelCountries");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PSChannels");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "PhaseStrategies");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Strategies");
        }
    }
}
