using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalAssetManagementRepoArch.Infrastructure.Migrations
{
    public partial class UpdatedOnDeleteRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhaseStrategies_Strategies_StrategyId",
                table: "PhaseStrategies");

            migrationBuilder.DropForeignKey(
                name: "FK_PSChannelCountries_PSChannels_PSChannelId",
                table: "PSChannelCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_PSChannelCountryAds_PSChannelCountries_PSChannelCountryId",
                table: "PSChannelCountryAds");

            migrationBuilder.DropForeignKey(
                name: "FK_PSChannels_Channels_ChannelId",
                table: "PSChannels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Strategies",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Phases",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseStrategies_Strategies_StrategyId",
                table: "PhaseStrategies",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSChannelCountries_PSChannels_PSChannelId",
                table: "PSChannelCountries",
                column: "PSChannelId",
                principalTable: "PSChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSChannelCountryAds_PSChannelCountries_PSChannelCountryId",
                table: "PSChannelCountryAds",
                column: "PSChannelCountryId",
                principalTable: "PSChannelCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSChannels_Channels_ChannelId",
                table: "PSChannels",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhaseStrategies_Strategies_StrategyId",
                table: "PhaseStrategies");

            migrationBuilder.DropForeignKey(
                name: "FK_PSChannelCountries_PSChannels_PSChannelId",
                table: "PSChannelCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_PSChannelCountryAds_PSChannelCountries_PSChannelCountryId",
                table: "PSChannelCountryAds");

            migrationBuilder.DropForeignKey(
                name: "FK_PSChannels_Channels_ChannelId",
                table: "PSChannels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Strategies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Phases",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseStrategies_Strategies_StrategyId",
                table: "PhaseStrategies",
                column: "StrategyId",
                principalTable: "Strategies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PSChannelCountries_PSChannels_PSChannelId",
                table: "PSChannelCountries",
                column: "PSChannelId",
                principalTable: "PSChannels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PSChannelCountryAds_PSChannelCountries_PSChannelCountryId",
                table: "PSChannelCountryAds",
                column: "PSChannelCountryId",
                principalTable: "PSChannelCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PSChannels_Channels_ChannelId",
                table: "PSChannels",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
