
CREATE TABLE Brands
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Ingredients
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(300)
);

CREATE TABLE Products
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Category NVARCHAR(100),
    Price DECIMAL(10,2),
    BrandId INT NOT NULL,

    CONSTRAINT FK_Products_Brands
    FOREIGN KEY (BrandId) REFERENCES Brands(Id)
);

-- Sample brands
INSERT INTO Brands (Name)
VALUES
('Glow Essentials'),
('Pure Botanics'),
('Skin Harmony');

-- Sample ingredients
INSERT INTO Ingredients (Name, Description)
VALUES
('Niacinamide', 'Ingredient commonly used in skincare formulations'),
('Hyaluronic Acid', 'Ingredient used in hydrating skincare products'),
('Salicylic Acid', 'Ingredient commonly used in acne-focused products'),
('Glycerin', 'Humectant used to help retain moisture');

-- Sample products
INSERT INTO Products (Name, Category, Price, BrandId)
VALUES
('Gentle Face Wash', 'Cleanser', 850, 1),
('Daily Moisturizer', 'Moisturizer', 950, 2),
('Hydrating Serum', 'Serum', 650, 3),
('Daily Sunscreen', 'Sunscreen', 1000, 1),
('Salicylic Face Wash', 'Cleanser', 750, 2);
