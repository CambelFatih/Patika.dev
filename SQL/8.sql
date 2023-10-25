--test veritabanınızda employee isimli sütun bilgileri id(INTEGER), name VARCHAR(50), birthday DATE, email VARCHAR(100) olan bir tablo oluşturalım.
create table employee
(
	id serial primary key,
	name varchar(50) not null,
	birthday date not null,
	email varchar(100)
)

--Oluşturduğumuz employee tablosuna 'Mockaroo' servisini kullanarak 50 adet veri ekleyelim.
insert into employee (id, name, birthday, email) values (1, 'Aylin', '1993-02-15 08:30:12', 'aylin@example.com');
insert into employee (id, name, birthday, email) values (2, 'Barış', '1987-07-20 14:45:35', 'baris@example.com');
insert into employee (id, name, birthday, email) values (3, 'Cemile', '1986-09-10 10:20:18', 'cemile@example.com');
insert into employee (id, name, birthday, email) values (4, 'Deniz', '1990-11-25 16:55:42', 'deniz@example.com');
insert into employee (id, name, birthday, email) values (5, 'Elif', '1984-04-30 09:10:29', 'elif@example.com');
insert into employee (id, name, birthday, email) values (6, 'Ferhat', '1996-05-18 11:40:07', 'ferhat@example.com');
insert into employee (id, name, birthday, email) values (7, 'Gökhan', '1979-12-05 15:25:56', 'gokhan@example.com');
insert into employee (id, name, birthday, email) values (8, 'Hande', '2001-02-12 12:15:30', 'hande@example.com');
insert into employee (id, name, birthday, email) values (9, 'Irmak', '1983-08-21 17:30:22', 'irmak@example.com');
insert into employee (id, name, birthday, email) values (10, 'Jale', '1990-06-28 13:50:45', 'jale@example.com');
insert into employee (id, name, birthday, email) values (11, 'Ali', '1980-03-10 09:15:20', 'ali@example.com');
insert into employee (id, name, birthday, email) values (12, 'Belgin', '1995-07-24 15:40:28', 'belgin@example.com');
insert into employee (id, name, birthday, email) values (13, 'Cemil', '1987-05-05 12:22:09', 'cemil@example.com');
insert into employee (id, name, birthday, email) values (14, 'Derya', '1992-08-14 18:10:36', 'derya@example.com');
insert into employee (id, name, birthday, email) values (15, 'Emre', '1984-02-20 21:55:17', 'emre@example.com');
insert into employee (id, name, birthday, email) values (16, 'Funda', '1998-09-21 22:30:53', 'funda@example.com');
insert into employee (id, name, birthday, email) values (17, 'Gürkan', '1990-12-01 16:40:25', 'gurkan@example.com');
insert into employee (id, name, birthday, email) values (18, 'Handan', '1983-07-15 23:18:47', 'handan@example.com');
insert into employee (id, name, birthday, email) values (19, 'Ismail', '1991-01-30 09:55:33', 'ismail@example.com');
insert into employee (id, name, birthday, email) values (20, 'Jale', '1993-06-26 18:25:15', 'jale@example.com');
insert into employee (id, name, birthday, email) values (21, 'Eren Demir', '1989-06-15 14:20:10', 'eren.demir@example.com');
insert into employee (id, name, birthday, email) values (22, 'Ayşe Yılmaz', '1980-05-25 10:45:30', 'ayse.yilmaz@example.com');
insert into employee (id, name, birthday, email) values (23, 'Mehmet Kaya', '1995-03-12 09:30:15', 'mehmet.kaya@example.com');
insert into employee (id, name, birthday, email) values (24, 'Selin Akın', '1990-02-18 08:15:45', 'selin.akin@example.com');
insert into employee (id, name, birthday, email) values (25, 'Emre Çetin', '1983-07-29 17:30:20', 'emre.cetin@example.com');
insert into employee (id, name, birthday, email) values (26, 'Zeynep Can', '2001-11-05 15:10:55', 'zeynep.can@example.com');
insert into employee (id, name, birthday, email) values (27, 'Ali Yıldırım', '1975-04-30 07:45:40', 'ali.yildirim@example.com');
insert into employee (id, name, birthday, email) values (28, 'Gülay Özdemir', '1987-10-10 21:20:10', 'gulay.ozdemir@example.com');
insert into employee (id, name, birthday, email) values (29, 'Ahmet Arslan', '1988-01-23 18:25:05', 'ahmet.arslan@example.com');
insert into employee (id, name, birthday, email) values (30, 'Pelin Demirci', '1999-12-07 14:45:30', 'pelin.demirci@example.com');
insert into employee (id, name, birthday, email) values (31, 'Ege', '1989-05-14 14:25:30', 'ege@example.com');
insert into employee (id, name, birthday, email) values (32, 'Cem', '1995-09-20 10:15:45', 'cem@example.com');
insert into employee (id, name, birthday, email) values (33, 'Selin', '2000-03-12 09:30:15', 'selin@example.com');
insert into employee (id, name, birthday, email) values (34, 'Emir', '1993-12-25 16:55:42', 'emir@example.com');
insert into employee (id, name, birthday, email) values (35, 'Aysu', '1987-04-30 09:10:29', 'aysu@example.com');
insert into employee (id, name, birthday, email) values (36, 'Mehmet', '1980-02-18 11:40:07', 'mehmet@example.com');
insert into employee (id, name, birthday, email) values (37, 'Oya', '1975-05-05 15:25:56', 'oya@example.com');
insert into employee (id, name, birthday, email) values (38, 'Mehmet', '1990-01-12 12:15:30', 'mehmet@example.com');
insert into employee (id, name, birthday, email) values (39, 'Rabia', '1983-08-21 17:30:22', 'rabia@example.com');
insert into employee (id, name, birthday, email) values (40, 'Aslı', '1996-06-28 13:50:45', 'asli@example.com');
insert into employee (id, name, birthday, email) values (41, 'Zehra', '1972-09-15 12:18:10', 'zehra@example.com');
insert into employee (id, name, birthday, email) values (42, 'Şebnem', '1963-12-29 05:11:18', 'sebnem@example.com');
insert into employee (id, name, birthday, email) values (43, 'Reyhan', '1966-04-07 17:16:30', 'reyhan@example.com');
insert into employee (id, name, birthday, email) values (44, 'Betül', '1960-10-28 06:16:21', 'betul@example.com');
insert into employee (id, name, birthday, email) values (45, 'Derya', '2002-03-19 10:20:37', 'derya@example.com');
insert into employee (id, name, birthday, email) values (46, 'Kerem', '1984-11-29 11:17:04', 'kerem@example.com');
insert into employee (id, name, birthday, email) values (47, 'Ceren', '1978-08-17 04:26:10', 'ceren@example.com');
insert into employee (id, name, birthday, email) values (48, 'Levent', '1992-11-26 03:45:39', 'levent@example.com');
insert into employee (id, name, birthday, email) values (49, 'Cemre', '1979-04-03 21:09:57', 'cemre@example.com');
insert into employee (id, name, birthday, email) values (50, 'Tolga', '2010-08-01 20:19:36', 'tolga@example.com');


