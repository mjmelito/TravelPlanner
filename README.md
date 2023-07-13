# _NomadCraft_

#### By _**Sierra Rhodes, Justin Shaffer, Matt Melito**_

#### This simple web application is designed to be used as a travel planner that allows the user to input their destinations, mode of transportation, lodging and then displaying them in the trip they name and create. 

## Technologies Used

* _ASP.Net_
* _C#_
* _MySQL_
* _HTML_
* _CSS_
* _JavaScript_


## Description

_This is a travel planner application that allows the user to create a trip and store their created destinations, mode of transportation, and lodging. The user has full CRUD functionality for each one. They can create, see the details, edit, and delete for each thing they create. The user can register and login and logout._

## Setup/Installation Requirements

* _Install .NET 6_
* _clone the repository_
* _Navigate to 'TravelPlanner.Solution' directory in your terminal_
* _Open the project in any text editor/ VSCode preferably_
* _Commit changes to your respository_
* _Create a new file called appsettings.json_
* _Add the following code to the appsettings.json file you created:
```markdown
{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[NAME-YOU-WANT-FOR-YOUR-DATABASE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];" } }
```

## Recreating the Database

* _To add a migration naviate to TravelPlanner.Solution in your command line_
* _Navigate to TravelPlanner_
* _Run dotnet build_
* _Run the command "dotnet tool install --global dotnet-ef --version 6.0.0_
* _Run the command "dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0"_
* _Run the command "dotnet ef migrations add Initial"_
* _Run "dotnet ef database update" in your command line._
* _Run dotnet watch run_

## Known Bugs

* _None_


## License

Copyright 2023 Sierra Rhodes, Justin Shaffer, Matt Melito 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
