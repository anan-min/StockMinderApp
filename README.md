# StockMinder

**Author:** อนันต์ มิ่งมิตรพัฒนะกุล (Anant Mingmitpatanakun)
**Student ID:** 1660706688
**Section:** 327D

This project is a part of the CS356 Mobile Application Development 1 course,
2nd semester, academic year 2566, Department of Computer Science, Faculty of Information Technology and Innovation, Bangkok University.

## Project Description

StockMinder is a mobile application for managing stock products and reporting issues. 
The project aims to develop an application using .NET MAUI to manage stock products and report issues that may occur. 
The project scope includes three main functions:

1) **Authentication**
   - Register: Collects user information such as employee_id, username, password, email, and department.
   - Login: Verifies user's username and password, allowing access to the system upon successful verification.

2) **Stock Management**
   - Search Item: Displays products that match the search query in a collection view.
   - Edit Item: Allows editing of selected product information.
   - Add Item: Adds new product information and images.

3) **Report Management**
   - Submit Report: Creates a report with a title and content and saves it when the user submits.
   - View Reports: Displays saved reports in a list view.

## Application Usage

### Main Page
Contains icons for each page in the application (Edit Product, Search Product, Add Product, Authenticate, Submit Report, and View Reports).

### Hamburger Menu
Part of the application used to open various windows in the application.

### Register
Collects username, password, email, and department. Upon submission, the system creates a user account.

### Login
Collects username and password for logging into the system.

### Search Item
Searches for products based on product ID or text in the search bar and displays the results in a list view.

### Edit Item
Allows increasing or decreasing the quantity of selected products in stock using add and remove buttons.

### Add Item
Adds a new product to the stock with the following information: product ID, product name, current stock level, stock location, and product description. When all information is entered and the product is submitted, it is saved in the system.

### Submit Report
Enters a report title and details, and submits to create a report related to stock products.

### View Reports
Displays all saved reports in a list view.
