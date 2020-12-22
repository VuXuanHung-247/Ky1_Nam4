use SPORT_SHOP
go
go
-----------------CATEGORY-----------------
-----------------CATEGORY_LIST-----------------
select * from CATEGORY
go
-----------------CATEGORY_ADD-----------------
alter proc sp_category_add
(
   @categoryName nvarchar(50),
   @categoryURL nvarchar(200),
   @createdDate datetime
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
EXEC sp_category_add N'Bóng tenis','','2020-10-20'
GO
-----------------CATEGORY_UPDATE-----------------
create proc sp_category_update 
(
   @categoryID int,
   @categoryName nvarchar(50),
   @categoryURL nvarchar(200),
   @createdDate datetime
)as
begin 
    update CATEGORY
	set CategoryName = @categoryName,
		CategoryURL = @categoryURL,
		CreatedDate = @createdDate
	where CategoryID = @categoryID
end
go
exec sp_category_update 1,N'Bóng đá',N'New','2020-10-20'
GO
-----------------CATEGORY_DELETE-----------------
create proc sp_category_delete 
(
   @categoryID int
)as
begin
    delete from PRODUCT where CategoryID = @categoryID
	delete from CATEGORY  where CategoryID = @categoryID
end
go
exec sp_category_delete 10
GO
-----------------CATEGORY_SEARCH_BY_Name_&_CreateDate-----------------
create PROCEDURE sp_category_search 
(
    @categoryName nvarchar(50),
	@createdDate datetime	
) as
begin
    select CategoryID, CategoryName,CreatedDate , CategoryURL
    from
        CATEGORY 
    where
        (@categoryName IS NULL OR CategoryName like '%'+@categoryName+'%')
		AND (@createdDate IS NULL OR CreatedDate = @createdDate)
end
go
EXEC sp_category_search N'Bóng','2020-10-20'