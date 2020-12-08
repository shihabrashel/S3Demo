Create database S3Db
Go
Use S3Db
Go
--drop table Building
Create table Building(
Id smallint primary key Identity(1,1),
Name varchar(50) not null,
Location varchar(50)
)
Go
--drop table [Object]
Create table [Object](
Id tinyint primary key Identity(1,1),
Name varchar(50) not null
)
Go
--drop table DataField
Create table DataField(
Id tinyint primary key Identity(1,1),
Name varchar(50) not null
)
Go
--drop table Reading
Create table Reading(
BuildingId smallint not null foreign key REFERENCES Building(Id),
ObjectId tinyint not null foreign key REFERENCES [Object](Id),
DataFieldId tinyint not null foreign key REFERENCES DataField(Id),
[Value] Decimal(18,2) not null,
[Timestamp] datetime not null
)
Go
Create Clustered index CI_Reading_BuildingId on dbo.Reading(BuildingId)
Go

Create procedure GetBuildingData
As
Begin
	Set NOCOUNT ON
	Select Id,[Name] from dbo.Building
	Set NOCOUNT OFF
End
Go
Create procedure GetObjectData
As
Begin
	Set NOCOUNT ON
	Select Id,[Name] from dbo.[Object]
	Set NOCOUNT OFF
End
Go
Create procedure GetDataFields
As
Begin
	Set NOCOUNT ON
	Select Id,[Name] from dbo.DataField
	Set NOCOUNT OFF
End
Go
Alter procedure GetReadingData 
(
	@buildingId smallint,
	@objectId tinyint,
	@dataFieldId tinyint,
	@startDate datetime,
	@endDate datetime
)
As
--exec GetReadingData 1,11,3,'2020-12-08','2020-12-09'
Begin
	Set NOCOUNT ON
	Select [Value],FORMAT([Timestamp],'hh') as [Timestamp] from dbo.Reading
	where BuildingId=@buildingId
	and ObjectId=@objectId
	and @dataFieldId=@dataFieldId
	and Timestamp between @startDate and @endDate
	Set NOCOUNT OFF
End
Go
Insert into dbo.Building values('Test','Test')
Go
Insert into dbo.[Object] values('Test')
Go
Insert into dbo.DataField values('Test')
Go

Alter procedure LoadBuildingData
As
Begin
	Set NOCOUNT ON
	Declare @Id int
	Set @Id = 1

	While(@Id <= 100)
	Begin
		 Insert into dbo.Building values('Building - ' + CAST(@Id as nvarchar(20)),'Building - ' + CAST(@Id as nvarchar(20))+' - Location') 
		 Set @Id = @Id + 1
	End
	Set NOCOUNT OFF
End

Select * from Building

Alter procedure LoadObjectData
As
Begin
	Set NOCOUNT ON
	Declare @Id int
	Set @Id = 1

	While(@Id <= 20)
	Begin
		 Insert into dbo.[Object] values('Object - ' + CAST(@Id as nvarchar(20)))
		 Set @Id = @Id + 1
	End
	Set NOCOUNT OF
End

Select * from [Object]

Alter procedure LoadDataFieldData
As
Begin
	Set NOCOUNT ON
	Declare @Id int
	Set @Id = 1

	While(@Id <= 20)
	Begin
		 Insert into dbo.DataField values('Data Field - ' + CAST(@Id as nvarchar(20)))
		 Set @Id = @Id + 1
	End
	Set NOCOUNT OFF
End

Select * from dbo.DataField
Select * from Reading
truncate table Reading

Alter procedure LoadReadingData
As
Begin
	Set NOCOUNT ON
	declare @minBuildingId int=(Select MIN(Id) from dbo.Building)
	declare @maxBuildingId int=(Select Max(Id) from dbo.Building)

	declare @objectId int=0;
	declare @dataFieldId int=0;
	declare @value int=0;

	declare @lowerLimitForObject int=1;
	declare @upperLimitForObject int=20;

	declare @lowerLimitForDataField int=1;
	declare @upperLimitForDataField int=20;

	declare @lowerLimitForValue int=1;
	declare @upperLimitForValue int=20;

	declare @timeStamp Datetime=GetDate();

	declare @minRow int=1;
	declare @maxRow int=10512000;

	while(@minBuildingId<=@maxBuildingId)
	Begin
		IF EXISTS(Select * from dbo.Building where Id=@maxBuildingId)
		set @timeStamp=GetDate();
		set @minRow=1;
		Begin
			while(@minRow<=@maxRow)
			Begin
				select @objectId = Round(((@upperLimitForObject - @lowerLimitForObject) * Rand() + @lowerLimitForObject), 0)
				select @dataFieldId = Round(((@upperLimitForDataField - @lowerLimitForDataField) * Rand() + @lowerLimitForDataField), 0)
				select @value = Round(((@upperLimitForValue - @lowerLimitForValue) * Rand() + @lowerLimitForValue), 0)
				Insert into dbo.Reading values (@maxBuildingId,@objectId,@dataFieldId,@value,@timeStamp);
				set @timeStamp=(SELECT DATEADD(mi, -1,   @timeStamp));
				set @minRow=@minRow+1;
			End
		
		End
		set @maxBuildingId=@maxBuildingId-1;
		print(@maxBuildingId)
	End
	Set NOCOUNT OFF
End
