using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL_EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftsModelsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AMid = table.Column<int>(nullable: false),
                    ModelName = table.Column<string>(nullable: true),
                    PlacesCount = table.Column<int>(nullable: false),
                    AircraftTonnage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftsModelsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PointOfDepartures = table.Column<string>(nullable: true),
                    TimeOfDeparture = table.Column<DateTime>(nullable: false),
                    PointOfDestination = table.Column<string>(nullable: true),
                    TimeOfArrival = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PilotsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AircraftsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aid = table.Column<int>(nullable: false),
                    AircraftName = table.Column<string>(nullable: true),
                    AircraftsModelsId = table.Column<int>(nullable: true),
                    AircraftBuildDate = table.Column<DateTime>(nullable: false),
                    AircraftExpluatationSpan = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AircraftsList_AircraftsModelsList_AircraftsModelsId",
                        column: x => x.AircraftsModelsId,
                        principalTable: "AircraftsModelsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cid = table.Column<int>(nullable: false),
                    PilotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewsList_PilotsList_PilotId",
                        column: x => x.PilotId,
                        principalTable: "PilotsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(nullable: false),
                    FlihtID = table.Column<int>(nullable: true),
                    AircraftsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsList_AircraftsList_AircraftsId",
                        column: x => x.AircraftsId,
                        principalTable: "AircraftsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketsList_FlightsList_FlihtID",
                        column: x => x.FlihtID,
                        principalTable: "FlightsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeparturesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Did = table.Column<int>(nullable: false),
                    FlightId = table.Column<int>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    CrewId = table.Column<int>(nullable: true),
                    AircraftId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeparturesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeparturesList_AircraftsList_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "AircraftsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeparturesList_CrewsList_CrewId",
                        column: x => x.CrewId,
                        principalTable: "CrewsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeparturesList_FlightsList_FlightId",
                        column: x => x.FlightId,
                        principalTable: "FlightsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StewardessesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sid = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CrewsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StewardessesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StewardessesList_CrewsList_CrewsId",
                        column: x => x.CrewsId,
                        principalTable: "CrewsList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftsList_AircraftsModelsId",
                table: "AircraftsList",
                column: "AircraftsModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_CrewsList_PilotId",
                table: "CrewsList",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesList_AircraftId",
                table: "DeparturesList",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesList_CrewId",
                table: "DeparturesList",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_DeparturesList_FlightId",
                table: "DeparturesList",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_StewardessesList_CrewsId",
                table: "StewardessesList",
                column: "CrewsId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsList_AircraftsId",
                table: "TicketsList",
                column: "AircraftsId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsList_FlihtID",
                table: "TicketsList",
                column: "FlihtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeparturesList");

            migrationBuilder.DropTable(
                name: "StewardessesList");

            migrationBuilder.DropTable(
                name: "TicketsList");

            migrationBuilder.DropTable(
                name: "CrewsList");

            migrationBuilder.DropTable(
                name: "AircraftsList");

            migrationBuilder.DropTable(
                name: "FlightsList");

            migrationBuilder.DropTable(
                name: "PilotsList");

            migrationBuilder.DropTable(
                name: "AircraftsModelsList");
        }
    }
}
