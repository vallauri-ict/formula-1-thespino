CREATE TABLE [countries] (
  [code] char(3) PRIMARY KEY NOT NULL,
  [name] varchar(40) NOT NULL,
  [nationality] varchar(40) NOT NULL
)
GO

CREATE TABLE [drivers] (
  [id] int(11) PRIMARY KEY IDENTITY(1, 1),
  [firstname] varchar(40) NOT NULL,
  [lastname] varchar(40) NOT NULL,
  [dob] date NOT NULL,
  [pob] varchar(40) NOT NULL,
  [country_code] char(3) NOT NULL
)
GO

CREATE TABLE [teams] (
  [id] int(11) PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [name] varchar(40) NOT NULL,
  [fullname] varchar(80) NOT NULL,
  [powerunit] varchar(40) NOT NULL,
  [technicalchief] varchar(40) NOT NULL,
  [chassis] varchar(40) NOT NULL,
  [country_code] char(3) NOT NULL,
  [driver1_id] int(11) NOT NULL,
  [driver2_id] int(11) NOT NULL
)
GO

CREATE TABLE [circuits] (
  [id] int(11) PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [name] varchar(40) NOT NULL,
  [length] int(10) NOT NULL,
  [recordlap] int(10) DEFAULT (null),
  [location] varchar(80) NOT NULL,
  [country_code] char(3)
)
GO

CREATE TABLE [races] (
  [id] int(11) PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [name] varchar(40) NOT NULL,
  [laps] int(10) DEFAULT (null),
  [date] date DEFAULT (null),
  [circuit_id] int(11) DEFAULT (null)
)
GO

CREATE TABLE [scores] (
  [id] int(11) PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [score] int(10) NOT NULL,
  [details] varchar(500) DEFAULT ''
)
GO

CREATE TABLE [races_scores] (
  [id] int(11) PRIMARY KEY NOT NULL IDENTITY(1, 1),
  [position] int(10) DEFAULT (null),
  [fastestlap] int(10) DEFAULT (null),
  [driver_id] int(11),
  [score_id] int(11),
  [race_id] int(11)
)
GO

ALTER TABLE [drivers] ADD FOREIGN KEY ([country_code]) REFERENCES [countries] ([code])
GO

ALTER TABLE [teams] ADD FOREIGN KEY ([country_code]) REFERENCES [countries] ([code])
GO

ALTER TABLE [teams] ADD FOREIGN KEY ([driver1_id]) REFERENCES [drivers] ([id])
GO

ALTER TABLE [teams] ADD FOREIGN KEY ([driver2_id]) REFERENCES [drivers] ([id])
GO

ALTER TABLE [circuits] ADD FOREIGN KEY ([country_code]) REFERENCES [countries] ([code])
GO

ALTER TABLE [races] ADD FOREIGN KEY ([circuit_id]) REFERENCES [circuits] ([id])
GO

ALTER TABLE [races_scores] ADD FOREIGN KEY ([driver_id]) REFERENCES [drivers] ([id])
GO

ALTER TABLE [races_scores] ADD FOREIGN KEY ([score_id]) REFERENCES [scores] ([id])
GO

ALTER TABLE [races_scores] ADD FOREIGN KEY ([race_id]) REFERENCES [races] ([id])
GO
