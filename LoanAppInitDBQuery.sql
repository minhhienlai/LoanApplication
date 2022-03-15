DROP DATABASE IF EXISTS [LoanApp]
GO

CREATE DATABASE [LoanApp]
GO

USE [LoanApp]
GO
-- [Demographics] TABLE
CREATE TABLE [dbo].[Demographics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](450) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CreatedAt] Datetime NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedAt] Datetime NULL,
	[ModifiedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Demographics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
-- [Businesses] TABLE
CREATE TABLE [dbo].[Businesses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessCode] [nvarchar](450) NULL,
	[Name] [nvarchar](450) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] Datetime NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedAt] Datetime NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[OwnerId] [int] NULL,
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
	[Amount] [float] NULL,
	[PayBackInMonths] [int] NULL,
	[APRPercent] [int] NULL,
	[CreditScore] [int] NULL,
	[LatePaymentRate] [float] NULL,
	[TotalDebt] [float] NULL,
	[RiskRate] [float] NOT NULL,
	[DateSubmitted] [datetime2](7) NULL,
	[DateProcessed] [datetime2](7) NULL,
	[Status] [int] NULL,
	[CreatedAt] Datetime NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[ModifiedAt] Datetime NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[BusinessId] [int] NULL,
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
