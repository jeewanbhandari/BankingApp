# XYZ Bank Console Application

## Overview

This console application serves as a simulation for basic banking operations at XYZ Bank. Users can create savings accounts, manage transactions, and view account details.

## Project Structure

1. **Transaction.cs**: Manages financial transaction details.
2. **IAccount.cs**: Defines the common account interface.
3. **Account.cs**: Implements the base account class with shared functionality.
4. **SavingsAccount.cs**: Inherits from Account and adds specific details for a savings account.
5. **Program.cs**: The entry point managing user interactions.

## How to Run

1. Open the project in your preferred C# development environment.
2. Start debugging the application.

## Usage

Upon launching the program, users can choose from the following options:

### 1. Create a New Savings Account

- Select option 1 to create a new savings account.
- Specify the account type (currently supports Savings Account).
- Enter account details, including account number, account holder name, and initial balance.

### 2. Manage an Existing Account

- Choose option 2 to manage an existing account.
- Input the account number.
- Perform transactions: deposit, withdrawal, or display account information.

### 3. Exit the Application

- Select option 3 to exit the application.

## Dependencies

- .NET Core runtime (Version 6).

## Instructions

Ensure you have the .NET Core runtime (Version 6) installed on your system before running the application.

## Notes

- Error handling is implemented to enhance the user experience.
