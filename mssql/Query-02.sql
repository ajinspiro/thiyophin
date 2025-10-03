SELECT * from Test;
ALTER TABLE Test ADD Gender varchar(1);
ALTER TABLE Test DROP COLUMN Gender;
ALTER TABLE Test ADD Gender varchar(1) CONSTRAINT MaleByDefault DEFAULT 'M';
INSERT INTO Test (Id, Name, BankBalance) values(104, 'Harbajan', 121212);
ALTER TABLE Test DROP CONSTRAINT DF__Test__Gender__48CFD27E;
UPDATE Test SET Gender='M' WHERE Gender is NULL;