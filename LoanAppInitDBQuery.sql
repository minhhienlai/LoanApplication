DROP DATABASE IF EXISTS [LoanApp]
GO

CREATE DATABASE [LoanApp]
GO

USE [LoanApp]
GO
-- [Demographics] TABLE
CREATE TABLE [dbo].[Demographics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[PhoneNo] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Demographics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
-- [Businesses] TABLE
CREATE TABLE [dbo].[Businesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessCode] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[OwnerId] [int] NOT NULL,
 CONSTRAINT [PK_Businesses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Businesses] ADD  DEFAULT ((0)) FOR [OwnerId]
GO

ALTER TABLE [dbo].[Businesses]  WITH CHECK ADD  CONSTRAINT [FK_Businesses_Demographics_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Demographics] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Businesses] CHECK CONSTRAINT [FK_Businesses_Demographics_OwnerId]
GO
-- [LoanApps] TABLE
CREATE TABLE [dbo].[LoanApps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [float] NOT NULL,
	[PayBackInMonths] [int] NOT NULL,
	[APRPercent] [int] NOT NULL,
	[CreditScore] [int] NOT NULL,
	[LatePaymentRate] [float] NOT NULL,
	[TotalDebt] [float] NOT NULL,
	[RiskRate] [float] NOT NULL,
	[DateSubmitted] [datetime2](7) NOT NULL,
	[DateProcessed] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[BusinessId] [int] NOT NULL,
 CONSTRAINT [PK_LoanApps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LoanApps] ADD  DEFAULT ((0)) FOR [BusinessId]
GO

ALTER TABLE [dbo].[LoanApps]  WITH CHECK ADD  CONSTRAINT [FK_LoanApps_Businesses_BusinessId] FOREIGN KEY([BusinessId])
REFERENCES [dbo].[Businesses] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[LoanApps] CHECK CONSTRAINT [FK_LoanApps_Businesses_BusinessId]
GO