use [ERS-cachememory]

go

create table dbo.spent_energy_meter
(
    id           int identity primary key,
    customer     varchar(60),
    streetName   varchar(120),
    spent_total  float,
    streetNumber varchar(10),
    city         varchar(50),
    state        varchar(50)
)
go

create table dbo.spent_energy_record
(
    timestamp    datetime,
    user_id      int
    constraint spent_energy_record_spent_enegry_meter_id_fk
    references dbo.spent_energy_meter,
    spent_energy float,
    id	int identity primary key
)