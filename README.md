# Items Management System.

_This system is a simple application to an user or employee can manage customers, items and all the items assigned to a customer and generate report of them. It's a system for testing skill purpose. Documentation is available in two formats inside this repository, find Items Management.pdf or Items Management.chm. Master branch only has the initial structure of the project, but development once has the complete final project._

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

## Deployment (Two ways) 📦

_The following steps are required to install the system in a temporary production environment:_

```
Download and install .Net 8 SDK from the following link: 
```
* [.Net8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
```
Download application from the following link:
```
* [Items Management System release](https://drive.google.com/drive/folders/1-dL8EbARDDn9QzV6Oo6tvF66hVzzGas9?usp=sharing)
```
And unzip the file into a folder named 'Items Management System' in Local Disk C.
```
```
Open command line as Administrator and run the following command: cd "C:\Items Management System\ProductManagement.exe"
```
```
The application is going to says where is running (Now listening on...), access to the following link:
```
* [Items Management System](http://localhost:5000)
```
If you don't get the interface of the application, see if you have another port and change it. Example: listening on localhost:5000, or 5001, or the once that it says, you are going to change it in the browser.
```
```
IMPORTANT: If you close the command line, application will shut down. This is only a temporary production environment.
```

_The next steps are required to install the system in a IIS server on a Windows PC:_

```
Download and install .Net 8 SDK from the following link: 
```
* [.Net8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
```
Download application from the following link:
```
* [Items Management System release](https://drive.google.com/drive/folders/1-dL8EbARDDn9QzV6Oo6tvF66hVzzGas9?usp=sharing)
```
And unzip the file into a folder named 'Items Management System' in Local Disk C.
```
```
Install IIS. Follow this link to have three ways to install it:
```
* [IIS server]([https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://www.itechguides.com/install-iis-windows-10/))
```
In IIS: 
```
```
Create Site: Name: ItemsMSystem, Application pool: ItemsMSystem, Physical path: C:\Items Management System, Binding Type: http, Binding Port: 8081
```
```
Run the following link to access to the application:
```
* [Items Management System](http://localhost:8081)

## Build with 🛠️

* [VisualStudio2022](https://visualstudio.microsoft.com/es/vs/) - used IDE

## Author ✒️

* **Odalis Núñez** - [olnunez](#olnunez)
