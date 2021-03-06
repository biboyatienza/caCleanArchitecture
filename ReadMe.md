# ca's Clean Architecture playgrond .Net/C#/VsCode

## Toolings
* Visual Studio Code
  * vscode-sqlite
* dotnet 6
* GitHub

## Notes
### Adding .net .gitignore file
```
$ dotnet new gitignore
```
### Creating a .net solution
```
$ dotnet new sln -n caCleanArchitecture 
```

### Creating a .net class library project
```
$ dotnet new classlib -o ./Core/Domain 
```

### Adding .net project to a .net solution
```
$ dotnet sln add ./Core/Domain 
```

### Project referencing 
```
caCleanArchitecture/Host/WebApi$ dotnet add reference ..\..\Core\Application\Application.csproj ..\..\Infra\Infrastructure\Infrastructure.csproj
```

### Adding NuGet packages 
* Adding
```
$ dotnet add package Microsoft.EntityFrameworkCore.SQLite
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer
$ dotnet add package Microsoft.EntityFrameworkCore.Design
$ dotnet add package Microsoft.EntityFrameworkCore.Tools
$ dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
$ dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
```

* Removing
```
$ dotnet remove package Microsoft.VisualStudio.Web.CodeGeneration.Design
```




### .net EF Migration
https://docs.microsoft.com/en-us/ef/core/cli/dotnet

* Add migration
```
caCleanArchitecture/Infra/Infrastructure$ dotnet ef migrations add InitialDbCreation -s ../../Host/WebApi  --verbose
caCleanArchitecture/Infra/Infrastructure$ dotnet ef migrations add AddProductTable -s ../../Host/WebApi  --verbose

```
* Updating database
```
caCleanArchitecture/Infra/Infrastructure$ dotnet ef database update InitialDbCreation -s ../../Host/WebApi  
caCleanArchitecture/Infra/Infrastructure$ dotnet ef database update -s ../../Host/WebApi  
```

### Updating to latest version of .net Entity Framework tools 
The Entity Framework tools version '6.0.3' is older than that of the runtime '6.0.4'. Update the tools for the latest features and bug fixes. See https://aka.ms/AAc1fbw for more information.
```
$ dotnet tool update --global dotnet-ef
```

### Removing nullable warnings
By default, Nullable is enable on YOUR_PROJECT.csproj.
Make the value as disable in order for the warning to disappear.  
```
  <Nullable>disable</Nullable>
```

### Apply late .gitignore file
```
$ git rm -r --cached . 
$ git add .
$ git commit -m 'Removed all files that are in the .gitignore' 
$ git push origin master
```

### .net 6 IOrderedQueryable does not contain a definition for 'ToListAsync'
* https://stackoverflow.com/questions/64933763/dbset-does-not-contain-a-definition-for-tolistasync-although-im-using-ne

Use this Microsoft.EntityFrameworkCore namespace.

```
using Microsoft.EntityFrameworkCore
```

### This async method lacks ???await??? operators and will run synchronously. Consider using the ???await??? operator to await non-blocking API calls, or ???await Task.Run(???)??? to do CPU-bound work on a background thread.

```
  return awit Task.FromResult<object>(null);
```