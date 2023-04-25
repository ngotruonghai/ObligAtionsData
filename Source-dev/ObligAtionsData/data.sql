USE [ObligAtionsData]
GO
/****** Object:  Table [dbo].[Army]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Army](
	[ID] [int] IDENTITY(3,1) NOT NULL,
	[CMND] [varchar](20) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Army] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoObligAtion]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoObligAtion](
	[ID] [int] IDENTITY(2,1) NOT NULL,
	[FullnameBirth] [nvarchar](100) NULL,
	[FullnameCommon] [nvarchar](100) NULL,
	[Birthday] [date] NULL,
	[Sex] [int] NULL,
	[CMND] [varchar](30) NULL,
	[BirthRegistration] [nvarchar](200) NULL,
	[Countryside] [nvarchar](250) NULL,
	[Nation] [nvarchar](50) NULL,
	[Religion] [nchar](50) NULL,
	[Nationality] [nchar](50) NULL,
	[FamilyResidence] [nvarchar](350) NULL,
	[MyCurrentResidence] [nvarchar](350) NULL,
	[FamilyMember] [nvarchar](350) NULL,
	[Self] [nvarchar](350) NULL,
	[LearnLevel] [nvarchar](250) NULL,
	[GraduationYear] [int] NULL,
	[JobTrainingFields] [nvarchar](200) NULL,
	[EnglishLevel] [nvarchar](100) NULL,
	[CSVN] [date] NULL,
	[CSVNOfficial] [date] NULL,
	[TNCS] [date] NULL,
	[Bonus] [nvarchar](150) NULL,
	[Discipline] [nvarchar](150) NULL,
	[Job] [nvarchar](150) NULL,
	[Wage] [nvarchar](20) NULL,
	[Grade] [nchar](150) NULL,
	[JobLevel] [nvarchar](150) NULL,
	[PlaceWorkStudy] [nvarchar](300) NULL,
	[FatherFullName] [nvarchar](50) NULL,
	[FatherInformation] [bit] NULL,
	[FatherBirthDay] [datetime] NULL,
	[MotherFullName] [nvarchar](50) NULL,
	[Motherformations] [bit] NULL,
	[MotherBirthDay] [datetime] NULL,
	[WifeHusbandName] [nvarchar](150) NULL,
	[WifeHusband] [datetime] NULL,
	[WifeHusJob] [nvarchar](300) NULL,
	[WifeHusBaby] [bit] NULL,
	[FamilyBaby] [int] NULL,
	[FamilyNumber] [int] NULL,
	[CreateBy] [int] NULL,
	[UpdateBy] [varchar](50) NULL,
	[FatherJob] [nvarchar](300) NULL,
	[MotherJob] [nvarchar](300) NULL,
	[FamilyChildGrild] [int] NULL,
	[FamilyChildBoy] [int] NULL,
	[FamilySelf] [int] NULL,
 CONSTRAINT [PK_InfoObligAtion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfoUser]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfoUser](
	[ID] [int] IDENTITY(3,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[FullName] [nvarchar](30) NULL,
	[Status] [int] NULL,
	[Password] [varchar](20) NULL,
 CONSTRAINT [PK_InfoUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuItems]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Link] [varchar](50) NULL,
	[Status] [int] NULL,
	[Level] [int] NULL,
	[Parent] [int] NULL,
	[OrderBy] [int] NULL,
	[Key] [varchar](5) NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionUserMenuItems]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionUserMenuItems](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUserQueue] [int] NULL,
	[IDMenuItemQueue] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Army] ON 

INSERT [dbo].[Army] ([ID], [CMND], [Status]) VALUES (3, N'025781461', 1)
SET IDENTITY_INSERT [dbo].[Army] OFF
GO
SET IDENTITY_INSERT [dbo].[InfoObligAtion] ON 

INSERT [dbo].[InfoObligAtion] ([ID], [FullnameBirth], [FullnameCommon], [Birthday], [Sex], [CMND], [BirthRegistration], [Countryside], [Nation], [Religion], [Nationality], [FamilyResidence], [MyCurrentResidence], [FamilyMember], [Self], [LearnLevel], [GraduationYear], [JobTrainingFields], [EnglishLevel], [CSVN], [CSVNOfficial], [TNCS], [Bonus], [Discipline], [Job], [Wage], [Grade], [JobLevel], [PlaceWorkStudy], [FatherFullName], [FatherInformation], [FatherBirthDay], [MotherFullName], [Motherformations], [MotherBirthDay], [WifeHusbandName], [WifeHusband], [WifeHusJob], [WifeHusBaby], [FamilyBaby], [FamilyNumber], [CreateBy], [UpdateBy], [FatherJob], [MotherJob], [FamilyChildGrild], [FamilyChildBoy], [FamilySelf]) VALUES (2, N'Ngô Trường Hải', N'Ngô Trường Hải', CAST(N'1999-04-08' AS Date), 1, N'3', N'04/08/1999', N'VN', N'test', N'test                                              ', N'test                                              ', N'test', N'test', N'test', N'test', N'test', 1999, N'test', N'test', CAST(N'1999-04-08' AS Date), CAST(N'1999-04-08' AS Date), CAST(N'1999-04-08' AS Date), N'test', N'test', N'test', N'test', N'test                                                                                                                                                  ', N'test', N'test', N'test', 1, CAST(N'1999-04-08T00:00:00.000' AS DateTime), N'test', 1, CAST(N'1999-04-08T00:00:00.000' AS DateTime), N'test', CAST(N'1999-04-08T00:00:00.000' AS DateTime), N'test', 1, 5, 5, 3, N'0', N'test', N'test', 5, 6, 1)
SET IDENTITY_INSERT [dbo].[InfoObligAtion] OFF
GO
SET IDENTITY_INSERT [dbo].[InfoUser] ON 

INSERT [dbo].[InfoUser] ([ID], [UserName], [FullName], [Status], [Password]) VALUES (3, N'Admin', N'System Admin', 1, N'123')
SET IDENTITY_INSERT [dbo].[InfoUser] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON 

INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (1, N'Tạo User', N'/User/UserCreate', 1, 2, 2, 1, N'USC')
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (2, N'Quản lý User', NULL, 1, 1, 0, 1, NULL)
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (3, N'Quản lý quân dân tự vệ', NULL, 1, 1, 0, 2, NULL)
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (4, N'Thêm quan dân', NULL, 1, 2, 3, 1, N'AC')
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (5, N'Xóa quân dân', NULL, 1, 2, 3, 2, N'AD')
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (6, N'Xóa User', NULL, 1, 2, 2, 2, N'USD')
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (7, N'Xem thông tin User', N'/User/UserInfo', 1, 2, 2, 3, N'USI')
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (8, N'Phân quyền Menu', NULL, 1, 2, 2, 4, N'USU')
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (9, N'Quản lý nghĩa vụ quân sự', NULL, 1, 1, 0, 3, NULL)
INSERT [dbo].[MenuItems] ([ID], [Name], [Link], [Status], [Level], [Parent], [OrderBy], [Key]) VALUES (10, N'Thêm quân sự', N'/Military/MilitaryCreate', 1, 2, 9, 1, N'AUSC')
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[PermissionUserMenuItems] ON 

INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (1, 3, 2, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (2, 3, 8, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (3, 3, 7, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (4, 3, 1, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (5, 3, 6, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (6, 3, 4, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (7, 3, 3, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (8, 3, 5, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (9, 3, 10, 1)
INSERT [dbo].[PermissionUserMenuItems] ([ID], [IDUserQueue], [IDMenuItemQueue], [Status]) VALUES (10, 3, 9, 1)
SET IDENTITY_INSERT [dbo].[PermissionUserMenuItems] OFF
GO
/****** Object:  StoredProcedure [dbo].[CheckInfoUser]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*  
 CreateBy: HaiNT126  
 CreateDate: 27/03/2023  
 Desc: Lấy thông tin User  
*/  
CREATE PROC [dbo].[CheckInfoUser]  
@UserName varchar(20),  
@Password varchar(20)  
AS  
BEGIN  
 SELECT * FROM InfoUser(NOLOCK) WHERE Status=1 AND UserName=@UserName  and Password=@Password
