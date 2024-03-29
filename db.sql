use master
GO

create database RadioStation
GO

use RadioStation
GO

create table Пользователи(
	ID int primary key,
	Логин varchar(50) NOT NULL UNIQUE,
	Пароль varchar(50) NOT NULL,
	Статус varchar(20) CHECK(Статус IN ('admin', 'user', 'listener'))  DEFAULT('listener') NOT NULL
)

create table Должности(
	Код int primary key,
	Название varchar(150) NOT NULL,
	Оклад money NOT NULL,
	Обязанности varchar(250) NOT NULL,
	Требования varchar(250) NOT NULL
)
GO

create table Исполнители(
	Код int primary key,
	Наименование varchar(150) NOT NULL,
	Описание varchar(250) NOT NULL,
)
GO

create table Жанр(
	Код int primary key,
	Наименование varchar(150) NOT NULL,
	Описание varchar(250) NOT NULL,
)
GO

create table Записи(
	Код int primary key,
	Наименование varchar(150) NOT NULL,
	[Код исполнителя] int NOT NULL,
	Альбом varchar(100) NOT NULL,
	Год date NOT NULL,
	[Код жанра] int NOT NULL

	CONSTRAINT FK_Записи_КодИсполнителя FOREIGN KEY([Код исполнителя]) 
	REFERENCES Исполнители(Код) ON DELETE CASCADE ON UPDATE CASCADE,

	CONSTRAINT FK_Записи_КодЖанра FOREIGN KEY([Код жанра]) 
	REFERENCES Жанр(Код) ON DELETE CASCADE ON UPDATE CASCADE,
)
GO

create table Сотрудники(
	Код int primary key,
	ФИО varchar(100) NOT NULL,
	Возраст int NOT NULL,
	Пол varchar(100) NOT NULL,
	Адрес varchar(150) NOT NULL,
	Телефон varchar(30) NOT NULL,
	Должность int NOT NULL,

	CONSTRAINT FK_Сотрудники_Должность FOREIGN KEY(Должность) 
	REFERENCES Должности(Код) ON DELETE CASCADE ON UPDATE CASCADE,
)
GO

create table [График работы](
	Код int primary key,
	Дата date NOT NULL,
	Сотрудник int NOT NULL,
	Время time NOT NULL,
	Запись int,

	CONSTRAINT FK_График_Сотрудник FOREIGN KEY(Сотрудник) 
	REFERENCES Сотрудники(Код) ON DELETE CASCADE ON UPDATE CASCADE,

	CONSTRAINT FK_График_Запись FOREIGN KEY(Запись) 
	REFERENCES Записи(Код) ON DELETE CASCADE ON UPDATE CASCADE,

	CONSTRAINT UQ_График_ДатаСотрудникЗапись UNIQUE(Дата, Сотрудник, Запись)
)
GO

INSERT INTO Должности (Код, Название, Оклад, Обязанности, Требования)
VALUES 
    (1, 'Радиоведущий', 50000, 'Ведение радиопередач, интервьюирование гостей', 'Опыт работы ведущим, хорошая коммуникативная способность'),
    (2, 'Музыкальный редактор', 45000, 'Подбор музыкального контента, создание плейлистов', 'Знание музыкальных жанров, опыт работы в редактировании музыки'),
    (3, 'Техник-звукорежиссер', 55000, 'Настройка оборудования, сведение звука', 'Технические навыки, знание звукового оборудования'),
    (4, 'Радиожурналист', 48000, 'Подготовка новостных и информационных материалов', 'Навыки журналистской работы, умение работать с информацией'),
    (5, 'Продюсер', 60000, 'Организация и контроль работы радиостанции, управление проектами', 'Опыт работы в сфере медиа, лидерские навыки'),
	(6, 'Радиоинженер', 55000, 'Обслуживание и настройка радиооборудования', 'Технические навыки, знание радиотехники'),
	(7, 'Медиапланировщик', 48000, 'Разработка медиапланов, планирование рекламных активностей', 'Знание рекламных стратегий, аналитические навыки'),
	(8, 'Программист', 60000, 'Разработка программного обеспечения для радиостанции', 'Навыки программирования, знание языков программирования'),
	(9, 'Маркетолог', 55000, 'Проведение маркетинговых исследований, разработка маркетинговых стратегий', 'Знание маркетинговых инструментов, аналитические навыки'),
	(10, 'Рекламный менеджер', 50000, 'Поиск рекламных партнеров, управление рекламными проектами', 'Навыки ведения переговоров, умение работать с клиентами')
