# Car Rental API

The **Car Rental API** is a backend application for managing car rental services. It provides functionality for user authentication, car management, and rental operations with secure JWT-based authorization.

---

## Features

- Manage car details, availability, and rental transactions.
- User registration and login with secure authentication.
- Admin functionality for adding and updating car details.
- Role-based access control (Admin and User).
- Email notifications for successful rentals.
- Error handling with meaningful responses.

---

## Folder Structure

- **Controllers**: API endpoints for car and user operations.
- **Services**: Business logic for managing cars, users, and rentals.
- **Repositories**: Database access layer for persisting data.
- **Screenshots**: Contains relevant screenshots of the system.

---

## API Endpoints

### Car Controller

| **Endpoint**                                   | **HTTP Method** | **Authorization**  | **Description**                                                                 |
|-----------------------------------------------|-----------------|--------------------|---------------------------------------------------------------------------------|
| `/api/Car/GetAvailableCars`                   | `GET`           | User or Admin      | Retrieves a list of available cars.                                            |
| `/api/Car/addCar`                              | `POST`          | Admin              | Adds a new car to the system.                                                  |
| `/api/Car/UpdateCarAvailabilty/{id}`          | `PUT`           | Admin              | Updates the availability status of a car.                                      |
| `/api/Car/{id}`                                | `GET`           | User or Admin      | Retrieves details of a specific car by its ID.                                 |
| `/api/Car/RentCar`                             | `PUT`           | User or Admin      | Rents a car and updates its availability.                                      |

### User Controller

| **Endpoint**                  | **HTTP Method** | **Authorization** | **Description**                                     |
|-------------------------------|-----------------|-------------------|-----------------------------------------------------|
| `/api/User/Login`             | `POST`          | Public            | Authenticates a user and returns a JWT token.       |
| `/api/User/RegisterUser`      | `POST`          | Public            | Registers a new user account.                      |

---

## Services

### CarService
- `addCar(Car car)`: Adds a new car to the database.
- `UpdateCarAvailability(Guid id)`: Updates the car's availability.
- `GetAvailableCars()`: Fetches a list of all available cars.
- `GetCarById(Guid id)`: Retrieves details of a car by its ID.
- `RentCar(RentCarDetails details)`: Processes a car rental, updates availability, and sends a confirmation email.

### UserService
- `RegisterUser(User user)`: Handles user registration.
- `LoginUser(LoginCredentials credentials)`: Authenticates a user and generates a JWT token.

### EmailService
- `SendEmailAsync(string email, string subject, string message)`: Sends an email notification using SMTP configuration.

### JwtService
- `GenerateToken(string username, string role)`: Creates a JWT token with user claims (e.g., username, role, and expiration).

---

## Repositories

### CarRepo
- `AddCar(Car car)`: Saves a new car to the database.
- `UpdateCarAvailability(Guid id)`: Updates the availability of a car.
- `GetAvailableCars()`: Retrieves a list of available cars.
- `GetCarById(Guid id)`: Fetches details of a car by ID.

### UserRepo
- `RegisterUser(User user)`: Saves user details to the database.
- `LoginUser(LoginCredentials credentials)`: Validates user credentials and fetches roles.

---

## Authentication

- **JWT Tokens**: Used for secure authorization.
- **Claims**:
  - Username: Identifies the user.
  - Role: Specifies the user type (Admin/User).
  - Expiry: Tokens expire after 1 hour.

---

## Screenshots

All relevant screenshots are stored in the `screenshots` folder, illustrating various API operations and responses.

---

