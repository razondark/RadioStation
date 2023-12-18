use master
GO

CREATE DATABASE ServiceStation
GO

use ServiceStation
GO

CREATE TABLE Ремонтники(
	ID int CONSTRAINT CK_Ремонтники_ID CHECK(ID > 0) CONSTRAINT PK_Ремонтники_ID PRIMARY KEY,
	Фамилия varchar(50) NOT NULL,
	Разряд int CONSTRAINT CK_Ремонтники_Разряд CHECK(Разряд > 0) NOT NULL,
	Адрес varchar(100) NOT NULL,
	Телефон varchar(20) NOT NULL,
	Оклад int CONSTRAINT CK_Ремонтники_Оклад CHECK(Оклад >= 0) NOT NULL,
	Стаж int CONSTRAINT CK_Ремонтники_Стаж CHECK(Стаж >= 0) NOT NULL
)
GO

CREATE TABLE Автомобили(
	ID int CONSTRAINT CK_Автомобили_ID CHECK(ID > 0) CONSTRAINT PK_Автомобили_ID PRIMARY KEY,
	Номер varchar(20) NOT NULL,
	Марка varchar(30) NOT NULL,
	Цвет varchar(30) NOT NULL,
	[Заводской номер] varchar(30) CONSTRAINT UQ_Автомобили_ЗаводскойНомер UNIQUE NOT NULL,
	Пробег int CONSTRAINT CK_Автомобили_Пробег CHECK(Пробег >= 0) NOT NULL,
	Владелец varchar(100) NOT NULL,
	Техпаспорт varchar(30) CONSTRAINT UQ_Автомобили_Техпаспорт UNIQUE NOT NULL,
	[Год выпуска] date NOT NULL
)
GO

CREATE TABLE [Произведенный ремонт](
	Мастер int CONSTRAINT CK_ПроизведенныйРемонт_Мастер CHECK(Мастер > 0),
	Автомобиль int CONSTRAINT CK_ПроизведенныйРемонт_Автомобиль CHECK(Автомобиль > 0),
	Состояние varchar(50) NOT NULL,
	[Дата поступления] date NOT NULL,
	Документ varchar(50) NOT NULL,
	[Дата окончания] date NULL,
	Стоимость money NULL,
	[Содержание ремонта] varchar(200) NULL,

	CONSTRAINT PK_ПроизведенныйРемонт PRIMARY KEY(Мастер, Автомобиль, [Дата поступления]),

	CONSTRAINT FK_ПроизведенныййРемонт_Мастер FOREIGN KEY(Мастер)
	REFERENCES Ремонтники(ID) ON DELETE CASCADE ON UPDATE CASCADE,

	CONSTRAINT FK_ПроизведенныййРемонт_Автомобиль FOREIGN KEY(Автомобиль)
	REFERENCES Автомобили(ID) ON DELETE CASCADE ON UPDATE CASCADE
)
GO

INSERT INTO Ремонтники
VALUES
	(1, 'Иванов', '1', 'Тверская область, город Солнечногорск, спуск Славы, 81', '89997774455', '50000', '7')
	(2, 'Петров', '3', 'Ярославская область, город Дмитров, наб. Ладыгина, 06', '84445556787', '30000', '2'),
	(3, 'Сидоров', '2', 'Магаданская область, город Орехово-Зуево, ул. 1905 года, 86', '87456321478', '35000', '3'),
	(4, 'Генадьев', '2', 'Псковская область, город Коломна, шоссе Ленина, 24', '85412345789', '36000', '3'),
	(5, 'Рыбов', '5', 'Ростовская область, город Ногинск, бульвар Ленина, 75', '87456547896', '70000', '6'),
	(6, 'Котов', '3', 'Тверская область, город Видное, бульвар Ленина, 45', '87456328521', '40000', '4'),
	(7, 'Булыжников', '4', 'Ярославская область, город Зарайск, наб. Домодедовская, 84', '81236547896', '15000', '4'),
	(8, 'Аркадьев', '1', 'Ростовская область, город Истра, наб. Ломоносова, 02', '87412369854', '20000', '1'),
	(9, 'Хороводов', '4', 'Тамбовская область, город Люберцы, шоссе Домодедовская, 19', '85214698547', '26000', '5'),
	(10, 'Доков', '2', 'Архангельская область, город Дорохово, пр. Гоголя, 38', '84445556787', '80000', '7')
