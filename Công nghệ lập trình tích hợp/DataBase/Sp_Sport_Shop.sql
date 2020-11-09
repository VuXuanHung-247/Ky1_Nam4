use SPORT_SHOP
go

create proc sp_brand_add
(
   @brandName nvarchar(50),
   @brandURL nvarchar(200),
   @createdDate date
)
AS
BEGIN
    DECLARE @temp INT, @i INT
	IF((SELECT COUNT(BrandID) FROM BRAND)=0)
	SET @temp =0
	ELSE 
	SET @temp = (SELECT MAX(CAST(BrandID AS INT)) FROM BRAND)
	SET @temp = @temp +1
	SET @i = @temp
	SET IDENTITY_INSERT BRAND on
	INSERT INTO BRAND(BrandID, BrandName, BrandURL, CreatedDate)
	VALUES (@i,@brandName,@brandURL,@createdDate)
	SET IDENTITY_INSERT BRAND off
END
GO
EXEC sp_brand_add N'Bóng đá','','2020-10-20'
GO