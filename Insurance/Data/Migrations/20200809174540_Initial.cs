using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insurance.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentNumber = table.Column<string>(maxLength: 5, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    PolicyCount = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    EMBG = table.Column<string>(maxLength: 13, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    AccidentDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNumber = table.Column<string>(maxLength: 5, nullable: false),
                    PolicyType = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CascoPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chassis = table.Column<string>(maxLength: 17, nullable: false),
                    Registration = table.Column<string>(maxLength: 8, nullable: false),
                    Power = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    Premium = table.Column<int>(nullable: false),
                    VehicleColor = table.Column<string>(nullable: true),
                    AgreeDate = table.Column<DateTime>(nullable: true),
                    PolicyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CascoPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CascoPolicy_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeHealth = table.Column<string>(nullable: true),
                    Premium = table.Column<int>(nullable: false),
                    AgreeDate = table.Column<DateTime>(nullable: true),
                    InsuredId = table.Column<int>(nullable: false),
                    PolicyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthPolicy_User_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthPolicy_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TravelPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTravel = table.Column<string>(nullable: true),
                    DayCount = table.Column<int>(nullable: false),
                    Premium = table.Column<int>(nullable: false),
                    AgreeDate = table.Column<DateTime>(nullable: true),
                    InsuredId = table.Column<int>(nullable: false),
                    PolicyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPolicy_User_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelPolicy_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CascoPolicy_PolicyId",
                table: "CascoPolicy",
                column: "PolicyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Case_UserId",
                table: "Case",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthPolicy_InsuredId",
                table: "HealthPolicy",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthPolicy_PolicyId",
                table: "HealthPolicy",
                column: "PolicyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Policy_AgentId",
                table: "Policy",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_OwnerId",
                table: "Policy",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPolicy_InsuredId",
                table: "TravelPolicy",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPolicy_PolicyId",
                table: "TravelPolicy",
                column: "PolicyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CascoPolicy");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "HealthPolicy");

            migrationBuilder.DropTable(
                name: "TravelPolicy");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
