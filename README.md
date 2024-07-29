# TenderAutoApp

## Overview

The Tender Auto App is a comprehensive backend application developed to streamline the tender management process. This application is built using a layered architecture to ensure scalability, maintainability, and ease of testing. This document provides an overview of the technologies used, the application’s architecture, and the key functionalities implemented.

## Table of Contents

1. [Technologies Used](#technologies-used)
2. [Project Structure](#project-structure)
3. [Key Functionalities](#key-functionalities)
4. [How to Run](#how-to-run)
5. [Contribution](#contribution)
6. [License](#license)

## Technologies Used

- **ASP.NET Core**: The primary framework used for building the backend services, ensuring a robust and scalable application.
- **Entity Framework Core**: Used for interacting with the PostgreSQL database, providing an ORM layer for data manipulation.
- **PostgreSQL**: The relational database management system used to store all application data.
- **RabbitMQ**: Utilized for messaging and handling background tasks, ensuring reliable and asynchronous processing.
- **AutoMapper**: Used for object-object mapping, simplifying the transformation between Data Transfer Objects (DTOs) and entities.
- **Autofac**: A dependency injection container used to manage service lifetimes and dependencies.
- **SSO (Single Sign-On)**: Implemented for secure authentication and authorization.
- **JWT (JSON Web Tokens)**: Used for secure and stateless user authentication.
- **BCrypt**: Used for password hashing to ensure security.
- **VueJs and NuxtJs**: Frontend frameworks used for building the user interface, though primarily mentioned here for completeness as the focus is on the backend.
- **DevExtreme VueJs and Vuetify**: UI component libraries used for enhancing the frontend user experience.

## Project Structure

The project follows a layered architecture, which includes the following layers:

1. **Domain Layer**:
   - Entities: Contains the entity classes representing the database tables.
2. **Core Layer**:
   - Interfaces: Defines the contracts for repositories and services.
   - DTOs: Data Transfer Objects used for communication between layers.
3. **Infrastructure Layer**:
   - Data Context: Configuration of the Entity Framework Core and database context.
   - Repositories: Implementation of the repository pattern for data access.
   - Migrations: Database migration files.
4. **Service Layer**:
   - Services: Business logic and service implementations.
   - Mapping Profiles: AutoMapper profiles for mapping between entities and DTOs.
5. **API Layer**:
   - Controllers: API endpoints to handle HTTP requests.
   - Middlewares: Custom middleware for handling exceptions, authentication, etc.
   - DTO Mappings: Configuration for AutoMapper.

## Key Functionalities

- **User Management**:
  - User registration and login.
  - Role-based access control (Admin, Company Representative, General User).
  - Profile management and updates.
- **Tender Management**:
  - Creation, modification, and deletion of tenders.
  - Viewing tender details, including title, description, start and end dates, status, type, budget, and responsible person.
  - Managing tender offers and evaluating them.
- **Company Management**:
  - Adding, modifying, and deleting companies.
  - Managing company participation in tenders and tracking their offers.
- **Product Management**:
  - Adding, modifying, and deleting products.
  - Categorizing products and managing their association with tenders.
- **Notification Management**:
  - Sending notifications for tender updates, important announcements, and tender results.
  - Managing notifications based on user roles and preferences.
- **Offer Management**:
  - Adding, modifying, and deleting offers.
  - Viewing offer statistics, including average offers and the lowest three offers.
  - Associating offers with tender results.
- **Department Management**:
  - Adding, modifying, and deleting departments.
  - Associating departments with tenders.
- **Tender Responsible Management**:
  - Adding, modifying, and deleting tender responsible persons.
  - Updating tender status information.

## How to Run

1. Clone the Repository:
    ```bash
    git clone https://github.com/yunuspektass/TenderAutoApp
    ```

2. Navigate to the Project Directory:
    ```bash
    cd TenderAutoApp
    ```

3. Setup Database:
    Ensure PostgreSQL is installed and configured. Update the connection string in the `appsettings.json` file.

4. Run Migrations:
    ```bash
    dotnet ef database update
    ```

5. Run the Application:
    ```bash
    dotnet run
    ```

## Contribution

Contributions are welcome. Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License.

---

This README provides a comprehensive overview of the Tender Auto App, detailing the technologies used, the architecture followed, and the key functionalities implemented. This should help any developer or stakeholder understand and contribute to the project effectively.
