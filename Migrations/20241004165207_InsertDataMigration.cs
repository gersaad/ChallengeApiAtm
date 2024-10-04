using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Cryptography;
using System.Security.Policy;
using ChallengeApiAtm.Repositorios.Interfaces;
using ChallengeApiAtm.Data;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ChallengeApiAtm.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var password = "10000.LCvGVSoB+pCir4GWgvrxIw==.tpkTQx+7/TliA6Y3gL2XLTJoSCaZgUJquKxpLL056wk=";  //Password = 1234;
                            
            migrationBuilder.Sql(@"
            INSERT INTO Cuenta (NombreUsuario, NumeroCuenta, Saldo, UltimaExtraccionId) VALUES 
            ('Juan Perez', '1234567890', 1500.00, NULL),
            ('Maria Lopez', '0987654321', 3500.00, NULL),
            ('Carlos Gomez', '1122334455', 5000.00, NULL),
            ('Ana Martinez', '5566778899', 2000.00, NULL),
            ('Luis Fernandez', '6677889900', 800.00, NULL),
            ('Sofia Garcia', '7788990011', 1200.00, NULL),
            ('Pablo Diaz', '9988776655', 4300.00, NULL),
            ('Laura Ortega', '2233445566', 2750.00, NULL),
            ('Federico Ruiz', '3344556677', 5900.00, NULL),
            ('Gabriela Castro', '4455667788', 6200.00, NULL);

            INSERT INTO Tarjeta (NumeroTarjeta, CuentaId) VALUES 
            ('1111222233334444', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1234567890')),
            ('2222333344445555', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '0987654321')),
            ('3333444455556666', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1122334455')),
            ('4444555566667777', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '5566778899')),
            ('5555666677778888', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '6677889900')),
            ('6666777788889999', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '7788990011')),
            ('7777888899990000', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '9988776655')),
            ('8888999900001111', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '2233445566')),
            ('9999000011112222', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '3344556677')),
            ('0000111122223333', (SELECT Id FROM Cuenta WHERE NumeroCuenta = '4455667788'));

            INSERT INTO TarjetaCredencial (PinHash, IntentosFallidos, Bloqueada, TarjetaId) VALUES 
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '1111222233334444')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '2222333344445555')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '3333444455556666')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '4444555566667777')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '5555666677778888')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '6666777788889999')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '7777888899990000')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '8888999900001111')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '9999000011112222')),
            ('" + password + @"', 0, 0, (SELECT Id FROM Tarjeta WHERE NumeroTarjeta = '0000111122223333'));

            INSERT INTO Operacion (Fecha, Monto, Tipo, CuentaId) VALUES 
            ('2023-10-01', 500.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1234567890')),
            ('2023-10-02', 150.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1234567890')),
            ('2023-10-03', 200.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1234567890')),
            ('2023-10-04', 300.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1234567890')),
            ('2023-10-05', 400.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1234567890')),

            ('2023-10-01', 600.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '0987654321')),
            ('2023-10-02', 200.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '0987654321')),
            ('2023-10-03', 300.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '0987654321')),
            ('2023-10-04', 100.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '0987654321')),
            ('2023-10-05', 400.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '0987654321')),

            ('2023-10-01', 700.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1122334455')),
            ('2023-10-02', 250.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1122334455')),
            ('2023-10-03', 150.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1122334455')),
            ('2023-10-04', 350.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1122334455')),
            ('2023-10-05', 500.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '1122334455')),

            ('2023-10-01', 400.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '5566778899')),
            ('2023-10-02', 120.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '5566778899')),
            ('2023-10-03', 220.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '5566778899')),
            ('2023-10-04', 180.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '5566778899')),
            ('2023-10-05', 450.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '5566778899')),

            ('2023-10-01', 550.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '6677889900')),
            ('2023-10-02', 210.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '6677889900')),
            ('2023-10-03', 100.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '6677889900')),
            ('2023-10-04', 140.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '6677889900')),
            ('2023-10-05', 380.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '6677889900')),

            ('2023-10-01', 650.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '7788990011')),
            ('2023-10-02', 170.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '7788990011')),
            ('2023-10-03', 270.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '7788990011')),
            ('2023-10-04', 240.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '7788990011')),
            ('2023-10-05', 490.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '7788990011')),

            ('2023-10-01', 900.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '9988776655')),
            ('2023-10-02', 220.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '9988776655')),
            ('2023-10-03', 120.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '9988776655')),
            ('2023-10-04', 180.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '9988776655')),
            ('2023-10-05', 360.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '9988776655')),

            ('2023-10-01', 730.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '2233445566')),
            ('2023-10-02', 260.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '2233445566')),
            ('2023-10-03', 330.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '2233445566')),
            ('2023-10-04', 270.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '2233445566')),
            ('2023-10-05', 550.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '2233445566')),

            ('2023-10-01', 980.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '3344556677')),
            ('2023-10-02', 280.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '3344556677')),
            ('2023-10-03', 140.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '3344556677')),
            ('2023-10-04', 310.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '3344556677')),
            ('2023-10-05', 450.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '3344556677')),

            ('2023-10-01', 870.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '4455667788')),
            ('2023-10-02', 190.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '4455667788')),
            ('2023-10-03', 110.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '4455667788')),
            ('2023-10-04', 350.00, 1, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '4455667788')),
            ('2023-10-05', 370.00, 0, (SELECT Id FROM Cuenta WHERE NumeroCuenta = '4455667788'));
        ");
        }
    }
}
