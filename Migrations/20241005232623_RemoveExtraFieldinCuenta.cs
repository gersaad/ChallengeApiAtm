using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeApiAtm.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExtraFieldinCuenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaExtraccionId",
                table: "Cuenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UltimaExtraccionId",
                table: "Cuenta",
                type: "int",
                nullable: true);
        }
    }
}