GO

INSERT INTO Исполнители (Код, Наименование, Описание)
VALUES 
    (1, 'Coldplay', 'Британская рок-группа'),
    (2, 'Adele', 'Британская певица и автор песен'),
    (3, 'Maroon 5', 'Американская поп-рок группа'),
    (4, 'Ed Sheeran', 'Британский певец и автор песен'),
    (5, 'Taylor Swift', 'Американская певица и автор песен'),
	(6, 'Imagine Dragons', 'Американская рок-группа'),
	(7, 'Bruno Mars', 'Американский певец и музыкант'),
	(8, 'Rihanna', 'Барбадосская певица, актриса и модель'),
	(9, 'Justin Bieber', 'Канадский поп-певец и автор песен'),
	(10, 'Beyoncé', 'Американская певица, актриса и продюсер')
GO

INSERT INTO Жанр (Код, Наименование, Описание)
VALUES 
    (1, 'Рок', 'Музыкальный жанр с акцентом на гитарную музыку и энергичные ритмы'),
    (2, 'Поп', 'Популярный музыкальный жанр с мелодичными композициями и коммерческим успехом'),
    (3, 'Хип-хоп', 'Музыкальный жанр, характеризующийся речитативом и ритмичными битами'),
    (4, 'Электронная', 'Музыкальный жанр, созданный с использованием электронных инструментов и синтезаторов'),
    (5, 'Джаз', 'Музыкальный жанр с характерными импровизациями и джазовыми аккордами'),
	(6, 'Классическая', 'Музыкальный жанр, представляющий классическую музыку и композиции известных композиторов'),
	(7, 'Рэп', 'Музыкальный жанр с ритмичными речитативами и акцентом на текстовые сообщения'),
	(8, 'Регги', 'Музыкальный жанр, исходящий из Ямайки и характеризующийся ритмичными басами и позитивной атмосферой'),
	(9, 'Рок-н-ролл', 'Энергичный музыкальный жанр, сочетающий в себе элементы ритм-энд-блюза и кантри'),
	(10, 'Соул', 'Музыкальный жанр, выделившийся из афроамериканской музыки с акцентом на эмоциональное исполнение и глубокий вокал')
GO

INSERT INTO Записи (Код, Наименование, [Код исполнителя], Альбом, Год, [Код жанра])
VALUES 
    (1, 'Yellow', 1, 'Parachutes', '2000-07-10', 1),
    (2, 'Rolling in the Deep', 2, '21', '2010-11-29', 2),
    (3, 'Sugar', 3, 'V', '2014-08-29', 2),
    (4, 'Shape of You', 4, '÷', '2017-01-06', 4),
    (5, 'Love Story', 5, 'Fearless', '2008-09-12', 5),
	(6, 'Radioactive', 6, 'Night Visions', '2012-04-02', 1),
	(7, 'Just the Way You Are', 7, 'Doo-Wops & Hooligans', '2010-07-20', 2),
	(8, 'Diamonds', 8, 'Unapologetic', '2012-09-26', 5),
	(9, 'Sorry', 9, 'Purpose', '2015-10-23', 7),
	(10, 'Halo', 10, 'I Am... Sasha Fierce', '2008-11-08', 5),
	(11, 'Counting Stars', 6, 'Native', '2013-06-14', 1),
	(12, 'Grenade', 7, 'Doo-Wops & Hooligans', '2010-09-28', 2),
	(13, 'Umbrella', 8, 'Good Girl Gone Bad', '2007-03-29', 7),
	(14, 'Baby', 9, 'My World 2.0', '2010-01-18', 7),
	(15, 'Crazy in Love', 10, 'Dangerously in Love', '2003-05-18', 10),
	(16, 'Clocks', 1, 'A Rush of Blood to the Head', '2002-10-10', 1),
	(17, 'Hello', 2, '25', '2015-10-23', 2),
	(18, 'Animals', 3, 'V', '2014-08-29', 1),
	(19, 'Thinking Out Loud', 4, 'x', '2014-06-20', 3),
	(20, 'You Belong with Me', 5, 'Fearless', '2008-11-07', 4)
