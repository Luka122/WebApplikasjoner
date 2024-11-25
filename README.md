# ITPE3200 - Group Exam

### Useful Commands
Update Migrations:
```dotnet ef migrations add <MigrationName>``` <br />

## Project Requirements
* Sub-application 1: the front-end and back-end should use the Model-View-Controller framework of ASP.NET 8.0
* Sub-application 2: the backend should be .NET 8.0 (can reuse that from Sub-application 1), and the front-end should use a front-end framework with AJAX call (e.g., React).
* A short documentation of 2000-5000 words (in English) must be written, which should include some diagrams for the software architecture and database (here is a document for inspiration).

## Web Application Requirements - Web-based Food Registration Tool

**User experience**, including:
* Basic design, not plain text and bare buttons  
* Dynamic content  
* Friendly navigation  
* If the user experience is confusing or does not reflect the normal expectation of the given task, it will negatively affect the grade.  

**Coding style and documentation**, including:
* Neat code, structured, and modularised  
* Understandable code, either self-explanatory or with suitable comments (in English)  
* If the program is buggy or has warnings (use `dotnet build` to verify), it will negatively affect the grade.  

**Functionality**, including:
* Database operation with at least 2 types of entity (including views and CRUD)  
* Repository pattern and DAL  
* Asynchronous database access  
* Forms and input validation (server-side)  
* Error handling and logging (server-side)  
* Authentication and authorisation (server-side)  
* Unit testing (server-side), at least 8 tests, including:
  * The complete positive tests and negative tests for each CRUD method (where testing is meaningful) of 1 entity/table  
* If the requirements are finished in a low quality or incomplete (e.g., for the requirement error handling and logging, if only part of the code is covered by error handling and logging), it will negatively affect the grades.  

**Additional Notes**:
* It will be taken into account in the evaluation if you have a beautiful design, extra rich user experience, and extra functionality (be creative).

## Inspiration / More Info
**Background**:  
Food companies can apply for healthy food label, which indicates their products meet specific criteria based on nutrition values. This label helps consumers choose healthier products.

**Task**:  
Design and develop a web-based food registration tool that allows food producers to **create, read, update, and delete** records of food products and nutritional values.

**Features**:
1. **Food Record Management (CRUD)**:  
   - **Create**: Input food name, food group, and nutritional info.  
   - **Read**: View records with nutritional values.  
   - **Update**: Edit records for food group and nutritional values.  
   - **Delete**: Remove food records.  

2. **Data Model**:
   - **Food Name**  
   - **Food Group** (e.g., Vegetables, Fruits, Meat)  
   - **Nutritional Values (per 100g)**:  
     - Energy (kcal)  
     - Fat (g)  
     - Carbohydrates (g)  
     - Proteins (g)  
     - Fiber (g)  
     - Salt (g)

3. **User Interface**:
   - **Clean design** with intuitive navigation.
   - **Tables/Forms** for food records and input.

4. **Additional Functionalities**:
   - **Search/Filter**: Based on food name, group, or nutritional values.  
   - **Validation**: Ensure correct data input for nutritional values.