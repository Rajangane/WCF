Select * from EmployeeDetail


IF OBJECT_ID(N'[dbo].[EmployeeDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeDetails];
GO


CREATE TABLE [dbo].[EmployeeDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Salary] int  NOT NULL,
    [Email] varchar(50)  NOT NULL
);
GO
select * from EmployeeDetail

drop database employee_management

ALTER TABLE [dbo].[EmployeeDetails]
ADD CONSTRAINT [PK_EmployeeDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO