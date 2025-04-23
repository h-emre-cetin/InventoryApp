# InventoryApp

InventoryApp is a .NET 9 web application designed to manage product inventories. It provides APIs for creating, reading, updating, and deleting product information. The application uses Entity Framework Core with MySQL for data persistence and includes Swagger for API documentation.

## Features

- **Product Management**: Add, update, delete, and view products.
- **Database Integration**: Uses MySQL with Entity Framework Core for data storage.
- **API Documentation**: Integrated Swagger/OpenAPI for easy API exploration.
- **Unit Testing**: Includes xUnit-based tests for services and repositories.

## Technologies Used

- **.NET 9**
- **Entity Framework Core 6**
- **Pomelo MySQL Provider**
- **Swagger/OpenAPI**
- **xUnit** for testing

## Installation

1. Clone the repository:
   - git clone https://github.com/your-repo/InventoryApp.git cd InventoryApp    

2. Set up the database:
   - Update the `DefaultConnection` string in `appsettings.json` with your MySQL connection details.

3. Apply migrations:
   - dotnet ef database update
 
4. Run the application:
   - dotnet run
	
## Usage

- Access the Swagger UI at `https://localhost:5001/swagger` to explore the API endpoints.
- Use the provided endpoints to manage products in the inventory.

## API Endpoints

- `GET /api/products` - Retrieve all products.
- `GET /api/products/{id}` - Retrieve a product by ID.
- `POST /api/products` - Add a new product.
- `PUT /api/products/{id}` - Update an existing product.
- `DELETE /api/products/{id}` - Delete a product.

## Testing

Run the unit tests using the following command:
- dotnet test

## Short Feedback
- The task was easy to complete AI, but it took a bit longer than expected due to the need to set up nuget packages and ensure all dependencies were correctly configured.
- The code was not ready to run after generation, I need to make changes.
- The task took me 2 and a half hours to complete.
- The challenges was migration and nuget packages. Because Pomelo is using 6.x.x and I need downgrade the EF to use it.
- "Explain by step by step" specific prompt I learned as a good practice to complete the task.
- I changed nuget packages to the related version, added new nuget packages to make it usable.
