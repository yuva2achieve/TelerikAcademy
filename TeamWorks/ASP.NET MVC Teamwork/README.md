ASP.NET MVC – Practical Teamwork Project:
==========================

Created By:
-----------
* Borislav Jivkov
* Boncho Vylkov
* Petar Penev
* Yanko Malinov

Description:
----------
Student system application allowing students to enroll in courses and earn certificates. The application has separate Admin area that allows adding, editing and deleting of courses, certificates and students.

Technologies used:
------------------
* C#
* ASP.NET MVC 5
* Microsoft SQL Server 2012
* Entity Framework
* KendoUI 
* Bootstrap
* TFS

Project Description
-------------------
Design and implement an ASP.NET MVC application. It can be a discussion forum, blog system, e-commerce site, online gaming site, social network, or any other Web application by your choice.
The application should have public part (accessible without authentication), private part (available for registered users) and administrative part (available for administrators only).

General Requirements
---------------------
Your Web application should use the following technologies, frameworks and development techniques:
* Use ASP.NET MVC 5 and Visual Studio 2013
* You should use Razor template engine for generating the UI
 * At least 3 Kendo UI widgets should be used (using the ASP.NET MVC Wrappers)
 * ASP.NET WebForms is not allowed
 * Use at least one section and at least one partial view
* Use MS SQL Server as database back-end
* Use Entity Framework to access your database
 * Using Unit of Work and Repository pattern is not mandatory
* Use at least one MVC Area in your project (e.g. for administration)
* Create at least two tables with data with server-side paging and sorting
 * You can use Kendo UI Grid or generate your own HTML tables
* Adapt the default ASP.NET MVC site template from Visual Studio 2013
 * Use responsive design based on Twitter Bootstrap
 * You may change the standard theme and modify it to apply own web design and visual styles
* Use the standard ASP.NET Identity System for managing users and roles
 * Your registered users should have at least one of the two roles: user and administrator
* Use at least one AJAX form and/or SignalR communication
* Write few unit tests for your controllers logic
* Apply error handling and data validation to avoid crashes when invalid data is entered
* Handle correctly the special HTML characters and tags like <br />
* Prevent yourself from security holes (XSS, XSRF, Parameter Tampering, etc.)
* Use a source control system by choice for team collaboration.

Public Part
-----------
The public part of your projects should be visible without authentication. This public part could be the application start page, the user login and user registration forms, as well as the public data of the users, e.g. the blog posts in a blog system, the public offers in a bid system, the products in an e-commerce system, etc.

Private Part (User Area)
------------------------
Registered users should have personal area in the Web application accessible after successful login. This area could hold for example the user's profiles management functionality, the user's offers in a bid system, the user's posts in a blog system, the user's photos in a photo sharing system, the user's contacts in a social network, etc.

Administration Part
-------------------
System administrators should have administrative access to the system and permissions to administer all major information objects in the system, e.g. to create / edit / delete users and other administrators, to edit / delete offers in a bid system, to edit / delete photos and album in a photo sharing system, to edit / delete posts in a blogging system, edit / delete products and categories in an e-commerce system, etc.