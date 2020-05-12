CREATE TABLE [Countries] (
  [Code] char(2) PRIMARY KEY NOT NULL,
  [Name] varchar(40) NOT NULL
)
GO

CREATE TABLE [Drivers] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirstName] varchar(40) NOT NULL,
  [LastName] varchar(40) NOT NULL,
  [Dob] date NOT NULL,
  [Pob] varchar(40) NOT NULL,
  [ImageUrl] varchar(255) DEFAULT (null),
  [Country_Code] char(2) NOT NULL
)
GO

CREATE TABLE [Teams] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(40) NOT NULL,
  [FullName] varchar(80) NOT NULL,
  [PowerUnit] varchar(40) NOT NULL,
  [TechnicalChief] varchar(40) NOT NULL,
  [Chassis] varchar(40) NOT NULL,
  [Country_Code] char(2) NOT NULL,
  [Driver1_id] int NOT NULL,
  [Driver2_id] int NOT NULL
)
GO

CREATE TABLE [Circuits] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(40) NOT NULL,
  [Length] varchar(20) NOT NULL,
  [RecordLap] varchar(80) DEFAULT (null),
  [Location] varchar(80) NOT NULL,
  [ImageUrl] varchar(255) DEFAULT (null),
  [Country_Code] char(2)
)
GO

CREATE TABLE [Races] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(40) NOT NULL,
  [Laps] int DEFAULT (null),
  [Date] date DEFAULT (null),
  [Circuit_Id] int DEFAULT (null)
)
GO

CREATE TABLE [Results] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Position] int NOT NULL,
  [Score] int NOT NULL,
  [FastestLap] varchar(80) DEFAULT (null),
  [Driver_Id] int,
  [Race_Id] int
)
GO

ALTER TABLE [Drivers] ADD FOREIGN KEY ([Country_Code]) REFERENCES [Countries] ([Code])
GO

ALTER TABLE [Teams] ADD FOREIGN KEY ([Country_Code]) REFERENCES [Countries] ([Code])
GO

ALTER TABLE [Teams] ADD FOREIGN KEY ([Driver1_id]) REFERENCES [Drivers] ([Id])
GO

ALTER TABLE [Teams] ADD FOREIGN KEY ([Driver2_id]) REFERENCES [Drivers] ([Id])
GO

ALTER TABLE [Circuits] ADD FOREIGN KEY ([Country_Code]) REFERENCES [Countries] ([Code])
GO

ALTER TABLE [Races] ADD FOREIGN KEY ([Circuit_Id]) REFERENCES [Circuits] ([Id])
GO

ALTER TABLE [Results] ADD FOREIGN KEY ([Driver_Id]) REFERENCES [Drivers] ([Id])
GO

ALTER TABLE [Results] ADD FOREIGN KEY ([Race_Id]) REFERENCES [Races] ([Id])
GO
