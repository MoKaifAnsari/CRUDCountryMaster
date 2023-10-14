USE [DBCruedMaster]
GO
/****** Object:  Table [dbo].[tbl_CountryMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CountryMaster](
	[Countryid] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [varchar](50) NULL,
	[CountryName] [varchar](100) NULL,
	[IsActive] [bit] NULL,
	[State] [bit] NULL,
	[Pincode] [bit] NULL,
 CONSTRAINT [PK__tbl_Coun__10CE6F87614CCF1E] PRIMARY KEY CLUSTERED 
(
	[Countryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_StateMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_StateMaster](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](100) NULL,
	[StateCode] [varchar](100) NULL,
	[StateName] [varchar](100) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_CountryMaster] ON 
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (3, N'UK', N'United Kingdom', 0, 1, 0)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (4, N'CA', N'Canada', 1, 0, 1)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (22, N'PAK', N'Pakistan', 1, 0, 1)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (32, N'AU', N'Austreliya', 0, 1, 0)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (33, N'UAE', N'Dubai', 1, 0, 1)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (39, N'JP', N'Japan', 1, 0, 1)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (40, N'In', N'India', 1, 0, 1)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (41, N'Am', N'America', 1, 1, 1)
GO
INSERT [dbo].[tbl_CountryMaster] ([Countryid], [CountryCode], [CountryName], [IsActive], [State], [Pincode]) VALUES (42, N'SAB', N'Saudy Arabiya', 0, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_CountryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_StateMaster] ON 
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (4, N'Dubai', N'987', N'Hamam', 1)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (7, N'Austreliya', N'AUE', N'Sidany', 1)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (11, N'Japan', N'jp', N'Bhutan', 0)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (20, N'India', N'123001', N'Uttar Pradesh', 0)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (21, N'Pakistan ', N'098722', N'Mumbai', 0)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (23, N'America', N'15#55', N'Swedan', 1)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (25, N'Saudy Arabiya', N'JD', N'Jadda', 1)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (28, N'India ', N'200012', N'Lucknow', 0)
GO
INSERT [dbo].[tbl_StateMaster] ([StateId], [Country], [StateCode], [StateName], [IsActive]) VALUES (29, N'India', N'12432', N'Delhi', 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_StateMaster] OFF
GO
/****** Object:  StoredProcedure [dbo].[DeleteCountryMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteCountryMaster]
@Countryid int=0
as
begin
Declare @Msg varchar(Max)='',@Focus Varchar(100)=''  
 delete from tbl_CountryMaster where Countryid=@Countryid
 Set @Msg='State has been Deletes successfully.'  
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteStateMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteStateMaster]
@StateId int=0
as
begin
Declare @Msg varchar(Max)='',@Focus Varchar(100)='' 
delete from tbl_StateMaster where StateId=@StateId
Set @Msg='State has been Deletes successfully.' 
end
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateCountryMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertUpdateCountryMaster]
@Countryid int=0,
@CountryCode varchar(20),
@CountryName varchar(100),
@IsActive bit,
@State bit,
@Pincode bit
as  
begin  
 Declare @Msg varchar(Max)='',@Focus Varchar(100)='', @Status int=0  
 if @Countryid=0
 begin
 insert into tbl_CountryMaster(CountryCode,CountryName,IsActive,State,Pincode) values(@CountryCode,@CountryName,@IsActive,@State,@Pincode)
 Set @Msg='data has been saved successfully.'  
     Set @Status=1  
    end 
 else
 begin
 update tbl_CountryMaster set CountryCode=@CountryCode,CountryName=@CountryName,IsActive=@IsActive,State=@State,Pincode=@Pincode where Countryid=@Countryid
Set @Msg='Date has been Update successfully.'  
    Set @Status=2  
    end    
   select @Msg As Msg,@Focus As Focus,@Status As [Status]  
end
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateStateMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertUpdateStateMaster]  
 @StateId int,  
 @Country varchar(50),  
 @StateCode varchar(10),  
 @StateName varchar(100),  
 @IsActive bit  
as  
begin  
 Declare @Msg varchar(Max)='',@Focus Varchar(100)='', @Status int=0 
   IF Exists(Select StateID From tbl_StateMaster Where StateCode=@StateCode And StateID<>@StateID)  
   Begin  
 Set @Msg='State Code Already Exist'  
 Set @Focus='txtStateCode'  
   End  
   Else IF Exists(Select StateId From tbl_StateMaster Where StateName=@StateName And StateId<>@StateId)  
   Begin  
 Set @Msg='State Name Already Exist'  
 Set @Focus='txtStateName'  
   End  
   Else IF not Exists(Select Countryid from tbl_CountryMaster where CountryName=@Country And IsActive=@IsActive)  
   begin  
  Set @Msg='Enter Valid Country'  
  Set @Focus='txtCountry'  
   end  
   else  
   begin
 if (@StateId=0)
    Begin
     Insert into tbl_StateMaster(Country,StateCode,StateName,IsActive)  
     Values(@Country,@StateCode, @StateName,@IsActive)  
     Set @Msg='State has been saved successfully.'  
     Set @Status=1  
    end 
else
  begin  
    Update tbl_StateMaster Set Country=@Country,StateCode=@StateCode,StateName=@StateName  
    ,IsActive=@IsActive where StateId=@StateId  
    Set @Msg='State has been Update successfully.'  
    Set @Status=2  
    end 
ENd
   select @Msg As Msg,@Focus As Focus,@Status As [Status] 
end
GO
/****** Object:  StoredProcedure [dbo].[USP_ShowCountryMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Proc [dbo].[USP_ShowCountryMaster]
(
@Countryid int=0,
@Type Varchar(1)
)
As  ---USP_ShowCountryMaster '0','S'
Begin
	IF(@Type='S')
	Begin
		Select Countryid,CountryCode,CountryName,(case when IsActive=1 then 'YES' else 'NO' end) As IsActive,
		(case when State=1 then 'YES' else 'NO' end) As State,(case when Pincode=1 then 'YES' else 'NO' end) As Pincode
  From tbl_CountryMaster  order by Countryid desc
	End
	Else
	Begin
		Select Countryid,CountryCode,CountryName,(case when IsActive=1 then 'YES' else 'NO' end) As IsActive,
		(case when State=1 then 'YES' else 'NO' end) As State,(case when Pincode=1 then 'YES' else 'NO' end) As Pincode
  From tbl_CountryMaster where Countryid=@Countryid
	End
End
select * from tbl_CountryMaster
GO
/****** Object:  StoredProcedure [dbo].[USP_ShowStateMaster]    Script Date: 14-Oct-23 6:38:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Proc [dbo].[USP_ShowStateMaster]
(
@StateId int=0,
@Type Varchar(1)
)
As  ---ShowCountryMaster '0','S'
Begin
	--Declare @Cond NVarchar(Max)=''
	IF(@Type='S')
	Begin
		Select tbl_CountryMaster.CountryName+':'+tbl_CountryMaster.CountryCode as Country,tbl_StateMaster.StateId,tbl_StateMaster.StateCode,tbl_StateMaster.StateName,(case when tbl_StateMaster.IsActive=1 then 'YES' else 'NO' end) As IsActive    
  From tbl_StateMaster Left Join tbl_CountryMaster On tbl_StateMaster.Country=tbl_CountryMaster.CountryName order by StateId desc
	End
	Else
	Begin
		Select tbl_CountryMaster.CountryName+':'+tbl_CountryMaster.CountryCode as Country,tbl_StateMaster.StateId,tbl_StateMaster.StateCode,tbl_StateMaster.StateName,(case when tbl_StateMaster.IsActive=1 then 'YES' else 'NO' end) As IsActive    
  From tbl_StateMaster Left Join tbl_CountryMaster On tbl_StateMaster.Country=tbl_CountryMaster.CountryName where StateId=@StateId order by StateId desc
	End
End


GO
