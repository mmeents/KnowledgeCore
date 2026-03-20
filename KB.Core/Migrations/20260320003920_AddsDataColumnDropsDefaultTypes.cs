using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KB.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddsDataColumnDropsDefaultTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ItemRelationTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ItemTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "{}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Items");

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
        }
    }
}
