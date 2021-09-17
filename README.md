# OnlineMarketPlace-Starter

18-September-jump-session Online market place .NET starter project.

## OnlineMarketPlace-Starter

A RESTful API created using .NET 5. We have used PostgreSQL as the relational database using Entity Framework to interact with it.
The application comes configured with JSON Web Token (JWT) as a method of add authentication. Using JWT, we can protect certain endpoints and ensure that user must be logged-in to access those. it also contains a login route completely implemented.

## Setup and Installation

### Getting started - Installation

Visual Studio IDE is reccomended to use this project but in the case of Visual Studio Code being used as the prereffered editor please sure you have downloaded and installed the dotnet CLI, which can be found [here](https://dotnet.microsoft.com/download)

1. **Clone the project repo from GitHub by running the following commands in your directory of choice**
   ```sh
   git clone https://github.com/lerato1ofone/OnlineMarketPlace-Starter.git
   cd OnlineMarketPlace-Starter
   ```
2. **Database**

   Download postgres and install:

   - download from [here](https://www.postgresql.org/download) and install locally on the machine

3. **Run migrations**

   Using Visual Studio, in the root application directory open the Package Manager Console by shortcut ALT+T+N=O or by navigating to Tools > Nuget Package Manager > Package Manager Console and run the following commands to Update your migrations with the initial migration configured with the application
   ` Update-Database `

   - If using, Visual Studio Code
     ```sh
     dotnet ef database update
     ```

   ````
   To run own migrations use commands for Visual Studio:
   ```sh
   Add-Migration MigrationName
   Update-Database
   ````

   Using Visual Studio Code

   ```sh
   dotnet ef migrations add yourMigrationName
   dotnet ef database update
   ```

## Run

In Visual Studio run the application using key F5.

In Visual Studio Code run the application by running command:

```sh
dotnet run
```
