# Challenge API ATM

Este es un proyecto de ejemplo que implementa una API REST para emular el funcionamiento de un ATM. La aplicación permite realizar un logueo de usuario, consultas de saldo, retiros y ver el historial de operaciones.

## Tecnologías Utilizadas
- **.NET Core 8**: Para el desarrollo de la API.
- **Entity Framework Core**: ORM para la gestión de bases de datos.
- **SQL Server**: Base de datos relacional.
- **JWT (JSON Web Tokens)**: Para autenticación.

## Ejecucion
Una vez clonado el repositorio y abierto la solución en Visual Studio, antes de iniciar el API será necesario configurar la cadena de conexión a la base de datos local en el archivo appsettings.json. 
Aclaraciones: 
- Swagger activado por defecto al iniciar la app. 
- Las migraciones se ejecutarán automáticamente al iniciar la aplicación, lo que generará la base de datos y se insertarán datos de prueba de forma automática, permitiendo probar el aplicativo sin configuraciones adicionales.

## Endpoints
### Loguear
Dado un numero de tarjeta y pin, validara que ambos sean correctos y coinciden con los que están dados de alta. El endpoint retorna un token JWT el cual es necesario para acceder a los otros endpoints del API. Si se ingresa el PIN invalido hasta 4 veces, la tarjeta quedara bloqueada y no permitirá la generación del token.

- Metodo: POST
- Ruta: /api/Login/Loguear
  ![Loguear](https://github.com/user-attachments/assets/e457b57d-2b5c-45ee-8000-9ea878829ca7)

Los numeros de Tarjeta de Credito validos para realizar el logueo son los siguientes:
- 1111222233334444
- 2222333344445555
- 3333444455556666
- 4444555566667777
- 5555666677778888
- 6666777788889999
- 7777888899990000
- 8888999900001111
- 9999000011112222
- 0000111122223333

El PIN por defecto es "1234". 

### Saldo
Dado un número de tarjeta, retornará la siguiente información: nombre de usuario, número de cuenta, saldo actual y fecha de la última extracción.

- Metodo: GET
- Ruta: /api/Cuenta/Saldo
  ![Saldo](https://github.com/user-attachments/assets/2ffdfdbd-04fa-4f5e-92b9-2f402dc2ba82)

### Retiro
Dado un número de tarjeta y un monto específico, se realizará una extracción de saldo de la cuenta asociada a la tarjeta. En caso de que el saldo disponible sea menor al monto solicitado, se retornará un código de error. Si todo es correcto, se generará un resumen de la operación con la siguiente información: número de cuenta, monto retirado, saldo restante, fecha de la operación y estado de la operación.

- Metodo: POST
- Ruta: /api/Cuenta/Retiro
![Retiro](https://github.com/user-attachments/assets/1fe48430-8e28-4da5-8fed-8ccca92472ec)

### Historial
Dado un número de tarjeta y la cantidad de páginas a solicitar, se retornará el historial de todas las operaciones realizadas en la cuenta asociada a la tarjeta. El listado retornado estará paginado, entregando por defecto 10 registros por página.

- Metodo: GET
- Ruta: /api/Tarjeta/Historial
![Historial](https://github.com/user-attachments/assets/b7adb389-f843-4a34-aefd-bc2f10e37953)


## DER
![DER](https://github.com/user-attachments/assets/4ecbd088-6805-4e54-bfaf-c73d62db8623)

