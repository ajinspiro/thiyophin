SELECT * FROM ContactGroups;
SELECT * FROM Contacts;
CREATE TABLE ContactGroup (Id int primary key identity(1,1), Name varchar(10));
INSERT INTO ContactGroup values('Family'), ('Workspace'), ('School');
DELETE FROM ContactGroups;
CREATE PROCEDURE AddGroup AS
BEGIN
    INSERT INTO ContactGroups values('Family'), ('Workspace'), ('School');
END;

EXEC AddGroup;

DROP PROCEDURE AddGroup;

CREATE PROCEDURE AddGroup
    @GroupName varchar(10)
AS
BEGIN
    INSERT INTO ContactGroups values(@GroupName);
END;

EXEC AddGroup 'Family';

EXEC AddGroup 'Workspace';

EXEC sp_rename 'ContactGroup', 'ContactGroups';