END
GO
/****** Object:  StoredProcedure [dbo].[CreatePermissionUserMenuItems]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CreatePermissionUserMenuItems] 
@UserID int, 
@MenuID int, 
@ParentID int,
@Flang int 
AS 
BEGIN 
DECLARE @IDParent int, @CountL2 INT,@CountL1 INT

	--Level 2
	 if(@Flang=1) 
	 BEGIN
		IF NOT exists(select*from PermissionUserMenuItems(nolock) where IDUserQueue=@UserID AND IDMenuItemQueue=@MenuID )
		BEGIN
			 INSERT INTO [dbo].[PermissionUserMenuItems] ([IDUserQueue] , [IDMenuItemQueue] , [Status])
			 VALUES (@UserID,@MenuID,1) 
		END 
	END

	ELSE
	BEGIN
		 DELETE PermissionUserMenuItems
			WHERE IDUserQueue=@UserID
			AND IDMenuItemQueue=@MenuID 
	END

	--return
	--Level 1
	SELECT @CountL2=Count(*) FROM(SELECT*FROM PermissionUserMenuItems(NOLOCK) WHERE IDUserQueue=@UserID ) as a
	INNER JOIN (SELECT*FROM MenuItems(NOLOCK) WHERE status=1 and level=2 and Parent= @ParentID) as b on a.IDMenuItemQueue=b.ID
	
	SELECT @CountL1=Count(*) FROM(SELECT*FROM PermissionUserMenuItems(NOLOCK) WHERE IDUserQueue=@UserID) as a
	INNER JOIN (SELECT*FROM MenuItems(NOLOCK) WHERE status=1 and level=1 and id=@ParentID ) as b on a.IDMenuItemQueue=b.ID

	SELECT @IDParent=parent FROM MenuItems(NOLOCK) WHERE status=1 and level=2 and ID=@MenuID

	SELECT @CountL1,@CountL2
	

	IF(@Flang=1)
	BEGIN
		if(@CountL1=0)
		BEGIN
			INSERT INTO [dbo].[PermissionUserMenuItems] ([IDUserQueue] , [IDMenuItemQueue] , [Status])
			 VALUES (@UserID,@IDParent,1)
		END
	END
	ELSE
	BEGIN
		if(@CountL2=0)
		BEGIN
			--SELECT @UserID,@IDParent
			DELETE PermissionUserMenuItems
			WHERE IDUserQueue=@UserID
			AND IDMenuItemQueue=@IDParent 
		END
	END
 END
GO
/****** Object:  StoredProcedure [dbo].[CreateUserInfo]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	DESC: Thêm một User
*/
CREATE proc [dbo].[CreateUserInfo]
@UserName VARCHAR(20),
@FullName NVARCHAR(100)
AS
BEGIN 
declare @UserID int
SELECT @UserID=ID FROM InfoUser(NOLOCK) WHERE UserName=@UserName AND FullName=@FullName AND [Password]='1234567890'

