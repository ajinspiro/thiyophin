SELECT * FROM Contacts;
SELECT * FROM ContactGroups;

-- add new column to Contacts table 'ContactGroupId'
ALTER TABLE Contacts ADD ContactGroupId int;
UPDATE Contacts SET ContactGroupId=12 WHERE [Family, Workspace]='Family';
UPDATE Contacts SET ContactGroupId=13 WHERE [Family, Workspace]='Workspace';
ALTER TABLE Contacts DROP COLUMN [Family, Workspace];
UPDATE Contacts set contactgroupid=22 where contactgroupid=13;
UPDATE Contacts set contactgroupid=13 where contactgroupid=22;
ALTER TABLE Contacts ADD CONSTRAINT fk_contacts_groups foreign key (ContactGroupId) references ContactGroups(Id);
ALTER TABLE Contacts DROP CONSTRAINT fk_contacts_groups;
SELECT Contacts.Id, Contacts.Name, Contacts.ContactNumber, ContactGroups.Name as ContactName FROM Contacts JOIN ContactGroups ON Contacts.ContactGroupId=ContactGroups.Id;