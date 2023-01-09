
--CREATE TABLE ingredients
CREATE TABLE [ingredients] (
	[id] smallint NOT NULL IDENTITY(1,1),
        [name] nvarchar (30) NOT NULL UNIQUE,
        [image] nvarchar (1000) NOT NULL,
		[calories] smallint NOT NULL,
	PRIMARY KEY(id)
)

select * From [ingredients]
 



--CREATE TABLE recipes
CREATE TABLE [recipes] (
	[id] smallint NOT NULL IDENTITY(1,1),
        [name] nvarchar (30) NOT NULL,
        [image] nvarchar (1000) NOT NULL,
		[cookingMethod] nvarchar (30) NOT NULL,
		[time] smallint NOT NULL,
	PRIMARY KEY(id)
)

select * From [recipes]

DELETE FROM [recipes] WHERE [id] = 15

--CREATE TABLE ingredients In Recipes
CREATE TABLE [ingredientsInRecipes] (
	recipeId smallint FOREIGN KEY REFERENCES [recipes](id) NOT NULL,
	ingredientId smallint FOREIGN KEY REFERENCES [ingredients](id) NOT NULL,
)

select * From [ingredientsInRecipes]

DELETE FROM [ingredientsInRecipes] WHERE recipeId = 13


