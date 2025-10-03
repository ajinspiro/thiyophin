In SQL (and specifically in SQL Server), a **constraint** is a rule you apply to a table column (or set of columns) to enforce data integrity — basically to control what kind of data can go into the table.

Think of it as **guardrails** on your database.

---

### 🔑 Common Types of Constraints in SQL Server

1. **PRIMARY KEY**

   * Ensures each row is unique and not null.
   * Usually the main identifier of a row.

   ```sql
   CREATE TABLE Users (
       UserID INT PRIMARY KEY,
       Name NVARCHAR(100)
   );
   ```

2. **FOREIGN KEY**

   * Ensures that a column’s value exists in another table (relationship).

   ```sql
   CREATE TABLE Orders (
       OrderID INT PRIMARY KEY,
       UserID INT FOREIGN KEY REFERENCES Users(UserID)
   );
   ```

3. **UNIQUE**

   * Ensures all values in a column are unique (but allows one `NULL` by default).

   ```sql
   ALTER TABLE Users ADD CONSTRAINT UQ_Users_Email UNIQUE (Email);
   ```

4. **CHECK**

   * Ensures values satisfy a condition.

   ```sql
   ALTER TABLE Users 
   ADD CONSTRAINT CK_Users_Age CHECK (Age >= 18);
   ```

5. **DEFAULT**

   * Provides a default value if none is supplied.

   ```sql
   ALTER TABLE Users
   ADD CONSTRAINT DF_Users_Status DEFAULT 'Active' FOR Status;
   ```

6. **NOT NULL**

   * Ensures a column can’t store `NULL`.

   ```sql
   ALTER TABLE Users
   ALTER COLUMN Name NVARCHAR(100) NOT NULL;
   ```

---

### ⚡ Why Constraints Matter

* Prevent invalid data (e.g., negative age, duplicate emails).
* Preserve relationships (e.g., don’t allow orders for non-existing users).
* Keep your database **reliable and consistent**.

---
