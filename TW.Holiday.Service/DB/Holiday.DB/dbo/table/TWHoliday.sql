CREATE TABLE [dbo].[TWHoliday]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Year] INT NOT NULL,
	[Month] INT NOT NULL,
	[Day] INT NOT NULL,
	[IsHoliday] bit NOT NULL DEFAULT 0,
	[Category] NVARCHAR(128) NULL,
	[Description] NVARCHAR(512) NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'是否為假日',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'TWHoliday',
    @level2type = N'COLUMN',
    @level2name = N'IsHoliday'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'日',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'TWHoliday',
    @level2type = N'COLUMN',
    @level2name = N'Day'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'月',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'TWHoliday',
    @level2type = N'COLUMN',
    @level2name = N'Month'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'年',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'TWHoliday',
    @level2type = N'COLUMN',
    @level2name = N'Year'