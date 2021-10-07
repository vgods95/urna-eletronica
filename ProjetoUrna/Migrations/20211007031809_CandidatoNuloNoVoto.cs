using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoUrna.Migrations
{
    public partial class CandidatoNuloNoVoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_voting_candidate_candidate_id",
                table: "voting");

            migrationBuilder.AlterColumn<int>(
                name: "candidate_id",
                table: "voting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_voting_candidate_candidate_id",
                table: "voting",
                column: "candidate_id",
                principalTable: "candidate",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_voting_candidate_candidate_id",
                table: "voting");

            migrationBuilder.AlterColumn<int>(
                name: "candidate_id",
                table: "voting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_voting_candidate_candidate_id",
                table: "voting",
                column: "candidate_id",
                principalTable: "candidate",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
