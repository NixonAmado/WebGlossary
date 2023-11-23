using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phases_Phasestructures_PhaseStructureId",
                table: "Phases");

            migrationBuilder.DropForeignKey(
                name: "FK_Phases_Phasetypes_PhaseTypeId",
                table: "Phases");

            migrationBuilder.DropForeignKey(
                name: "FK_Phases_Phaseverbaltenses_PhaseVerbalTenseId",
                table: "Phases");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Verbaltenses_VerbalTenseId",
                table: "Words");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_Wordtypes_WordTypeId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wordtypes",
                table: "Wordtypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_WordTypeId",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Verbaltenses",
                table: "Verbaltenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phaseverbaltenses",
                table: "Phaseverbaltenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phasetypes",
                table: "Phasetypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phasestructures",
                table: "Phasestructures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phases",
                table: "Phases");

            migrationBuilder.DropIndex(
                name: "IX_Phases_PhaseVerbalTenseId",
                table: "Phases");

            migrationBuilder.RenameTable(
                name: "Wordtypes",
                newName: "wordtype");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "word");

            migrationBuilder.RenameTable(
                name: "Verbaltenses",
                newName: "verbaltense");

            migrationBuilder.RenameTable(
                name: "Phaseverbaltenses",
                newName: "Phaseverbaltense");

            migrationBuilder.RenameTable(
                name: "Phasetypes",
                newName: "phasetype");

            migrationBuilder.RenameTable(
                name: "Phasestructures",
                newName: "phasestructure");

            migrationBuilder.RenameTable(
                name: "Phases",
                newName: "phase");

            migrationBuilder.RenameColumn(
                name: "WordText",
                table: "word",
                newName: "wordText");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "word",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WordTypeId",
                table: "word",
                newName: "WordType_id");

            migrationBuilder.RenameColumn(
                name: "VerbalTenseId",
                table: "word",
                newName: "VerbalTense_id");

            migrationBuilder.RenameIndex(
                name: "IX_Words_VerbalTenseId",
                table: "word",
                newName: "VerbalTense_id_idx");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Phaseverbaltense",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "phase",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhaseVerbalTenseId",
                table: "phase",
                newName: "PhaseVerbalTense_id");

            migrationBuilder.RenameColumn(
                name: "PhaseTypeId",
                table: "phase",
                newName: "PhaseType_id");

            migrationBuilder.RenameColumn(
                name: "PhaseStructureId",
                table: "phase",
                newName: "PhaseStructure_id");

            migrationBuilder.RenameColumn(
                name: "Phase1",
                table: "phase",
                newName: "Phase");

            migrationBuilder.RenameIndex(
                name: "IX_Phases_PhaseTypeId",
                table: "phase",
                newName: "PhaseType_id_idx");

            migrationBuilder.RenameIndex(
                name: "IX_Phases_PhaseStructureId",
                table: "phase",
                newName: "phaseStructure_id_idx");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "wordtype",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "wordText",
                table: "word",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Translation",
                table: "word",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "verbaltense",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phaseverbaltense",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "phasetype",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "phasestructure",
                type: "varchar(70)",
                maxLength: 70,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Translation",
                table: "phase",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Phase",
                table: "phase",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "wordtype",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "word",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "verbaltense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "Phaseverbaltense",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "phasetype",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "phasestructure",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "phase",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    email = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Expires = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Created = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Revoked = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.Role_id, x.User_id });
                    table.ForeignKey(
                        name: "FK_UsersRoles_Role_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRoles_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_User_id",
                table: "RefreshToken",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_User_id",
                table: "UsersRoles",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "PhaseStructure_id",
                table: "phase",
                column: "PhaseStructure_id",
                principalTable: "phasestructure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "PhaseType_id",
                table: "phase",
                column: "PhaseType_id",
                principalTable: "phasetype",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "PhaseVerbalTense_id",
                table: "phase",
                column: "PhaseStructure_id",
                principalTable: "Phaseverbaltense",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "VerbalTense_id",
                table: "word",
                column: "VerbalTense_id",
                principalTable: "verbaltense",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "WordType_id",
                table: "word",
                column: "VerbalTense_id",
                principalTable: "wordtype",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PhaseStructure_id",
                table: "phase");

            migrationBuilder.DropForeignKey(
                name: "PhaseType_id",
                table: "phase");

            migrationBuilder.DropForeignKey(
                name: "PhaseVerbalTense_id",
                table: "phase");

            migrationBuilder.DropForeignKey(
                name: "VerbalTense_id",
                table: "word");

            migrationBuilder.DropForeignKey(
                name: "WordType_id",
                table: "word");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "wordtype");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "word");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "verbaltense");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "Phaseverbaltense");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "phasetype");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "phasestructure");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "phase");

            migrationBuilder.RenameTable(
                name: "wordtype",
                newName: "Wordtypes");

            migrationBuilder.RenameTable(
                name: "word",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "verbaltense",
                newName: "Verbaltenses");

            migrationBuilder.RenameTable(
                name: "Phaseverbaltense",
                newName: "Phaseverbaltenses");

            migrationBuilder.RenameTable(
                name: "phasetype",
                newName: "Phasetypes");

            migrationBuilder.RenameTable(
                name: "phasestructure",
                newName: "Phasestructures");

            migrationBuilder.RenameTable(
                name: "phase",
                newName: "Phases");

            migrationBuilder.RenameColumn(
                name: "wordText",
                table: "Words",
                newName: "WordText");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Words",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WordType_id",
                table: "Words",
                newName: "WordTypeId");

            migrationBuilder.RenameColumn(
                name: "VerbalTense_id",
                table: "Words",
                newName: "VerbalTenseId");

            migrationBuilder.RenameIndex(
                name: "VerbalTense_id_idx",
                table: "Words",
                newName: "IX_Words_VerbalTenseId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Phaseverbaltenses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Phases",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PhaseVerbalTense_id",
                table: "Phases",
                newName: "PhaseVerbalTenseId");

            migrationBuilder.RenameColumn(
                name: "PhaseType_id",
                table: "Phases",
                newName: "PhaseTypeId");

            migrationBuilder.RenameColumn(
                name: "PhaseStructure_id",
                table: "Phases",
                newName: "PhaseStructureId");

            migrationBuilder.RenameColumn(
                name: "Phase",
                table: "Phases",
                newName: "Phase1");

            migrationBuilder.RenameIndex(
                name: "PhaseType_id_idx",
                table: "Phases",
                newName: "IX_Phases_PhaseTypeId");

            migrationBuilder.RenameIndex(
                name: "phaseStructure_id_idx",
                table: "Phases",
                newName: "IX_Phases_PhaseStructureId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wordtypes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldMaxLength: 70)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "WordText",
                table: "Words",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldMaxLength: 70)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Translation",
                table: "Words",
                type: "longtext",
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Verbaltenses",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldMaxLength: 70)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phaseverbaltenses",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phasetypes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldMaxLength: 70)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Phasestructures",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(70)",
                oldMaxLength: 70)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Translation",
                table: "Phases",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Phase1",
                table: "Phases",
                type: "longtext",
                nullable: false,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wordtypes",
                table: "Wordtypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Verbaltenses",
                table: "Verbaltenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phaseverbaltenses",
                table: "Phaseverbaltenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phasetypes",
                table: "Phasetypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phasestructures",
                table: "Phasestructures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phases",
                table: "Phases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordTypeId",
                table: "Words",
                column: "WordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_PhaseVerbalTenseId",
                table: "Phases",
                column: "PhaseVerbalTenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_Phasestructures_PhaseStructureId",
                table: "Phases",
                column: "PhaseStructureId",
                principalTable: "Phasestructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_Phasetypes_PhaseTypeId",
                table: "Phases",
                column: "PhaseTypeId",
                principalTable: "Phasetypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phases_Phaseverbaltenses_PhaseVerbalTenseId",
                table: "Phases",
                column: "PhaseVerbalTenseId",
                principalTable: "Phaseverbaltenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Verbaltenses_VerbalTenseId",
                table: "Words",
                column: "VerbalTenseId",
                principalTable: "Verbaltenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Wordtypes_WordTypeId",
                table: "Words",
                column: "WordTypeId",
                principalTable: "Wordtypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
