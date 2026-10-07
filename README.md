\# Smart Service Request Management System  using the Dotnet framework 



A full-stack web application for creating, managing, assigning, filtering, and tracking service requests.



The project is built using \*\*ASP.NET Core Web API, C#, Entity Framework Core, SQL Server, and React.js\*\*.



\## Features



\- Create new service requests

\- View all service requests

\- Edit existing service requests

\- Delete service requests

\- Update request status

\- Filter requests by status

\- Filter requests by priority

\- Assign requests to users/admins

\- Priority management: Low, Medium, High

\- Status management: Pending, In Progress, Completed

\- User and service request relationship

\- RESTful Web APIs

\- Responsive React.js frontend

\- Swagger API documentation



\## Tech Stack



\### Backend

\- C#

\- ASP.NET Core Web API

\- Entity Framework Core

\- SQL Server

\- Swagger



\### Frontend

\- React.js

\- JavaScript

\- HTML5

\- CSS3



\### Tools

\- Git

\- GitHub

\- Visual Studio Code

\- SQL Server Management Studio



\## Project Structure



```text

smart-service-request-management/

│

├── Backend/

│   ├── Controllers/

│   │   ├── ServiceRequestsController.cs

│   │   └── UsersController.cs

│   │

│   ├── Data/

│   │   └── AppDbContext.cs

│   │

│   ├── Models/

│   │   ├── ServiceRequest.cs

│   │   └── User.cs

│   │

│   ├── Migrations/

│   ├── Program.cs

│   ├── appsettings.json

│   └── Backend.csproj

│

└── Frontend/

&#x20;   ├── src/

&#x20;   │   ├── App.jsx

&#x20;   │   ├── main.jsx

&#x20;   │   └── index.css

&#x20;   ├── package.json

&#x20;   └── vite.config.js

```



\## Database



The application uses \*\*SQL Server\*\* with Entity Framework Core.



Default local connection:



```text

Server=localhost\\SQLEXPRESS;

Database=SmartServiceDB;

Trusted\_Connection=True;

TrustServerCertificate=True;

```



Update the connection string in:



```text

Backend/appsettings.json

```



according to your local SQL Server configuration.



\## Backend Setup



Go to the backend folder:



```bash

cd Backend

```



Restore dependencies:



```bash

dotnet restore

```



Run database migrations:



```bash

dotnet ef database update

```



Run the backend:



```bash

dotnet run

```



The API runs on:



```text

http://localhost:5006

```



Swagger documentation:



```text

http://localhost:5006/swagger

```



\## Frontend Setup



Open another terminal and go to the frontend:



```bash

cd Frontend

```



Install dependencies:



```bash

npm install

```



Start the React application:



```bash

npm run dev

```



The frontend runs on:



```text

http://localhost:5173

```



\## API Endpoints



\### Service Requests



| Method | Endpoint | Description |

|---|---|---|

| GET | `/api/ServiceRequests` | Get all service requests |

| GET | `/api/ServiceRequests/{id}` | Get request by ID |

| POST | `/api/ServiceRequests` | Create a new request |

| PUT | `/api/ServiceRequests/{id}` | Update a request |

| PATCH | `/api/ServiceRequests/{id}/status` | Update request status |

| DELETE | `/api/ServiceRequests/{id}` | Delete a request |



\### Filtering



Filter by status:



```text

GET /api/ServiceRequests?status=Pending

```



Filter by priority:



```text

GET /api/ServiceRequests?priority=High

```



Filter by both:



```text

GET /api/ServiceRequests?status=Pending\&priority=High

```



\### Users



| Method | Endpoint | Description |

|---|---|---|

| GET | `/api/Users` | Get all users |

| GET | `/api/Users/{id}` | Get user by ID |

| POST | `/api/Users` | Create a user |

| PUT | `/api/Users/{id}` | Update a user |

| DELETE | `/api/Users/{id}` | Delete a user |



\## Sample Service Request



```json

{

&#x20; "title": "Laptop Issue",

&#x20; "description": "Laptop is not starting properly.",

&#x20; "priority": "High",

&#x20; "status": "Pending",

&#x20; "userId": 1,

&#x20; "assignedTo": "Admin"

}

```



\## Request Status Flow



```text

Pending

&#x20;  ↓

In Progress

&#x20;  ↓

Completed

```



\## Database Relationship



A service request belongs to a user through `UserId`.



```text

User

&#x20;|

&#x20;| 1

&#x20;|

&#x20;| \*

ServiceRequest

```



Entity Framework Core is used to manage this relationship and database operations.



\## Screenshots



Add application screenshots here after taking them:



```text

Frontend Dashboard

Create Service Request

Service Request List

Swagger API

```



Example:



```markdown

!\[Dashboard](screenshots/dashboard.png)

```



\## Future Improvements



\- JWT-based authentication

\- Separate Admin and User dashboards

\- Email notifications

\- Pagination

\- Search functionality

\- Deployment to a cloud platform

\- Improved role-based access control



\## Learning Outcomes



Through this project, I practiced:



\- C# and ASP.NET Core Web API

\- REST API development

\- Entity Framework Core

\- SQL Server database integration

\- CRUD operations

\- Database relationships

\- React.js frontend development

\- API integration using JavaScript

\- Git and GitHub

\- Basic full-stack application architecture

