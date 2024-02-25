 # Interview System

## Project Overview
 
 The Interview System System customizes interview questions based on a candidate's skill level and technology expertise. This ensures a more targeted and relevant interview experience, allowing interviewers to efficiently evaluate candidates while providing a fair and challenging assessment based on individual skills and qualifications.

 # Table of Contents
- Solution Structure
	- Structure description
- Key Features
 - Getting Started
	- Prerequisites
	- Installation
- Contribute
- Build and Run 
- Build and Test

# Solution Structure
## CQRS and Clean Architecture in .NET 6
```
|-- InterviewSystem.Api
|  	|-- Controllers
|-- InterviewSystem.Application
|  	|-- Responses
|  	|-- Enumerations
|  	|-- ApplicationServiceRegistration.cs
|-- InterviewSystem.Domain
|  	|--Common
|   |--Models
|-- InterviewSystem.Persistence
|  	|-- PersistenceRegistration.cs
|	|--Repositories
|	|--Contracts
|	|--Entities
```

## Structure description

1. **InterviewSystem.Api**

The API project serves as the entry point for external systems to interact with your application. It exposes endpoints, handles HTTP requests, and communicates with the Application layer.

2. **InterviewSystem.Application**

The Application project is the core of your business logic, following the CQRS pattern. It contains command and query handlers, use cases, and orchestrates interactions between the API, Domain, and Persistence layers.

3. **InterviewSystem.Domain**

The Domain project encapsulates the core business logic and domain model. It contains entities, aggregates, value objects, and domain services.

4. **InterviewSystem.Persistence**

The Persistence project handles data access and storage. It contains repositories that interact with the database.

# Key Features

**Questions**: Registering new questions into the system and retrieving relevant one's when needed for interview <br/><br/>
**Performance evaluation**: Get a performance review of the interviewee after when interview is done<br/><br/>

# Getting Started
## Prerequisites
- .NET SDK 6.0
- Visual Studio 2022 or Visual Studio Code
- SQL Server and SQL Server Management Studio 19

## Installation
1. Clone the repository: git clone https://bolzonihartmannyao@dev.azure.com/bolzonihartmannyao/Interview%20System/_git/Backend
2. Navigate to the project directory: cd Backend
3. Restore dependencies: dotnet restore
4. Build the project: dotnet build
5. Run the project: dotnet run
 

# Contribute
## Creating a new branch
**Create a new branch from develop when starting a new task** <br/>
> git checkout -b branch-name origin/develop

## Creating a Pull Request
**First to make sure that there were no changes made to develop we use**
> git fetch

**Do a rebase from remote develop branch to ensure that own branch is up to date**
> git rebase origin/develop

**Resolve conflicts if any**
This can be done using Visual Studio Interface

**Continue rebase until it is done**
> git rebase --continue

**Push your changes to online repository**
> git push -f

## Commit message convention
The format for commit message is:

&lt;type&gt;(scope): &lt;short summary&gt;<br/>
Example<br/>
feat(Authentication): Added authentication process<br/>
test(Authentication): Added scenarios of authentication

Different &lt;type&gt;
- feature: For new functionalities
- test: Adding/modifying tests
- fix: For bug fix
- docs: Documentation changes only
- refactor: For commnits concerning refactorization of code
- perf: Code that improves performance
- build: Changes that affects the build system or external dependencies (e.g. gulp, broccoli, npm)
- ci: Changes to our CI configuration files and scripts

## Custom branch naming convention

- **`feature`**: Intended for feature development.
- **`release`**: Reserved for deploying releases.
- **`hotfix`**: Designated for urgent fixes in the production environment.


# Build and Run
cd interview-system
dotnet build
dotnet run

# Build and Test
cd interview-system
dotnet test