GO

INSERT INTO Автомобили
VALUES
	(1, 'О321НО62', 'ВАЗ 2115', 'Белый', '1GBKP32R7X3364110', '200000', 'Иванов Иван Иванович', '72НХ 930457', '2000'),
	(2, 'В888ВВ62', 'Volvo S60', 'Черный', 'UJ5ZK134875629465', '100000', 'Петров Петр Петрович', '83ЕН 821979', '2010'),
	(3, 'Р632АБ62', 'Ford Focus 2', 'Синий', 'MT9NM903646872714', '150000', 'Константинов Кондрат Платонович', '48АА 285698', '2005'),
	(4, 'О981НН62', 'Mazda 3', 'Красный', 'WE4KU578951966974', '260000', 'Кулагин Феликс Филатович', '82ТХ 468325', '2006'),
	(5, 'К777КК62', 'Renault Duster', 'Белый', 'YP1KT014326450993', '90000', 'Молчанов Василий Дмитриевич', '10ХХ 393056', '2015'),
	(6, 'Х065СК62', 'Hyndai Creta', 'Серый', 'VL1BY391758805447', '20000', 'Родионов Леонард Даниилович', '76ТУ 536205', '2020'),
	(7, 'Н123НН197', 'Hyndai Elantra', 'Черный', 'DW3NS440313188502', '15000', 'Степанов Ибрагил Онисимович', '62КА 854738', '2022'),
	(8, 'У222УУ62', 'ВАЗ 2114', 'Желтый', 'RZ6WH060665346046', '300000', 'Данилов Анатолий Дмитриевич', '41КВ 541634', '1999'),
	(9, 'Т732АР62', 'BMW M4', 'Синий', 'UD0MV962879481986', '5000', 'Красильников Альберт Ефимович', '51ТЕ 555640', '2023'),
	(10, 'В872РВ62', 'Honda Civic', 'Коричневый', 'NN9BB406886357966', '170000', 'Сазонов Остап Львович', '62ХО 475562', '2009')
GO

INSERT INTO [Произведенный ремонт]
VALUES
	(1, 1, 'Битый', '29.12.2021', 'Паспорт', '30.12.2021', '50000', 'Установка 2JZ, замена масла, замена передней левой ступицы'),
	(2, 2, 'Не битый', '15.04.2022', 'Паспорт', '16.04.2022', '10000', 'ТО5'),
	(4, 3, 'Не битый', '15.04.2022', 'Паспорт', '15.04.2022', '3000', 'Замена резины'),
	(5, 4, 'Не битый', '17.05.2022', 'Паспорт', '19.05.2022', '15000', 'ТО7'),
	(2, 5, 'Не битый', '17.05.2022', 'Паспорт', '18.05.2022', '17000', 'Замена сцепления и МКПП'),
	(3, 6, 'Не битый', '20.06.2022', 'Паспорт', '20.06.2022', '12000', 'ТО2'),
	(1, 7, 'Не битый', '21.06.2022', 'Паспорт', '23.06.2022', '5000', 'Замена масла и фильтров'),
	(5, 8, 'Битый', '21.06.2022', 'Паспорт', '19.07.2022', '50000', 'Ремонт кузова'),
	(7, 9, 'Новый', '20.06.2022', 'Паспорт', '21.06.2022', '30000', 'ТО0'),
	(8, 10, 'Не битый', '25.06.2022', 'Паспорт', '26.06.2022', '20000', 'Установка турбины'),
	(10, 1, 'Не битый', '30.06.2022', 'Паспорт', '15.07.2022', '40000', 'Установка 3JZ'),
	(4, 8, 'Не битый', '03.07.2022', 'Паспорт', '10.07.2022', '6500', 'Ремонт порогов'),
	(7, 3, 'Не битый', '05.07.2022', 'Паспорт', '06.07.2022', '7000', 'Замена ступичного подшипника'),
	(8, 6, 'Не битый', '06.07.2022', 'Паспорт', '16.07.2022', '50000', 'Перекраска кузова'),
	(6, 2, 'Битый', '05.08.2022', 'Паспорт', '10.08.2022', '26500', 'Кузовной ремонт')
GO