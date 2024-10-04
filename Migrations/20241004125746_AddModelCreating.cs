using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChallengeApiAtm.Migrations
{
    /// <inheritdoc />
    public partial class AddModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operaciones_Cuentas_CuentaId",
                table: "Operaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_TarjetaCredenciales_Tarjetas_TarjetaId",
                table: "TarjetaCredenciales");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjetas_Cuentas_CuentaId",
                table: "Tarjetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarjetas",
                table: "Tarjetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarjetaCredenciales",
                table: "TarjetaCredenciales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operaciones",
                table: "Operaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas");

            migrationBuilder.RenameTable(
                name: "Tarjetas",
                newName: "Tarjeta");

            migrationBuilder.RenameTable(
                name: "TarjetaCredenciales",
                newName: "TarjetaCredencial");

            migrationBuilder.RenameTable(
                name: "Operaciones",
                newName: "Operacion");

            migrationBuilder.RenameTable(
                name: "Cuentas",
                newName: "Cuenta");

            migrationBuilder.RenameIndex(
                name: "IX_Tarjetas_CuentaId",
                table: "Tarjeta",
                newName: "IX_Tarjeta_CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_TarjetaCredenciales_TarjetaId",
                table: "TarjetaCredencial",
                newName: "IX_TarjetaCredencial_TarjetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Operaciones_CuentaId",
                table: "Operacion",
                newName: "IX_Operacion_CuentaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarjeta",
                table: "Tarjeta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarjetaCredencial",
                table: "TarjetaCredencial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operacion",
                table: "Operacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operacion_Cuenta_CuentaId",
                table: "Operacion",
                column: "CuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Cuenta_CuentaId",
                table: "Tarjeta",
                column: "CuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TarjetaCredencial_Tarjeta_TarjetaId",
                table: "TarjetaCredencial",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operacion_Cuenta_CuentaId",
                table: "Operacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Cuenta_CuentaId",
                table: "Tarjeta");

            migrationBuilder.DropForeignKey(
                name: "FK_TarjetaCredencial_Tarjeta_TarjetaId",
                table: "TarjetaCredencial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarjetaCredencial",
                table: "TarjetaCredencial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarjeta",
                table: "Tarjeta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operacion",
                table: "Operacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cuenta",
                table: "Cuenta");

            migrationBuilder.RenameTable(
                name: "TarjetaCredencial",
                newName: "TarjetaCredenciales");

            migrationBuilder.RenameTable(
                name: "Tarjeta",
                newName: "Tarjetas");

            migrationBuilder.RenameTable(
                name: "Operacion",
                newName: "Operaciones");

            migrationBuilder.RenameTable(
                name: "Cuenta",
                newName: "Cuentas");

            migrationBuilder.RenameIndex(
                name: "IX_TarjetaCredencial_TarjetaId",
                table: "TarjetaCredenciales",
                newName: "IX_TarjetaCredenciales_TarjetaId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarjeta_CuentaId",
                table: "Tarjetas",
                newName: "IX_Tarjetas_CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Operacion_CuentaId",
                table: "Operaciones",
                newName: "IX_Operaciones_CuentaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarjetaCredenciales",
                table: "TarjetaCredenciales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarjetas",
                table: "Tarjetas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operaciones",
                table: "Operaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cuentas",
                table: "Cuentas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operaciones_Cuentas_CuentaId",
                table: "Operaciones",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TarjetaCredenciales_Tarjetas_TarjetaId",
                table: "TarjetaCredenciales",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjetas_Cuentas_CuentaId",
                table: "Tarjetas",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
