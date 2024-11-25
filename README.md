# ITPE3200 - Group Exam

### Useful Commands
Update Migrations:
```dotnet ef migrations add <MigrationName>``` <br />

## Project Requirements
* Sub-application 1: the front-end and back-end should use the Model-View-Controller framework of ASP.NET 8.0
* Sub-application 2: the backend should be .NET 8.0 (can reuse that from Sub-application 1), and the front-end should use a front-end framework with AJAX call (e.g., React).
* A short documentation of 2000-5000 words (in English) must be written, which should include some diagrams for the software architecture and database (here is a document for inspiration).

## Web Application Requirements - Web-based Food Registration Tool

### User Experience
- [ ] Basic design, not plain text and bare buttons
- [ ] Dynamic content
- [ ] Friendly navigation
- [ ] User experience is clear and meets normal task expectations

### Coding Style and Documentation
- [ ] Neat, structured, and modularised code
- [ ] Code is self-explanatory or has suitable comments (in English)
- [ ] No warnings or bugs (verified with `dotnet build`)

### Functionality
- [ ] Database operations with at least 2 types of entity (including views and CRUD)
- [ ] Repository pattern and Data Access Layer (DAL)
- [ ] Asynchronous database access
- [ ] Forms and input validation (server-side)
- [ ] Error handling and logging (server-side)
- [ ] Authentication and authorisation (server-side)
- [ ] Unit testing (server-side), including:
  - [ ] At least 8 unit tests
  - [ ] Complete positive tests for CRUD methods of 1 entity/table
  - [ ] Complete negative tests for CRUD methods of 1 entity/table


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
