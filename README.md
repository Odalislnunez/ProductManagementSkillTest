# Items Management System.

_This system is a simple application to an user or employee can manage customers, items and all the items assigned to a customer and generate report of them. It's a system for testing skill purpose. Documentation is available in two formats inside this repository, find Items Management.pdf or Items Management.chm._

## Getting start 🚀

_These instructions will allow you to get a copy of the project running on your local machine for development and testing purposes._

### Prerequisites 📋

```
- Visual Studio 2022.
- Git bash (Opcional).
```

### Installation 🔧

```
Clone the project with git bash, or otherwise within visual studio.
```
```
Open the project in visual studio.
```
```
Run it (this will cause the database to be created in SQLite, if not already created) and the corresponding migrations to be applied.
```

## Running tests ⚙️

### End-to-end tests 🔩

```
The process is started by registering in the application and entering through the login.
```
```
Then some products are created from the 'Items' option of the main menu.
```
```
From the option 'Customers' of the main menu some customers are created and later for each customer created, by means of the option of 'View items' some products are assigned to him.
```
```
Then in reports, the three types of reports are generated.
```
```
For the 'Customer items' report, 'From item' and 'To item' parameters must be specified to generate the report.
```
```
The user is logged out of the application.
```

### Coding style tests ⌨️

_To perform the coding style tests, it is required to view the code and check the code structure._

```
Organized folders: controllers, views, etc.
```
```
Endpoints with comments.
```
```
Indexed code.
```

## Deployment 📦

_The following steps are required to install the system in a production environment:_

```
Crear compilado del proyecto: Ejecutar proyecto en release, Publish WIS.Web: Configuration = Release, Target Framework = net6.0, Target Runtime = win-x86.
```
```
Crear carpeta Cliente en ruta: C:\inetpub\wwwroot\ y dentro de esta colocar el compilado del proyecto.
```
```
Instalar IIS.
```
```
Crear Server Certificate: Self-Signed Certificate, Name: Certificado, Type: Personal.
```
```
Crear Aplication Pool: Name: DefaultAspApp, .NET CLR Version: No Managed Code, Enable 32-Bit Applications: True, Identity: farmahorro\_InterfaceDynamic.
```
```
Crear Site: Name: Wis, Application pool: DefaultAspApp, Physical path: C:\inetpub\wwwroot\Cliente, Binding Type: https, Binding Port: 443, SSL Certificate: Certificado.
```
```
Instalar dependencias: aspnet core runtime 6.0.21 x86, VFPOLEDBSetup.
```

## Build with 🛠️

* [VisualStudio2022](https://visualstudio.microsoft.com/es/vs/) - used IDE

## Author ✒️

* **Odalis Núñez** - [olnunez](#olnunez)
