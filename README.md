# FILE MANAGER PROJECT

This project is part of the Vueling Training course. It consists in a CRUD for student objects and storing them in different file extensions.

## Implementation

In this implementation I tried to apply the Abstract Factory method and 2 layer architecture. Firstly identifying what methods the abstract factory needs to implement in order to create the concrete factories needed.

### 1. Planning

There were main points:

> The elements needed in the form.
>
> Identify the products I'm going to create with the method.
> 
> Handling objects with different file extensions.

### 2. Responsabilities

In this project there were 5 main responsabilities:

1. Management of the txt file.
2. Management of the json file.
3. Management of the xml file.
4. Management of the inputs through a form.
5. Storage of the data in an object.

### 3. The code

The code is implemented trying to follow the 10x10x10 rule and, following the abstract factory, there is an Abstract Factory (IStudentDao.cs), 3 concrete factory (TxtStudentDao.cs, XmlStudentDao.cs, JsonStudentDao.cs) implementing the abstract one, a client (a form) and a product.

### Presentation Layer

## *frmStudent.cs

frmStudent is responsible for, once received the event from the client, execute the right method from the multiple factories. It gathers the data in a Student object to pass to the different methods.

### DataAccess Layer

## *StudentDao

StudentDao is responsible of defining the methods shared by every factory.

## *JsonStudentDao

JsonStudentDao is responsible for the handling of all the methods involving a json file. It adds the student in the file, updates its info, deletes students and lists all the students in the json file.
I use a generic list of Student objects for the storage of information.

## *TxtStudentDao

TxtStudentDao is responsible for the handling of all the methods involving a txt file. It adds the student in the file, updates its info, deletes students and lists all the students in the txt file.
I use a StringBuilder with a specific format for the storage of information.

## *XmlStudentDao

TxtStudentDao is responsible for the handling of all the methods involving a txt file. It adds the student in the file, updates its info, deletes students and lists all the students in the txt file.
I use a XDocument and XmlDocument for different tasks with the file handling.

### Common Layer

## *Student

Student is responsible for the definition of the attributes our product will have and generating the needed constructors to work with.
It helps us bring the data from presentation layer to Data Acces Layer and vice-versa.

### Improvement for the future

> Refactor the code, make it more legible and efficient.
>
> Apply SOLID principles
> 
> Apply exceptions, specially in every file access.
> 
> Improve listing of students with better formatting.
>
> Apply Testing to classes.

### Technology Stack

`C#, .Net Framework, Json.NET, MSTest`