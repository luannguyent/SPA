# Booking System
This project shows how to use ASP.NET Web API with Angular JS using Entity Framework Code First
# How to create database to run this project
USE [BookingSys]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Property]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TypeId] [int] NOT NULL,
	[UpdateAt] [datetime] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReservationNumber] [nvarchar](max) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[UpdateAt] [datetime] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdateBy] [nvarchar](50) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Type]    Script Date: 12/5/2015 8:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UpdateAt] [datetime] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[CreateBy] [nvarchar](50) NULL,
	[UpdateBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'aa6d6350-2842-4a31-9d7f-01f06079204e', N'User')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd51426ab-b9b2-4260-8ee2-0d5bd1e787ac', N'Administrator')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd71998b3-b7d1-480f-932e-915036deb3f9', N'aa6d6350-2842-4a31-9d7f-01f06079204e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'685edab3-3c1b-43a0-92c8-dea7313e65fb', N'd51426ab-b9b2-4260-8ee2-0d5bd1e787ac')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7a18f4d4-e876-4f44-9cf2-ee630c690a40', N'd51426ab-b9b2-4260-8ee2-0d5bd1e787ac')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'd51426ab-b9b2-4260-8ee2-0d5bd1e787ac')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa82c870-ac16-4efe-ab45-8fa37d9ae190', N'd51426ab-b9b2-4260-8ee2-0d5bd1e787ac')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'685edab3-3c1b-43a0-92c8-dea7313e65fb', N'luannguyent', N'APmaHRw0m50xom6Qc/76Uc7TlcRwYMPyX3aBoddfVv6B/3iOxSZo3FtxoWo+0tBZUA==', N'5ea1b37e-bf9b-4ddb-abfe-fba7080ef936', N'IdentityUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'7a18f4d4-e876-4f44-9cf2-ee630c690a40', N'user', N'AFAQr/YovoDyqK3ubpCYpFJ0dHhLQ4DOO2ph/dU4fESqfTjzGaDzqiaQJ4cFIqFVuQ==', N'a62b27d6-5a71-4846-b0ec-2e611ea9f13d', N'IdentityUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'd71998b3-b7d1-480f-932e-915036deb3f9', N'luannt5', N'AJsp7A1xOelDAGBcV0K2OJfId+uUSkQC8CsPiSTa4TYQr38BXy5KCAkUwGgBrFZd7A==', N'fc4f06bd-0d3d-49c8-87d2-118f0449d9e8', N'IdentityUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'admin', N'ADL9od3z7jn7mCvti/nOOYiq6VvJm2fJxn/0vcOzCjKUIA5U2cGaweAabgIajYz0jQ==', N'9488768c-e494-4faa-bddc-755558dbf6bc', N'IdentityUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'fa82c870-ac16-4efe-ab45-8fa37d9ae190', N'luannguyent123', N'AEcmstR9onN7G0KjBxvjPNuSqzhE4d8pcQi+urHODRVhnBSO0V3sfdU9PC/wq6RcOQ==', N'd388f55c-746b-4e4c-ad6d-3138c8644de4', N'IdentityUser')
SET IDENTITY_INSERT [dbo].[Property] ON 

INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (1, N'HaLong Bay', 1, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (2, N'Slovakia', 1, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (4, N'Macao', 1, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (5, N'SaiGon', 1, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (7, N'Sony-P1', 3, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (8, N'Sony-P2', 3, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Property] ([Id], [Name], [TypeId], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (9, N'Sony-P3', 3, CAST(N'2015-11-30 22:47:51.273' AS DateTime), CAST(N'2015-11-30 22:47:51.273' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
SET IDENTITY_INSERT [dbo].[Property] OFF
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([Id], [Name], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (1, N'Room', CAST(N'2015-11-30 22:46:17.150' AS DateTime), CAST(N'2015-11-30 22:46:17.150' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
INSERT [dbo].[Type] ([Id], [Name], [UpdateAt], [CreateAt], [CreateBy], [UpdateBy]) VALUES (3, N'Projector', CAST(N'2015-11-30 22:46:17.150' AS DateTime), CAST(N'2015-11-30 22:46:17.150' AS DateTime), N'eb5f202c-97a2-4770-b89f-3cee0d11d453', N'eb5f202c-97a2-4770-b89f-3cee0d11d453')
SET IDENTITY_INSERT [dbo].[Type] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Property_dbo.Type_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Type] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_dbo.Property_dbo.Type_TypeId]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reservation_dbo.Property_PropertyId] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Property] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_dbo.Reservation_dbo.Property_PropertyId]
GO
