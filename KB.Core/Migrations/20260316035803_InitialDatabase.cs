using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KB.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemRelationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: false),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false),
                    RelatedItemId = table.Column<int>(type: "int", nullable: false),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRelations_ItemRelationTypes_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalTable: "ItemRelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemRelations_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemRelations_Items_RelatedItemId",
                        column: x => x.RelatedItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ItemRelationTypes",
                columns: new[] { "Id", "Description", "Relation" },
                values: new object[,]
                {
                    { 1, "Project → Feature, Project → Sub-Project, Domain → Concept", "Contains" },
                    { 2, "inverse of Contains (optional if you traverse IncomingRelations)", "BelongsTo" },
                    { 3, "Feature → Feature, Component → Component, Skill → Skill", "DependsOn" },
                    { 4, "Feature → Requirement, Component → Feature", "Implements" },
                    { 5, "Rule → Scope, Rule → Feature, Standard → Component", "Governs" },
                    { 6, "Rule → Domain, Constraint → Project", "AppliesTo" },
                    { 7, "Feature → Skill, Role → Skill", "Requires" },
                    { 8, "Feature → Feature, Project → Project (inheritance/variation)", "Extends" },
                    { 9, "Rule → Rule (precedence)", "Overrides" },
                    { 10, "Constraint → Requirement, Rule → Rule", "ConflictsWith" },
                    { 11, "Decision → Decision (evolution over time)", "SupersededBy" },
                    { 12, "Concept → Concept, Technology → Skill (concrete instance of)", "Exemplifies" },
                    { 13, "Generic catch-all for weak associations", "RelatedTo" }
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Recursive, can contain sub-projects", "Project" },
                    { 2, "Bounded context / problem area (DDD influence)", "Domain" },
                    { 3, "Deliverable capability", "Feature" },
                    { 4, "Technical building block (service, lib, module)", "Component" },
                    { 5, "Functional or non-functional", "Requirement" },
                    { 6, "Things that limit decisions (time, budget, tech)", "Constraint" },
                    { 7, "A governing directive", "Rule" },
                    { 8, "Boundary of applicability for rules", "Scope" },
                    { 9, "Capability, knowledge area, or technology", "Skill" },
                    { 10, "Persona or team function (Dev, Architect, QA...)", "Role" },
                    { 11, "An ADR, a resolved choice with rationale", "Decision" },
                    { 12, "Abstract idea or domain term (ubiquitous language)", "Concept" },
                    { 13, "A convention or coding standard", "Standard" },
                    { 14, "Language, framework, tool, platform", "Technology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelations_ItemId_RelationTypeId_RelatedItemId",
                table: "ItemRelations",
                columns: new[] { "ItemId", "RelationTypeId", "RelatedItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelations_RelatedItemId",
                table: "ItemRelations",
                column: "RelatedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelations_RelationTypeId",
                table: "ItemRelations",
                column: "RelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelationTypes_Relation",
                table: "ItemRelationTypes",
                column: "Relation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_Name",
                table: "ItemTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRelations");

            migrationBuilder.DropTable(
                name: "ItemRelationTypes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemTypes");
        }
    }
}
