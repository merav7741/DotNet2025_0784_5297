# Jewelry Luxury Shop - 3-Tier Architecture System

## Overview
This project is a comprehensive management system for a luxury jewelry store, developed using **.NET** and following a professional **3-Tier Architecture**. The system manages products, customers, and orders, ensuring high performance, data integrity, and a clear separation of concerns.

## Architecture
The project is structured into three main layers:

### 1. UI (User Interface) - Windows Forms
- Developed using **WinForms**, providing a rich and intuitive desktop experience for store administrators.
- Communicates exclusively with the Business Logic Layer (BL).
- Responsible for data presentation and gathering user input.

### 2. BL (Business Logic Layer)
- The "Brain" of the application.
- Implements complex business rules, such as:
    - **Stock Validation:** Ensuring products are available before an order is placed.
    - **Price Calculations:** Managing discounts, preferred customer rates, and total order sums.
    - **Data Transformation:** Converting between Data Objects (DO) and Business Objects (BO).
- Uses **Interfaces** to maintain loose coupling with the data layer.

### 3. DAL (Data Access Layer)
- Responsible for data persistence.
- Implements the **Facade Pattern** and **Factory Pattern**, allowing the system to switch seamlessly between different data sources.
- Supports two modes:
    - **DalList:** In-memory storage for rapid testing.
    - **DalXml:** Persistent storage using XML files.

## Key Features & Design Patterns
- **Loose Coupling:** Extensive use of Interfaces (`IDal`, `IBl`) to ensure components are independent.
- **Extension Methods:** Used for clean and readable object mapping (DO to BO and vice versa).
- **Logging:** A custom `LogManager` using `System.Reflection` to track system events and errors dynamically.
- **LINQ:** Advanced data querying and filtering throughout the application.

## Technologies Used
- **Language:** C#
- **Framework:** .NET
- **Data Format:** XML
- **UI Framework:** Windows Forms
