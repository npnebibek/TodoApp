# ToDo List Application
A full-stack application featuring a modular .NET Web API and a reactive Angular frontend.

## Technology Stack
* **Frontend:** Angular 21.2.13 with Tailwind CSS for styling
* **Backend:** .NET 10 Web API
* **Testing:** xUnit (Backend) and Vitest (Frontend)

## Architecture & Design Choices
* **Modular Structure:** The backend has a modular and maintainable structure making codebase lightweight and easy to navigate.
* **Separated Test Suite:** Unit tests for the api are organised into a dedicated project within the solution, ensuring a clean separation between production code and testing logic.
* **State Management:** Utilises Angular **Signals** to manage the Todo list state, ensuring reactive and highly performant UI updates.

## Getting Started

### Prerequisites
* [Node.js](https://nodejs.org/) (Latest LTS)
* [.NET SDK](https://dotnet.microsoft.com/download) (Latest version)

### Running the Backend
1. Navigate to the backend folder:
    ```bash
    cd TodoApp.Api

2. Restore dependencies and then run the API:
    ```bash
    dotnet restore
    dotnet run

The api should start running on http://localhost:5200 or check the console what port it is running on.

### Running the Frontend
1. Navigate to the frontend folder
    ```bash
    cd TodoApp.Client

2. Install dependencies:
    ```bash
    npm install

3. Start the application:
    ```bash
    npm start

The frontend should start running on http://localhost:4200


### Testing
* **Backend:**: ` cd Todo.Api.Tests` and run ` dotnet test ` from the test.
* **Frontend:**: Run ` npm test ` from the frontend directory.


### Using the App
* The UI includes a text input to add in the To Do items. After typing click `Add`. This will add the todo item.
* The checkbox next to the item can toggle the item into done or undone state.
* Delete button next to each item on the list will remove the to do item from the list.