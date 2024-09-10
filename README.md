**News Service API**

This is a .NET 6 Web API application that fetches and stores news articles from an external news API. The application retrieves the latest news, processes it, and stores it in a SQL Server database. It also uses AutoMapper for object-to-object mapping, Swagger for API documentation, and is containerized using Docker.

**Features**

Fetches articles from an external news API.
Stores news articles and their sources in a SQL Server database.
Uses Entity Framework Core for database interaction.
AutoMapper is used for DTO-to-entity mapping.
Includes API documentation via Swagger.
Contains unit tests for various scenarios using xUnit and Moq.
Containerized using Docker for easy deployment.

**Technologies Used**

.NET 6
ASP.NET Core Web API
Entity Framework Core (SQL Server)
AutoMapper
Swagger (Swashbuckle)
xUnit (Unit testing)
Moq (Mocking in unit tests)
Docker

**Getting Started**

Make sure you have the following installed:

.NET 6 SDK
SQL Server
Docker (for containerization)
Setting Up the Project

1. Clone the repository
2. Install dependencies
3. Configure the database: Update the appsettings.json file with your SQL Server connection string
4. Apply migrations
5. Run the application
6. Access Swagger

**Endpoints**

POST /api/news/fetch-and-store - Fetches and stores the latest news articles from an external source.

**Docker Support**

1. Build the Docker image
2. Run the Docker container

**Project Structure**

Business: Contains the business logic for fetching and storing articles.
Repository: Handles data access and database interactions (EF Core).
Abstractions: Contains DTOs and interfaces for service abstraction.
API: Controllers and API routing.
Tests: Unit tests using xUnit and Moq.
