USE [master]
GO
/****** Object:  Database [Emelina_KS]    Script Date: 09.11.2022 13:48:32 ******/
CREATE DATABASE [Emelina_KS]
ALTER DATABASE [Emelina_KS] SET COMPATIBILITY_LEVEL = 150
GO

USE [Emelina_KS]
GO
/****** Object:  Table [dbo].[Группы]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Группы](
	[Номер_группы] [varchar](10) NOT NULL,
	[Пароль] [varchar](16) NOT NULL,
 CONSTRAINT [PK_Группы] PRIMARY KEY CLUSTERED 
(
	[Номер_группы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Дежурство]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Дежурство](
	[Код_преподавателя] [int] NOT NULL,
	[Дата] [date] NOT NULL,
	[Группа] [varchar](10) NOT NULL,
	[Код_дежурного1] [int] NOT NULL,
	[Код_дежурного2] [int] NOT NULL,
 CONSTRAINT [PK__Дежурств__A23BBB09E23643C3] PRIMARY KEY CLUSTERED 
(
	[Код_преподавателя] ASC,
	[Дата] ASC,
	[Группа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Отсутствующие]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Отсутствующие](
	[Дата] [date] NOT NULL,
	[Код_студента] [int] NOT NULL,
 CONSTRAINT [PK_Отсутствующие] PRIMARY KEY CLUSTERED 
(
	[Дата] ASC,
	[Код_студента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пары]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пары](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Код_преподавателя] [int] NOT NULL,
	[День_недели] [varchar](50) NOT NULL,
	[Номер_пары] [int] NOT NULL,
	[Группа] [varchar](10) NOT NULL,
 CONSTRAINT [PK__Пары__F92B2E4757BA6783] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uniquestring] UNIQUE NONCLUSTERED 
(
	[Код_преподавателя] ASC,
	[День_недели] ASC,
	[Номер_пары] ASC,
	[Группа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Подгруппы]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Подгруппы](
	[Код_преподавателя] [int] NOT NULL,
	[Первая_подгруппа] [bit] NOT NULL,
 CONSTRAINT [PK_Подгруппы] PRIMARY KEY CLUSTERED 
(
	[Код_преподавателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Преподаватели]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Преподаватели](
	[Код_преподавателя] [int] NOT NULL,
	[Фамилия_преподавателя] [nvarchar](30) NOT NULL,
	[Имя_преподавателя] [nvarchar](20) NOT NULL,
	[Отчество_преподавателя] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Код_преподавателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Студенты]    Script Date: 09.11.2022 13:48:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Студенты](
	[Код_студента] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия_студента] [varchar](30) NOT NULL,
	[Имя_студента] [varchar](20) NOT NULL,
	[Отчество_студента] [varchar](20) NULL,
	[Группа] [varchar](10) NOT NULL,
	[Первая_подгруппа] [bit] NOT NULL,
	[Отдежурено_циклов] [int] NULL,
 CONSTRAINT [PK__Студенты__A6B4ED05F7526D64] PRIMARY KEY CLUSTERED 
(
	[Код_студента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Дежурство]  WITH CHECK ADD  CONSTRAINT [FK__Дежурство__Код_п__2D27B809] FOREIGN KEY([Код_преподавателя])
REFERENCES [dbo].[Преподаватели] ([Код_преподавателя])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Дежурство] CHECK CONSTRAINT [FK__Дежурство__Код_п__2D27B809]
GO
ALTER TABLE [dbo].[Дежурство]  WITH CHECK ADD  CONSTRAINT [FK_Дежурство_Студенты] FOREIGN KEY([Код_дежурного1])
REFERENCES [dbo].[Студенты] ([Код_студента])
GO
ALTER TABLE [dbo].[Дежурство] CHECK CONSTRAINT [FK_Дежурство_Студенты]
GO
ALTER TABLE [dbo].[Дежурство]  WITH CHECK ADD  CONSTRAINT [FK_Дежурство_Студенты1] FOREIGN KEY([Код_дежурного2])
REFERENCES [dbo].[Студенты] ([Код_студента])
GO
ALTER TABLE [dbo].[Дежурство] CHECK CONSTRAINT [FK_Дежурство_Студенты1]
GO
ALTER TABLE [dbo].[Отсутствующие]  WITH CHECK ADD  CONSTRAINT [FK_Отсутствующие_Студенты] FOREIGN KEY([Код_студента])
REFERENCES [dbo].[Студенты] ([Код_студента])
GO
ALTER TABLE [dbo].[Отсутствующие] CHECK CONSTRAINT [FK_Отсутствующие_Студенты]
GO
ALTER TABLE [dbo].[Пары]  WITH CHECK ADD  CONSTRAINT [FK__Пары__Код_препод__286302EC] FOREIGN KEY([Код_преподавателя])
REFERENCES [dbo].[Преподаватели] ([Код_преподавателя])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Пары] CHECK CONSTRAINT [FK__Пары__Код_препод__286302EC]
GO
ALTER TABLE [dbo].[Пары]  WITH CHECK ADD  CONSTRAINT [FK_Пары_Группы] FOREIGN KEY([Группа])
REFERENCES [dbo].[Группы] ([Номер_группы])
GO
ALTER TABLE [dbo].[Пары] CHECK CONSTRAINT [FK_Пары_Группы]
GO
ALTER TABLE [dbo].[Подгруппы]  WITH CHECK ADD  CONSTRAINT [FK_Подгруппы_Преподаватели] FOREIGN KEY([Код_преподавателя])
REFERENCES [dbo].[Преподаватели] ([Код_преподавателя])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Подгруппы] CHECK CONSTRAINT [FK_Подгруппы_Преподаватели]
GO
ALTER TABLE [dbo].[Студенты]  WITH CHECK ADD  CONSTRAINT [FK_Студенты_Группы] FOREIGN KEY([Группа])
REFERENCES [dbo].[Группы] ([Номер_группы])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Студенты] CHECK CONSTRAINT [FK_Студенты_Группы]
GO

insert into Группы
(
Номер_группы,
Пароль
)
values
('20ИНФ3-3','2033'),
('20ИС3-1','2031'),
('20ИС3-3','2033'),
('20СА1-1','2011'),
('21ЗИО-2д','212'),
('21ИС2-1','2121'),
('22ИС1-1','2211'),
('Админ','007'),
('ПИ3-2д','32')
insert into Студенты
(
Фамилия_студента,
Имя_студента,
Отчество_студента,
Группа,
Первая_подгруппа,
Отдежурено_циклов
)
values
('Бородин','Леонид','Сергеевич','20ИС3-1',1,0),
('Горина','Екатерина','Вячеславовна','20ИС3-1',1,0),
('Ивашко','Александра','Сергеевна','20ИС3-1',1,0),
('Микловш','Никита','Сергеевич','20ИС3-1',0,0),
('Урматбек','Марина',NULL,'20ИС3-1',0,0),
('Ходосцов','Владислав','Сергеевич','20ИС3-1',0,0),
('Гладкова','Алиса','Сергеевна','22ИС1-1',1,4),
('Ефремова','Мария','Андреевна','22ИС1-1',1,4),
('Косоруков','Никита',NULL,'22ИС1-1',0,4),
('Косоруков','Матвей',NULL,'22ИС1-1',0,4),
('Буянова','Анастасия',NULL,'20ИНФ3-3',1,41),
('Вешнякова','Владислава',NULL,'20ИНФ3-3',1,42),
('Мустафаева','Эвелина',NULL,'20ИНФ3-3',1,42),
('Панина','Мария',NULL,'20ИНФ3-3',0,42),
('Сангинов','Илья',NULL,'20ИНФ3-3',0,42),
('Волчкова','Арина',NULL,'20ИС3-3',1,0),
('Кузнецов','Тимофей',NULL,'20ИС3-3',1,0),
('Куликова','Кристина','Рустамовна','20ИС3-3',1,0),
('Нагих','Полина','Владимировна','20ИС3-3',0,1),
('Рагимли','Рауль',NULL,'20ИС3-3',0,0),
('Янкевич','Майя','Игоревна','20ИС3-3',0,0)

insert into Преподаватели
(
Код_преподавателя,
Фамилия_преподавателя,
Имя_преподавателя,
Отчество_преподавателя
)
values
(215,'Смирнов','Евгений','Михайлович'),
(103,'Емелина','Елена','Ивановна'),
(311,'Руденко','Светлана','Николаевна'),
(312,'Климова','Галина','Львовна'),
(208,'Василенко','Константин','Александрович'),
(404,'Сутормина','Елена','Павловна')

insert into Пары
(
Код_преподавателя,
День_недели,
Номер_пары,
Группа
)
values
(215,'Понедельник',1,'21ЗИО-2д'),
(215,'Понедельник',2,'20СА1-1'),
(215,'Понедельник',3,'21ИС2-1'),
(215,'Понедельник',4,'20ИС3-1'),
(311,'Понедельник',1,'ПИ3-2д'),
(311,'Понедельник',2,'21ЗИО-2д'),
(311,'Понедельник',3,'20ИС3-1'),
(208,'Вторник',1,'20ИС3-1'),
(215,'Вторник',1,'22ИС1-1'),
(215,'Вторник',2,'22ИС1-1'),
(215,'Вторник',3,'22ИС1-1'),
(215,'Вторник',4,'20ИС3-1'),
(215,'Среда',1,'22ИС1-1'),
(215,'Среда',2,'20ИС3-1'),
(215,'Среда',3,'20ИС3-1'),
(215,'Среда',4,'20СА1-1'),
(311,'Среда',3,'ПИ3-2д'),
(311,'Среда',4,'20ИС3-1'),
(103,'Среда',1,'22ИС1-1'),
(103,'Среда',2,'20ИС3-1'),
(103,'Среда',3,'22ИС1-1'),
(103,'Среда',4,'21ЗИО-2д'),
(103,'Четверг',1,'22ИС1-1'),
(103,'Четверг',2,'20ИС3-1'),
(103,'Четверг',3,'22ИС1-1'),
(103,'Четверг',4,'20ИС3-1'),
(312,'Пятница',1,'22ИС1-1'),
(312,'Пятница',2,'20ИНФ3-3'),
(312,'Пятница',3,'22ИС1-1'),
(312,'Пятница',4,'20ИС3-1'),
(404, 'Понедельник',5,'22ИС1-1'),
(404, 'Вторник',4,'22ИС1-1'),
(404, 'Среда',3,'22ИС1-1'),
(404, 'Четверг',2,'22ИС1-1'),
(404, 'Пятница',1,'22ИС1-1')

insert into Подгруппы
(
Код_преподавателя,
Первая_подгруппа
)
values
(311,1),
(312,0)