--Sütunların her birine göre diğer sütunları güncelleyecek 5 adet UPDATE işlemi yapalım.
-- 22. kişinin bilgilerini güncelle
UPDATE employee
SET name = 'Murat',
    birthday = '1990-05-25',
    email = 'murat@example.com'
WHERE id = 7;

-- 32. kişinin bilgilerini güncelle
UPDATE employee
SET name = 'Fatma',
    birthday = '1965-03-14',
    email = 'fatma@example.com'
WHERE id = 15;

-- 24. kişinin bilgilerini güncelle
UPDATE employee
SET name = 'Süleyman',
    birthday = '1980-07-20',
    email = 'suleyman@example.com'
WHERE id = 28;

-- 3. kişinin bilgilerini güncelle
UPDATE employee
SET name = 'Zehra',
    birthday = '1972-01-05',
    email = 'zehra@example.com'
WHERE id = 1;

-- 41. kişinin bilgilerini güncelle
UPDATE employee
SET name = 'Gökhan',
    birthday = '1985-08-10',
    email = 'gokhan@example.com'
WHERE id = 11;


--Sütunların her birine göre ilgili satırı silecek 5 adet DELETE işlemi yapalım.
DELETE FROM employee WHERE id = 33
DELETE FROM employee WHERE name = 'Belgin'
DELETE FROM employee WHERE birthday = '1989-05-14 14:25:30'
DELETE FROM employee WHERE email = 'derya@example.com'
DELETE FROM employee WHERE id in(11,19,27,35,43)