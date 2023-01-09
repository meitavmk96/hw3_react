-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Lin&Meitav>
-- Create date: <02-01-2022>
-- Description:	<Description>
-- =============================================

CREATE PROCEDURE spReadRecipeIngredient
	@recipeId smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT [id], [name], [image],[calories]
    FROM [ingredientsInRecipes] INNER JOIN [ingredients]
    ON [ingredientsInRecipes].[ingredientId] = [ingredients].[id] 
    WHERE [ingredientsInRecipes].[recipeId] = @recipeId
END
GO

--check procedure
exec spReadRecipeIngredient 2
