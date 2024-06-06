# Multiple-user-authentication
A .NET 8 application that exemplifies a system capable of managing authentication for multiple types of users and that can be applied to different contexts.

## Concepts and Paterns
- Clean Architecture
- Repository
- Dependency Inversion
- Dependency Injection
- Service Result Patern

## Libs 
- Entity Framework Core
- Identity
- IdentityModel.Tokens.Jwt
- AutoMapper

## User and Permissions
### Admin
- Have permissions over **all** resources
### Manager
- Have permissions over **some** resources
### Client
- Have permissions over  **basic** resources

## Features
- Login for every user
- JWT Authentication
- Role Autorization
- Register for every user
- Get for every user
- Update for every user
