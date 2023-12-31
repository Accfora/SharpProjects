create database Lab8;

USE [Lab8]
GO
/****** Object:  Table [dbo].[Абонемент/Е3]    Script Date: 04.09.2022 14:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Абонемент/Е3](
	[Дата_выдачи] [date] NOT NULL,
	[Срок_возраста] [int] NOT NULL,
	[Отметка_о_возрасте] [bit] NOT NULL,
	[Код_книги] [bigint] NOT NULL,
	[Код_читателя] [int] NOT NULL,
 CONSTRAINT [Unique_Identifier4] PRIMARY KEY CLUSTERED 
(
	[Дата_выдачи] ASC,
	[Код_книги] ASC,
	[Код_читателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Автор/E1]    Script Date: 04.09.2022 14:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Автор/E1](
	[Фамилия] [varchar](15) NOT NULL,
	[Имя] [varchar](10) NOT NULL,
	[Отчество] [varchar](20) NOT NULL,
	[Дата_рождения] [date] NOT NULL,
	[Нациаональность] [varchar](20) NOT NULL,
	[Род_деятельности] [varchar](30) NOT NULL,
	[Код_автора] [int] NOT NULL,
 CONSTRAINT [Unique_Identifier1] PRIMARY KEY CLUSTERED 
(
	[Код_автора] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Книга/E2]    Script Date: 04.09.2022 14:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Книга/E2](
	[Код_книги] [bigint] NOT NULL,
	[Название] [varchar](30) NOT NULL,
	[Год_издания] [int] NOT NULL,
	[Количество_страниц] [int] NOT NULL,
	[Издательство] [varchar](30) NOT NULL,
	[Код_автора] [int] NULL,
 CONSTRAINT [Unique_Identifier3] PRIMARY KEY CLUSTERED 
(
	[Код_книги] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Читатель/E4]    Script Date: 04.09.2022 14:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Читатель/E4](
	[Код_читателя] [int] NOT NULL,
	[Фамилия] [varchar](15) NOT NULL,
	[Имя] [varchar](10) NOT NULL,
	[Отчество] [varchar](20) NOT NULL,
	[Дата_рождения] [date] NOT NULL,
	[Паспортные_данные] [varchar](30) NOT NULL,
	[Адрес] [varchar](30) NOT NULL,
	[Контактный_телефон] [varchar](10) NOT NULL,
 CONSTRAINT [Unique_Identifier5] PRIMARY KEY CLUSTERED 
(
	[Код_читателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Штраф/E5]    Script Date: 04.09.2022 14:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Штраф/E5](
	[Дата_возврата] [date] NULL,
	[Состояние] [varchar](15) NULL,
	[Книга_утеряна] [bit] NOT NULL,
	[Штраф] [int] NOT NULL,
	[Дата_выдачи] [date] NOT NULL,
	[Код_книги] [bigint] NOT NULL,
	[Код_читателя] [int] NOT NULL,
 CONSTRAINT [Unique_Identifier2] PRIMARY KEY CLUSTERED 
(
	[Дата_выдачи] ASC,
	[Код_книги] ASC,
	[Код_читателя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2006-01-15' AS Date), 2, 1, 1, 1)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2010-10-12' AS Date), 4, 0, 2, 2)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2012-04-17' AS Date), 3, 1, 3, 3)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2015-02-05' AS Date), 7, 1, 4, 4)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2019-06-12' AS Date), 4, 0, 1, 3)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2019-06-12' AS Date), 5, 1, 2, 3)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2019-06-12' AS Date), 6, 1, 4, 3)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2019-06-12' AS Date), 6, 0, 5, 3)
INSERT [dbo].[Абонемент/Е3] ([Дата_выдачи], [Срок_возраста], [Отметка_о_возрасте], [Код_книги], [Код_читателя]) VALUES (CAST(N'2019-06-12' AS Date), 1, 1, 5, 5)
GO
INSERT [dbo].[Автор/E1] ([Фамилия], [Имя], [Отчество], [Дата_рождения], [Нациаональность], [Род_деятельности], [Код_автора]) VALUES (N'Ввввв', N'выфвы', N'Снюсович', CAST(N'1222-01-15' AS Date), N'Луна', N'Писатель ебать', 1)
INSERT [dbo].[Автор/E1] ([Фамилия], [Имя], [Отчество], [Дата_рождения], [Нациаональность], [Род_деятельности], [Код_автора]) VALUES (N'Конч', N'Георг', N'Галактинович', CAST(N'2004-10-12' AS Date), N'Венера', N'Писатель', 2)
INSERT [dbo].[Автор/E1] ([Фамилия], [Имя], [Отчество], [Дата_рождения], [Нациаональность], [Род_деятельности], [Код_автора]) VALUES (N'Вода', N'Спрайт', N'Виски', CAST(N'2000-07-04' AS Date), N'Земля', N'Водичка', 3)
INSERT [dbo].[Автор/E1] ([Фамилия], [Имя], [Отчество], [Дата_рождения], [Нациаональность], [Род_деятельности], [Код_автора]) VALUES (N'Ambrej', N'Dreisterne', N'mons110', CAST(N'2005-01-15' AS Date), N'Земля', N'Студент', 4)
INSERT [dbo].[Автор/E1] ([Фамилия], [Имя], [Отчество], [Дата_рождения], [Нациаональность], [Род_деятельности], [Код_автора]) VALUES (N'вграп', N'ваптот', N'ваопн', CAST(N'1999-04-24' AS Date), N'марс', N'Планета', 5)
GO
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (1, N'АААА', 2005, 200, N'ооо нет', 1)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (2, N'ООО', 2000, 15, N'даа', 2)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (3, N'Почему', 1998, 39, N'гшаршг', 3)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (4, N'аооааоао', 2006, 412, N'апвпа', 4)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (5, N'рпаргп', 2009, 42, N'4', 5)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (6, N'кеоекыо', 2000, 43, N'ооо нет', 1)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (7, N'ыоыеко', 1999, 2, N'4', 1)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (8, N'пноча', 2015, 10, N'ооо нет', 2)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (9, N'пеагеш', 1944, 236, N'апвпа', 5)
INSERT [dbo].[Книга/E2] ([Код_книги], [Название], [Год_издания], [Количество_страниц], [Издательство], [Код_автора]) VALUES (10, N'арпвец1', 1971, 22, N'арсвчсрп', 1)
GO
INSERT [dbo].[Читатель/E4] ([Код_читателя], [Фамилия], [Имя], [Отчество], [Дата_рождения], [Паспортные_данные], [Адрес], [Контактный_телефон]) VALUES (1, N'пвап', N'вап', N'вап', CAST(N'2001-01-01' AS Date), N'что', N'бездомный', N'91991')
INSERT [dbo].[Читатель/E4] ([Код_читателя], [Фамилия], [Имя], [Отчество], [Дата_рождения], [Паспортные_данные], [Адрес], [Контактный_телефон]) VALUES (2, N'шощз', N'ити', N'чсс', CAST(N'2003-02-02' AS Date), N'нет', N'лваал', N'9123')
INSERT [dbo].[Читатель/E4] ([Код_читателя], [Фамилия], [Имя], [Отчество], [Дата_рождения], [Паспортные_данные], [Адрес], [Контактный_телефон]) VALUES (3, N'ироыа', N'прг', N'немчс', CAST(N'2002-02-22' AS Date), N'да', N'белова 6', N'135235')
INSERT [dbo].[Читатель/E4] ([Код_читателя], [Фамилия], [Имя], [Отчество], [Дата_рождения], [Паспортные_данные], [Адрес], [Контактный_телефон]) VALUES (4, N'оит', N'прапр', N'иаим', CAST(N'2005-04-04' AS Date), N'апвп', N'пав', N'86934')
INSERT [dbo].[Читатель/E4] ([Код_читателя], [Фамилия], [Имя], [Отчество], [Дата_рождения], [Паспортные_данные], [Адрес], [Контактный_телефон]) VALUES (5, N'кйцкй', N'тпар', N'дгн', CAST(N'2008-09-19' AS Date), N'онрпо', N'нопп', N'672535')
INSERT [dbo].[Читатель/E4] ([Код_читателя], [Фамилия], [Имя], [Отчество], [Дата_рождения], [Паспортные_данные], [Адрес], [Контактный_телефон]) VALUES (6, N'арра', N'смчт', N'парр', CAST(N'2000-10-10' AS Date), N'вап', N'2авы', N'4124')
GO
INSERT [dbo].[Штраф/E5] ([Дата_возраста], [Состояние], [Книга_утеряна], [Штраф], [Дата_выдачи], [Код_книги], [Код_читателя]) VALUES (CAST(N'2006-01-16' AS Date), N'норм', 0, 500, CAST(N'2006-01-15' AS Date), 1, 1)
INSERT [dbo].[Штраф/E5] ([Дата_возраста], [Состояние], [Книга_утеряна], [Штраф], [Дата_выдачи], [Код_книги], [Код_читателя]) VALUES (CAST(N'2010-10-15' AS Date), N'никакое', 1, 2500, CAST(N'2010-10-12' AS Date), 2, 2)
INSERT [dbo].[Штраф/E5] ([Дата_возраста], [Состояние], [Книга_утеряна], [Штраф], [Дата_выдачи], [Код_книги], [Код_читателя]) VALUES (CAST(N'2012-04-20' AS Date), N'норм', 0, 500, CAST(N'2012-04-17' AS Date), 3, 3)
INSERT [dbo].[Штраф/E5] ([Дата_возраста], [Состояние], [Книга_утеряна], [Штраф], [Дата_выдачи], [Код_книги], [Код_читателя]) VALUES (CAST(N'2015-02-12' AS Date), N'ужас', 0, 1000, CAST(N'2015-02-05' AS Date), 4, 4)
INSERT [dbo].[Штраф/E5] ([Дата_возраста], [Состояние], [Книга_утеряна], [Штраф], [Дата_выдачи], [Код_книги], [Код_читателя]) VALUES (CAST(N'2019-06-13' AS Date), N'норм', 0, 1000, CAST(N'2019-06-12' AS Date), 5, 5)
GO
ALTER TABLE [dbo].[Абонемент/Е3]  WITH CHECK ADD  CONSTRAINT [Пользуется] FOREIGN KEY([Код_читателя])
REFERENCES [dbo].[Читатель/E4] ([Код_читателя])
GO
ALTER TABLE [dbo].[Абонемент/Е3] CHECK CONSTRAINT [Пользуется]
GO
ALTER TABLE [dbo].[Абонемент/Е3]  WITH CHECK ADD  CONSTRAINT [Учавствует] FOREIGN KEY([Код_книги])
REFERENCES [dbo].[Книга/E2] ([Код_книги])
GO
ALTER TABLE [dbo].[Абонемент/Е3] CHECK CONSTRAINT [Учавствует]
GO
ALTER TABLE [dbo].[Книга/E2]  WITH CHECK ADD  CONSTRAINT [Является автором] FOREIGN KEY([Код_автора])
REFERENCES [dbo].[Автор/E1] ([Код_автора])
GO
ALTER TABLE [dbo].[Книга/E2] CHECK CONSTRAINT [Является автором]
GO
ALTER TABLE [dbo].[Штраф/E5]  WITH CHECK ADD  CONSTRAINT [Устанавливается] FOREIGN KEY([Дата_выдачи], [Код_книги], [Код_читателя])
REFERENCES [dbo].[Абонемент/Е3] ([Дата_выдачи], [Код_книги], [Код_читателя])
GO
ALTER TABLE [dbo].[Штраф/E5] CHECK CONSTRAINT [Устанавливается]
GO
