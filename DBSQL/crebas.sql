/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     2017/8/1 8:45:28                             */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkAreas') and o.name = 'FK_WorkAreas_Projects_ProjectId')
alter table dbo.WorkAreas
   drop constraint FK_WorkAreas_Projects_ProjectId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItemPrices') and o.name = 'FK_WorkItemPrices_WorkItems_WorkItemId')
alter table dbo.WorkItemPrices
   drop constraint FK_WorkItemPrices_WorkItems_WorkItemId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItemPrices') and o.name = 'FK_WorkItemPrices_WorkTeams_WorkTeamId')
alter table dbo.WorkItemPrices
   drop constraint FK_WorkItemPrices_WorkTeams_WorkTeamId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItemPrices') and o.name = 'FK_WorkItemPrices_WorkTypeUnits_WorkTypeUnitId')
alter table dbo.WorkItemPrices
   drop constraint FK_WorkItemPrices_WorkTypeUnits_WorkTypeUnitId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItemProgresses') and o.name = 'FK_WorkItemProgresses_WorkItemPrices_WorkItemPriceId')
alter table dbo.WorkItemProgresses
   drop constraint FK_WorkItemProgresses_WorkItemPrices_WorkItemPriceId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItems') and o.name = 'FK_WorkItems_WorkAreas_WorkAreaId')
alter table dbo.WorkItems
   drop constraint FK_WorkItems_WorkAreas_WorkAreaId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItems') and o.name = 'FK_WorkItems_WorkItems_ParentId')
alter table dbo.WorkItems
   drop constraint FK_WorkItems_WorkItems_ParentId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkItems') and o.name = 'FK_WorkItems_WorkTypes_WorkTypeId')
alter table dbo.WorkItems
   drop constraint FK_WorkItems_WorkTypes_WorkTypeId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkTypeUnits') and o.name = 'FK_WorkTypeUnits_WorkTypes_WorkTypeId')
alter table dbo.WorkTypeUnits
   drop constraint FK_WorkTypeUnits_WorkTypes_WorkTypeId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkTypeUnits') and o.name = 'FK_WorkTypeUnits_WorkUnits_WorkUnitId')
alter table dbo.WorkTypeUnits
   drop constraint FK_WorkTypeUnits_WorkUnits_WorkUnitId
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('dbo.WorkTypes') and o.name = 'FK_WorkTypes_WorkTypes_ParentId')
alter table dbo.WorkTypes
   drop constraint FK_WorkTypes_WorkTypes_ParentId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Companys')
            and   type = 'U')
   drop table dbo.Companys
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.Projects')
            and   type = 'U')
   drop table dbo.Projects
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkAreas')
            and   name  = 'IX_WorkAreas_ProjectId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkAreas.IX_WorkAreas_ProjectId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkAreas')
            and   type = 'U')
   drop table dbo.WorkAreas
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkItemPrices')
            and   name  = 'IX_WorkItemPrices_WorkTypeUnitId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkItemPrices.IX_WorkItemPrices_WorkTypeUnitId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkItemPrices')
            and   name  = 'IX_WorkItemPrices_WorkTeamId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkItemPrices.IX_WorkItemPrices_WorkTeamId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkItemPrices')
            and   type = 'U')
   drop table dbo.WorkItemPrices
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkItemProgresses')
            and   name  = 'IX_WorkItemProgresses_WorkItemPriceId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkItemProgresses.IX_WorkItemProgresses_WorkItemPriceId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkItemProgresses')
            and   type = 'U')
   drop table dbo.WorkItemProgresses
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkItems')
            and   name  = 'IX_WorkItems_WorkTypeId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkItems.IX_WorkItems_WorkTypeId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkItems')
            and   name  = 'IX_WorkItems_WorkAreaId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkItems.IX_WorkItems_WorkAreaId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkItems')
            and   name  = 'IX_WorkItems_ParentId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkItems.IX_WorkItems_ParentId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkItems')
            and   type = 'U')
   drop table dbo.WorkItems
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkTeams')
            and   type = 'U')
   drop table dbo.WorkTeams
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkTypeUnits')
            and   name  = 'IX_WorkTypeUnits_WorkUnitId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkTypeUnits.IX_WorkTypeUnits_WorkUnitId
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkTypeUnits')
            and   name  = 'IX_WorkTypeUnits_WorkTypeId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkTypeUnits.IX_WorkTypeUnits_WorkTypeId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkTypeUnits')
            and   type = 'U')
   drop table dbo.WorkTypeUnits
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('dbo.WorkTypes')
            and   name  = 'IX_WorkTypes_ParentId'
            and   indid > 0
            and   indid < 255)
   drop index dbo.WorkTypes.IX_WorkTypes_ParentId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkTypes')
            and   type = 'U')
   drop table dbo.WorkTypes
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.WorkUnits')
            and   type = 'U')
   drop table dbo.WorkUnits