IF(@UserID>0)
BEGIN 
	UPDATE InfoUser SET Status=1 WHERE ID=@UserID
END

ELSE
BEGIN
	INSERT INTO [dbo].[InfoUser]
           ([UserName]
           ,[FullName]
           ,[Status]
           ,[Password])
     VALUES
           (@UserName
           ,@FullName
           ,1
           ,'1234567890')
END
END
GO
/****** Object:  StoredProcedure [dbo].[GetCheckUserMenuItems]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetCheckUserMenuItems]
@UserID int
as
begin
SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=1
SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=2
select b.*from (select*from PermissionUserMenuItems(nolock) where IDUserQueue=@UserID) as a
inner join (select*from MenuItems(NOLOCK) WHERE STATUS=1 AND level=2) as b on b.id=a.IDMenuItemQueue
end
GO
/****** Object:  StoredProcedure [dbo].[GetInfoUser]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	CreateBy: HaiNT126
	CreateDate: 27/03/2023
	Desc: Lấy thông tin User
*/
CREATE PROC [dbo].[GetInfoUser]
AS
BEGIN
	SELECT * FROM InfoUser(NOLOCK) WHERE Status=1
END
GO
/****** Object:  StoredProcedure [dbo].[GetMenuItems]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**/      
CREATE PROC [dbo].[GetMenuItems]      
@UserID INT      
AS      
BEGIN      
--SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=1    
--SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=2    
--return    
IF(@UserID=0)
BEGIN
SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=1
SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=2
RETURN
END

