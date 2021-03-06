/*    ==Параметры сценариев==

    Версия исходного сервера : SQL Server 2019 (15.0.2000)
    Выпуск исходного ядра СУБД : Выпуск Microsoft SQL Server Enterprise Edition
    Тип исходного ядра СУБД : Изолированный SQL Server

    Версия целевого сервера : SQL Server 2019
    Выпуск целевого ядра СУБД : Выпуск Microsoft SQL Server Enterprise Edition
    Тип целевого ядра СУБД : Изолированный SQL Server
*/
USE [master]
GO
/****** Object:  Database [DocsVisionTestDB]    Script Date: 02.08.2020 14:52:29 ******/
CREATE DATABASE [DocsVisionTestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DocsVisionTestDB', FILENAME = N'D:\DataBases\MSSQL_DocsVision\DocsVisionTestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DocsVisionTestDB_log', FILENAME = N'D:\DataBases\MSSQL_DocsVision\DocsVisionTestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DocsVisionTestDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DocsVisionTestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DocsVisionTestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DocsVisionTestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DocsVisionTestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DocsVisionTestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DocsVisionTestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET RECOVERY FULL 
GO
ALTER DATABASE [DocsVisionTestDB] SET  MULTI_USER 
GO
ALTER DATABASE [DocsVisionTestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DocsVisionTestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DocsVisionTestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DocsVisionTestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DocsVisionTestDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DocsVisionTestDB', N'ON'
GO
ALTER DATABASE [DocsVisionTestDB] SET QUERY_STORE = OFF
GO
USE [DocsVisionTestDB]
GO
/****** Object:  User [user]    Script Date: 02.08.2020 14:52:29 ******/
CREATE USER [user] FOR LOGIN [user] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ELLINISTSTATION\Ellinist]    Script Date: 02.08.2020 14:52:29 ******/
CREATE USER [ELLINISTSTATION\Ellinist] FOR LOGIN [ELLINISTSTATION\Ellinist] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ellinist]    Script Date: 02.08.2020 14:52:29 ******/
CREATE USER [ellinist] FOR LOGIN [ellinist] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [user]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [user]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [user]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [user]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [user]
GO
ALTER ROLE [db_datareader] ADD MEMBER [user]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [user]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [user]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [user]
GO
ALTER ROLE [db_owner] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [ELLINISTSTATION\Ellinist]
GO
ALTER ROLE [db_owner] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [ellinist]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [ellinist]
GO
/****** Object:  Table [dbo].[tbAttachments]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAttachments](
	[id_Attachment] [bigint] IDENTITY(1,1) NOT NULL,
	[id_LetterAttachment] [bigint] NOT NULL,
	[attachment] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_tbAttachments] PRIMARY KEY CLUSTERED 
(
	[id_Attachment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbDepartments]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDepartments](
	[id_Department] [bigint] IDENTITY(1,1) NOT NULL,
	[departmentName] [nvarchar](50) NOT NULL,
	[departmentComment] [nvarchar](200) NULL,
	[mainDepartmentFlag] [bit] NOT NULL,
 CONSTRAINT [PK_tbDepartments] PRIMARY KEY CLUSTERED 
(
	[id_Department] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbLetters]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbLetters](
	[id_Letter] [bigint] IDENTITY(1,1) NOT NULL,
	[id_DepartmentLetter] [bigint] NOT NULL,
	[letterRegisterDateTime] [datetime] NOT NULL,
	[letterName] [nvarchar](200) NOT NULL,
	[letterDateTime] [datetime] NOT NULL,
	[letterTopic] [nvarchar](200) NULL,
	[letterFrom] [varchar](100) NOT NULL,
	[letterTo] [varchar](100) NOT NULL,
	[letterContent] [nvarchar](max) NULL,
	[letterComment] [nvarchar](200) NULL,
	[isLetterIncoming] [bit] NOT NULL,
 CONSTRAINT [PK_tbLetters] PRIMARY KEY CLUSTERED 
(
	[id_Letter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTags]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTags](
	[id_Tag] [bigint] IDENTITY(1,1) NOT NULL,
	[tagName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tbTags] PRIMARY KEY CLUSTERED 
(
	[id_Tag] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbTagsOfLetters]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbTagsOfLetters](
	[id_LetterLink] [bigint] NOT NULL,
	[id_TagLink] [bigint] NOT NULL,
	[id_Link] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tbTagsOfLetters] PRIMARY KEY CLUSTERED 
(
	[id_Link] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbDepartments] ON 

INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (2, N'Организация DocsVision', N'Основной головной отдел.
Пока отдел является головным, его нельзя удалить!
Для удаления отдела снимите флаг головного!', 1)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (3, N'Администрация', N'Отдел, к которому относятся секретари, юристы, директорат и т.п.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (4, N'Бухгалтерия', N'Это кузница балансов, сверок, платежек и счетов-фактур.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (5, N'Гараж', N'Он же - транспортный цех.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (6, N'Отдел развития', N'В задачи этого отдела входят работы по поиску новых ниш.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (7, N'Отдел снабжения', N'Это мастера по закупкам компьютерной и оргтехники.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (8, N'Отдел систем управления базами данных', N'Здесь работают мастера по SQL', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (9, N'Отдел программирования', N'Это вотчина программистов всех мастей.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (10, N'Отдел документооборота', N'Здесь работают кудесники коммерческой и художественной корреспонденции.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (11, N'Плановый отдел', N'Они чего-то планируют, но чего - сами зачастую не знают.', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (12, N'Столовая', N'По сути - это кухня здорового питания сотрудников организации', 0)
INSERT [dbo].[tbDepartments] ([id_Department], [departmentName], [departmentComment], [mainDepartmentFlag]) VALUES (13, N'HR-отдел', N'Отдел кадров - это святая святых любой организации.', 0)
SET IDENTITY_INSERT [dbo].[tbDepartments] OFF
GO
SET IDENTITY_INSERT [dbo].[tbLetters] ON 

INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (2, 3, CAST(N'2020-08-01T22:03:33.443' AS DateTime), N'Письмо от CodeProject 1', CAST(N'2020-07-01T00:00:00.000' AS DateTime), N'The Daily Build - The Proper Way to Destroy Angular Components', N'mailout@maillist.codeproject.com', N'info@docsvision.com', N'New Articles, Tech Blogs and Tips




345645645645656', N'Headline article', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (3, 3, CAST(N'2020-08-02T14:04:04.317' AS DateTime), N'Письмо от CodeProject 2', CAST(N'2020-07-02T00:00:00.000' AS DateTime), N'Daily News - MP3 is 25 years old', N'mailout@maillist.codeproject.com', N'info@docsvision.com', N'Собственно, само содержание письма', N'Industry News', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (4, 9, CAST(N'2020-08-02T12:18:11.147' AS DateTime), N'ITVDN рассылка 1', CAST(N'2020-07-03T00:00:00.000' AS DateTime), N'Такого никогда не было и больше не будет!', N'info@cbsarea.com', N'info@docsvision.com', N'Добрый день!

Мы заметили, что Вы давно не читаете новостную рассылку ITVDN. И это очень огорчает нас. 
Возможно, Вы ждете специальное мега крутое предложение? Вот оно!
Ловите специальный промо код, по которому Вы можете до 1 августа приобрести любой пакет подписки со скидкой 50%.
Промо-код FTIA12E

Если наши письма автоматически попадают в спам, это можно исправить, перетащив письмо в инбокс и отметив, что это не спам.
Возможно, Вы уже изучили на ITVDN все, что Вас интересовало. Или у Вас есть другая учетная запись, другой емейл, которым Вы пользуетесь сейчас.
А может быть, Вы не нашли на ITVDN курсы, которые Вам нужны.
Пожалуйста, напишите, почему Вы не читаете нашу рассылку.
Если Вы больше не хотите получать ее - отпишитесь.', N'Очередная реклама', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (5, 13, CAST(N'2020-08-02T09:33:56.130' AS DateTime), N'Какой-то чувак хочет у нас работать', CAST(N'2020-07-04T00:00:00.000' AS DateTime), N'Касательно вакансии C# Programmer', N'vgoliney@yandex.ru', N'kartashova.a@docsvision.com', N'Анастасия, добрый день!
 
Меня очень заинтересовала вакансия программиста C# в Вашей организации.
 
В связи с тем, что в течение длительного времени я не занимался непосредственно программированием (только факультативно - в рамках собственного саморазвития) я могу претендовать на позицию junior с соответствующим понижением в зарплате.
 
Так получилось, что в течение 10 лет я занимался направлением строительного проектирования, в том числе выполнял обязанности главного инженера проекта.
В области программирования я занимался созданием ERP систем для операторов связи. Это была целиком и полностью наша разработка.
В мой профиль деятельности входило написание ТЗ, создание структуры таблиц в БД (СУБД, которую мы использовали - Oracle), написание клиентского окончания (на языке C++), отладка, тестирование, внедрение и развертывание у клиентов.
 
По прошествии определенного времени я понял, что только программирование - моя цель и желание в жизни
 
Поэтому я решил в корне поменять специфику (точнее - вернуться на круги своя) и снова стать программистом.
 
Мой опыт в программировании:
от языка Fortran-4, через Pascal и Assembler до языков C, C++ и C#.
Работал с разными СУБД - MS SQL, MySQL, SQLite, Interbase, Firebird, Oracle, PostgeSQL.
Также имею определенный опыт в верстке на HTML и CSS.
 
В области программирования работаю в среде Visual Studio (WinForms и WPF).
 
Английский язык - свободно. Грамотная речь, умение писать большие тексты - являюсь автором двух публикаций в издательстве "Питер Паблишинг".
 
Если все то, что я написал выше, Вас как-то заинтересует, готов предоставить любую дополнительную информацию.
 
Заранее спасибо за уделенное внимание,
 
-- 
С уважением,
Вячеслав Николаевич Голиней
+7 (911) 987-05-05', N'Послать его, что ли?', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (6, 13, CAST(N'2020-07-30T19:40:11.033' AS DateTime), N'Ответ назойливому кандидату', CAST(N'2020-07-05T00:00:00.000' AS DateTime), N'RE: Касательно вакансии C# Programmer', N'Kartashova.A@docsvision.com', N'vgoliney@yandex.ru', N'Вячеслав, добрый день!
Спасибо за ваш отклик, давайте начнем с задания, в вашем резюме указан опыт работы с базами данных, что является для нас важным плюсом в должности вакансию Младший разработчик C#/ MS SQL/ Postgre SQL.
Ознакомитесь с тестовым заданием, пожалуйста, если вы готовы его выполнить, напишите сроки выполнения.
Спасибо и удачи 

С уважением,  
Анастасия Карташова 
Ведущий менеджер по персоналу 
Компания «ДоксВижн» 
E-mail: kartashova.a@docsvision.com | Тел.: +7 (812) 622-16-89 (доб. 367) | +7 (911) 005-70-31  | docsvision.com 

Данное сообщение предназначено исключительно для использования его предполагаемым получателем (-ями), содержащиеся в нем сведения являются конфиденциальной информацией ООО "ДоксВижн" и не могут разглашаться третьим лицам без предварительного письменного согласия ООО "ДоксВижн". Не допускается распространение, копирование и использование данной информации другими лицами. Если вы не являетесь предполагаемым получателем и / или получили данное сообщение ошибочно, пожалуйста, сообщите нам об этом ответным электронным сообщением или по вышеуказанным телефонам, удалите исходное сообщение и уничтожьте любые его копии из вашей системы. Любое распространение, несанкционированный просмотр, использование, разглашение, распространение, копирование или действия в отношении содержания настоящего электронного сообщения, полностью или частично, строго запрещены 
', N'Первая отмазка', 0)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (7, 13, CAST(N'2020-08-01T19:44:58.083' AS DateTime), N'Новое письмо от кандидата', CAST(N'2020-07-07T00:00:00.000' AS DateTime), N'Re: Касательно вакансии C# Programmer', N'vgoliney@yandex.ru', N'kartashova.a@docsvision.com', N'Анастасия, добрый день!
 
Спасибо за оказанное доверие выполнить задание.
К сожалению, письмо от вас пришло только поздно вечером в пятницу (19 июня), прочитать сумел только сегодня...
Постараюсь выполнить задание за три дня (как указано в самом задании). Если почувствую, что не успеваю, сообщу вам не позднее завтрашнего дня.
 
Еще раз спасибо,
 
С уважением, Вячеслав Голиней.
+7 (911) 987-05-05
', N'Надо же - он настаивает!', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (8, 13, CAST(N'2020-08-01T15:43:26.770' AS DateTime), N'Пусть помучается', CAST(N'2020-07-08T00:00:00.000' AS DateTime), N'RE: Касательно вакансии C# Programmer', N'Kartashova.A@docsvision.com', N'vgoliney@yandex.ru', N'Добрый день!
Хорошо, в любом случае, качество реализации решения важнее, так что если вам нужно будет глубже погрузится в технологии, сообщите нам 

С уважением,  
Анастасия Карташова 
Ведущий менеджер по персоналу ', N'Я не скажу ни да ни нет - но пусть он поработает!', 0)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (9, 9, CAST(N'2020-08-01T19:30:30.720' AS DateTime), N'Кандидат боится', CAST(N'2020-07-09T00:00:00.000' AS DateTime), N'Re: Касательно вакансии C# Programmer', N'vgoliney@yandex.ru', N'elkhov.d@docsvision.com', N'+ elkhov.d@
 
Анастасия, добрый день.
 
Как и обещал, направляю вам письмо по поводу тестового задания.
К сожалению, выполнить его в обозначенные сроки я не смогу.
Если бы задача ограничивалась только рамками WinForms или WPF, то я ее уже бы вам выслал.
Ситуация заключается в том, что я не работал ранее с web-сервисами. Для того, чтобы с ними познакомиться мне понадобится не менее недели.
Я уже связывался с Денисом - он меня понял; мы договорились, что я, в любом случае, поставлю вас в известность.
Сама задача мне интересна, и я ее выполню независимо от того, какое решение вы примете.
Я сам понимаю, что на данный момент не подхожу вам. Мне не хватает кое-каких знаний.
 
Извините за беспокойство, спасибо за проявленное внимание.
 
Всего вам доброго...
 
С уважением, Вячеслав Голиней.
', N'Чувствует, что не справится...', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (10, 13, CAST(N'2020-08-02T12:17:30.440' AS DateTime), N'Пусть работает', CAST(N'2020-07-11T00:00:00.000' AS DateTime), N'RE: Касательно вакансии C# Programmer', N'Kartashova.A@docsvision.com', N'vgoliney@yandex.ru', N'Добрый день!
Спасибо за ваш ответ! 
На ваше решение «Сама задача мне интересна, и я ее выполню независимо от того, какое решение вы примете» - поддерживаю 😊
Всего вам доброго!
', N'Введите комментарий к письму', 0)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (11, 3, CAST(N'2020-08-02T10:31:21.470' AS DateTime), N'Ждем результат от очередного кандидата', CAST(N'2020-07-18T00:00:00.000' AS DateTime), N'Сообщаем о выпавшем в осадок кандидате на должность программиста c#', N'Kartashova.A@docsvision.com', N'office@docsvision.com', N'Уважаемое руководство!

Спешу сообщить, что рассматриваемый кандидат ушел в глубокий АУТ...

Он не пишет, не звонит, не теребонькает.

Мы его потеряли!

С уважением,  
Анастасия Карташова 
Ведущий менеджер по персоналу ', N'Скорее всего, кандидат не справится с заданием - да и в топку его!', 0)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (12, 3, CAST(N'2020-08-01T10:56:11.293' AS DateTime), N'Вебинар - искусственный интеллект', CAST(N'2020-07-14T00:00:00.000' AS DateTime), N'РБК Pro: ваше приглашение на вебинар «Искусственный интеллект для бизнеса: как выбрать и реализовать проект»', N'noreply@nic.ru', N'info@docsvision.com', N'Уважаемый клиент!
 
Наш партнёр — РБК Pro — приглашает вас на бесплатный вебинар «Искусственный интеллект для бизнеса: как выбрать и реализовать проект».
 
Спикер — Александр Фонарев, сооснователь и директор по анализу данных компании Rubbles, занимающейся разработкой бизнес решений на базе искусственного интеллекта (ИИ). PhD в области Data Science. Более 5 лет преподавал в Школе анализа данных «Яндекса».

Вы узнаете:
 об искусственном интеллекте в бизнесе: как и где его применять. Разбор кейсов;
 как на этапе оценки распознать перспективное решение на основе ИИ и отсеять убыточные проекты;
 как работает ИИ: как устроены алгоритмы, и о каких ограничениях важно знать бизнесу;
 о команде Data Science проекта: какой она должна быть и как эффективно выстроить её работу.', N'Очередная рекламная рассылка', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (13, 13, CAST(N'2020-08-02T10:22:05.623' AS DateTime), N'Уведомление о доставке', CAST(N'2020-07-15T00:00:00.000' AS DateTime), N'Delivered: Re: Касательно вакансии C# Programmer', N'postmaster@digdes.com', N'vgoliney@yandex.ru', N'Your message has been delivered to the following recipients:

vgoliney@yandex.ru', N'Введите комментарий к письму', 1)
INSERT [dbo].[tbLetters] ([id_Letter], [id_DepartmentLetter], [letterRegisterDateTime], [letterName], [letterDateTime], [letterTopic], [letterFrom], [letterTo], [letterContent], [letterComment], [isLetterIncoming]) VALUES (14, 3, CAST(N'2020-08-02T10:40:42.217' AS DateTime), N'С победой над коронавирусом!', CAST(N'2020-07-20T00:00:00.000' AS DateTime), N'Поздравление', N'secretary@docsvision.com', N'everybody@docsvision.com', N'Коронавирус - это фейк, придуманный сильными мира сего для какой-то своей цели!

Мы не будем верить в эту ерунду!

Поэтому - всем срочно на работу!', N'Лучше быть богатым и здоровым, чем бедным и больным!', 1)
SET IDENTITY_INSERT [dbo].[tbLetters] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTags] ON 

INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (8, N'Важное')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (12, N'Новый')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (13, N'Обучение')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (6, N'Отдых')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (9, N'Программы')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (5, N'Работа')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (2, N'Технологии')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (4, N'Уведомление')
INSERT [dbo].[tbTags] ([id_Tag], [tagName]) VALUES (3, N'Финансы')
SET IDENTITY_INSERT [dbo].[tbTags] OFF
GO
SET IDENTITY_INSERT [dbo].[tbTagsOfLetters] ON 

INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (6, 5, 15)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (12, 2, 33)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (12, 4, 34)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (12, 3, 35)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (8, 5, 53)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (9, 2, 93)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (9, 5, 94)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (7, 5, 110)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (7, 4, 111)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (2, 2, 113)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (2, 3, 114)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (2, 9, 115)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (5, 5, 123)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (5, 9, 124)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (5, 8, 125)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (13, 2, 128)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (11, 6, 132)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (10, 8, 133)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (4, 3, 136)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (4, 9, 137)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (4, 13, 138)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (3, 2, 141)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (3, 9, 142)
INSERT [dbo].[tbTagsOfLetters] ([id_LetterLink], [id_TagLink], [id_Link]) VALUES (3, 5, 143)
SET IDENTITY_INSERT [dbo].[tbTagsOfLetters] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tbDepartments]    Script Date: 02.08.2020 14:52:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbDepartments] ON [dbo].[tbDepartments]
(
	[departmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tbLetters]    Script Date: 02.08.2020 14:52:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbLetters] ON [dbo].[tbLetters]
(
	[letterName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_tbTags]    Script Date: 02.08.2020 14:52:29 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbTags] ON [dbo].[tbTags]
(
	[tagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbDepartments] ADD  CONSTRAINT [DF_tbDepartments_mainDepartmentFlag]  DEFAULT ((0)) FOR [mainDepartmentFlag]
GO
ALTER TABLE [dbo].[tbLetters] ADD  CONSTRAINT [DF_tbLetters_id_DepartmentLetter]  DEFAULT ((1)) FOR [id_DepartmentLetter]
GO
ALTER TABLE [dbo].[tbLetters] ADD  CONSTRAINT [DF_tbLetters_letterRegisterDateTime]  DEFAULT (getdate()) FOR [letterRegisterDateTime]
GO
ALTER TABLE [dbo].[tbLetters] ADD  CONSTRAINT [DF_tbLetters_isLetterIncoming]  DEFAULT ((1)) FOR [isLetterIncoming]
GO
ALTER TABLE [dbo].[tbAttachments]  WITH CHECK ADD  CONSTRAINT [FK_tbAttachments_tbLetters] FOREIGN KEY([id_LetterAttachment])
REFERENCES [dbo].[tbLetters] ([id_Letter])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbAttachments] CHECK CONSTRAINT [FK_tbAttachments_tbLetters]
GO
ALTER TABLE [dbo].[tbLetters]  WITH CHECK ADD  CONSTRAINT [FK_tbLetters_tbDepartments] FOREIGN KEY([id_DepartmentLetter])
REFERENCES [dbo].[tbDepartments] ([id_Department])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbLetters] CHECK CONSTRAINT [FK_tbLetters_tbDepartments]
GO
ALTER TABLE [dbo].[tbTagsOfLetters]  WITH CHECK ADD  CONSTRAINT [FK_tbTagsOfLetters_tbLetters] FOREIGN KEY([id_LetterLink])
REFERENCES [dbo].[tbLetters] ([id_Letter])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbTagsOfLetters] CHECK CONSTRAINT [FK_tbTagsOfLetters_tbLetters]
GO
ALTER TABLE [dbo].[tbTagsOfLetters]  WITH CHECK ADD  CONSTRAINT [FK_tbTagsOfLetters_tbTags] FOREIGN KEY([id_TagLink])
REFERENCES [dbo].[tbTags] ([id_Tag])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbTagsOfLetters] CHECK CONSTRAINT [FK_tbTagsOfLetters_tbTags]
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionAddTag]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <31.07.2020>
-- Description:	<Добавление тэга>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionAddTag]
	-- Add the parameters for the stored procedure here
	@TAGNAME nvarchar(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO tbTags (tagName) VALUES (@TAGNAME);
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionDeleteDepartment]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <22/07/2020>
-- Description:	<Процедура удаления записи из таблицы отделов>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionDeleteDepartment] -- Для обновления процедуры заменить CREATE на ALTER
	@IDDELETEDEPARTMENT bigint -- Параметр: идентификатор удаляемого отдела
AS

DECLARE @DEPARTMENTFLAG bit;      -- Флаг отдела (головной или обычный)
DECLARE @IDMAINDEPARTMENT bigint; -- Идентификатор головного отдела

-- Определяем идентификатор отдела, который считается головным (главным)
SELECT @IDMAINDEPARTMENT = id_Department FROM tbDepartments WHERE mainDepartmentFlag = 1;
-- Определяем флаг удаляемого отдела (является ли он главным или обычным)
SELECT @DEPARTMENTFLAG = mainDepartmentFlag FROM tbDepartments WHERE id_Department = @IDDELETEDEPARTMENT;

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@DEPARTMENTFLAG = 1) -- Проверяем флаг отдела
	BEGIN -- Если отдел головной (главный), его удалять нельзя - возвращаемся из процедуры со значением 0
		RAISERROR('Error', 16, 1);
	END
	ELSE
	BEGIN -- Если отдел обычный, его допускается удалить - проводим удаление
		BEGIN TRANSACTION -- Для обеспечения гарантированности выполнения операции - начинаем транзакцю
		-- Обновляем в дочерней таблице (таблица писем) идентификатор родительского отдела
		-- при удалении текущего родительского отдела, для записей в таблице писем родительским становится головной (главный) отдел
		UPDATE tbLetters SET id_DepartmentLetter = @IDMAINDEPARTMENT WHERE id_DepartmentLetter = @IDDELETEDEPARTMENT;
		-- Удаляем запись отдела
		DELETE FROM tbDepartments WHERE id_Department = @IDDELETEDEPARTMENT;
		COMMIT -- Завершаем транзакцию
		RETURN 1 -- Возвращаем значение 1 - операция прошла успешно
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionDeleteLetter]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <29/07/2020>
-- Description:	<Процедура удаления записи из таблицы писем>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionDeleteLetter] 
	@IDDELETELETTER bigint -- Параметр: идентификатор удаляемого письма
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM tbLetters WHERE id_Letter = @IDDELETELETTER;
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionDeleteTag]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionDeleteTag]
	-- Add the parameters for the stored procedure here
	@IDDELETETAG bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM tbTags WHERE id_Tag = @IDDELETETAG;
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionInsertDepartment]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <22/07/2020>
-- Description:	<Процедура добавления записи в таблицу отделов>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionInsertDepartment] -- Для обновления процедуры заменить CREATE на ALTER 
	-- Add the parameters for the stored procedure here
	@DEPARTMENTNAME     nvarchar(50),  -- Название отдела
	@DEPARTMENTCOMMENT  nvarchar(200), -- Комментарий по отделу
	@MAINDEPARTMENTFLAG bit,           -- Флаг главного отдела (1 (true) - главный отдел, 0 (false) - обычный отдел)
	@LASTRECORDID bigint OUTPUT        -- Выходной параметр, содержащий последний созданный идентификатор записей
AS
DECLARE @IDOLDMAINDEPARTMENT bigint;   -- Идентификатор предыдущего главного отдела
DECLARE @IDNEWDEPARTMENT bigint;

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@MAINDEPARTMENTFLAG = 1)
	BEGIN -- В случае смены статуса отдела - новый отдел имеет флаг 1 (true)
		-- Находим значение идентификатора записи для предыдущего главного отдела
		SELECT @IDOLDMAINDEPARTMENT = id_Department FROM tbDepartments WHERE mainDepartmentFlag = 1;
		-- Обновляем старую запись (запись для старого главного отдела)
		UPDATE tbDepartments SET mainDepartmentFlag = 0 WHERE id_Department = @IDOLDMAINDEPARTMENT;
		-- Добавляем новую запись с новым главным отделом
		INSERT INTO tbDepartments (departmentName, departmentComment, mainDepartmentFlag)
			   VALUES (@DEPARTMENTNAME, @DEPARTMENTCOMMENT, 1);
	END
	ELSE
	BEGIN -- В случае, если новый отдел имеет флаг 0 (false) -  отсутствие изменений в статусе отделов
		-- Добавляем новую запись с сохранением старого главного отдела
		INSERT INTO tbDepartments (departmentName, departmentComment) VALUES (@DEPARTMENTNAME, @DEPARTMENTCOMMENT);
	END
SELECT @LASTRECORDID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionInsertLetter]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <28/07/2020>
-- Description:	<Inserting new record to tbLetters>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionInsertLetter] -- При обновлении заменить CREATE на ALTER
	-- Add the parameters for the stored procedure here
	@IDDEPARTMENTLETTER bigint = 2, 
	@LETTERNAME nvarchar(200),
	@LETTERDATETIME date,
	@LETTERTOPIC nvarchar(200),
	@LETTERFROM varchar(100),
	@LETTERTO varchar(100),
	@LETTERCONTENT nvarchar(MAX),
	@LETTERCOMMENT nvarchar(200),
	@ISLETTERINCOMING bit,
	@LASTRECORDID bigint OUTPUT        -- Выходной параметр, содержащий последний созданный идентификатор записей
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO tbLetters (id_DepartmentLetter, letterName, letterDateTime, letterTopic, letterFrom, letterTo, letterContent, letterComment, isLetterIncoming)
	VALUES (@IDDEPARTMENTLETTER, @LETTERNAME, @LETTERDATETIME, @LETTERTOPIC, @LETTERFROM, @LETTERTO, @LETTERCONTENT, @LETTERCOMMENT, @ISLETTERINCOMING);

	SELECT @LASTRECORDID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionRenameTag]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <31.07.2020>
-- Description:	<Переименование тэга>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionRenameTag]
	-- Add the parameters for the stored procedure here
	@IDTAG bigint,
	@TAGNAME nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE tbTags SET tagName = @TAGNAME WHERE id_Tag = @IDTAG;
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionSelectDepartments]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionSelectDepartments] 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM tbDepartments ORDER BY departmentName ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionSelectLetters]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <31.07.2020>
-- Description:	<Динамический запросы выборки списка писем>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionSelectLetters]
	@WHERECONDITION varchar(MAX)
AS
DECLARE @SELECTQUERY varchar(MAX);


BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @SELECTQUERY = @WHERECONDITION;

	EXEC (@SELECTQUERY);	
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionSelectTags]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <31.07.2020>
-- Description:	<Процедура выборки тэгов>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionSelectTags]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM tbTags ORDER BY tagName;
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionUpdateDepartment]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <22/07/2020>
-- Description:	<Процедура обновления записи в таблице отделов>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionUpdateDepartment]
	-- Add the parameters for the stored procedure here
	@IDUPDATEDEPARTMENT bigint,        -- Идентификатор обновляемой записи таблицы отделов
	@DEPARTMENTNAME nvarchar(50),      -- Название отдела
	@DEPARTMENTCOMMENT nvarchar(200),  -- Комментарий по отделу
	@MAINDEPARTMENTFLAG bit            -- Флаг главного отдела (1 (true) - главный отдел, 0 (false) - обычный отдел)
AS
DECLARE @IDOLDMAINDEPARTMENT bigint;  -- Идентификатор предыдущего главного отдела

BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@MAINDEPARTMENTFLAG = 1)
	BEGIN -- В случае смены статуса отдела - новый отдел имеет флаг 1 (true)
	    -- Находим значение идентификатора записи для предыдущего главного отдела
		SELECT @IDOLDMAINDEPARTMENT = id_Department FROM tbDepartments WHERE mainDepartmentFlag = 1;
		-- Обновляем старую запись (запись для старого главного отдела)
		UPDATE tbDepartments SET mainDepartmentFlag = 0 WHERE id_Department = @IDOLDMAINDEPARTMENT;
		-- Обновляем новую запись с новым главным отделом
		UPDATE tbDepartments SET departmentName = @DEPARTMENTNAME, departmentComment = @DEPARTMENTCOMMENT,
		       mainDepartmentFlag = 1 WHERE id_Department = @IDUPDATEDEPARTMENT;
	END
	ELSE
	BEGIN -- В случае, если новый отдел имеет флаг 0 (false) - отсутствие изменений в статусе отделов
		UPDATE tbDepartments SET departmentName = @DEPARTMENTNAME, departmentComment = @DEPARTMENTCOMMENT
		       WHERE id_Department = @IDUPDATEDEPARTMENT;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[DocsVisionUpdateLetter]    Script Date: 02.08.2020 14:52:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ellinist>
-- Create date: <29.07.2020>
-- Description:	<Процедура обновления выбранного письма>
-- =============================================
CREATE PROCEDURE [dbo].[DocsVisionUpdateLetter] 
	@IDLETTER bigint,
	@IDDEPARTMENTLETTER bigint, 
	@LETTERNAME nvarchar(200),
	@LETTERDATETIME date,
	@LETTERTOPIC nvarchar(200),
	@LETTERFROM varchar(100),
	@LETTERTO varchar(100),
	@LETTERCONTENT nvarchar(MAX),
	@LETTERCOMMENT nvarchar(200),
	@ISLETTERINCOMING bit
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE tbLetters SET letterName = @LETTERNAME, id_DepartmentLetter = @IDDEPARTMENTLETTER, letterDateTime = @LETTERDATETIME,
	                     letterTopic = @LETTERTOPIC, letterFrom = @LETTERFROM, letterTo = @LETTERTO, letterContent = @LETTERCONTENT,
						 letterComment = @LETTERCOMMENT, isLetterIncoming = @ISLETTERINCOMING, letterRegisterDateTime = GETDATE()
    WHERE id_Letter = @IDLETTER;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор записи в таблице вложений' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbAttachments', @level2type=N'COLUMN',@level2name=N'id_Attachment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор письма для вложения' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbAttachments', @level2type=N'COLUMN',@level2name=N'id_LetterAttachment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Вложение (файл, изображение и т.д.)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbAttachments', @level2type=N'COLUMN',@level2name=N'attachment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Таблица вложений писем' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbAttachments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор отдела организации' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbDepartments', @level2type=N'COLUMN',@level2name=N'id_Department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название отдела' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbDepartments', @level2type=N'COLUMN',@level2name=N'departmentName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Комментарий по отделу' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbDepartments', @level2type=N'COLUMN',@level2name=N'departmentComment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Флаг, является ли данный отдел главным (необходим для защиты главного отдела от удаления)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbDepartments', @level2type=N'COLUMN',@level2name=N'mainDepartmentFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Таблица отделов организации' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbDepartments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор записи в таблице писем' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'id_Letter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор отдела для письма (вычисление в триггере)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'id_DepartmentLetter'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата регистрации письма (внесения в БД)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterRegisterDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название письма (произвольный текст)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата получения или отправки письма' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Тема письма (необязательное поле)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterTopic'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Отправитель (гиперссылка)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterFrom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Адресат (гиперссылка)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterTo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Содержание письма (необязательное поле)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Комментарий к письму (необязательное поле)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'letterComment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Тип письма: входящее (true) или исходящее (false)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters', @level2type=N'COLUMN',@level2name=N'isLetterIncoming'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Таблица писем организации' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbLetters'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор записи в таблице тэгов' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbTags', @level2type=N'COLUMN',@level2name=N'id_Tag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название тэга' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbTags', @level2type=N'COLUMN',@level2name=N'tagName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Таблица набора тэгов' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbTags'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний идентификатор письма' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbTagsOfLetters', @level2type=N'COLUMN',@level2name=N'id_LetterLink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Внешний идентификатор тэга' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbTagsOfLetters', @level2type=N'COLUMN',@level2name=N'id_TagLink'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Таблица связи тэгов с письмами' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tbTagsOfLetters'
GO
USE [master]
GO
ALTER DATABASE [DocsVisionTestDB] SET  READ_WRITE 
GO
