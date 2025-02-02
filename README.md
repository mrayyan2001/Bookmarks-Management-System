# Bookmarks Management System

This is a simple CRUD application using ASP.NET Core 8 and Entity Framework for a Bookmarks Management System.

We will be using Razor Pages to create a simple web application that allows users to create, read, update, and delete bookmarks.

The guide will walk you through the steps to create a new project, create a model, add a scaffolded item, enable IIS Express, and run the application.

## Prerequisites

- Visual Studio 2022
- .NET 8.0
- SQL Server Express LocalDB
- Internet Information Services (IIS) Express

## The workflow steps are as follows:

### Step 1: Create a new project

1. Open Visual Studio 2022
2. Click on `Create a new project`
3. Select `ASP.NET Core Web Application A project template for creating an ASP.NET Core application with example ASP.NET Core Razor Pages content.`
4. Click `Next`
5. Name your project and click `Next`
6. Select `.NET 8.0` and click `Create`

### Step 2: Create a model

1. Right-click on the project and select `Add` -> `New Folder` and name it `Models`
2. Right-click on the `Models` folder and select `Add` -> `Class...`
3. Name the class `Bookmark.cs` and click `Add`
4. Add the following code to the `Bookmark.cs` file:

```csharp
namespace BookmarkManagementSystem.Model
{
    public class Bookmark
    {
        public int ID { get; set; }
        public string Title {  get; set; }
        public string URL { get; set; }
    }
}
```

### Step 3: Add `Bookmarks` folder to Pages

1. Right-click on `Pages` folder and select `Add` -> `New Folder` and name it `Bookmarks`

### Step 4: Add scaffolded item

1. Right-click on the `Bookmarks` folder and select `Add` -> `New Scaffolded Item...`
2. Select `Razor Pages using Entity Framework (CRUD)` and click `Add`
3. Model class: `Bookmark (BookmarkManagementSystem.Model)`
4. Data context class: `BookmarkManagementSystem.Data.BookmarkManagementSystemContext` or create a new one

### Step 5: Enable Internet Information Services (IIS) Express

1. Open `Control Panel` and click on `Programs and Features` -> `Turn Windows features on or off`
2. Enable `Internet Information Services`
3. Click `OK`

### Step 6: On `Package Manager Console` run the following commands:

1. `Add-Migration Initial`
2. `Update-Database`

### Step 7: Run the application

1. Click on the `IIS Express` button to run the application
2. Navigate to `https://localhost:{port}/Bookmarks` to view the application

## To see the database:

1. Open `View` -> `SQL Server Object Explorer`
2. Expand the `(localdb)\MSSQLLocalDB` node
3. Expand the `Databases` node

## Frontend

For the frontend, we used Bootstrap to style the application.

## Images of the application

### Home Page

<p align="center">
  <img src="./Images/image.png" alt="Home Page" width="600">
</p>

### Create Bookmark

<p align="center">
  <img src="./Images/image-1.png" alt="Create Bookmark" width="600">
</p>

### Edit Bookmark

<p align="center">
  <img src="./Images/image-2.png" alt="Edit Bookmark" width="600">
</p>

### Delete Bookmark

<p align="center">
  <img src="./Images/image-3.png" alt="Delete Bookmark" width="600">
</p>

### Details Bookmark

<p align="center">
  <img src="./Images/image-4.png" alt="Details Bookmark" width="600">
</p>

## UML Diagrams

![alt text](image.png)

```plantUML
@startuml
package "BookmarkManagementSystem.Model" {
    class Bookmark {
        - int ID
        - string Title
        - string URL
    }
}
@enduml
```

![alt text](image-1.png)

```plantUML
@startuml

actor User

usecase "Create a Bookmark" as UC_Create
usecase "View Bookmarks" as UC_View
usecase "Update a Bookmark" as UC_Update
usecase "Delete a Bookmark" as UC_Delete
usecase "Open a Bookmark" as UC_Open

User --> UC_Create
User --> UC_View
User --> UC_Update
User --> UC_Delete
User --> UC_Open

@enduml
```

![alt text](image-2.png)

```plantUML
@startuml

start

:User navigates to the system;
if (Choose Action?) then (Create a Bookmark)
    :Display Create Form;
    :User inputs Title and URL;
    if (Valid Input?) then (Yes)
        :Save Bookmark to Database;
    else (No)
        :Show Validation Errors;
    endif;
    :Redirect to Bookmark List;
elseif (View Bookmarks)
    :Retrieve and Display Bookmark List;
    :User selects a Bookmark;
    :Display Bookmark Details;
elseif (Update a Bookmark)
    :Display Edit Form;
    :User updates Title and/or URL;
    if (Valid Input?) then (Yes)
        :Save Changes to Database;
    else (No)
        :Show Validation Errors;
    endif;
    :Redirect to Bookmark List;
elseif (Delete a Bookmark)
    :User confirms Deletion;
    :Remove Bookmark from Database;
    :Redirect to Bookmark List;
elseif (Open a Bookmark)
    :Open URL in Browser;
endif;

stop

@enduml
```
