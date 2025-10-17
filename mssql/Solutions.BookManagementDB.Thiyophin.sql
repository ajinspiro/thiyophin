-- Task 1
use BookStoreDb;
CREATE TABLE Authors (Id int primary key, Name varchar(100), Country varchar(100), BirthYear int);
-- Drop table Authors;
-- SELECT * from Authors;

-- Task 2
CREATE TABLE Books (Id int primary key, Title varchar(100), AuthorId int, PublishedDate date, Price decimal(10,2), IsAvailable bit);
-- SELECT * from Books;
ALTER TABLE Books ADD CONSTRAINT fk_authors_id foreign key (AuthorId) references Authors(Id);
-- Alter table Books Drop constraint fk_authors_id;

-- Task 3
Insert into Authors values (1,'R.K. Nair','India',1975);
Insert into Authors values(2, 'A.P.J.Abdul Kalam','India',1931);
Insert into Authors values(3, 'Arthur Conan Doyle','United Kingdom',1859);
Insert into Authors values(4, 'Anita Desai','India',1937);
Insert into Authors values(5,'Meena Rao','India',1980);

-- Task 4
Insert into Books values(1,'The Silent River',1,'2010-05-11',450.75,1);
Insert into Books values(2,'Wings of Fire',2,'2000-09-15',300.00,1);
Insert into Books values(3, 'The Lost World', 3, '1995-11-12', 250.00, 0);
Insert into Books values(4, 'Into the Forest', 4, '2018-03-22', 520.00, 1);
Insert into Books values(5, 'Data Science Simplified', 5, '2022-10-10', 890.25, 1);
Insert into Books values(6, 'Sherlock Holmes Returns', 3, '2005-04-15', 600.50, 1);

-- Task 5
SELECT Books.Id, Books.TItle, Books.PublishedDate, Books.Price, Books.IsAvailable, Authors.Name as AuthorName, Authors.Country as AuthorCountry From Books Join Authors on Books.AuthorId=Authors.Id;
SELECT Authors.Name as AuthorName, COUNT(Authors.Name) as NumberBooksWrote From Books Join Authors on Books.AuthorId=Authors.Id Group By Authors.Name Having COUNT(Authors.Name) > 1;
SELECT Authors.Name as AuthorName, COUNT(Authors.Name) as NumberBooksWrote From Books Join Authors on Books.AuthorId=Authors.Id Group By Authors.Name;
Select AVG(Price) as AveragePriceAfter2010 from Books where Year(PublishedDate) > 2010;

-- Task 6
ALTER TABLE Books ADD Genre varchar(100);
Update Books set Genre='Fiction' where Id=1;
Update Books set Genre='Biography' where Id=2;
Update Books set Genre='Adventure' where Id=3;
Update Books set Genre='Fiction' where Id=4;
Update Books set Genre='Education' where Id=5;
Update Books set Genre='Mystery' where Id=6;

-- Task 7
ALTER TABLE Books ADD Rating decimal(3,2);
Update Books set Rating=4.3 where Id=1;
Update Books set Rating=4.8 where Id=2;
Update Books set Rating=4.1 where Id=3;
Update Books set Rating=3.9 where Id=4;
Update Books set Rating=4.7 where Id=5;
Update Books set Rating=4.5 where Id=6;

-- Task 8
SELECT Top(3) * from Books order by rating Desc;
Select avg(Rating) as AverageRatingPerGenre, Genre from Books GROUP BY Genre;
SELECT sum(Price) as TotalPriceOfBooksFromIndia from Books join Authors on Books.AuthorId=Authors.Id where Authors.Country='India';
Select Title, Rating, IsAvailable from Books where IsAvailable=1 and Rating >= 4.5;


-- Task 9
ALTER TABLE Books ADD DiscountPercent decimal(5,2);
UPDATE Books set DiscountPercent=15 where Price>500;
UPDATE Books set DiscountPercent=5 where Price<=500;
Alter TABLE Books ADD FinalPrice decimal(5,2);
UPDATE Books set FinalPrice=(Price-(Price * DiscountPercent/100))

-- Task 10
Select Title, Price, DiscountPercent, FinalPrice from Books;
Select sum(FinalPrice) as SumOfFinalPriceGroupedByGenre, avg(FinalPrice) as AvgOfFinalPriceGroupedByGenre from Books GROUP BY Genre;
DELETE from Books where Rating<4.0 or IsAvailable=0;
SELECT * from Books;