SELECT C.*FROM(SELECT*FROM InfoUser(NOLOCK) WHERE ID=@UserID) AS A    
INNER JOIN(SELECT * FROM PermissionUserMenuItems(NOLOCK) WHERE STATUS=1) AS B ON A.ID = B.IDUserQueue    
INNER JOIN(SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=1) AS C ON C.ID = B.IDMenuItemQueue    
ORDER BY C.Orderby    
    
    
SELECT C.*FROM(SELECT*FROM InfoUser(NOLOCK) WHERE ID=@UserID) AS A    
INNER JOIN(SELECT * FROM PermissionUserMenuItems(NOLOCK) WHERE STATUS=1) AS B ON A.ID = B.IDUserQueue    
INNER JOIN(SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND level=2) AS C ON C.ID = B.IDMenuItemQueue    
ORDER BY C.Orderby    
END
GO
/****** Object:  StoredProcedure [dbo].[GetPermissionMenuUser]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
	DESC: lấy danh sách key, phân quyền thực thi API
*/
CREATE PROC [dbo].[GetPermissionMenuUser]
@UserName VARCHAR(20),
@Password VARCHAR(20)
AS
BEGIN
Declare @UserID INT
SELECT TOP(1) @UserID=ID  FROM InfoUser(NOLOCK) WHERE UserName=@UserName AND Password=@Password
SELECT B.* FROM (SELECT*FROM PermissionUserMenuItems(NOLOCK) WHERE IDUserQueue=@UserID) AS A
INNER JOIN (SELECT*FROM MenuItems(NOLOCK) WHERE STATUS=1 AND LEVEL=2) AS B ON B.ID=A.IDMenuItemQueue
END
GO
/****** Object:  StoredProcedure [dbo].[InfoObligAtionView]    Script Date: 4/3/2023 9:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InfoObligAtionView]
as
begin
select a.* from (select*from InfoObligAtion) as a
inner join (select*from Army(nolock) where status=1) as b on b.ID=a.CMND
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên khai sinh' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FullnameBirth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên thường dùng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FullnameCommon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày tháng năm sinh' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Giới tính 0: Name 1:Nữ 3:khác' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Số CMND hoặc Số thẻ căn cước' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'CMND'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nơi đăng ký khai sinh' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'BirthRegistration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quê quán' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Countryside'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dân Tộc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Nation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tôn giáo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Religion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quốc tịch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Nationality'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nơi ở của gia đình' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilyResidence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nơi ở hiện tại của bản thân' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'MyCurrentResidence'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Thành phần gia đình' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilyMember'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bản thân' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Self'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trình độ học vấn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'LearnLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Năm tốt nghiệp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'GraduationYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngành nghề đào tạo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'JobTrainingFields'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Trình độ ngoại ngữ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'EnglishLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày vào đảng CSVN' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'CSVN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày vào đảng CSVN chính thức' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'CSVNOfficial'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngày vào Đoàn TNCS Hồ Chí Minh' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'TNCS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Khen thưởng ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Bonus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kỹ luật' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Discipline'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lương' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Wage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngạch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Grade'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cấp bậc công việc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'JobLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nơi làm việc (học tập)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'PlaceWorkStudy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên cha' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FatherFullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tình trạng của cha 0: sống 1: chết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FatherInformation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên mẹ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'MotherFullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tình trạng của mẹ 0: sống 1: chết' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'Motherformations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Họ tên vợ chồng' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'WifeHusbandName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vợ chồng sinh năm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'WifeHusband'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'bản thân có mấy con' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilyBaby'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gia đình có mấy con' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilyNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gia đình có mấy người con gái' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilyChildGrild'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gia đình có mấy người con trai' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilyChildBoy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bản thân là con thứ mấy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InfoObligAtion', @level2type=N'COLUMN',@level2name=N'FamilySelf'
GO
