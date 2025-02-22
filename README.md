# MiroClone (RealTime Board)

MiroClone is a real-time collaborative whiteboard application that allows users to create, edit, and share boards dynamically. It provides a seamless drawing experience using Fabric.js and supports real-time updates through SignalR.

## Technologies Used

- **ASP.NET Core** - Backend API development
- **Angular** - Frontend framework
- **SQL Server** - Database management
- **SignalR** - Real-time communication
- **Fabric.js** - Canvas rendering & manipulation
- **Entity Framework Core** - ORM for database operations

## API Endpoints

### Authentication

- **Register** - `POST /api/account/register`
- **Sign In** - `POST /api/account/signin`

### Board Management

- **Get All Boards** - `GET /api/Board`
- **Create Board** - `POST /api/Board`
- **Get Board by ID** - `GET /api/Board/{id}`
- **Update Board** - `PUT /api/Board/{id}`
- **Delete Board** - `DELETE /api/Board/{id}`
- **Search Boards** - `GET /api/Board/search`

### User Management

- **Get All Users** - `GET /api/User`

## Features

- Real-time collaborative board using **SignalR**
- Freehand drawing, shapes, and text support with **Fabric.js**
- User authentication and board access control
- Board creation, editing, and deletion
- Search functionality for boards

## Installation & Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/MiroClone.git
   cd MiroClone
   ```
2. Set up the backend:
   ```bash
   cd Backend
   dotnet restore
   dotnet run
   ```
3. Set up the frontend:
   ```bash
   cd Frontend
   npm install
   ng serve
   ```
4. Access the application in your browser at `http://localhost:4200/`.

## License
This project is open-source and available under the MIT License.