GO

INSERT INTO Сотрудники (Код, ФИО, Возраст, Пол, Адрес, Телефон, Должность)
VALUES 
    (1, 'Иванов Иван Иванович', 30, 'Мужской', 'г. Москва, ул. Ленина, 1', '1234567890', 1),
    (2, 'Петрова Елена Сергеевна', 28, 'Женский', 'г. Санкт-Петербург, пр. Невский, 10', '9876543210', 2),
    (3, 'Смирнов Алексей Николаевич', 35, 'Мужской', 'г. Екатеринбург, ул. Пушкина, 15', '5555555555', 3),
    (4, 'Козлова Мария Дмитриевна', 32, 'Женский', 'г. Новосибирск, ул. Гагарина, 5', '9999999999', 4),
    (5, 'Васильев Денис Александрович', 27, 'Мужской', 'г. Казань, ул. Баумана, 20', '1111111111', 5),
	(6, 'Сидорова Анна Игоревна', 29, 'Женский', 'г. Ростов-на-Дону, ул. Лермонтова, 8', '2222222222', 1),
	(7, 'Кузнецов Александр Сергеевич', 33, 'Мужской', 'г. Самара, ул. Мичурина, 12', '3333333333', 2),
	(8, 'Николаева Ольга Викторовна', 31, 'Женский', 'г. Красноярск, ул. Советская, 25', '4444444444', 3),
	(9, 'Алексеев Сергей Владимирович', 36, 'Мужской', 'г. Уфа, ул. Ленина, 50', '6666666666', 4),
	(10, 'Морозова Екатерина Андреевна', 26, 'Женский', 'г. Волгоград, пр. Ленина, 30', '7777777777', 5)
GO

INSERT INTO [График работы] (Код, Дата, Сотрудник, Время, Запись)
VALUES 
    (1, '2023-06-01', 1, '09:00:00', 1),
	(2, '2023-06-01', 2, '10:00:00', 2),
	(3, '2023-06-01', 3, '11:00:00', 3),
	(4, '2023-06-01', 4, '12:00:00', 4),
	(5, '2023-06-01', 5, '13:00:00', 5),
	(6, '2023-06-02', 1, '09:00:00', 6),
	(7, '2023-06-02', 2, '10:00:00', 7),
	(8, '2023-06-02', 3, '11:00:00', 8),
	(9, '2023-06-02', 4, '12:00:00', 9),
	(10, '2023-06-02', 5, '13:00:00', 10),
	(11, '2023-06-03', 1, '09:00:00', 11),
	(12, '2023-06-03', 2, '10:00:00', 12),
	(13, '2023-06-03', 3, '11:00:00', 13),
	(14, '2023-06-03', 4, '12:00:00', 14),
	(15, '2023-06-03', 5, '13:00:00', 15),
	(16, '2023-06-04', 1, '09:00:00', NULL),
	(17, '2023-06-04', 2, '10:00:00', NULL),
	(18, '2023-06-04', 3, '11:00:00', NULL),
	(19, '2023-06-04', 4, '12:00:00', NULL),
	(20, '2023-06-04', 5, '13:00:00', NULL)
GO

INSERT INTO Пользователи
VALUES
	(1, 'admin', 'admin', 'admin'),
	(2, 'user', 'user', 'user'),
	(3, 'listener', 'listener', 'listener')
GO