go

/*==============================================================*/
/* Table: Companys                                              */
/*==============================================================*/
create table dbo.Companys (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   Email                nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   MobilePhone          nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   TelPhone             nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime2(7)         not null,
   WeChat               nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   constraint PK_Companys primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: Projects                                              */
/*==============================================================*/
create table dbo.Projects (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   Decription           nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime2(7)         not null,
   constraint PK_Projects primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkAreas                                             */
/*==============================================================*/
create table dbo.WorkAreas (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   Position             nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   ProjectId            int                  not null,
   Remark               nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime2(7)         not null,
   constraint PK_WorkAreas primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkAreas_ProjectId                                */
/*==============================================================*/




create nonclustered index IX_WorkAreas_ProjectId on dbo.WorkAreas (ProjectId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkItemPrices                                        */
/*==============================================================*/
create table dbo.WorkItemPrices (
   Id                   int                  not null,
   WorkItemId           int                  not null,
   WorkTypeUnitId       int                  not null,
   WorkTeamId           int                  null,
   Price                int                  not null,
   Remark               nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   CreateTime           datetime2(7)         not null,
   UpdateTime           datetime2(7)         not null,
   constraint PK_WorkItemPrices primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkItemPrices_WorkTeamId                          */
/*==============================================================*/




create nonclustered index IX_WorkItemPrices_WorkTeamId on dbo.WorkItemPrices (WorkTeamId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkItemPrices_WorkTypeUnitId                      */
/*==============================================================*/




create nonclustered index IX_WorkItemPrices_WorkTypeUnitId on dbo.WorkItemPrices (WorkTypeUnitId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkItemProgresses                                    */
/*==============================================================*/
create table dbo.WorkItemProgresses (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   CurrentDate          datetime2(7)         not null,
   UpdateTime           datetime2(7)         not null,
   WorkItemPriceId      int                  null,
   WorkQuantity         float                not null,
   constraint PK_WorkItemProgresses primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkItemProgresses_WorkItemPriceId                 */
/*==============================================================*/




create nonclustered index IX_WorkItemProgresses_WorkItemPriceId on dbo.WorkItemProgresses (WorkItemPriceId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkItems                                             */
/*==============================================================*/
create table dbo.WorkItems (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   ParentId             int                  null,
   Remark               nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime2(7)         not null,
   WorkAreaId           int                  not null,
   WorkTypeId           int                  not null,
   constraint PK_WorkItems primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkItems_ParentId                                 */
/*==============================================================*/




create nonclustered index IX_WorkItems_ParentId on dbo.WorkItems (ParentId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkItems_WorkAreaId                               */
/*==============================================================*/




create nonclustered index IX_WorkItems_WorkAreaId on dbo.WorkItems (WorkAreaId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkItems_WorkTypeId                               */
/*==============================================================*/




create nonclustered index IX_WorkItems_WorkTypeId on dbo.WorkItems (WorkTypeId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkTeams                                             */
/*==============================================================*/
create table dbo.WorkTeams (
   Id                   int                  identity(1, 1),
   ContractName         nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   CreateTime           datetime2(7)         not null,
   FullName             nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   MobilePhone          nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   TelPhone             nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime2(7)         not null,
   constraint PK_WorkTeams primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkTypeUnits                                         */
/*==============================================================*/
create table dbo.WorkTypeUnits (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   UpdateTime           datetime2(7)         not null,
   WorkTypeId           int                  not null,
   WorkUnitId           int                  not null,
   constraint PK_WorkTypeUnits primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkTypeUnits_WorkTypeId                           */
/*==============================================================*/




create nonclustered index IX_WorkTypeUnits_WorkTypeId on dbo.WorkTypeUnits (WorkTypeId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkTypeUnits_WorkUnitId                           */
/*==============================================================*/




create nonclustered index IX_WorkTypeUnits_WorkUnitId on dbo.WorkTypeUnits (WorkUnitId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkTypes                                             */
/*==============================================================*/
create table dbo.WorkTypes (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   Description          nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   ParentId             int                  null,
   UpdateTime           datetime2(7)         not null,
   constraint PK_WorkTypes primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

/*==============================================================*/
/* Index: IX_WorkTypes_ParentId                                 */
/*==============================================================*/




create nonclustered index IX_WorkTypes_ParentId on dbo.WorkTypes (ParentId ASC)
   on "PRIMARY"
go

/*==============================================================*/
/* Table: WorkUnits                                             */
/*==============================================================*/
create table dbo.WorkUnits (
   Id                   int                  identity(1, 1),
   CreateTime           datetime2(7)         not null,
   Name                 nvarchar(Max)        collate SQL_Latin1_General_CP1_CI_AS null,
   UpdateTime           datetime2(7)         not null,
   constraint PK_WorkUnits primary key (Id)
         on "PRIMARY"
)
on "PRIMARY"
go

alter table dbo.WorkAreas
   add constraint FK_WorkAreas_Projects_ProjectId foreign key (ProjectId)
      references dbo.Projects (Id)
         on delete cascade
go

alter table dbo.WorkItemPrices
   add constraint FK_WorkItemPrices_WorkItems_WorkItemId foreign key (WorkItemId)
      references dbo.WorkItems (Id)
go

alter table dbo.WorkItemPrices
   add constraint FK_WorkItemPrices_WorkTeams_WorkTeamId foreign key (WorkTeamId)
      references dbo.WorkTeams (Id)
go

alter table dbo.WorkItemPrices
   add constraint FK_WorkItemPrices_WorkTypeUnits_WorkTypeUnitId foreign key (WorkTypeUnitId)
      references dbo.WorkTypeUnits (Id)
         on delete cascade
go

alter table dbo.WorkItemProgresses
   add constraint FK_WorkItemProgresses_WorkItemPrices_WorkItemPriceId foreign key (WorkItemPriceId)
      references dbo.WorkItemPrices (Id)
go

alter table dbo.WorkItems
   add constraint FK_WorkItems_WorkAreas_WorkAreaId foreign key (WorkAreaId)
      references dbo.WorkAreas (Id)
         on delete cascade
go

alter table dbo.WorkItems
   add constraint FK_WorkItems_WorkItems_ParentId foreign key (ParentId)
      references dbo.WorkItems (Id)
go

alter table dbo.WorkItems
   add constraint FK_WorkItems_WorkTypes_WorkTypeId foreign key (WorkTypeId)
      references dbo.WorkTypes (Id)
         on delete cascade
go

alter table dbo.WorkTypeUnits
   add constraint FK_WorkTypeUnits_WorkTypes_WorkTypeId foreign key (WorkTypeId)
      references dbo.WorkTypes (Id)
         on delete cascade
go

alter table dbo.WorkTypeUnits
   add constraint FK_WorkTypeUnits_WorkUnits_WorkUnitId foreign key (WorkUnitId)
      references dbo.WorkUnits (Id)
         on delete cascade
go

alter table dbo.WorkTypes
   add constraint FK_WorkTypes_WorkTypes_ParentId foreign key (ParentId)
      references dbo.WorkTypes (Id)
go

