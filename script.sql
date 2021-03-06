USE [Students]
GO
/****** Object:  Table [dbo].[t_Authors]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Authors](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Createdby_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Bulk]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Bulk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](250) NULL,
	[LastName] [varchar](250) NULL,
	[Age] [varchar](250) NULL,
 CONSTRAINT [PK_t_Bulk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Categories]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Book_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Complaint]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Complaint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Total] [varchar](250) NULL,
	[Concluded] [varchar](250) NULL,
	[Not_Concluded] [varchar](250) NULL,
	[Complainletteryear] [varchar](250) NULL,
 CONSTRAINT [PK_t_Complaint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Country]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Country](
	[CountryID] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](250) NULL,
	[CountryPopulation] [float] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Employees]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Employees](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](250) NOT NULL,
	[LastName] [varchar](250) NOT NULL,
	[MobileNumber] [varchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Instituiton]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Instituiton](
	[Id] [uniqueidentifier] NOT NULL,
	[SchoolName] [nvarchar](250) NULL,
	[MobileNumber] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Website] [nvarchar](250) NULL,
	[County] [nvarchar](250) NULL,
	[Town] [nvarchar](250) NULL,
	[PostalAddress] [nvarchar](250) NULL,
	[PostalCode] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SchoolType] [nvarchar](250) NULL,
	[Createdby_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_Instituiton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_IssueBooks]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_IssueBooks](
	[Id] [uniqueidentifier] NOT NULL,
	[BorrowerId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[BookNo] [nvarchar](250) NOT NULL,
	[IssuedCopies] [nvarchar](250) NOT NULL,
	[IssuedDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_t_IssuedBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_IssueBooksss]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_IssueBooksss](
	[Id] [uniqueidentifier] NOT NULL,
	[BorrowerId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[BookNo] [nvarchar](250) NOT NULL,
	[IssuedCopies] [nvarchar](250) NOT NULL,
	[IssuedDate] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_t_IssuedBooksss] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Languages]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Languages](
	[Id] [uniqueidentifier] NOT NULL,
	[LanguageName] [varchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Location]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Location](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Createdby_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_LostBooks]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_LostBooks](
	[Id] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[BorrowerId] [uniqueidentifier] NOT NULL,
	[BookNo] [nvarchar](250) NOT NULL,
	[DateReported] [datetime] NOT NULL,
	[ReportedBy_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_LostBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Members]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Members](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[MobileNumber] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[MembershipNo] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_t_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Publishers]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Publishers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Publishers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_RegisterBooks]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_RegisterBooks](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](250) NULL,
	[BookNo] [nvarchar](250) NULL,
	[LanguageId] [uniqueidentifier] NULL,
	[ISBN_No] [nvarchar](250) NULL,
	[Edition] [nvarchar](250) NULL,
	[Copies] [nvarchar](250) NULL,
	[PublisherId] [uniqueidentifier] NULL,
	[PublishedYear] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[CategoryId] [uniqueidentifier] NULL,
	[BarCode] [nvarchar](250) NULL,
	[Pages] [nvarchar](250) NULL,
	[AuthorId] [uniqueidentifier] NULL,
	[LocationId] [uniqueidentifier] NULL,
	[VendorId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_RegisterBooks_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_ReturnedBooks]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_ReturnedBooks](
	[Id] [uniqueidentifier] NOT NULL,
	[BorrowerId] [uniqueidentifier] NOT NULL,
	[BookId] [uniqueidentifier] NOT NULL,
	[BookNo] [nvarchar](250) NOT NULL,
	[ReturnedCopies] [nvarchar](250) NOT NULL,
	[ReturnedDate] [datetime] NOT NULL,
	[ReturnedStatus] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_t_ReturnedBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Stream]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Stream](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Students]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Students](
	[Id] [uniqueidentifier] NOT NULL,
	[AdmNo] [nvarchar](250) NULL,
	[FirstName] [nvarchar](250) NULL,
	[MiddleName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[EntryTerm] [nvarchar](250) NULL,
	[EntryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_t_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_User]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_t_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Users]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[MobileNumber] [nvarchar](50) NOT NULL,
	[ActivationCode] [uniqueidentifier] NOT NULL,
	[PasswordResetToken] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_t_Users_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Vendors]    Script Date: 2/18/2021 11:38:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Vendors](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[MobileNumber] [nvarchar](250) NOT NULL,
	[EmailAddress] [nvarchar](250) NULL,
	[Website] [nvarchar](250) NULL,
	[PostalAddress] [nvarchar](250) NULL,
	[PostalCode] [nvarchar](250) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Createdby_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_t_Vendors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_Authors] ADD  CONSTRAINT [DF_t_Authors_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_Categories] ADD  CONSTRAINT [DF_t_Book_Categories_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_Employees] ADD  CONSTRAINT [DF_t_Employees_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_Languages] ADD  CONSTRAINT [DF_t_Language_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_Publishers] ADD  CONSTRAINT [DF_t_Publishers_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_RegisterBooks] ADD  CONSTRAINT [DF_t_RegisterBooks_DeliveryDate]  DEFAULT (getdate()) FOR [DeliveryDate]
GO
ALTER TABLE [dbo].[t_Students] ADD  CONSTRAINT [DF_t_Student_EntryDate]  DEFAULT (getdate()) FOR [EntryDate]
GO
ALTER TABLE [dbo].[t_Users] ADD  CONSTRAINT [DF_t_Users_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_Vendors] ADD  CONSTRAINT [DF_t_Vendors_EntryDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[t_IssueBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_IssueBooks_t_RegisterBooks] FOREIGN KEY([BookId])
REFERENCES [dbo].[t_RegisterBooks] ([Id])
GO
ALTER TABLE [dbo].[t_IssueBooks] CHECK CONSTRAINT [FK_t_IssueBooks_t_RegisterBooks]
GO
ALTER TABLE [dbo].[t_LostBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_LostBooks_t_RegisterBooks] FOREIGN KEY([BookId])
REFERENCES [dbo].[t_RegisterBooks] ([Id])
GO
ALTER TABLE [dbo].[t_LostBooks] CHECK CONSTRAINT [FK_t_LostBooks_t_RegisterBooks]
GO
ALTER TABLE [dbo].[t_LostBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_LostBooks_t_Students] FOREIGN KEY([BorrowerId])
REFERENCES [dbo].[t_Students] ([Id])
GO
ALTER TABLE [dbo].[t_LostBooks] CHECK CONSTRAINT [FK_t_LostBooks_t_Students]
GO
ALTER TABLE [dbo].[t_RegisterBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_RegisterBooks_t_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[t_Authors] ([Id])
GO
ALTER TABLE [dbo].[t_RegisterBooks] CHECK CONSTRAINT [FK_t_RegisterBooks_t_Authors]
GO
ALTER TABLE [dbo].[t_RegisterBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_RegisterBooks_t_Languages] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[t_Languages] ([Id])
GO
ALTER TABLE [dbo].[t_RegisterBooks] CHECK CONSTRAINT [FK_t_RegisterBooks_t_Languages]
GO
ALTER TABLE [dbo].[t_RegisterBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_RegisterBooks_t_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[t_Location] ([Id])
GO
ALTER TABLE [dbo].[t_RegisterBooks] CHECK CONSTRAINT [FK_t_RegisterBooks_t_Location]
GO
ALTER TABLE [dbo].[t_RegisterBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_RegisterBooks_t_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[t_Publishers] ([Id])
GO
ALTER TABLE [dbo].[t_RegisterBooks] CHECK CONSTRAINT [FK_t_RegisterBooks_t_Publishers]
GO
ALTER TABLE [dbo].[t_RegisterBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_RegisterBooks_t_RegisterBooks] FOREIGN KEY([VendorId])
REFERENCES [dbo].[t_Vendors] ([Id])
GO
ALTER TABLE [dbo].[t_RegisterBooks] CHECK CONSTRAINT [FK_t_RegisterBooks_t_RegisterBooks]
GO
ALTER TABLE [dbo].[t_ReturnedBooks]  WITH CHECK ADD  CONSTRAINT [FK_t_ReturnedBooks_t_RegisterBooks] FOREIGN KEY([BookId])
REFERENCES [dbo].[t_RegisterBooks] ([Id])
GO
ALTER TABLE [dbo].[t_ReturnedBooks] CHECK CONSTRAINT [FK_t_ReturnedBooks_t_RegisterBooks]
GO
ALTER TABLE [dbo].[t_Students]  WITH CHECK ADD  CONSTRAINT [FK_t_Students_t_Stream] FOREIGN KEY([StreamId])
REFERENCES [dbo].[t_Stream] ([Id])
GO
ALTER TABLE [dbo].[t_Students] CHECK CONSTRAINT [FK_t_Students_t_Stream]
GO
