use SPORT_SHOP
go
go
-----------------CATEGORY
-----------------CATEGORY_LIST
select*from CATEGORY
go
-----------------CATEGORY_ADD
create proc sp_category_add
(
   @categoryName nvarchar(50),
   @categoryURL nvarchar(200),
   @createdDate date
)
AS
BEGIN
    DECLARE @temp INT, @i INT
	IF((SELECT COUNT(CategoryID) FROM CATEGORY)=0)
	SET @temp =0
	ELSE 
	SET @temp = (SELECT MAX(CAST(CategoryID AS INT)) FROM CATEGORY)
	SET @temp = @temp +1
	SET @i = @temp
	SET IDENTITY_INSERT CATEGORY on
	INSERT INTO CATEGORY(CategoryID, CategoryName, CategoryURL, CreatedDate)
	VALUES (@i,@categoryName,@categoryURL,@createdDate)
	SET IDENTITY_INSERT CATEGORY off
END
GO
EXEC sp_category_add N'Bóng rổ','','2020-10-20'
GO