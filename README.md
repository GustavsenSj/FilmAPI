# FilmAPI

This is a simple API that allows you to manage a film database. It is created using Entity Framework Code First workflow
and an ASP.NET Core Web API in C#. The project is based on an assignment from Noroff School of Technology and Digital
Media.

## Assignment requirements

### Use Entity Framework Code First to create a database

**Requirements**

- [x] Create models and DbContext to cater for the specifications
- [x] Proper configuration of datatypes is to be done using data attributes.
- [x] Comments on each of the classes showing where navigation properties are and aspects of DbContext.
- [x] Connection String should not be hard coded into DbContext.

### Create a Web API in ASP.NET Core

**Requirements**

- [x] Create controllers and DTOs according to the specifications.
- [x] Encapsulate DbContext into Services for each domain entity. Movie, Character, and Franchise.
- [x] Swagger/Open API documentation using annotations.
- [ ] Summary (///) tags for each method you write, explaining what the method does, any exceptions it can throw, and
  what data it returns (if applicable). You do not need to write summary tags for overloaded methods.

## Collaborators

This project was made as a group project by the following people:

- [Philip Thangngat](https://github.com/thangfart)
- [Sjur Gustavsen](https://github.com/GustavsenSj)

## Installation and usage

To run this project you need to have a local Microsoft SQL Server on your system. For connection to the database you
need tho have a connection string in the appsettings.json file. The connection string should look like this:

```json
"ConnectionStrings":{
"FilmAPI": "your connection string here"
}
```

To create the database an populate it width dummy data you need to run the following commands in the Package Manager Console:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```



