/****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM Roles

ALTER TABLE Roles
ADD Status bit not null default 1;