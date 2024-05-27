CREATE DATABASE IF NOT EXISTS BarCocktail;
USE BarCocktail;

CREATE TABLE RECETTE
(
    recetteId INT PRIMARY KEY auto_increment NOT NULL,
    recetteQuantite double not null,
    liquideId int not null,
    cocktailId int not null,
    FOREIGN KEY (liquideId) REFERENCES LIQUIDES(liquideId),
    FOREIGN KEY (cocktailId) REFERENCES COCKTAILS(cocktailId)
);

CREATE TABLE LIQUIDES
(
    liquideId INT PRIMARY KEY auto_increment NOT NULL,
    liquideNom VARCHAR(30) not null,
    liquideType VARCHAR(15) not null
);

CREATE TABLE COCKTAILS
(
    cocktailId INT PRIMARY KEY auto_increment NOT NULL,
    cocktailNom varchar(30) not null
);

-- Ajout de liquides supplémentaires
INSERT INTO LIQUIDES (liquideNom, liquideType) VALUES
('Vodka', 'Alcool'),
('Rhum blanc', 'Alcool'),
('Whisky', 'Alcool'),
('Tequila', 'Alcool'),
('Cointreau', 'Alcool'),
('Gin', 'Alcool'),
('Jus de citron', 'Jus'),
('Jus ananas', 'Jus'),
('Cranberry', 'Jus'),
('Limonade', 'Soda'),
('Grenadine', 'Sirop'),
('Lait de coco', 'Lait');

-- Ajout de cocktails supplémentaires
INSERT INTO COCKTAILS (cocktailNom) VALUES
('Cosmopolitan'),
('Long Island Iced Tea'),
('Whisky Sour'),
('Tequila Sunrise'),
('Gin Tonic');


select * from cocktails;
select * from liquides;