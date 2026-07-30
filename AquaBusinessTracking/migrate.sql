IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] int NOT NULL IDENTITY,
        [RoleName] nvarchar(max) NOT NULL,
        [Explanation] nvarchar(max) NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_Department] (
        [RecId] int NOT NULL IDENTITY,
        [DepartmentName] nvarchar(max) NOT NULL,
        [DepartmentCode] nvarchar(max) NOT NULL,
        [Explanation] nvarchar(max) NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_Department] PRIMARY KEY ([RecId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_Permission] (
        [RecId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Db_Permission] PRIMARY KEY ([RecId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_Shift] (
        [RecId] int NOT NULL IDENTITY,
        [ShiftName] nvarchar(max) NOT NULL,
        [ShiftCode] nvarchar(max) NOT NULL,
        [ShiftStartHours] time NULL,
        [ShiftEndHours] time NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_Shift] PRIMARY KEY ([RecId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] int NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [SurName] nvarchar(max) NOT NULL,
        [CoverImgUrl] nvarchar(max) NULL,
        [DepartmentId] int NOT NULL,
        [ShiftTitle] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUsers_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_RolePermission] (
        [RoleId] int NOT NULL,
        [PermissionId] int NOT NULL,
        CONSTRAINT [PK_Db_RolePermission] PRIMARY KEY ([RoleId], [PermissionId]),
        CONSTRAINT [FK_Db_RolePermission_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_RolePermission_Db_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Db_Permission] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] int NOT NULL,
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] int NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_Basin] (
        [RecId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Category] nvarchar(max) NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_Basin] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_Basin_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_Basin_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_Basin_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_BoilerSteamFeedWaterCondensateData] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [Boil] decimal(18,2) NOT NULL,
        [FeedWater] decimal(18,2) NOT NULL,
        [KM2Kodens] decimal(18,2) NOT NULL,
        [Hvac] decimal(18,2) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        CONSTRAINT [PK_Db_BoilerSteamFeedWaterCondensateData] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_BoilerSteamFeedWaterCondensateData_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BoilerSteamFeedWaterCondensateData_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BoilerSteamFeedWaterCondensateData_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_BufferAnalysisReport] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [BufferExitTime] time NULL,
        [SampleCollectionTime] time NULL,
        [SampleResultTime] time NULL,
        [BufferNo] nvarchar(max) NOT NULL,
        [ProductType] nvarchar(max) NOT NULL,
        [TargetGrammage] decimal(18,2) NULL,
        [GrammageTop] decimal(18,2) NULL,
        [GrammageMiddle] decimal(18,2) NULL,
        [GrammageBottom] decimal(18,2) NULL,
        [LabAverageGrammage] decimal(18,2) NULL,
        [QcsGrammage] decimal(18,2) NULL,
        [ThicknessMicrons] decimal(18,2) NULL,
        [MoistureTop] decimal(18,2) NULL,
        [MoistureMiddle] decimal(18,2) NULL,
        [MoistureBottom] decimal(18,2) NULL,
        [AverageMoisture] decimal(18,2) NULL,
        [QcsMoisture] decimal(18,2) NULL,
        [BurstStrengthKpa] decimal(18,2) NULL,
        [BurstIndex] decimal(18,2) NULL,
        [Cobb60Uncoated] decimal(18,2) NULL,
        [Cobb60Coated] decimal(18,2) NULL,
        [RctKnM] decimal(18,2) NULL,
        [CmtNewton] decimal(18,2) NULL,
        [CctKnM] decimal(18,2) NULL,
        [SctCd] decimal(18,2) NULL,
        [SctIndexCd] decimal(18,2) NULL,
        [GurleyPorosity] decimal(18,2) NULL,
        [BentsenPorosityUncoated] decimal(18,2) NULL,
        [ColorLStar] decimal(18,2) NULL,
        [ColorAStar] decimal(18,2) NULL,
        [ColorBStar] decimal(18,2) NULL,
        [TensileStrengthWidth] decimal(18,2) NULL,
        [TensileStrengthLength] decimal(18,2) NULL,
        [FillerPercent] decimal(18,2) NULL,
        [DyeDosageAmount] decimal(18,2) NULL,
        [SizerGrammage] decimal(18,2) NULL,
        [Starch] decimal(18,2) NULL,
        [Silica] decimal(18,2) NULL,
        [SuitableForMondi] bit NULL,
        [AquaEcoFL16] bit NULL,
        [AquaFL18] bit NULL,
        [AquaPowerFL20] bit NULL,
        [AquaHighPowerFL22] bit NULL,
        [AquaTestliner] bit NULL,
        [TlProductionGivenToFl] bit NULL,
        [Description] nvarchar(max) NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_BufferAnalysisReport] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_BufferAnalysisReport_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BufferAnalysisReport_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BufferAnalysisReport_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_BufferGramajProfile] (
        [RecId] int NOT NULL IDENTITY,
        [BufferNo] decimal(18,2) NOT NULL,
        [SampleNo] int NOT NULL,
        [Gramaj] int NOT NULL,
        [Thickness] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_BufferGramajProfile] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_BufferGramajProfile_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BufferGramajProfile_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BufferGramajProfile_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [Time] time NOT NULL,
        [MachineSpeed] decimal(18,2) NOT NULL,
        [ProductionType] nvarchar(max) NOT NULL,
        [Grammage] decimal(18,2) NOT NULL,
        [TurnCount] int NOT NULL,
        [Fau] decimal(18,2) NOT NULL,
        [Ntu] decimal(18,2) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        CONSTRAINT [PK_Db_CirculationTankAirPressureMeasurementTurbidity] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_CirculationTankAirPressureMeasurementTurbidity_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_CirculationTankAirPressureMeasurementTurbidity_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_CirculationTankAirPressureMeasurementTurbidity_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_DoughPreparation] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [PulperNo] nvarchar(max) NOT NULL,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [QueueNo] decimal(18,2) NOT NULL,
        [Clippings] decimal(18,2) NOT NULL,
        [Bale] decimal(18,2) NOT NULL,
        [KG] decimal(18,2) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_DoughPreparation] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_DoughPreparation_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_DoughPreparation_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_DoughPreparation_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_DoughPreparationAnalysisResults] (
        [RecId] int NOT NULL IDENTITY,
        [SampleCollectionTime] int NOT NULL,
        [SampleResultDeliveryTime] int NOT NULL,
        [SampleTakenLocation] nvarchar(max) NOT NULL,
        [KM] real NOT NULL,
        [SR] int NOT NULL,
        [DryMatter] int NOT NULL,
        [pH] real NOT NULL,
        [Conductivity] int NOT NULL,
        [CaCO3] int NOT NULL,
        [Filling] real NOT NULL,
        [Blur] int NOT NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_DoughPreparationAnalysisResults] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_DoughPreparationAnalysisResults_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_DoughPreparationAnalysisResults_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_DoughPreparationAnalysisResults_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_ElectricMotorTracking] (
        [RecId] int NOT NULL IDENTITY,
        [ElectricMotorOrderNo] nvarchar(max) NOT NULL,
        [ElectricMotorBrand] nvarchar(max) NOT NULL,
        [kW] real NOT NULL,
        [Voltage] decimal(18,2) NOT NULL,
        [DepartmentId] int NOT NULL,
        [Explanation] nvarchar(max) NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_ElectricMotorTracking] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_ElectricMotorTracking_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_ElectricMotorTracking_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_ElectricMotorTracking_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_ElectricShiftWork] (
        [RecId] int NOT NULL IDENTITY,
        [ShiftId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_ElectricShiftWork] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_ElectricShiftWork_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_ElectricShiftWork_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_ElectricShiftWork_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_KazanChemicalsHead] (
        [RecId] int NOT NULL IDENTITY,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [Day] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_KazanChemicalsHead] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_KazanChemicalsHead_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_KazanChemicalsHead_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_KazanChemicalsHead_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_KazanDailyShiftMonitoring] (
        [RecId] int NOT NULL IDENTITY,
        [ShihtId] int NOT NULL,
        [ShiftUserName] nvarchar(max) NOT NULL,
        [JobDone] int NOT NULL,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [Permission] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_KazanDailyShiftMonitoring] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_KazanDailyShiftMonitoring_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_KazanDailyShiftMonitoring_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShihtId] FOREIGN KEY ([ShihtId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_LabWork] (
        [Recıd] int NOT NULL IDENTITY,
        [LabTestName] nvarchar(max) NOT NULL,
        [LabTestRequest] nvarchar(max) NOT NULL,
        [LabTestCount] nvarchar(max) NOT NULL,
        [LabTestUserNames] nvarchar(max) NOT NULL,
        [ShiftId] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_LabWork] PRIMARY KEY ([Recıd]),
        CONSTRAINT [FK_Db_LabWork_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_LabWork_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_LabWork_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_LogisticsTrackingReport] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [CarrierCompany] nvarchar(max) NOT NULL,
        [DepartureLocation] nvarchar(max) NOT NULL,
        [ArrivalLocation] nvarchar(max) NOT NULL,
        [Vehicle] nvarchar(max) NOT NULL,
        [DriverNameOrPlate] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NULL,
        [ProcessingCompany] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [InvoiceNumber] nvarchar(max) NOT NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_LogisticsTrackingReport] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_LogisticsTrackingReport_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_LogisticsTrackingReport_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_LogisticsTrackingReport_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [DB_MassWasteBalance] (
        [RecId] int NOT NULL IDENTITY,
        [Month] int NOT NULL,
        [Year] int NOT NULL,
        [WasteCode] nvarchar(max) NOT NULL,
        [PreviousMonthCarryover] decimal(18,2) NOT NULL,
        [UsedInProduction] decimal(18,2) NOT NULL,
        [NextMonthCarryover] decimal(18,2) NOT NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_DB_MassWasteBalance] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_DB_MassWasteBalance_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DB_MassWasteBalance_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DB_MassWasteBalance_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [DB_MassWasteSupplier] (
        [RecId] int NOT NULL IDENTITY,
        [Month] int NOT NULL,
        [Year] int NOT NULL,
        [CompanyName] nvarchar(max) NOT NULL,
        [GrossWeight] decimal(18,2) NOT NULL,
        [NetWeight] decimal(18,2) NOT NULL,
        [WasteCode] nvarchar(max) NOT NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_DB_MassWasteSupplier] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_DB_MassWasteSupplier_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DB_MassWasteSupplier_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DB_MassWasteSupplier_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_NaturelGasMeterMonitoring] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [DailyConsumption] int NOT NULL,
        [Pressure] real NOT NULL,
        [Heat] real NOT NULL,
        [CalorificValue] real NOT NULL,
        [StandartCubicmeter] decimal(18,2) NOT NULL,
        [ConversionFactor] real NOT NULL,
        [kW] decimal(18,2) NOT NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [Control] int NOT NULL,
        [IsApproved] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_NaturelGasMeterMonitoring] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_NaturelGasMeterMonitoring_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_NaturelGasMeterMonitoring_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_NaturelGasMeterMonitoring_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_OilAnalysisReport] (
        [RecId] int NOT NULL IDENTITY,
        [DepartmentId] int NOT NULL,
        [MyProperty] int NOT NULL,
        [Hours] int NOT NULL,
        [Date] datetime2 NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_OilAnalysisReport] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_OilAnalysisReport_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_OilAnalysisReport_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_OilAnalysisReport_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_PapperMachineChemical] (
        [RecId] int NOT NULL IDENTITY,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [IncomingQuantity] decimal(18,2) NOT NULL,
        [ConsumedQuantity] decimal(18,2) NOT NULL,
        [RemainingQuantity] decimal(18,2) NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_PapperMachineChemical] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_PapperMachineChemical_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_PapperMachineChemical_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_PapperMachineChemical_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_PurificationChemicalsConsumption] (
        [RecId] int NOT NULL IDENTITY,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [Month] int NOT NULL,
        [IncomingQuantity] decimal(18,2) NOT NULL,
        [ConsumedQuantity] decimal(18,2) NOT NULL,
        [RemainingQuantity] decimal(18,2) NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_PurificationChemicalsConsumption] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_PurificationChemicalsConsumption_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_SalesScale] (
        [RecId] int NOT NULL IDENTITY,
        [ScaleDate] datetime2 NOT NULL,
        [ScaleHours] datetime2 NOT NULL,
        [ScaleNo] decimal(18,2) NOT NULL,
        [DeliveryNumber] nvarchar(max) NOT NULL,
        [CurrentAccountName] nvarchar(max) NOT NULL,
        [TruckPlate] nvarchar(max) NOT NULL,
        [AppUserId] int NOT NULL,
        [DeliveryQuantity] decimal(18,2) NOT NULL,
        [ScaleQuantity] decimal(18,2) NOT NULL,
        [ScaleGap] int NULL,
        [GapSuperVisior] nvarchar(max) NOT NULL,
        [GapDesicion] nvarchar(max) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_SalesScale] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_SalesScale_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_SalesScale_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_SalesScale_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_SentezAllData] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [BufferNo] nvarchar(max) NOT NULL,
        [ProductType] nvarchar(max) NOT NULL,
        [Grammage] decimal(18,2) NULL,
        [BufferRollDescription] nvarchar(max) NOT NULL,
        [StartTime] time NULL,
        [EndTime] time NULL,
        [IdealMachineSpeed] decimal(18,2) NULL,
        [ActualMachineSpeed] decimal(18,2) NULL,
        [SpeedReductionReason] nvarchar(max) NOT NULL,
        [BufferWidth] decimal(18,2) NULL,
        [ProducedQuantityKg] decimal(18,2) NULL,
        [DefectiveQuantityKg] decimal(18,2) NULL,
        [NetProductionKg] decimal(18,2) NULL,
        [RetentionDosageLtMin] decimal(18,2) NULL,
        [RetentionDosagePercent] decimal(18,2) NULL,
        [SizerStarchGsm] decimal(18,2) NULL,
        [OperatingStarchSolidContent] decimal(18,2) NULL,
        [OperatingStarchTemperature] decimal(18,2) NULL,
        [PreparationStarchSolidContent] decimal(18,2) NULL,
        [PreparationStarchTemperature] decimal(18,2) NULL,
        [QualityControlNumber] nvarchar(max) NOT NULL,
        [MeasuredGrammageAvg] decimal(18,2) NULL,
        [MeasuredThicknessAvg] decimal(18,2) NULL,
        [MeasuredMoistureAvg] decimal(18,2) NULL,
        [BurstStrengthKpa] decimal(18,2) NULL,
        [BurstIndex] decimal(18,2) NULL,
        [SctCd] decimal(18,2) NULL,
        [SctIndex] decimal(18,2) NULL,
        [RctKgf] decimal(18,2) NULL,
        [EctKnM] decimal(18,2) NULL,
        [CctKnM] decimal(18,2) NULL,
        [CmtKnM] decimal(18,2) NULL,
        [GurleyPorositySec] decimal(18,2) NULL,
        [BendsenPorosity] decimal(18,2) NULL,
        [Cobb60Absorption] decimal(18,2) NULL,
        [TensileSpeed] decimal(18,2) NULL,
        [Schopper] decimal(18,2) NULL,
        [Filler] decimal(18,2) NULL,
        [Ash] decimal(18,2) NULL,
        [ColorL] decimal(18,2) NULL,
        [ColorA] decimal(18,2) NULL,
        [ColorB] decimal(18,2) NULL,
        [Laborant] nvarchar(max) NOT NULL,
        [SilicaAdded] bit NULL,
        [SilicaDosageAmount] decimal(18,2) NULL,
        [AtcAdded] bit NULL,
        [AtcAmount] decimal(18,2) NULL,
        [DyeDosageAmount] decimal(18,2) NULL,
        [SuitableForSpecialCustomer] bit NULL,
        [ComplaintReceived] bit NULL,
        [QcsGrammage] decimal(18,2) NULL,
        [QcsMoisture] decimal(18,2) NULL,
        [MachineSr] decimal(18,2) NULL,
        [PulpChestSr] decimal(18,2) NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_SentezAllData] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_SentezAllData_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_SentezAllData_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_SentezAllData_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_SentezNotOrder] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [InvoiceDate] datetime2 NULL,
        [InvoiceNumber] nvarchar(max) NOT NULL,
        [SupplierCompany] nvarchar(max) NOT NULL,
        [SynthesisCode] nvarchar(max) NOT NULL,
        [ProductMaterial] nvarchar(max) NOT NULL,
        [Quantity] decimal(18,2) NULL,
        [Unit] nvarchar(max) NOT NULL,
        [ProductMaterialGroup] nvarchar(max) NOT NULL,
        [WarehouseEntryDate] datetime2 NULL,
        [WaitingPeriod] int NULL,
        [PurchaseDescription] nvarchar(max) NOT NULL,
        [DepartmentId] int NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_SentezNotOrder] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Db_SentezNotOrder_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Db_SentezNotOrder_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]),
        CONSTRAINT [FK_Db_SentezNotOrder_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_StarchAnalysisHeading] (
        [RecId] int NOT NULL IDENTITY,
        [SampleCollectionTime] int NOT NULL,
        [SampleResultDeliveryTime] int NOT NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [Location] nvarchar(max) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_StarchAnalysisHeading] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_StarchAnalysisHeading_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_StarchAnalysisHeading_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_StarchAnalysisHeading_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_SteamConsumption] (
        [RecId] int NOT NULL IDENTITY,
        [Location] nvarchar(max) NOT NULL,
        [Day] nvarchar(max) NOT NULL,
        [Date] time NOT NULL,
        [ConsumptionQuantity] decimal(18,2) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_SteamConsumption] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_SteamConsumption_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_SteamConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_SteamConsumption_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_TestHeader] (
        [RecId] int NOT NULL IDENTITY,
        [TestDepartmentName] nvarchar(max) NOT NULL,
        [AppUserId] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_TestHeader] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_TestHeader_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_TestHeader_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_TestHeader_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_VechileFuelLogs] (
        [RecId] int NOT NULL IDENTITY,
        [VehicleLicensePlate] nvarchar(max) NOT NULL,
        [VehicleName] nvarchar(max) NOT NULL,
        [EngineHourOrKm] nvarchar(max) NOT NULL,
        [FuelDeliveredLiters] decimal(18,2) NULL,
        [Recipient] nvarchar(max) NOT NULL,
        [ResponsibleDepartment] nvarchar(max) NOT NULL,
        [Date] datetime2 NOT NULL,
        [FuelPricePerLiter] decimal(18,2) NULL,
        [TotalAmount] decimal(18,2) NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_VechileFuelLogs] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_VechileFuelLogs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_VechileFuelLogs_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_VechileFuelLogs_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WarehouseRequestWait] (
        [RecId] int NOT NULL IDENTITY,
        [WaybillNo] nvarchar(max) NOT NULL,
        [WaybillInvoiceNo] nvarchar(max) NOT NULL,
        [IncomingCurrentAccountName] nvarchar(max) NOT NULL,
        [SentezInventoryCode] nvarchar(max) NOT NULL,
        [SentezInventoryName] nvarchar(max) NOT NULL,
        [Quanity] decimal(18,2) NOT NULL,
        [Unit] nvarchar(max) NOT NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [SentezInventoryGroup] nvarchar(max) NOT NULL,
        [DepartmentId] int NOT NULL,
        [WarehouseEntryDate] time NOT NULL,
        [ReturnDate] time NOT NULL,
        [WaitingTime] nvarchar(max) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WarehouseRequestWait] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WarehouseRequestWait_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WarehouseRequestWait_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WarehouseRequestWait_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WastePaperControl] (
        [RecId] int NOT NULL IDENTITY,
        [SequenceNumber] int NULL,
        [Date] datetime2 NOT NULL,
        [WaybillNumber] nvarchar(max) NOT NULL,
        [Company] nvarchar(max) NOT NULL,
        [VehicleLicensePlate] nvarchar(max) NOT NULL,
        [NumberOfBales] int NULL,
        [ReceivedPaperType] nvarchar(max) NOT NULL,
        [CorrugatedPercent] decimal(18,2) NULL,
        [MixedPercent] decimal(18,2) NULL,
        [WaybillQuantityKg] decimal(18,2) NULL,
        [GrossVehicleWeightKg] decimal(18,2) NULL,
        [EmptyVehicleWeightKg] decimal(18,2) NULL,
        [GrossEntryQuantityKg] decimal(18,2) NULL,
        [AverageBaleWeightKg] decimal(18,2) NULL,
        [ForeignMaterialPercent] decimal(18,2) NULL,
        [DeviceMoisturePercent] decimal(18,2) NULL,
        [OvenMoisturePercent] decimal(18,2) NULL,
        [AverageMoisturePercent] decimal(18,2) NULL,
        [MoistureExemptionPercent] decimal(18,2) NULL,
        [NetMoisturePercent] decimal(18,2) NULL,
        [MoistureDeductionKg] decimal(18,2) NULL,
        [ForeignMaterialDeductionKg] decimal(18,2) NULL,
        [NetInvoiceBaseKg] decimal(18,2) NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WastePaperControl] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WastePaperControl_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WastePaperControl_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WastePaperControl_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WastePaperCost] (
        [RecId] int NOT NULL IDENTITY,
        [SequenceNumber] int NULL,
        [Date] datetime2 NOT NULL,
        [WaybillNumber] nvarchar(50) NOT NULL,
        [Company] nvarchar(200) NOT NULL,
        [VehicleLicensePlate] nvarchar(20) NOT NULL,
        [NumberOfBales] int NULL,
        [ReceivedPaperType] nvarchar(100) NOT NULL,
        [CorrugatedPercent] decimal(5,2) NULL,
        [MixedPercent] decimal(5,2) NULL,
        [WaybillQuantityKg] decimal(18,2) NULL,
        [GrossVehicleWeightKg] decimal(18,2) NULL,
        [EmptyVehicleWeightKg] decimal(18,2) NULL,
        [GrossEntryQuantityKg] decimal(18,2) NULL,
        [AverageBaleWeightKg] decimal(18,2) NULL,
        [ForeignMaterialPercent] decimal(5,2) NULL,
        [DeviceMoisturePercent] decimal(5,2) NULL,
        [OvenMoisturePercent] decimal(5,2) NULL,
        [AverageMoisturePercent] decimal(5,2) NULL,
        [MoistureExemptionPercent] decimal(5,2) NULL,
        [NetMoisturePercent] decimal(5,2) NULL,
        [MoistureDeductionKg] decimal(18,2) NULL,
        [ForeignMaterialDeductionKg] decimal(18,2) NULL,
        [NetInvoiceBaseKg] decimal(18,2) NULL,
        [AgreedPrice] decimal(18,4) NULL,
        [GrossAmount] decimal(18,2) NULL,
        [NetPrice] decimal(18,4) NULL,
        [NetAmount] decimal(18,2) NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WastePaperCost] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WastePaperCost_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WastePaperCost_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WastePaperCost_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WaterPreparationAndConsumption] (
        [RecId] int NOT NULL IDENTITY,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [InsertDate] datetime2 NOT NULL,
        [IncomingQuantity] decimal(18,2) NOT NULL,
        [ConsumedQuantity] decimal(18,2) NOT NULL,
        [RemainingQuantity] decimal(18,2) NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WaterPreparationAndConsumption] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WaterPreparationAndConsumption_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WaterPreparationAndConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WaterPreparationAndConsumption_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WaterTreatmentAnalysisResults] (
        [RecId] int NOT NULL IDENTITY,
        [SampleCollectionTime] int NOT NULL,
        [SampleResultDeliveryTime] int NOT NULL,
        [SampleTakenLocation] nvarchar(max) NOT NULL,
        [DryMatter] int NOT NULL,
        [Filling] real NOT NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WaterTreatmentAnalysisResults] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WaterTreatmentAnalysisResults_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WaterTreatmentAnalysisResults_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WaterTreatmentAnalysisResults_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WinderCoilLengthControl] (
        [RecId] int NOT NULL IDENTITY,
        [CoilWidth] decimal(18,2) NOT NULL,
        [WinderCoilLength] decimal(18,2) NOT NULL,
        [Gramaj] decimal(18,2) NOT NULL,
        [Weight] decimal(18,2) NOT NULL,
        [DepartmentId] int NOT NULL,
        [TheoreticCoilLength] decimal(18,2) NOT NULL,
        [CoilLengthDifference] decimal(18,2) NOT NULL,
        [CoilLengthDeflection] decimal(18,2) NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [AppUserId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WinderCoilLengthControl] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WinderCoilLengthControl_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WinderCoilLengthControl_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WinderCoilLengthControl_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_WinderCoilTracking] (
        [RecId] int NOT NULL IDENTITY,
        [AppUserId] int NOT NULL,
        [BufferNo] nvarchar(max) NOT NULL,
        [PaperType] nvarchar(max) NOT NULL,
        [SetNo] int NOT NULL,
        [Gramaj] int NOT NULL,
        [SetCutterStartDate] datetime2 NOT NULL,
        [SetCutterEndDate] datetime2 NOT NULL,
        [MachineSpeed] int NOT NULL,
        [CoilDiameter] real NOT NULL,
        [CoilLength] int NOT NULL,
        [OutDiamater] int NOT NULL,
        [AdditionalNumber] int NOT NULL,
        [DepartmentId] int NOT NULL,
        [ShiftId] int NOT NULL,
        [Coil1] int NULL,
        [Coil2] int NULL,
        [Coil3] int NULL,
        [Coil4] int NULL,
        [Coil5] int NULL,
        [Coil6] int NULL,
        [Coil7] int NULL,
        [Coil8] int NULL,
        [Explanation] nvarchar(max) NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_WinderCoilTracking] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_WinderCoilTracking_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WinderCoilTracking_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_WinderCoilTracking_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_BasinMeasurement] (
        [Id] int NOT NULL IDENTITY,
        [BasinId] int NOT NULL,
        [EnteranceAKM] decimal(18,2) NULL,
        [OutAKM] decimal(18,2) NULL,
        [EnteranceKOI] decimal(18,2) NULL,
        [OutKOI] decimal(18,2) NULL,
        [TN] decimal(18,2) NULL,
        [Fosfat] decimal(18,2) NULL,
        [pH] decimal(18,2) NULL,
        [Renk] decimal(18,2) NULL,
        [DO] decimal(18,2) NULL,
        [Imhoff] decimal(18,2) NULL,
        [StartHours] nvarchar(max) NOT NULL,
        [EndHours] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Db_BasinMeasurement] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Db_BasinMeasurement_Db_Basin_BasinId] FOREIGN KEY ([BasinId]) REFERENCES [Db_Basin] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_KazanChemicalsDetail] (
        [RecId] int NOT NULL IDENTITY,
        [Incoming] decimal(18,2) NOT NULL,
        [Consumption] decimal(18,2) NOT NULL,
        [Remaining] decimal(18,2) NOT NULL,
        [KazanChemicalsHeadId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_KazanChemicalsDetail] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_KazanChemicalsDetail_Db_KazanChemicalsHead_KazanChemicalsHeadId] FOREIGN KEY ([KazanChemicalsHeadId]) REFERENCES [Db_KazanChemicalsHead] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_StarchAnalysisHeadingDetail] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [Time] time NULL,
        [MachineSpeed] decimal(18,2) NULL,
        [ProductionType] nvarchar(max) NOT NULL,
        [Grammage] decimal(18,2) NULL,
        [TurnCount] int NULL,
        [Fau] decimal(18,2) NULL,
        [Ntu] decimal(18,2) NULL,
        [DryMatterOven] decimal(18,2) NULL,
        [DryMatterRefractometer] decimal(18,2) NULL,
        [Temperature1] decimal(18,2) NULL,
        [ViscosityCp1] decimal(18,2) NULL,
        [ViscosityFord1] int NULL,
        [StarchAnalysisHeadingId] int NOT NULL,
        CONSTRAINT [PK_Db_StarchAnalysisHeadingDetail] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_StarchAnalysisHeadingDetail_Db_StarchAnalysisHeading_StarchAnalysisHeadingId] FOREIGN KEY ([StarchAnalysisHeadingId]) REFERENCES [Db_StarchAnalysisHeading] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE TABLE [Db_TestDetail] (
        [RecId] int NOT NULL IDENTITY,
        [InletFlowRate] decimal(18,2) NULL,
        [InletDryMatterPercent] decimal(18,2) NULL,
        [PolyelectrolyteConcentration] decimal(18,2) NULL,
        [PolyelectrolyteFlowRate] decimal(18,2) NULL,
        [BowlSpeed] int NULL,
        [ActualTorque] int NULL,
        [ActualDifferentialSpeed] int NULL,
        [CentrateWeirLevel] int NULL,
        [CakeDryMatterPercent] decimal(18,2) NULL,
        [CentrateTSS] int NULL,
        [PolyelectrolyteConsumption] decimal(18,2) NULL,
        [BowlTorque] int NULL,
        [Vibration] int NULL,
        [EnergyConsumption] int NULL,
        [EnergyConsumptionPerFeed] decimal(18,2) NULL,
        [TestHeaderId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_TestDetail] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_TestDetail_Db_TestHeader_TestHeaderId] FOREIGN KEY ([TestHeaderId]) REFERENCES [Db_TestHeader] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_AspNetUsers_DepartmentId] ON [AspNetUsers] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_Basin_AppUserId] ON [Db_Basin] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_Basin_DepartmentId] ON [Db_Basin] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_Basin_ShiftId] ON [Db_Basin] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BasinMeasurement_BasinId] ON [Db_BasinMeasurement] ([BasinId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BoilerSteamFeedWaterCondensateData_AppUserId] ON [Db_BoilerSteamFeedWaterCondensateData] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BoilerSteamFeedWaterCondensateData_DepartmentId] ON [Db_BoilerSteamFeedWaterCondensateData] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BoilerSteamFeedWaterCondensateData_ShiftId] ON [Db_BoilerSteamFeedWaterCondensateData] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BufferAnalysisReport_AppUserId] ON [Db_BufferAnalysisReport] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BufferAnalysisReport_DepartmentId] ON [Db_BufferAnalysisReport] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BufferAnalysisReport_ShiftId] ON [Db_BufferAnalysisReport] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BufferGramajProfile_AppUserId] ON [Db_BufferGramajProfile] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BufferGramajProfile_DepartmentId] ON [Db_BufferGramajProfile] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_BufferGramajProfile_ShiftId] ON [Db_BufferGramajProfile] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_CirculationTankAirPressureMeasurementTurbidity_AppUserId] ON [Db_CirculationTankAirPressureMeasurementTurbidity] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_CirculationTankAirPressureMeasurementTurbidity_DepartmentId] ON [Db_CirculationTankAirPressureMeasurementTurbidity] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_CirculationTankAirPressureMeasurementTurbidity_ShiftId] ON [Db_CirculationTankAirPressureMeasurementTurbidity] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_DoughPreparation_AppUserId] ON [Db_DoughPreparation] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_DoughPreparation_DepartmentId] ON [Db_DoughPreparation] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_DoughPreparation_ShiftId] ON [Db_DoughPreparation] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_DoughPreparationAnalysisResults_AppUserId] ON [Db_DoughPreparationAnalysisResults] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_DoughPreparationAnalysisResults_DepartmentId] ON [Db_DoughPreparationAnalysisResults] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_DoughPreparationAnalysisResults_ShiftId] ON [Db_DoughPreparationAnalysisResults] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricMotorTracking_AppUserId] ON [Db_ElectricMotorTracking] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricMotorTracking_DepartmentId] ON [Db_ElectricMotorTracking] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricMotorTracking_ShiftId] ON [Db_ElectricMotorTracking] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricShiftWork_AppUserId] ON [Db_ElectricShiftWork] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricShiftWork_DepartmentId] ON [Db_ElectricShiftWork] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricShiftWork_ShiftId] ON [Db_ElectricShiftWork] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanChemicalsDetail_KazanChemicalsHeadId] ON [Db_KazanChemicalsDetail] ([KazanChemicalsHeadId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanChemicalsHead_AppUserId] ON [Db_KazanChemicalsHead] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanChemicalsHead_DepartmentId] ON [Db_KazanChemicalsHead] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanChemicalsHead_ShiftId] ON [Db_KazanChemicalsHead] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanDailyShiftMonitoring_AppUserId] ON [Db_KazanDailyShiftMonitoring] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanDailyShiftMonitoring_DepartmentId] ON [Db_KazanDailyShiftMonitoring] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanDailyShiftMonitoring_ShiftId] ON [Db_KazanDailyShiftMonitoring] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_KazanDailyShiftMonitoring_ShihtId] ON [Db_KazanDailyShiftMonitoring] ([ShihtId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_LabWork_AppUserId] ON [Db_LabWork] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_LabWork_DepartmentId] ON [Db_LabWork] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_LabWork_ShiftId] ON [Db_LabWork] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_LogisticsTrackingReport_AppUserId] ON [Db_LogisticsTrackingReport] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_LogisticsTrackingReport_DepartmentId] ON [Db_LogisticsTrackingReport] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_LogisticsTrackingReport_ShiftId] ON [Db_LogisticsTrackingReport] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_DB_MassWasteBalance_AppUserId] ON [DB_MassWasteBalance] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_DB_MassWasteBalance_DepartmentId] ON [DB_MassWasteBalance] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_DB_MassWasteBalance_ShiftId] ON [DB_MassWasteBalance] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_DB_MassWasteSupplier_AppUserId] ON [DB_MassWasteSupplier] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_DB_MassWasteSupplier_DepartmentId] ON [DB_MassWasteSupplier] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_DB_MassWasteSupplier_ShiftId] ON [DB_MassWasteSupplier] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_NaturelGasMeterMonitoring_AppUserId] ON [Db_NaturelGasMeterMonitoring] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_NaturelGasMeterMonitoring_DepartmentId] ON [Db_NaturelGasMeterMonitoring] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_NaturelGasMeterMonitoring_ShiftId] ON [Db_NaturelGasMeterMonitoring] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_OilAnalysisReport_AppUserId] ON [Db_OilAnalysisReport] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_OilAnalysisReport_DepartmentId] ON [Db_OilAnalysisReport] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_OilAnalysisReport_ShiftId] ON [Db_OilAnalysisReport] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_PapperMachineChemical_AppUserId] ON [Db_PapperMachineChemical] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_PapperMachineChemical_DepartmentId] ON [Db_PapperMachineChemical] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_PapperMachineChemical_ShiftId] ON [Db_PapperMachineChemical] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_PurificationChemicalsConsumption_AppUserId] ON [Db_PurificationChemicalsConsumption] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_PurificationChemicalsConsumption_DepartmentId] ON [Db_PurificationChemicalsConsumption] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_PurificationChemicalsConsumption_ShiftId] ON [Db_PurificationChemicalsConsumption] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_RolePermission_PermissionId] ON [Db_RolePermission] ([PermissionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SalesScale_AppUserId] ON [Db_SalesScale] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SalesScale_DepartmentId] ON [Db_SalesScale] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SalesScale_ShiftId] ON [Db_SalesScale] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SentezAllData_AppUserId] ON [Db_SentezAllData] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SentezAllData_DepartmentId] ON [Db_SentezAllData] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SentezAllData_ShiftId] ON [Db_SentezAllData] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SentezNotOrder_AppUserId] ON [Db_SentezNotOrder] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SentezNotOrder_DepartmentId] ON [Db_SentezNotOrder] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SentezNotOrder_ShiftId] ON [Db_SentezNotOrder] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_StarchAnalysisHeading_AppUserId] ON [Db_StarchAnalysisHeading] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_StarchAnalysisHeading_DepartmentId] ON [Db_StarchAnalysisHeading] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_StarchAnalysisHeading_ShiftId] ON [Db_StarchAnalysisHeading] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_StarchAnalysisHeadingDetail_StarchAnalysisHeadingId] ON [Db_StarchAnalysisHeadingDetail] ([StarchAnalysisHeadingId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SteamConsumption_AppUserId] ON [Db_SteamConsumption] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SteamConsumption_DepartmentId] ON [Db_SteamConsumption] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_SteamConsumption_ShiftId] ON [Db_SteamConsumption] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_TestDetail_TestHeaderId] ON [Db_TestDetail] ([TestHeaderId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_TestHeader_AppUserId] ON [Db_TestHeader] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_TestHeader_DepartmentId] ON [Db_TestHeader] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_TestHeader_ShiftId] ON [Db_TestHeader] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_VechileFuelLogs_AppUserId] ON [Db_VechileFuelLogs] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_VechileFuelLogs_DepartmentId] ON [Db_VechileFuelLogs] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_VechileFuelLogs_ShiftId] ON [Db_VechileFuelLogs] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WarehouseRequestWait_AppUserId] ON [Db_WarehouseRequestWait] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WarehouseRequestWait_DepartmentId] ON [Db_WarehouseRequestWait] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WarehouseRequestWait_ShiftId] ON [Db_WarehouseRequestWait] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WastePaperControl_AppUserId] ON [Db_WastePaperControl] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WastePaperControl_DepartmentId] ON [Db_WastePaperControl] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WastePaperControl_ShiftId] ON [Db_WastePaperControl] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WastePaperCost_AppUserId] ON [Db_WastePaperCost] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WastePaperCost_DepartmentId] ON [Db_WastePaperCost] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WastePaperCost_ShiftId] ON [Db_WastePaperCost] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WaterPreparationAndConsumption_AppUserId] ON [Db_WaterPreparationAndConsumption] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WaterPreparationAndConsumption_DepartmentId] ON [Db_WaterPreparationAndConsumption] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WaterPreparationAndConsumption_ShiftId] ON [Db_WaterPreparationAndConsumption] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WaterTreatmentAnalysisResults_AppUserId] ON [Db_WaterTreatmentAnalysisResults] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WaterTreatmentAnalysisResults_DepartmentId] ON [Db_WaterTreatmentAnalysisResults] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WaterTreatmentAnalysisResults_ShiftId] ON [Db_WaterTreatmentAnalysisResults] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WinderCoilLengthControl_AppUserId] ON [Db_WinderCoilLengthControl] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WinderCoilLengthControl_DepartmentId] ON [Db_WinderCoilLengthControl] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WinderCoilLengthControl_ShiftId] ON [Db_WinderCoilLengthControl] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WinderCoilTracking_AppUserId] ON [Db_WinderCoilTracking] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WinderCoilTracking_DepartmentId] ON [Db_WinderCoilTracking] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    CREATE INDEX [IX_Db_WinderCoilTracking_ShiftId] ON [Db_WinderCoilTracking] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260515122108_MassBalanceSystem'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260515122108_MassBalanceSystem', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260520062650_date'
)
BEGIN
    ALTER TABLE [Db_PapperMachineChemical] ADD [Date] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260520062650_date'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260520062650_date', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260520100246_up'
)
BEGIN
    EXEC sp_rename N'[Db_SentezNotOrder].[Id]', N'RecId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260520100246_up'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260520100246_up', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260522050028_updateElectricMotorTracking'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricMotorTracking]') AND [c].[name] = N'Voltage');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricMotorTracking] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Db_ElectricMotorTracking] ALTER COLUMN [Voltage] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260522050028_updateElectricMotorTracking'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260522050028_updateElectricMotorTracking', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260527170930_upsdateRecId'
)
BEGIN
    EXEC sp_rename N'[Db_LabWork].[Recıd]', N'RecId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260527170930_upsdateRecId'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260527170930_upsdateRecId', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260601065612_migs'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_OilAnalysisReport]') AND [c].[name] = N'MyProperty');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Db_OilAnalysisReport] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Db_OilAnalysisReport] DROP COLUMN [MyProperty];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260601065612_migs'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260601065612_migs', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260601070334_OilUpdateded'
)
BEGIN
    ALTER TABLE [Db_OilAnalysisReport] ADD [LocationSampleWasTaken] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260601070334_OilUpdateded'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260601070334_OilUpdateded', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    EXEC sp_rename N'[Db_Permission].[Name]', N'Controller', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    ALTER TABLE [Db_Permission] ADD [Action] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    ALTER TABLE [Db_Permission] ADD [Controller] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    CREATE TABLE [Db_RetentionAnalysisHead] (
        [RecId] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [SampleCollectionTime] time NULL,
        [SampleResultTime] time NULL,
        [MachineSpeedRpm] decimal(18,2) NULL,
        [BasisWeightGrM2] decimal(18,2) NULL,
        [ProductionType] nvarchar(max) NULL,
        [RetentionPercent] decimal(18,2) NULL,
        [RetentionFeedLtMin] decimal(18,2) NULL,
        [PulpFlowLtMin] decimal(18,2) NULL,
        [UnderScreenCaCO3] decimal(18,2) NULL,
        [SilicaLtHour] decimal(18,2) NULL,
        [AtcFeedLtHour] decimal(18,2) NULL,
        [PlydacmacFeedLtHour] decimal(18,2) NULL,
        [PacFeedLtHour] decimal(18,2) NULL,
        [DiscFilterPulpFlowLtMin] decimal(18,2) NULL,
        [Location] nvarchar(max) NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [DepartmentId] int NOT NULL,
        [AppUserId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [ShiftId] int NOT NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_RetentionAnalysisHead] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Db_RetentionAnalysisHead_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    CREATE TABLE [Db_RetantionAnalysisDetail] (
        [RecId] int NOT NULL IDENTITY,
        [LocationName] nvarchar(max) NOT NULL,
        [ConsistencyPercent] decimal(18,2) NULL,
        [AshGr] decimal(18,2) NULL,
        [FillerPercent] decimal(18,2) NULL,
        [SrDegree] decimal(18,2) NULL,
        [Ph] decimal(18,2) NULL,
        [RetentionAnalysisHeadId] int NOT NULL,
        CONSTRAINT [PK_Db_RetantionAnalysisDetail] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_RetantionAnalysisDetail_Db_RetentionAnalysisHead_RetentionAnalysisHeadId] FOREIGN KEY ([RetentionAnalysisHeadId]) REFERENCES [Db_RetentionAnalysisHead] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    CREATE INDEX [IX_Db_RetantionAnalysisDetail_RetentionAnalysisHeadId] ON [Db_RetantionAnalysisDetail] ([RetentionAnalysisHeadId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    CREATE INDEX [IX_Db_RetentionAnalysisHead_AppUserId] ON [Db_RetentionAnalysisHead] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    CREATE INDEX [IX_Db_RetentionAnalysisHead_DepartmentId] ON [Db_RetentionAnalysisHead] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    CREATE INDEX [IX_Db_RetentionAnalysisHead_ShiftId] ON [Db_RetentionAnalysisHead] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260604084601_migRoles'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260604084601_migRoles', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    CREATE TABLE [Db_PlcMachine] (
        [RecId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [IpAddress] nvarchar(max) NOT NULL,
        [Rack] int NOT NULL,
        [Slot] int NOT NULL,
        [CpuType] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        CONSTRAINT [PK_Db_PlcMachine] PRIMARY KEY ([RecId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    CREATE TABLE [Db_PlcTags] (
        [RecId] int NOT NULL IDENTITY,
        [TagName] nvarchar(max) NOT NULL,
        [DisplayName] nvarchar(max) NOT NULL,
        [Unit] nvarchar(max) NOT NULL,
        [Group] nvarchar(max) NOT NULL,
        [DataAddress] nvarchar(max) NOT NULL,
        [DataType] nvarchar(max) NOT NULL,
        [IsActive] bit NOT NULL,
        [MachineId] int NOT NULL,
        CONSTRAINT [PK_Db_PlcTags] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_PlcTags_Db_PlcMachine_MachineId] FOREIGN KEY ([MachineId]) REFERENCES [Db_PlcMachine] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    CREATE TABLE [Db_PlcReading] (
        [RecId] int NOT NULL IDENTITY,
        [ReadingTime] datetime2 NOT NULL,
        [Value] float NOT NULL,
        [PlcTagId] int NOT NULL,
        CONSTRAINT [PK_Db_PlcReading] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_PlcReading_Db_PlcTags_PlcTagId] FOREIGN KEY ([PlcTagId]) REFERENCES [Db_PlcTags] ([RecId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    CREATE INDEX [IX_Db_PlcReading_PlcTagId] ON [Db_PlcReading] ([PlcTagId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    CREATE INDEX [IX_Db_PlcReading_ReadingTime] ON [Db_PlcReading] ([ReadingTime]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    CREATE INDEX [IX_Db_PlcTags_MachineId] ON [Db_PlcTags] ([MachineId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260608064422_plcIntegrations'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260608064422_plcIntegrations', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE TABLE [Dd_ElectricMeterLocation] (
        [RecId] int NOT NULL IDENTITY,
        [LocationName] nvarchar(max) NOT NULL,
        [Explanation] nvarchar(max) NULL,
        [InsertDate] datetime2 NOT NULL,
        [UpdateDate] datetime2 NOT NULL,
        [DeleteDate] datetime2 NOT NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        CONSTRAINT [PK_Dd_ElectricMeterLocation] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Dd_ElectricMeterLocation_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Dd_ElectricMeterLocation_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE TABLE [Db_CumulativeElectricityConsumption] (
        [RecId] int NOT NULL IDENTITY,
        [Year] int NOT NULL,
        [Month] int NOT NULL,
        [Consumption] decimal(18,2) NOT NULL,
        [Date] datetime2 NOT NULL,
        [InsertDate] datetime2 NOT NULL,
        [DeleteDate] datetime2 NOT NULL,
        [UpdateDate] datetime2 NOT NULL,
        [ElectricMeterLocationId] int NOT NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        CONSTRAINT [PK_Db_CumulativeElectricityConsumption] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Dd_ElectricMeterLocation_ElectricMeterLocationId] FOREIGN KEY ([ElectricMeterLocationId]) REFERENCES [Dd_ElectricMeterLocation] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE INDEX [IX_Db_CumulativeElectricityConsumption_AppUserId] ON [Db_CumulativeElectricityConsumption] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE INDEX [IX_Db_CumulativeElectricityConsumption_ElectricMeterLocationId] ON [Db_CumulativeElectricityConsumption] ([ElectricMeterLocationId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE INDEX [IX_Db_CumulativeElectricityConsumption_ShiftId] ON [Db_CumulativeElectricityConsumption] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE INDEX [IX_Dd_ElectricMeterLocation_AppUserId] ON [Dd_ElectricMeterLocation] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    CREATE INDEX [IX_Dd_ElectricMeterLocation_ShiftId] ON [Dd_ElectricMeterLocation] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615061958_migelectircCum'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260615061958_migelectircCum', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Dd_ElectricMeterLocation]') AND [c].[name] = N'UpdateDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Dd_ElectricMeterLocation] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Dd_ElectricMeterLocation] ALTER COLUMN [UpdateDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Dd_ElectricMeterLocation]') AND [c].[name] = N'InsertDate');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Dd_ElectricMeterLocation] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Dd_ElectricMeterLocation] ALTER COLUMN [InsertDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Dd_ElectricMeterLocation]') AND [c].[name] = N'DeleteDate');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Dd_ElectricMeterLocation] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Dd_ElectricMeterLocation] ALTER COLUMN [DeleteDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CumulativeElectricityConsumption]') AND [c].[name] = N'UpdateDate');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Db_CumulativeElectricityConsumption] ALTER COLUMN [UpdateDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CumulativeElectricityConsumption]') AND [c].[name] = N'InsertDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Db_CumulativeElectricityConsumption] ALTER COLUMN [InsertDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CumulativeElectricityConsumption]') AND [c].[name] = N'DeleteDate');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Db_CumulativeElectricityConsumption] ALTER COLUMN [DeleteDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615062817_migelectircCum1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260615062817_migelectircCum1', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Dd_ElectricMeterLocation_ElectricMeterLocationId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Dd_ElectricMeterLocation] DROP CONSTRAINT [FK_Dd_ElectricMeterLocation_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Dd_ElectricMeterLocation] DROP CONSTRAINT [FK_Dd_ElectricMeterLocation_Db_Shift_ShiftId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Dd_ElectricMeterLocation] DROP CONSTRAINT [PK_Dd_ElectricMeterLocation];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    EXEC sp_rename N'[Dd_ElectricMeterLocation]', N'Db_ElectricMeterLocation';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    EXEC sp_rename N'[Db_ElectricMeterLocation].[IX_Dd_ElectricMeterLocation_ShiftId]', N'IX_Db_ElectricMeterLocation_ShiftId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    EXEC sp_rename N'[Db_ElectricMeterLocation].[IX_Dd_ElectricMeterLocation_AppUserId]', N'IX_Db_ElectricMeterLocation_AppUserId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD [DepartmentId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD [DepartmentId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD CONSTRAINT [PK_Db_ElectricMeterLocation] PRIMARY KEY ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    CREATE INDEX [IX_Db_CumulativeElectricityConsumption_DepartmentId] ON [Db_CumulativeElectricityConsumption] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    CREATE INDEX [IX_Db_ElectricMeterLocation_DepartmentId] ON [Db_ElectricMeterLocation] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD CONSTRAINT [FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Db_ElectricMeterLocation_ElectricMeterLocationId] FOREIGN KEY ([ElectricMeterLocationId]) REFERENCES [Db_ElectricMeterLocation] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD CONSTRAINT [FK_Db_ElectricMeterLocation_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD CONSTRAINT [FK_Db_ElectricMeterLocation_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD CONSTRAINT [FK_Db_ElectricMeterLocation_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260615080822_update1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260615080822_update1', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260616124634_migkazanUpdate'
)
BEGIN
    DROP TABLE [Db_KazanChemicalsDetail];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260616124634_migkazanUpdate'
)
BEGIN
    ALTER TABLE [Db_KazanChemicalsHead] ADD [Consumption] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260616124634_migkazanUpdate'
)
BEGIN
    ALTER TABLE [Db_KazanChemicalsHead] ADD [Incoming] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260616124634_migkazanUpdate'
)
BEGIN
    ALTER TABLE [Db_KazanChemicalsHead] ADD [Remaining] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260616124634_migkazanUpdate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260616124634_migkazanUpdate', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] DROP CONSTRAINT [FK_Db_ElectricMeterLocation_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_KazanDailyShiftMonitoring] DROP CONSTRAINT [FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShihtId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteBalance] DROP CONSTRAINT [FK_DB_MassWasteBalance_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteBalance] DROP CONSTRAINT [FK_DB_MassWasteBalance_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteBalance] DROP CONSTRAINT [FK_DB_MassWasteBalance_Db_Shift_ShiftId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteSupplier] DROP CONSTRAINT [FK_DB_MassWasteSupplier_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteSupplier] DROP CONSTRAINT [FK_DB_MassWasteSupplier_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteSupplier] DROP CONSTRAINT [FK_DB_MassWasteSupplier_Db_Shift_ShiftId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [FK_Db_SentezNotOrder_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [FK_Db_SentezNotOrder_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [FK_Db_SentezNotOrder_Db_Shift_ShiftId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteSupplier] DROP CONSTRAINT [PK_DB_MassWasteSupplier];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [DB_MassWasteBalance] DROP CONSTRAINT [PK_DB_MassWasteBalance];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DROP INDEX [IX_Db_KazanDailyShiftMonitoring_ShihtId] ON [Db_KazanDailyShiftMonitoring];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanDailyShiftMonitoring]') AND [c].[name] = N'ShihtId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanDailyShiftMonitoring] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Db_KazanDailyShiftMonitoring] DROP COLUMN [ShihtId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[DB_MassWasteSupplier]', N'Db_MassWasteSupplier';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[DB_MassWasteBalance]', N'Db_MassWasteBalance';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_MassWasteSupplier].[IX_DB_MassWasteSupplier_ShiftId]', N'IX_Db_MassWasteSupplier_ShiftId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_MassWasteSupplier].[IX_DB_MassWasteSupplier_DepartmentId]', N'IX_Db_MassWasteSupplier_DepartmentId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_MassWasteSupplier].[IX_DB_MassWasteSupplier_AppUserId]', N'IX_Db_MassWasteSupplier_AppUserId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_MassWasteBalance].[IX_DB_MassWasteBalance_ShiftId]', N'IX_Db_MassWasteBalance_ShiftId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_MassWasteBalance].[IX_DB_MassWasteBalance_DepartmentId]', N'IX_Db_MassWasteBalance_DepartmentId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_MassWasteBalance].[IX_DB_MassWasteBalance_AppUserId]', N'IX_Db_MassWasteBalance_AppUserId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_ElectricMeterLocation].[InsertDate]', N'ReceiptDate', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_ElectricMeterLocation].[DepartmentId]', N'DepartmentId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_ElectricMeterLocation].[IX_Db_ElectricMeterLocation_DepartmentId]', N'IX_Db_ElectricMeterLocation_DepartmentId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_CumulativeElectricityConsumption].[InsertDate]', N'ReceiptDate', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_CumulativeElectricityConsumption].[DepartmentId]', N'DepartmentId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    EXEC sp_rename N'[Db_CumulativeElectricityConsumption].[IX_Db_CumulativeElectricityConsumption_DepartmentId]', N'IX_Db_CumulativeElectricityConsumption_DepartmentId', N'INDEX';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WinderCoilTracking]') AND [c].[name] = N'ShiftId');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Db_WinderCoilTracking] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Db_WinderCoilTracking] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WinderCoilTracking]') AND [c].[name] = N'AppUserId');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Db_WinderCoilTracking] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Db_WinderCoilTracking] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WinderCoilTracking] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WinderCoilLengthControl]') AND [c].[name] = N'ShiftId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Db_WinderCoilLengthControl] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Db_WinderCoilLengthControl] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WinderCoilLengthControl]') AND [c].[name] = N'AppUserId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Db_WinderCoilLengthControl] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Db_WinderCoilLengthControl] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WinderCoilLengthControl] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WaterTreatmentAnalysisResults]') AND [c].[name] = N'ShiftId');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Db_WaterTreatmentAnalysisResults] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Db_WaterTreatmentAnalysisResults] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WaterTreatmentAnalysisResults]') AND [c].[name] = N'AppUserId');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Db_WaterTreatmentAnalysisResults] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Db_WaterTreatmentAnalysisResults] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WaterTreatmentAnalysisResults] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WaterPreparationAndConsumption]') AND [c].[name] = N'ShiftId');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Db_WaterPreparationAndConsumption] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Db_WaterPreparationAndConsumption] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WaterPreparationAndConsumption]') AND [c].[name] = N'AppUserId');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Db_WaterPreparationAndConsumption] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Db_WaterPreparationAndConsumption] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WaterPreparationAndConsumption] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperCost]') AND [c].[name] = N'ShiftId');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperCost] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Db_WastePaperCost] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperCost]') AND [c].[name] = N'AppUserId');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperCost] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Db_WastePaperCost] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WastePaperCost] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperControl]') AND [c].[name] = N'ShiftId');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperControl] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Db_WastePaperControl] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperControl]') AND [c].[name] = N'AppUserId');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperControl] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [Db_WastePaperControl] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WastePaperControl] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WarehouseRequestWait]') AND [c].[name] = N'ShiftId');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Db_WarehouseRequestWait] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [Db_WarehouseRequestWait] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WarehouseRequestWait]') AND [c].[name] = N'AppUserId');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Db_WarehouseRequestWait] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [Db_WarehouseRequestWait] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_WarehouseRequestWait] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_VechileFuelLogs]') AND [c].[name] = N'ShiftId');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Db_VechileFuelLogs] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [Db_VechileFuelLogs] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_VechileFuelLogs]') AND [c].[name] = N'AppUserId');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Db_VechileFuelLogs] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Db_VechileFuelLogs] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_VechileFuelLogs] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_TestHeader]') AND [c].[name] = N'ShiftId');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Db_TestHeader] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Db_TestHeader] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_TestHeader]') AND [c].[name] = N'AppUserId');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Db_TestHeader] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Db_TestHeader] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_TestHeader] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SteamConsumption]') AND [c].[name] = N'ShiftId');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Db_SteamConsumption] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [Db_SteamConsumption] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SteamConsumption]') AND [c].[name] = N'AppUserId');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Db_SteamConsumption] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Db_SteamConsumption] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SteamConsumption] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_StarchAnalysisHeading]') AND [c].[name] = N'ShiftId');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Db_StarchAnalysisHeading] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Db_StarchAnalysisHeading] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_StarchAnalysisHeading]') AND [c].[name] = N'AppUserId');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Db_StarchAnalysisHeading] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [Db_StarchAnalysisHeading] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_StarchAnalysisHeading] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezNotOrder]') AND [c].[name] = N'ShiftId');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [Db_SentezNotOrder] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DROP INDEX [IX_Db_SentezNotOrder_DepartmentId] ON [Db_SentezNotOrder];
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezNotOrder]') AND [c].[name] = N'DepartmentId');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [' + @var32 + '];');
    EXEC(N'UPDATE [Db_SentezNotOrder] SET [DepartmentId] = 0 WHERE [DepartmentId] IS NULL');
    ALTER TABLE [Db_SentezNotOrder] ALTER COLUMN [DepartmentId] int NOT NULL;
    ALTER TABLE [Db_SentezNotOrder] ADD DEFAULT 0 FOR [DepartmentId];
    CREATE INDEX [IX_Db_SentezNotOrder_DepartmentId] ON [Db_SentezNotOrder] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezNotOrder]') AND [c].[name] = N'AppUserId');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [Db_SentezNotOrder] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezAllData]') AND [c].[name] = N'ShiftId');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezAllData] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [Db_SentezAllData] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezAllData]') AND [c].[name] = N'AppUserId');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezAllData] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [Db_SentezAllData] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezAllData] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SalesScale]') AND [c].[name] = N'ShiftId');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [Db_SalesScale] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [Db_SalesScale] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SalesScale]') AND [c].[name] = N'AppUserId');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [Db_SalesScale] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [Db_SalesScale] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SalesScale] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_RetentionAnalysisHead]') AND [c].[name] = N'ShiftId');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [Db_RetentionAnalysisHead] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_RetentionAnalysisHead]') AND [c].[name] = N'AppUserId');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [Db_RetentionAnalysisHead] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PurificationChemicalsConsumption]') AND [c].[name] = N'ShiftId');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [Db_PurificationChemicalsConsumption] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [Db_PurificationChemicalsConsumption] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PurificationChemicalsConsumption]') AND [c].[name] = N'AppUserId');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [Db_PurificationChemicalsConsumption] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [Db_PurificationChemicalsConsumption] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PapperMachineChemical]') AND [c].[name] = N'ShiftId');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [Db_PapperMachineChemical] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [Db_PapperMachineChemical] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PapperMachineChemical]') AND [c].[name] = N'AppUserId');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [Db_PapperMachineChemical] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [Db_PapperMachineChemical] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_PapperMachineChemical] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_OilAnalysisReport]') AND [c].[name] = N'ShiftId');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [Db_OilAnalysisReport] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [Db_OilAnalysisReport] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_OilAnalysisReport]') AND [c].[name] = N'AppUserId');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [Db_OilAnalysisReport] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [Db_OilAnalysisReport] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_OilAnalysisReport] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_NaturelGasMeterMonitoring]') AND [c].[name] = N'ShiftId');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [Db_NaturelGasMeterMonitoring] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [Db_NaturelGasMeterMonitoring] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var47 sysname;
    SELECT @var47 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_NaturelGasMeterMonitoring]') AND [c].[name] = N'AppUserId');
    IF @var47 IS NOT NULL EXEC(N'ALTER TABLE [Db_NaturelGasMeterMonitoring] DROP CONSTRAINT [' + @var47 + '];');
    ALTER TABLE [Db_NaturelGasMeterMonitoring] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_NaturelGasMeterMonitoring] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var48 sysname;
    SELECT @var48 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MassWasteSupplier]') AND [c].[name] = N'ShiftId');
    IF @var48 IS NOT NULL EXEC(N'ALTER TABLE [Db_MassWasteSupplier] DROP CONSTRAINT [' + @var48 + '];');
    ALTER TABLE [Db_MassWasteSupplier] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var49 sysname;
    SELECT @var49 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MassWasteSupplier]') AND [c].[name] = N'AppUserId');
    IF @var49 IS NOT NULL EXEC(N'ALTER TABLE [Db_MassWasteSupplier] DROP CONSTRAINT [' + @var49 + '];');
    ALTER TABLE [Db_MassWasteSupplier] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteSupplier] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var50 sysname;
    SELECT @var50 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MassWasteBalance]') AND [c].[name] = N'ShiftId');
    IF @var50 IS NOT NULL EXEC(N'ALTER TABLE [Db_MassWasteBalance] DROP CONSTRAINT [' + @var50 + '];');
    ALTER TABLE [Db_MassWasteBalance] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var51 sysname;
    SELECT @var51 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MassWasteBalance]') AND [c].[name] = N'AppUserId');
    IF @var51 IS NOT NULL EXEC(N'ALTER TABLE [Db_MassWasteBalance] DROP CONSTRAINT [' + @var51 + '];');
    ALTER TABLE [Db_MassWasteBalance] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteBalance] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var52 sysname;
    SELECT @var52 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LogisticsTrackingReport]') AND [c].[name] = N'ShiftId');
    IF @var52 IS NOT NULL EXEC(N'ALTER TABLE [Db_LogisticsTrackingReport] DROP CONSTRAINT [' + @var52 + '];');
    ALTER TABLE [Db_LogisticsTrackingReport] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var53 sysname;
    SELECT @var53 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LogisticsTrackingReport]') AND [c].[name] = N'AppUserId');
    IF @var53 IS NOT NULL EXEC(N'ALTER TABLE [Db_LogisticsTrackingReport] DROP CONSTRAINT [' + @var53 + '];');
    ALTER TABLE [Db_LogisticsTrackingReport] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_LogisticsTrackingReport] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var54 sysname;
    SELECT @var54 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LabWork]') AND [c].[name] = N'ShiftId');
    IF @var54 IS NOT NULL EXEC(N'ALTER TABLE [Db_LabWork] DROP CONSTRAINT [' + @var54 + '];');
    ALTER TABLE [Db_LabWork] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var55 sysname;
    SELECT @var55 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LabWork]') AND [c].[name] = N'AppUserId');
    IF @var55 IS NOT NULL EXEC(N'ALTER TABLE [Db_LabWork] DROP CONSTRAINT [' + @var55 + '];');
    ALTER TABLE [Db_LabWork] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_LabWork] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var56 sysname;
    SELECT @var56 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanDailyShiftMonitoring]') AND [c].[name] = N'ShiftId');
    IF @var56 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanDailyShiftMonitoring] DROP CONSTRAINT [' + @var56 + '];');
    ALTER TABLE [Db_KazanDailyShiftMonitoring] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var57 sysname;
    SELECT @var57 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanDailyShiftMonitoring]') AND [c].[name] = N'AppUserId');
    IF @var57 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanDailyShiftMonitoring] DROP CONSTRAINT [' + @var57 + '];');
    ALTER TABLE [Db_KazanDailyShiftMonitoring] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_KazanDailyShiftMonitoring] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var58 sysname;
    SELECT @var58 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanChemicalsHead]') AND [c].[name] = N'ShiftId');
    IF @var58 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanChemicalsHead] DROP CONSTRAINT [' + @var58 + '];');
    ALTER TABLE [Db_KazanChemicalsHead] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var59 sysname;
    SELECT @var59 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanChemicalsHead]') AND [c].[name] = N'AppUserId');
    IF @var59 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanChemicalsHead] DROP CONSTRAINT [' + @var59 + '];');
    ALTER TABLE [Db_KazanChemicalsHead] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_KazanChemicalsHead] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var60 sysname;
    SELECT @var60 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricShiftWork]') AND [c].[name] = N'ShiftId');
    IF @var60 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricShiftWork] DROP CONSTRAINT [' + @var60 + '];');
    ALTER TABLE [Db_ElectricShiftWork] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var61 sysname;
    SELECT @var61 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricShiftWork]') AND [c].[name] = N'AppUserId');
    IF @var61 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricShiftWork] DROP CONSTRAINT [' + @var61 + '];');
    ALTER TABLE [Db_ElectricShiftWork] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricShiftWork] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var62 sysname;
    SELECT @var62 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricMotorTracking]') AND [c].[name] = N'ShiftId');
    IF @var62 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricMotorTracking] DROP CONSTRAINT [' + @var62 + '];');
    ALTER TABLE [Db_ElectricMotorTracking] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var63 sysname;
    SELECT @var63 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricMotorTracking]') AND [c].[name] = N'AppUserId');
    IF @var63 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricMotorTracking] DROP CONSTRAINT [' + @var63 + '];');
    ALTER TABLE [Db_ElectricMotorTracking] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMotorTracking] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD [DeletedBy] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD [InUse] smallint NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD [InsertDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD [UpdatedBy] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var64 sysname;
    SELECT @var64 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparationAnalysisResults]') AND [c].[name] = N'ShiftId');
    IF @var64 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparationAnalysisResults] DROP CONSTRAINT [' + @var64 + '];');
    ALTER TABLE [Db_DoughPreparationAnalysisResults] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var65 sysname;
    SELECT @var65 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparationAnalysisResults]') AND [c].[name] = N'AppUserId');
    IF @var65 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparationAnalysisResults] DROP CONSTRAINT [' + @var65 + '];');
    ALTER TABLE [Db_DoughPreparationAnalysisResults] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_DoughPreparationAnalysisResults] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var66 sysname;
    SELECT @var66 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparation]') AND [c].[name] = N'ShiftId');
    IF @var66 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparation] DROP CONSTRAINT [' + @var66 + '];');
    ALTER TABLE [Db_DoughPreparation] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var67 sysname;
    SELECT @var67 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparation]') AND [c].[name] = N'AppUserId');
    IF @var67 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparation] DROP CONSTRAINT [' + @var67 + '];');
    ALTER TABLE [Db_DoughPreparation] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_DoughPreparation] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD [DeletedBy] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD [InUse] smallint NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD [InsertDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD [UpdatedBy] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var68 sysname;
    SELECT @var68 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CirculationTankAirPressureMeasurementTurbidity]') AND [c].[name] = N'ShiftId');
    IF @var68 IS NOT NULL EXEC(N'ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] DROP CONSTRAINT [' + @var68 + '];');
    ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var69 sysname;
    SELECT @var69 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CirculationTankAirPressureMeasurementTurbidity]') AND [c].[name] = N'AppUserId');
    IF @var69 IS NOT NULL EXEC(N'ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] DROP CONSTRAINT [' + @var69 + '];');
    ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var70 sysname;
    SELECT @var70 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferGramajProfile]') AND [c].[name] = N'ShiftId');
    IF @var70 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferGramajProfile] DROP CONSTRAINT [' + @var70 + '];');
    ALTER TABLE [Db_BufferGramajProfile] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var71 sysname;
    SELECT @var71 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferGramajProfile]') AND [c].[name] = N'AppUserId');
    IF @var71 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferGramajProfile] DROP CONSTRAINT [' + @var71 + '];');
    ALTER TABLE [Db_BufferGramajProfile] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_BufferGramajProfile] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var72 sysname;
    SELECT @var72 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferAnalysisReport]') AND [c].[name] = N'ShiftId');
    IF @var72 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferAnalysisReport] DROP CONSTRAINT [' + @var72 + '];');
    ALTER TABLE [Db_BufferAnalysisReport] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var73 sysname;
    SELECT @var73 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferAnalysisReport]') AND [c].[name] = N'AppUserId');
    IF @var73 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferAnalysisReport] DROP CONSTRAINT [' + @var73 + '];');
    ALTER TABLE [Db_BufferAnalysisReport] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_BufferAnalysisReport] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var74 sysname;
    SELECT @var74 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BoilerSteamFeedWaterCondensateData]') AND [c].[name] = N'ShiftId');
    IF @var74 IS NOT NULL EXEC(N'ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] DROP CONSTRAINT [' + @var74 + '];');
    ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var75 sysname;
    SELECT @var75 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BoilerSteamFeedWaterCondensateData]') AND [c].[name] = N'AppUserId');
    IF @var75 IS NOT NULL EXEC(N'ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] DROP CONSTRAINT [' + @var75 + '];');
    ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var76 sysname;
    SELECT @var76 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_Basin]') AND [c].[name] = N'ShiftId');
    IF @var76 IS NOT NULL EXEC(N'ALTER TABLE [Db_Basin] DROP CONSTRAINT [' + @var76 + '];');
    ALTER TABLE [Db_Basin] ALTER COLUMN [ShiftId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    DECLARE @var77 sysname;
    SELECT @var77 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_Basin]') AND [c].[name] = N'AppUserId');
    IF @var77 IS NOT NULL EXEC(N'ALTER TABLE [Db_Basin] DROP CONSTRAINT [' + @var77 + '];');
    ALTER TABLE [Db_Basin] ALTER COLUMN [AppUserId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_Basin] ADD [ReceiptDate] datetime2 NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteSupplier] ADD CONSTRAINT [PK_Db_MassWasteSupplier] PRIMARY KEY ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteBalance] ADD CONSTRAINT [PK_Db_MassWasteBalance] PRIMARY KEY ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    CREATE TABLE [Db_BoilerRoomDailyShiftMonitoring] (
        [RecId] int NOT NULL IDENTITY,
        [PersonelToWork] nvarchar(max) NOT NULL,
        [WorkIsDone] bit NOT NULL,
        [Explanation] nvarchar(max) NOT NULL,
        [WorkPermit] bit NOT NULL,
        [NextShiftWork] nvarchar(max) NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_BoilerRoomDailyShiftMonitoring] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_BoilerRoomDailyShiftMonitoring_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BoilerRoomDailyShiftMonitoring_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BoilerRoomDailyShiftMonitoring_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    CREATE INDEX [IX_Db_BoilerRoomDailyShiftMonitoring_AppUserId] ON [Db_BoilerRoomDailyShiftMonitoring] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    CREATE INDEX [IX_Db_BoilerRoomDailyShiftMonitoring_DepartmentId] ON [Db_BoilerRoomDailyShiftMonitoring] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    CREATE INDEX [IX_Db_BoilerRoomDailyShiftMonitoring_ShiftId] ON [Db_BoilerRoomDailyShiftMonitoring] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_CumulativeElectricityConsumption] ADD CONSTRAINT [FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_ElectricMeterLocation] ADD CONSTRAINT [FK_Db_ElectricMeterLocation_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteBalance] ADD CONSTRAINT [FK_Db_MassWasteBalance_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteBalance] ADD CONSTRAINT [FK_Db_MassWasteBalance_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteBalance] ADD CONSTRAINT [FK_Db_MassWasteBalance_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteSupplier] ADD CONSTRAINT [FK_Db_MassWasteSupplier_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteSupplier] ADD CONSTRAINT [FK_Db_MassWasteSupplier_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_MassWasteSupplier] ADD CONSTRAINT [FK_Db_MassWasteSupplier_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] ADD CONSTRAINT [FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] ADD CONSTRAINT [FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] ADD CONSTRAINT [FK_Db_SentezNotOrder_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] ADD CONSTRAINT [FK_Db_SentezNotOrder_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] ADD CONSTRAINT [FK_Db_SentezNotOrder_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622071907_DbRefactoring1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260622071907_DbRefactoring1', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var78 sysname;
    SELECT @var78 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperCost]') AND [c].[name] = N'Date');
    IF @var78 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperCost] DROP CONSTRAINT [' + @var78 + '];');
    ALTER TABLE [Db_WastePaperCost] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var79 sysname;
    SELECT @var79 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperControl]') AND [c].[name] = N'Date');
    IF @var79 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperControl] DROP CONSTRAINT [' + @var79 + '];');
    ALTER TABLE [Db_WastePaperControl] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var80 sysname;
    SELECT @var80 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_VechileFuelLogs]') AND [c].[name] = N'Date');
    IF @var80 IS NOT NULL EXEC(N'ALTER TABLE [Db_VechileFuelLogs] DROP CONSTRAINT [' + @var80 + '];');
    ALTER TABLE [Db_VechileFuelLogs] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var81 sysname;
    SELECT @var81 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SteamConsumption]') AND [c].[name] = N'Date');
    IF @var81 IS NOT NULL EXEC(N'ALTER TABLE [Db_SteamConsumption] DROP CONSTRAINT [' + @var81 + '];');
    ALTER TABLE [Db_SteamConsumption] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var82 sysname;
    SELECT @var82 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezAllData]') AND [c].[name] = N'Date');
    IF @var82 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezAllData] DROP CONSTRAINT [' + @var82 + '];');
    ALTER TABLE [Db_SentezAllData] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var83 sysname;
    SELECT @var83 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_RetentionAnalysisHead]') AND [c].[name] = N'Date');
    IF @var83 IS NOT NULL EXEC(N'ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [' + @var83 + '];');
    ALTER TABLE [Db_RetentionAnalysisHead] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var84 sysname;
    SELECT @var84 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PapperMachineChemical]') AND [c].[name] = N'Date');
    IF @var84 IS NOT NULL EXEC(N'ALTER TABLE [Db_PapperMachineChemical] DROP CONSTRAINT [' + @var84 + '];');
    ALTER TABLE [Db_PapperMachineChemical] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var85 sysname;
    SELECT @var85 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_OilAnalysisReport]') AND [c].[name] = N'Date');
    IF @var85 IS NOT NULL EXEC(N'ALTER TABLE [Db_OilAnalysisReport] DROP CONSTRAINT [' + @var85 + '];');
    ALTER TABLE [Db_OilAnalysisReport] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var86 sysname;
    SELECT @var86 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_NaturelGasMeterMonitoring]') AND [c].[name] = N'Date');
    IF @var86 IS NOT NULL EXEC(N'ALTER TABLE [Db_NaturelGasMeterMonitoring] DROP CONSTRAINT [' + @var86 + '];');
    ALTER TABLE [Db_NaturelGasMeterMonitoring] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var87 sysname;
    SELECT @var87 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LogisticsTrackingReport]') AND [c].[name] = N'Date');
    IF @var87 IS NOT NULL EXEC(N'ALTER TABLE [Db_LogisticsTrackingReport] DROP CONSTRAINT [' + @var87 + '];');
    ALTER TABLE [Db_LogisticsTrackingReport] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var88 sysname;
    SELECT @var88 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanChemicalsHead]') AND [c].[name] = N'Date');
    IF @var88 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanChemicalsHead] DROP CONSTRAINT [' + @var88 + '];');
    ALTER TABLE [Db_KazanChemicalsHead] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var89 sysname;
    SELECT @var89 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparation]') AND [c].[name] = N'Date');
    IF @var89 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparation] DROP CONSTRAINT [' + @var89 + '];');
    ALTER TABLE [Db_DoughPreparation] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var90 sysname;
    SELECT @var90 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CumulativeElectricityConsumption]') AND [c].[name] = N'Date');
    IF @var90 IS NOT NULL EXEC(N'ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [' + @var90 + '];');
    ALTER TABLE [Db_CumulativeElectricityConsumption] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var91 sysname;
    SELECT @var91 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CirculationTankAirPressureMeasurementTurbidity]') AND [c].[name] = N'Date');
    IF @var91 IS NOT NULL EXEC(N'ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] DROP CONSTRAINT [' + @var91 + '];');
    ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var92 sysname;
    SELECT @var92 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferAnalysisReport]') AND [c].[name] = N'Date');
    IF @var92 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferAnalysisReport] DROP CONSTRAINT [' + @var92 + '];');
    ALTER TABLE [Db_BufferAnalysisReport] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    DECLARE @var93 sysname;
    SELECT @var93 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BoilerSteamFeedWaterCondensateData]') AND [c].[name] = N'Date');
    IF @var93 IS NOT NULL EXEC(N'ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] DROP CONSTRAINT [' + @var93 + '];');
    ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] DROP COLUMN [Date];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    EXEC sp_rename N'[Db_StarchAnalysisHeadingDetail].[Date]', N'ReceiptDate', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260622082537_refactoringDbDatetime'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260622082537_refactoringDbDatetime', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623121828_BufferProduction'
)
BEGIN
    CREATE TABLE [Db_BufferProduction] (
        [RecId] int NOT NULL IDENTITY,
        [ShiftSupervisor] nvarchar(max) NOT NULL,
        [Product] nvarchar(max) NOT NULL,
        [GrPerM2] decimal(18,2) NOT NULL,
        [BufferNo] int NOT NULL,
        [BufferStart] datetime2 NULL,
        [BufferEnd] datetime2 NULL,
        [TotalDurationMinutes] int NOT NULL,
        [DowntimeMinutes] int NOT NULL,
        [BufferSpeed] decimal(18,2) NOT NULL,
        [BufferWidthCm] decimal(18,2) NOT NULL,
        [BufferSetCount] int NOT NULL,
        [TheoreticalBufferKg] decimal(18,2) NOT NULL,
        [MeasuredKg] decimal(18,2) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_BufferProduction] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_BufferProduction_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BufferProduction_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_BufferProduction_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623121828_BufferProduction'
)
BEGIN
    CREATE INDEX [IX_Db_BufferProduction_AppUserId] ON [Db_BufferProduction] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623121828_BufferProduction'
)
BEGIN
    CREATE INDEX [IX_Db_BufferProduction_DepartmentId] ON [Db_BufferProduction] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623121828_BufferProduction'
)
BEGIN
    CREATE INDEX [IX_Db_BufferProduction_ShiftId] ON [Db_BufferProduction] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623121828_BufferProduction'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260623121828_BufferProduction', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623140701_Vizor'
)
BEGIN
    DECLARE @var94 sysname;
    SELECT @var94 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferProduction]') AND [c].[name] = N'ShiftSupervisor');
    IF @var94 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferProduction] DROP CONSTRAINT [' + @var94 + '];');
    ALTER TABLE [Db_BufferProduction] DROP COLUMN [ShiftSupervisor];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623140701_Vizor'
)
BEGIN
    ALTER TABLE [Db_BufferProduction] ADD [ShiftSupervisorId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623140701_Vizor'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260623140701_Vizor', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623143319_Vizor1'
)
BEGIN
    EXEC sp_rename N'[Db_BufferProduction].[ShiftSupervisorId]', N'ShiftSupervisorUserId', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623143319_Vizor1'
)
BEGIN
    CREATE INDEX [IX_Db_BufferProduction_ShiftSupervisorUserId] ON [Db_BufferProduction] ([ShiftSupervisorUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623143319_Vizor1'
)
BEGIN
    ALTER TABLE [Db_BufferProduction] ADD CONSTRAINT [FK_Db_BufferProduction_AspNetUsers_ShiftSupervisorUserId] FOREIGN KEY ([ShiftSupervisorUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260623143319_Vizor1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260623143319_Vizor1', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260624063101_MachineStop'
)
BEGIN
    CREATE TABLE [Db_MachineStop] (
        [RecId] int NOT NULL IDENTITY,
        [StartTime] datetime2 NULL,
        [EndTime] datetime2 NULL,
        [DowntimeDuration] decimal(18,2) NULL,
        [BreakLocation] nvarchar(max) NULL,
        [DowntimeReason] nvarchar(max) NULL,
        [Explanation] nvarchar(max) NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_MachineStop] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_MachineStop_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_MachineStop_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_MachineStop_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260624063101_MachineStop'
)
BEGIN
    CREATE INDEX [IX_Db_MachineStop_AppUserId] ON [Db_MachineStop] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260624063101_MachineStop'
)
BEGIN
    CREATE INDEX [IX_Db_MachineStop_DepartmentId] ON [Db_MachineStop] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260624063101_MachineStop'
)
BEGIN
    CREATE INDEX [IX_Db_MachineStop_ShiftId] ON [Db_MachineStop] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260624063101_MachineStop'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260624063101_MachineStop', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] DROP CONSTRAINT [FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] DROP CONSTRAINT [FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_SentezAllData] DROP CONSTRAINT [FK_Db_SentezAllData_AspNetUsers_AppUserId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_SentezAllData] DROP CONSTRAINT [FK_Db_SentezAllData_Db_Shift_ShiftId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    CREATE TABLE [Db_PlanningScorBoardView] (
        [RecId] int NOT NULL IDENTITY,
        [PlanNo] nvarchar(max) NOT NULL,
        [UploadPdf] nvarchar(max) NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_PlanningScorBoardView] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_PlanningScorBoardView_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_PlanningScorBoardView_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_PlanningScorBoardView_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    CREATE INDEX [IX_Db_PlanningScorBoardView_AppUserId] ON [Db_PlanningScorBoardView] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    CREATE INDEX [IX_Db_PlanningScorBoardView_DepartmentId] ON [Db_PlanningScorBoardView] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    CREATE INDEX [IX_Db_PlanningScorBoardView_ShiftId] ON [Db_PlanningScorBoardView] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] ADD CONSTRAINT [FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] ADD CONSTRAINT [FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_SentezAllData] ADD CONSTRAINT [FK_Db_SentezAllData_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    ALTER TABLE [Db_SentezAllData] ADD CONSTRAINT [FK_Db_SentezAllData_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260630124910_scorboard'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260630124910_scorboard', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703111945_nullablepdf'
)
BEGIN
    DECLARE @var95 sysname;
    SELECT @var95 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PlanningScorBoardView]') AND [c].[name] = N'UploadPdf');
    IF @var95 IS NOT NULL EXEC(N'ALTER TABLE [Db_PlanningScorBoardView] DROP CONSTRAINT [' + @var95 + '];');
    ALTER TABLE [Db_PlanningScorBoardView] ALTER COLUMN [UploadPdf] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703111945_nullablepdf'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260703111945_nullablepdf', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703133046_favoriteMenu'
)
BEGIN
    CREATE TABLE [Db_FavoriteMenuItem] (
        [RecId] int NOT NULL IDENTITY,
        [ModuleId] int NOT NULL,
        [Url] nvarchar(max) NOT NULL,
        [DisplayOrder] int NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NOT NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_FavoriteMenuItem] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_FavoriteMenuItem_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_FavoriteMenuItem_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Db_FavoriteMenuItem_Db_Permission_ModuleId] FOREIGN KEY ([ModuleId]) REFERENCES [Db_Permission] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_FavoriteMenuItem_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703133046_favoriteMenu'
)
BEGIN
    CREATE INDEX [IX_Db_FavoriteMenuItem_AppUserId] ON [Db_FavoriteMenuItem] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703133046_favoriteMenu'
)
BEGIN
    CREATE INDEX [IX_Db_FavoriteMenuItem_DepartmentId] ON [Db_FavoriteMenuItem] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703133046_favoriteMenu'
)
BEGIN
    CREATE INDEX [IX_Db_FavoriteMenuItem_ModuleId] ON [Db_FavoriteMenuItem] ([ModuleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703133046_favoriteMenu'
)
BEGIN
    CREATE INDEX [IX_Db_FavoriteMenuItem_ShiftId] ON [Db_FavoriteMenuItem] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260703133046_favoriteMenu'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260703133046_favoriteMenu', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_FavoriteMenuItem] DROP CONSTRAINT [FK_Db_FavoriteMenuItem_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] DROP CONSTRAINT [FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [FK_Db_RetentionAnalysisHead_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [FK_Db_SentezNotOrder_Db_Department_DepartmentId];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var96 sysname;
    SELECT @var96 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WinderCoilTracking]') AND [c].[name] = N'DepartmentId');
    IF @var96 IS NOT NULL EXEC(N'ALTER TABLE [Db_WinderCoilTracking] DROP CONSTRAINT [' + @var96 + '];');
    ALTER TABLE [Db_WinderCoilTracking] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var97 sysname;
    SELECT @var97 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WinderCoilLengthControl]') AND [c].[name] = N'DepartmentId');
    IF @var97 IS NOT NULL EXEC(N'ALTER TABLE [Db_WinderCoilLengthControl] DROP CONSTRAINT [' + @var97 + '];');
    ALTER TABLE [Db_WinderCoilLengthControl] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var98 sysname;
    SELECT @var98 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WaterTreatmentAnalysisResults]') AND [c].[name] = N'DepartmentId');
    IF @var98 IS NOT NULL EXEC(N'ALTER TABLE [Db_WaterTreatmentAnalysisResults] DROP CONSTRAINT [' + @var98 + '];');
    ALTER TABLE [Db_WaterTreatmentAnalysisResults] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var99 sysname;
    SELECT @var99 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WaterPreparationAndConsumption]') AND [c].[name] = N'DepartmentId');
    IF @var99 IS NOT NULL EXEC(N'ALTER TABLE [Db_WaterPreparationAndConsumption] DROP CONSTRAINT [' + @var99 + '];');
    ALTER TABLE [Db_WaterPreparationAndConsumption] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var100 sysname;
    SELECT @var100 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperCost]') AND [c].[name] = N'DepartmentId');
    IF @var100 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperCost] DROP CONSTRAINT [' + @var100 + '];');
    ALTER TABLE [Db_WastePaperCost] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var101 sysname;
    SELECT @var101 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WastePaperControl]') AND [c].[name] = N'DepartmentId');
    IF @var101 IS NOT NULL EXEC(N'ALTER TABLE [Db_WastePaperControl] DROP CONSTRAINT [' + @var101 + '];');
    ALTER TABLE [Db_WastePaperControl] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var102 sysname;
    SELECT @var102 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_WarehouseRequestWait]') AND [c].[name] = N'DepartmentId');
    IF @var102 IS NOT NULL EXEC(N'ALTER TABLE [Db_WarehouseRequestWait] DROP CONSTRAINT [' + @var102 + '];');
    ALTER TABLE [Db_WarehouseRequestWait] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var103 sysname;
    SELECT @var103 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_VechileFuelLogs]') AND [c].[name] = N'DepartmentId');
    IF @var103 IS NOT NULL EXEC(N'ALTER TABLE [Db_VechileFuelLogs] DROP CONSTRAINT [' + @var103 + '];');
    ALTER TABLE [Db_VechileFuelLogs] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var104 sysname;
    SELECT @var104 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_TestHeader]') AND [c].[name] = N'DepartmentId');
    IF @var104 IS NOT NULL EXEC(N'ALTER TABLE [Db_TestHeader] DROP CONSTRAINT [' + @var104 + '];');
    ALTER TABLE [Db_TestHeader] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var105 sysname;
    SELECT @var105 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SteamConsumption]') AND [c].[name] = N'DepartmentId');
    IF @var105 IS NOT NULL EXEC(N'ALTER TABLE [Db_SteamConsumption] DROP CONSTRAINT [' + @var105 + '];');
    ALTER TABLE [Db_SteamConsumption] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var106 sysname;
    SELECT @var106 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_StarchAnalysisHeading]') AND [c].[name] = N'DepartmentId');
    IF @var106 IS NOT NULL EXEC(N'ALTER TABLE [Db_StarchAnalysisHeading] DROP CONSTRAINT [' + @var106 + '];');
    ALTER TABLE [Db_StarchAnalysisHeading] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var107 sysname;
    SELECT @var107 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezNotOrder]') AND [c].[name] = N'DepartmentId');
    IF @var107 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezNotOrder] DROP CONSTRAINT [' + @var107 + '];');
    ALTER TABLE [Db_SentezNotOrder] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var108 sysname;
    SELECT @var108 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SentezAllData]') AND [c].[name] = N'DepartmentId');
    IF @var108 IS NOT NULL EXEC(N'ALTER TABLE [Db_SentezAllData] DROP CONSTRAINT [' + @var108 + '];');
    ALTER TABLE [Db_SentezAllData] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var109 sysname;
    SELECT @var109 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_SalesScale]') AND [c].[name] = N'DepartmentId');
    IF @var109 IS NOT NULL EXEC(N'ALTER TABLE [Db_SalesScale] DROP CONSTRAINT [' + @var109 + '];');
    ALTER TABLE [Db_SalesScale] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var110 sysname;
    SELECT @var110 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_RetentionAnalysisHead]') AND [c].[name] = N'DepartmentId');
    IF @var110 IS NOT NULL EXEC(N'ALTER TABLE [Db_RetentionAnalysisHead] DROP CONSTRAINT [' + @var110 + '];');
    ALTER TABLE [Db_RetentionAnalysisHead] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var111 sysname;
    SELECT @var111 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PurificationChemicalsConsumption]') AND [c].[name] = N'DepartmentId');
    IF @var111 IS NOT NULL EXEC(N'ALTER TABLE [Db_PurificationChemicalsConsumption] DROP CONSTRAINT [' + @var111 + '];');
    ALTER TABLE [Db_PurificationChemicalsConsumption] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var112 sysname;
    SELECT @var112 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PlanningScorBoardView]') AND [c].[name] = N'DepartmentId');
    IF @var112 IS NOT NULL EXEC(N'ALTER TABLE [Db_PlanningScorBoardView] DROP CONSTRAINT [' + @var112 + '];');
    ALTER TABLE [Db_PlanningScorBoardView] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var113 sysname;
    SELECT @var113 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_PapperMachineChemical]') AND [c].[name] = N'DepartmentId');
    IF @var113 IS NOT NULL EXEC(N'ALTER TABLE [Db_PapperMachineChemical] DROP CONSTRAINT [' + @var113 + '];');
    ALTER TABLE [Db_PapperMachineChemical] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var114 sysname;
    SELECT @var114 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_OilAnalysisReport]') AND [c].[name] = N'DepartmentId');
    IF @var114 IS NOT NULL EXEC(N'ALTER TABLE [Db_OilAnalysisReport] DROP CONSTRAINT [' + @var114 + '];');
    ALTER TABLE [Db_OilAnalysisReport] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var115 sysname;
    SELECT @var115 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_NaturelGasMeterMonitoring]') AND [c].[name] = N'DepartmentId');
    IF @var115 IS NOT NULL EXEC(N'ALTER TABLE [Db_NaturelGasMeterMonitoring] DROP CONSTRAINT [' + @var115 + '];');
    ALTER TABLE [Db_NaturelGasMeterMonitoring] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var116 sysname;
    SELECT @var116 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MassWasteSupplier]') AND [c].[name] = N'DepartmentId');
    IF @var116 IS NOT NULL EXEC(N'ALTER TABLE [Db_MassWasteSupplier] DROP CONSTRAINT [' + @var116 + '];');
    ALTER TABLE [Db_MassWasteSupplier] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var117 sysname;
    SELECT @var117 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MassWasteBalance]') AND [c].[name] = N'DepartmentId');
    IF @var117 IS NOT NULL EXEC(N'ALTER TABLE [Db_MassWasteBalance] DROP CONSTRAINT [' + @var117 + '];');
    ALTER TABLE [Db_MassWasteBalance] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var118 sysname;
    SELECT @var118 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_MachineStop]') AND [c].[name] = N'DepartmentId');
    IF @var118 IS NOT NULL EXEC(N'ALTER TABLE [Db_MachineStop] DROP CONSTRAINT [' + @var118 + '];');
    ALTER TABLE [Db_MachineStop] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var119 sysname;
    SELECT @var119 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LogisticsTrackingReport]') AND [c].[name] = N'DepartmentId');
    IF @var119 IS NOT NULL EXEC(N'ALTER TABLE [Db_LogisticsTrackingReport] DROP CONSTRAINT [' + @var119 + '];');
    ALTER TABLE [Db_LogisticsTrackingReport] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var120 sysname;
    SELECT @var120 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_LabWork]') AND [c].[name] = N'DepartmentId');
    IF @var120 IS NOT NULL EXEC(N'ALTER TABLE [Db_LabWork] DROP CONSTRAINT [' + @var120 + '];');
    ALTER TABLE [Db_LabWork] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var121 sysname;
    SELECT @var121 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanDailyShiftMonitoring]') AND [c].[name] = N'DepartmentId');
    IF @var121 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanDailyShiftMonitoring] DROP CONSTRAINT [' + @var121 + '];');
    ALTER TABLE [Db_KazanDailyShiftMonitoring] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var122 sysname;
    SELECT @var122 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_KazanChemicalsHead]') AND [c].[name] = N'DepartmentId');
    IF @var122 IS NOT NULL EXEC(N'ALTER TABLE [Db_KazanChemicalsHead] DROP CONSTRAINT [' + @var122 + '];');
    ALTER TABLE [Db_KazanChemicalsHead] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var123 sysname;
    SELECT @var123 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_FavoriteMenuItem]') AND [c].[name] = N'DepartmentId');
    IF @var123 IS NOT NULL EXEC(N'ALTER TABLE [Db_FavoriteMenuItem] DROP CONSTRAINT [' + @var123 + '];');
    ALTER TABLE [Db_FavoriteMenuItem] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var124 sysname;
    SELECT @var124 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricShiftWork]') AND [c].[name] = N'DepartmentId');
    IF @var124 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricShiftWork] DROP CONSTRAINT [' + @var124 + '];');
    ALTER TABLE [Db_ElectricShiftWork] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var125 sysname;
    SELECT @var125 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricMotorTracking]') AND [c].[name] = N'DepartmentId');
    IF @var125 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricMotorTracking] DROP CONSTRAINT [' + @var125 + '];');
    ALTER TABLE [Db_ElectricMotorTracking] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var126 sysname;
    SELECT @var126 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_ElectricMeterLocation]') AND [c].[name] = N'DepartmentId');
    IF @var126 IS NOT NULL EXEC(N'ALTER TABLE [Db_ElectricMeterLocation] DROP CONSTRAINT [' + @var126 + '];');
    ALTER TABLE [Db_ElectricMeterLocation] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var127 sysname;
    SELECT @var127 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparationAnalysisResults]') AND [c].[name] = N'DepartmentId');
    IF @var127 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparationAnalysisResults] DROP CONSTRAINT [' + @var127 + '];');
    ALTER TABLE [Db_DoughPreparationAnalysisResults] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var128 sysname;
    SELECT @var128 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_DoughPreparation]') AND [c].[name] = N'DepartmentId');
    IF @var128 IS NOT NULL EXEC(N'ALTER TABLE [Db_DoughPreparation] DROP CONSTRAINT [' + @var128 + '];');
    ALTER TABLE [Db_DoughPreparation] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var129 sysname;
    SELECT @var129 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CumulativeElectricityConsumption]') AND [c].[name] = N'DepartmentId');
    IF @var129 IS NOT NULL EXEC(N'ALTER TABLE [Db_CumulativeElectricityConsumption] DROP CONSTRAINT [' + @var129 + '];');
    ALTER TABLE [Db_CumulativeElectricityConsumption] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var130 sysname;
    SELECT @var130 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_CirculationTankAirPressureMeasurementTurbidity]') AND [c].[name] = N'DepartmentId');
    IF @var130 IS NOT NULL EXEC(N'ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] DROP CONSTRAINT [' + @var130 + '];');
    ALTER TABLE [Db_CirculationTankAirPressureMeasurementTurbidity] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var131 sysname;
    SELECT @var131 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferProduction]') AND [c].[name] = N'DepartmentId');
    IF @var131 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferProduction] DROP CONSTRAINT [' + @var131 + '];');
    ALTER TABLE [Db_BufferProduction] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var132 sysname;
    SELECT @var132 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferGramajProfile]') AND [c].[name] = N'DepartmentId');
    IF @var132 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferGramajProfile] DROP CONSTRAINT [' + @var132 + '];');
    ALTER TABLE [Db_BufferGramajProfile] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var133 sysname;
    SELECT @var133 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BufferAnalysisReport]') AND [c].[name] = N'DepartmentId');
    IF @var133 IS NOT NULL EXEC(N'ALTER TABLE [Db_BufferAnalysisReport] DROP CONSTRAINT [' + @var133 + '];');
    ALTER TABLE [Db_BufferAnalysisReport] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var134 sysname;
    SELECT @var134 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BoilerSteamFeedWaterCondensateData]') AND [c].[name] = N'DepartmentId');
    IF @var134 IS NOT NULL EXEC(N'ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] DROP CONSTRAINT [' + @var134 + '];');
    ALTER TABLE [Db_BoilerSteamFeedWaterCondensateData] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var135 sysname;
    SELECT @var135 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_BoilerRoomDailyShiftMonitoring]') AND [c].[name] = N'DepartmentId');
    IF @var135 IS NOT NULL EXEC(N'ALTER TABLE [Db_BoilerRoomDailyShiftMonitoring] DROP CONSTRAINT [' + @var135 + '];');
    ALTER TABLE [Db_BoilerRoomDailyShiftMonitoring] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    DECLARE @var136 sysname;
    SELECT @var136 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Db_Basin]') AND [c].[name] = N'DepartmentId');
    IF @var136 IS NOT NULL EXEC(N'ALTER TABLE [Db_Basin] DROP CONSTRAINT [' + @var136 + '];');
    ALTER TABLE [Db_Basin] ALTER COLUMN [DepartmentId] int NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    CREATE TABLE [Db_Message] (
        [RecId] int NOT NULL IDENTITY,
        [SenderId] int NOT NULL,
        [ReceiverId] int NOT NULL,
        [Content] nvarchar(max) NOT NULL,
        [SentAt] datetime2 NOT NULL,
        [IsRead] bit NOT NULL,
        CONSTRAINT [PK_Db_Message] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_Message_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_Message_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    CREATE INDEX [IX_Db_Message_ReceiverId] ON [Db_Message] ([ReceiverId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    CREATE INDEX [IX_Db_Message_SenderId] ON [Db_Message] ([SenderId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_FavoriteMenuItem] ADD CONSTRAINT [FK_Db_FavoriteMenuItem_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_PurificationChemicalsConsumption] ADD CONSTRAINT [FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_RetentionAnalysisHead] ADD CONSTRAINT [FK_Db_RetentionAnalysisHead_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    ALTER TABLE [Db_SentezNotOrder] ADD CONSTRAINT [FK_Db_SentezNotOrder_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260713082315_message'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260713082315_message', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE TABLE [Db_IncomingGoodsTracking] (
        [RecId] int NOT NULL IDENTITY,
        [WaybillNo] nvarchar(max) NOT NULL,
        [ScaleHours] time NOT NULL,
        [ReceiptNo] nvarchar(max) NOT NULL,
        [CurrentAccountName] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [Plate] nvarchar(max) NOT NULL,
        [Operator] nvarchar(max) NOT NULL,
        [Unit] nvarchar(max) NOT NULL,
        [WaybillQuantity] decimal(18,2) NULL,
        [FilledQuantity] decimal(18,2) NULL,
        [EmptyQuantity] decimal(18,2) NULL,
        [Description] nvarchar(max) NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_IncomingGoodsTracking] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_IncomingGoodsTracking_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_IncomingGoodsTracking_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_IncomingGoodsTracking_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE TABLE [Db_RawMaterialIntake] (
        [RecId] int NOT NULL IDENTITY,
        [ScaleHours] time NOT NULL,
        [WaybillNo] nvarchar(max) NOT NULL,
        [CurrentAccountName] nvarchar(max) NOT NULL,
        [TruckPlate] nvarchar(max) NOT NULL,
        [Operator] nvarchar(max) NOT NULL,
        [WaybillQuantity] decimal(18,2) NOT NULL,
        [FilledQuantity] decimal(18,2) NOT NULL,
        [EmptyQuantity] decimal(18,2) NOT NULL,
        [NetQuantity] decimal(18,2) NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_RawMaterialIntake] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_RawMaterialIntake_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_RawMaterialIntake_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_RawMaterialIntake_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE INDEX [IX_Db_IncomingGoodsTracking_AppUserId] ON [Db_IncomingGoodsTracking] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE INDEX [IX_Db_IncomingGoodsTracking_DepartmentId] ON [Db_IncomingGoodsTracking] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE INDEX [IX_Db_IncomingGoodsTracking_ShiftId] ON [Db_IncomingGoodsTracking] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE INDEX [IX_Db_RawMaterialIntake_AppUserId] ON [Db_RawMaterialIntake] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE INDEX [IX_Db_RawMaterialIntake_DepartmentId] ON [Db_RawMaterialIntake] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    CREATE INDEX [IX_Db_RawMaterialIntake_ShiftId] ON [Db_RawMaterialIntake] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721134111_IncomeTracking'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260721134111_IncomeTracking', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721140415_IncomeTrackingv2'
)
BEGIN
    ALTER TABLE [Db_IncomingGoodsTracking] ADD [NetQuantity] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260721140415_IncomeTrackingv2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260721140415_IncomeTrackingv2', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260724143719_controller'
)
BEGIN
    ALTER TABLE [Db_FavoriteMenuItem] ADD [Controller] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260724143719_controller'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260724143719_controller', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260728131204_currentStock'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260728131204_currentStock', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260728133033_currentStockDeneme'
)
BEGIN
    ALTER TABLE [Db_WaterPreparationAndConsumption] ADD [CurrentStock] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260728133033_currentStockDeneme'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260728133033_currentStockDeneme', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260729083647_chemicalSupplierProducts'
)
BEGIN
    CREATE TABLE [Db_ChemicalSupplierProducts] (
        [RecId] int NOT NULL IDENTITY,
        [InventoryCode] nvarchar(max) NOT NULL,
        [InventoryName] nvarchar(max) NOT NULL,
        [CurrentAccountName] nvarchar(max) NOT NULL,
        [Product] nvarchar(max) NOT NULL,
        [Unit] nvarchar(max) NOT NULL,
        [ReceiptDate] datetime2 NULL,
        [ShiftId] int NULL,
        [AppUserId] int NULL,
        [DepartmentId] int NULL,
        [InsertDate] datetime2 NULL,
        [UpdateDate] datetime2 NULL,
        [DeleteDate] datetime2 NULL,
        [InUse] smallint NULL,
        [DeletedBy] int NULL,
        [UpdatedBy] int NULL,
        CONSTRAINT [PK_Db_ChemicalSupplierProducts] PRIMARY KEY ([RecId]),
        CONSTRAINT [FK_Db_ChemicalSupplierProducts_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_ChemicalSupplierProducts_Db_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Db_Department] ([RecId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Db_ChemicalSupplierProducts_Db_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Db_Shift] ([RecId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260729083647_chemicalSupplierProducts'
)
BEGIN
    CREATE INDEX [IX_Db_ChemicalSupplierProducts_AppUserId] ON [Db_ChemicalSupplierProducts] ([AppUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260729083647_chemicalSupplierProducts'
)
BEGIN
    CREATE INDEX [IX_Db_ChemicalSupplierProducts_DepartmentId] ON [Db_ChemicalSupplierProducts] ([DepartmentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260729083647_chemicalSupplierProducts'
)
BEGIN
    CREATE INDEX [IX_Db_ChemicalSupplierProducts_ShiftId] ON [Db_ChemicalSupplierProducts] ([ShiftId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260729083647_chemicalSupplierProducts'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260729083647_chemicalSupplierProducts', N'8.0.0');
END;
GO

COMMIT;
GO

