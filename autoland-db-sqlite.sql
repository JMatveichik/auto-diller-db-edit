-- Создание таблицы au_body_type
CREATE TABLE au_body_type (
    bt_id INTEGER PRIMARY KEY AUTOINCREMENT,
    bt_name TEXT NOT NULL
);

-- Создание таблицы au_automobiles
CREATE TABLE au_automobiles (
    a_id INTEGER PRIMARY KEY AUTOINCREMENT,
    a_mark TEXT NOT NULL,
    a_model TEXT NOT NULL,
    a_body_id INTEGER NOT NULL,
    a_place_count INTEGER NOT NULL CHECK (a_place_count > 0),
    a_prod_year INTEGER NOT NULL CHECK (a_prod_year > 1800),
    FOREIGN KEY (a_body_id) REFERENCES au_body_type(bt_id)
);

-- Создание таблицы au_dealers
CREATE TABLE au_dealers (
    d_id INTEGER PRIMARY KEY AUTOINCREMENT,
    d_name TEXT NOT NULL,
    d_address TEXT NOT NULL,
    d_telephone TEXT NOT NULL,
    d_fax TEXT NOT NULL
);

-- Создание таблицы au_drive_type
CREATE TABLE au_drive_type (
    dt_id INTEGER PRIMARY KEY AUTOINCREMENT,
    dt_name TEXT NOT NULL
);

-- Создание таблицы au_engine_type
CREATE TABLE au_engine_type (
    et_id INTEGER PRIMARY KEY AUTOINCREMENT,
    et_name TEXT NOT NULL
);

-- Создание таблицы au_fuel_type
CREATE TABLE au_fuel_type (
    ft_id INTEGER PRIMARY KEY AUTOINCREMENT,
    ft_name TEXT NOT NULL
);

-- Создание таблицы au_gearbox_type
CREATE TABLE au_gearbox_type (
    gt_id INTEGER PRIMARY KEY AUTOINCREMENT,
    gt_name TEXT NOT NULL
);

-- Создание таблицы au_suspension_type
CREATE TABLE au_suspension_type (
    st_id INTEGER PRIMARY KEY AUTOINCREMENT,
    st_name TEXT NOT NULL
);

-- Создание таблицы au_users
CREATE TABLE au_users (
    u_id INTEGER PRIMARY KEY AUTOINCREMENT,
    u_login TEXT NOT NULL UNIQUE,
    u_role TEXT DEFAULT 'user',
    u_password TEXT NOT NULL,
    u_name TEXT NOT NULL,
    u_surname TEXT NOT NULL,
    u_birthday TEXT NOT NULL, -- SQLite использует TEXT для дат
    u_email TEXT NOT NULL,
    u_telephone TEXT NOT NULL,
    u_address TEXT NOT NULL,
    u_avatar TEXT NOT NULL DEFAULT 'images/deafult.png'
);

-- Создание таблицы au_warranties
CREATE TABLE au_warranties (
    w_id INTEGER PRIMARY KEY AUTOINCREMENT,
    w_name TEXT NOT NULL,
    w_duration INTEGER NOT NULL,
    w_price REAL NOT NULL
);

-- Создание таблицы au_equipments
CREATE TABLE au_equipments (
    e_auto_id INTEGER NOT NULL,
    e_id INTEGER NOT NULL,
    e_name TEXT NOT NULL DEFAULT 'default',
    e_engine_name TEXT NOT NULL,
    e_engine_id INTEGER NOT NULL,
    e_engine_volume REAL NOT NULL,
    e_horse_power INTEGER NOT NULL CHECK (e_horse_power > 0),
    e_susp_id INTEGER NOT NULL,
    e_drive_id INTEGER NOT NULL,
    e_gearbox_id INTEGER NOT NULL,
    e_speed_count INTEGER NOT NULL CHECK (e_speed_count > 0),
    e_fuel_id INTEGER NOT NULL,
    e_interior TEXT NOT NULL,
    e_body_kit TEXT NOT NULL,
    e_weight INTEGER NOT NULL CHECK (e_weight > 0),
    e_price REAL NOT NULL CHECK (e_price > 0),
    e_image TEXT,
    PRIMARY KEY (e_auto_id, e_id),
    FOREIGN KEY (e_auto_id) REFERENCES au_automobiles(a_id) ON DELETE CASCADE,
    FOREIGN KEY (e_engine_id) REFERENCES au_engine_type(et_id) ON DELETE CASCADE,
    FOREIGN KEY (e_susp_id) REFERENCES au_suspension_type(st_id) ON DELETE CASCADE,
    FOREIGN KEY (e_drive_id) REFERENCES au_drive_type(dt_id) ON DELETE CASCADE,
    FOREIGN KEY (e_gearbox_id) REFERENCES au_gearbox_type(gt_id) ON DELETE CASCADE,
    FOREIGN KEY (e_fuel_id) REFERENCES au_fuel_type(ft_id) ON DELETE CASCADE
);

-- Создание таблицы au_contracts
CREATE TABLE au_contracts (
    c_id INTEGER PRIMARY KEY AUTOINCREMENT,
    c_user_id INTEGER NOT NULL,
    c_dealer_id INTEGER NOT NULL,
    c_auto_id INTEGER NOT NULL,
    c_equip_id INTEGER NOT NULL,
    c_warranty_id INTEGER NOT NULL,
    c_data TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (c_user_id) REFERENCES au_users(u_id) ON DELETE CASCADE,
    FOREIGN KEY (c_dealer_id) REFERENCES au_dealers(d_id) ON DELETE CASCADE,
    FOREIGN KEY (c_auto_id) REFERENCES au_automobiles(a_id) ON DELETE CASCADE,
    FOREIGN KEY (c_warranty_id) REFERENCES au_warranties(w_id) ON DELETE CASCADE,
    FOREIGN KEY (c_auto_id, c_equip_id) REFERENCES au_equipments(e_auto_id, e_id) ON DELETE CASCADE
);

-- Вставка данных в au_body_type
INSERT INTO au_body_type (bt_name) VALUES 
('Sedan'), ('SUV'), ('Coupe'), ('Hatchback'), ('Wagon'),
('Convertible'), ('Pickup'), ('Van'), ('Crossover'), ('Roadster');

-- Вставка данных в au_automobiles
INSERT INTO au_automobiles (a_mark, a_model, a_body_id, a_place_count, a_prod_year) VALUES 
('Toyota', 'Camry', 1, 5, 2022), ('Ford', 'Mustang', 3, 4, 2021), ('Tesla', 'Model S', 2, 5, 2023),
('Nissan', 'Juke', 2, 5, 2021), ('Honda', 'Civic', 1, 5, 2020), ('BMW', 'X5', 2, 5, 2022),
('Audi', 'A4', 1, 5, 2021), ('Mercedes', 'C-Class', 1, 5, 2023), ('Hyundai', 'Tucson', 2, 5, 2020),
('Kia', 'Sportage', 2, 5, 2022), ('Volkswagen', 'Golf', 4, 5, 2021), ('Subaru', 'Outback', 5, 5, 2023),
('Porsche', '911', 3, 2, 2022), ('Chevrolet', 'Camaro', 3, 2, 2021), ('Mazda', 'MX-5', 6, 2, 2020),
('Jeep', 'Wrangler', 2, 4, 2023), ('Ram', '1500', 7, 5, 2022), ('Dodge', 'Challenger', 3, 4, 2021),
('Lexus', 'RX', 2, 5, 2023), ('Volvo', 'XC60', 2, 5, 2022);

-- Вставка данных в au_dealers
INSERT INTO au_dealers (d_name, d_address, d_telephone, d_fax) VALUES 
('Auto Star', 'Cuza Voda 3/2', '+37368742637', '+37368742742'),
('Mercedes-Benz', 'Dacia 20/9', '+37354967423', '+37354969741'),
('DAAC Hermes', 'Petricani 37/1', '+37369658247', '+37369652475'),
('Toyota Center', 'Stefan cel Mare 10', '+37368012345', '+37368012346'),
('Ford Plaza', 'Mihai Eminescu 15', '+37368123456', '+37368123457'),
('Tesla Store', 'Alexandru cel Bun 20', '+37368234567', '+37368234568'),
('Nissan World', 'Ion Creanga 25', '+37368345678', '+37368345679'),
('Honda Motors', 'Decebal 30', '+37368456789', '+37368456780'),
('BMW Premium', 'Grigore Vieru 35', '+37368567890', '+37368567891'),
('Audi Center', 'Mircea cel Batran 40', '+37368678901', '+37368678902'),
('Hyundai Auto', 'Vasile Alecsandri 45', '+37368789012', '+37368789013'),
('Kia Motors', 'Constantin Negruzzi 50', '+37368890123', '+37368890124'),
('VW Group', 'Matei Basarab 55', '+37368901234', '+37368901235'),
('Subaru Star', 'Petru Movila 60', '+37369012345', '+37369012346'),
('Porsche Elite', 'Tighina 65', '+37369123456', '+37369123457');

-- Вставка данных в au_drive_type
INSERT INTO au_drive_type (dt_name) VALUES 
('AWD'), ('FWD'), ('RWD'), ('4WD'), ('2WD');

-- Вставка данных в au_engine_type
INSERT INTO au_engine_type (et_name) VALUES 
('V6'), ('V8'), ('Electric'), ('I4'), ('V12'),
('I6'), ('Hybrid'), ('Diesel'), ('Turbo I4'), ('Rotary');

-- Вставка данных в au_fuel_type
INSERT INTO au_fuel_type (ft_name) VALUES 
('Petrol'), ('Diesel'), ('Electric'), ('Hybrid'), ('CNG');

-- Вставка данных в au_gearbox_type
INSERT INTO au_gearbox_type (gt_name) VALUES 
('Manual'), ('Automatic'), ('CVT'), ('Dual Clutch'), ('Sequential');

-- Вставка данных в au_suspension_type
INSERT INTO au_suspension_type (st_name) VALUES 
('Standard'), ('Sport'), ('Off-Road'), ('Adaptive'), ('Air');

-- Вставка данных в au_users
INSERT INTO au_users (u_login, u_role, u_password, u_name, u_surname, u_birthday, u_email, u_telephone, u_address) VALUES 
('user1', 'user', 'pass1', 'John', 'Doe', '1985-01-01', 'john.doe@example.com', '123456789012', '123 Elm Street'),
('user2', 'user', 'pass2', 'Jane', 'Smith', '1990-02-02', 'jane.smith@example.com', '123456789013', '456 Oak Avenue'),
('user3', 'user', 'pass3', 'Bob', 'Brown', '1988-03-03', 'bob.brown@example.com', '123456789014', '789 Pine Road'),
('user4', 'user', 'pass4', 'Alice', 'Johnson', '1992-04-04', 'alice.j@example.com', '123456789015', '101 Maple Lane'),
('user5', 'user', 'pass5', 'Tom', 'Davis', '1985-05-05', 'tom.d@example.com', '123456789016', '202 Cedar Blvd'),
('user6', 'user', 'pass6', 'Lisa', 'Wilson', '1983-06-06', 'lisa.w@example.com', '123456789017', '303 Birch St'),
('user7', 'user', 'pass7', 'Mark', 'Taylor', '1979-07-07', 'mark.t@example.com', '123456789018', '404 Cherry Ave'),
('user8', 'user', 'pass8', 'Sara', 'Lee', '1995-08-08', 'sara.l@example.com', '123456789019', '505 Spruce Rd'),
('user9', 'user', 'pass9', 'Paul', 'Walker', '1981-09-09', 'paul.w@example.com', '123456789020', '606 Willow Dr'),
('user10', 'user', 'pass10', 'Emma', 'Harris', '1993-10-10', 'emma.h@example.com', '123456789021', '707 Ash St'),
('user11', 'user', 'pass11', 'Mike', 'Clark', '1987-11-11', 'mike.c@example.com', '123456789022', '808 Main St'),
('user12', 'user', 'pass12', 'Anna', 'Lewis', '1991-12-12', 'anna.l@example.com', '123456789023', '909 Oak Ave'),
('user13', 'user', 'pass13', 'David', 'King', '1984-01-13', 'david.k@example.com', '123456789024', '1010 Pine Rd'),
('Ilia', 'admin', 'admin', 'Ilia', 'Ranetchi', '2005-05-23', 'ilia@gmail.com', '+37367292196', 'gde-to'),
('abdul', 'user', 'qwerty', 'Abdul', 'Amar', '2005-12-05', 'abdul@gmail.com', '+37368523410', 'Somewhere'),
('user16', 'user', 'pass16', 'Olga', 'Petrov', '1986-02-16', 'olga.p@example.com', '123456789026', '1111 Elm St'),
('user17', 'user', 'pass17', 'Ivan', 'Sidorov', '1990-03-17', 'ivan.s@example.com', '123456789027', '1212 Maple Ln'),
('user18', 'user', 'pass18', 'Maria', 'Ivanova', '1988-04-18', 'maria.i@example.com', '123456789028', '1313 Cedar Blvd'),
('user19', 'user', 'pass19', 'Alex', 'Smirnov', '1992-05-19', 'alex.s@example.com', '123456789029', '1414 Birch St'),
('user20', 'user', 'pass20', 'Elena', 'Kuznetsova', '1985-06-20', 'elena.k@example.com', '123456789030', '1515 Cherry Ave'),
('user21', 'user', 'pass21', 'Peter', 'Jones', '1983-07-21', 'peter.j@example.com', '123456789031', '1616 Spruce Rd'),
('user22', 'user', 'pass22', 'Laura', 'Miller', '1995-08-22', 'laura.m@example.com', '123456789032', '1717 Willow Dr'),
('user23', 'user', 'pass23', 'James', 'Wilson', '1981-09-23', 'james.w@example.com', '123456789033', '1818 Ash St'),
('user24', 'user', 'pass24', 'Sophie', 'Taylor', '1993-10-24', 'sophie.t@example.com', '123456789034', '1919 Main St'),
('user25', 'user', 'pass25', 'Robert', 'Davis', '1987-11-25', 'robert.d@example.com', '123456789035', '2020 Oak Ave'),
('user26', 'user', 'pass26', 'Emily', 'Brown', '1991-12-26', 'emily.b@example.com', '123456789036', '2121 Pine Rd'),
('user27', 'user', 'pass27', 'Chris', 'Moore', '1984-01-27', 'chris.m@example.com', '123456789037', '2222 Elm St'),
('user28', 'user', 'pass28', 'Julia', 'White', '1986-02-28', 'julia.w@example.com', '123456789038', '2323 Maple Ln'),
('user29', 'user', 'pass29', 'Thomas', 'Green', '1990-03-29', 'thomas.g@example.com', '123456789039', '2424 Cedar Blvd'),
('user30', 'user', 'pass30', 'Natalie', 'Black', '1988-04-30', 'natalie.b@example.com', '123456789040', '2525 Birch St');

-- Вставка данных в au_warranties
INSERT INTO au_warranties (w_name, w_duration, w_price) VALUES 
('Basic Warranty', 24, 500.00), ('Extended Warranty', 36, 750.00), ('Premium Warranty', 48, 1000.00),
('Silver Plan', 12, 300.00), ('Gold Plan', 60, 1500.00), ('Platinum Plan', 72, 2000.00),
('Bronze Coverage', 18, 400.00), ('Diamond Plan', 84, 2500.00), ('Standard Plus', 30, 600.00),
('Elite Warranty', 96, 3000.00);

-- Вставка данных в au_equipments
INSERT INTO au_equipments (e_auto_id, e_id, e_name, e_engine_name, e_engine_id, e_engine_volume, e_horse_power, e_susp_id, e_drive_id, e_gearbox_id, e_speed_count, e_fuel_id, e_interior, e_body_kit, e_weight, e_price) VALUES 
-- Toyota Camry
(1, 1, 'Standard', 'V6', 1, 3.5, 301, 1, 2, 2, 6, 1, 'Fabric', 'None', 1500, 25000.00),
(1, 2, 'Sport', 'V6', 1, 3.5, 301, 2, 2, 2, 6, 1, 'Leather', 'Sport', 1550, 27000.00),
(1, 3, 'Luxury', 'V6', 1, 3.5, 301, 1, 2, 2, 6, 1, 'Leather', 'Luxury', 1600, 30000.00),
-- Ford Mustang
(2, 1, 'EcoBoost', 'V6', 1, 2.3, 310, 2, 3, 2, 6, 1, 'Fabric', 'Standard', 1400, 26000.00),
(2, 2, 'GT', 'V8', 2, 5.0, 450, 2, 3, 2, 6, 1, 'Leather', 'Sport', 1550, 35000.00),
(2, 3, 'Shelby', 'V8', 2, 5.2, 526, 2, 3, 2, 6, 1, 'Leather', 'Sport', 1700, 50000.00),
-- Tesla Model S
(3, 1, 'Standard Range', 'Electric', 3, 0.0, 670, 1, 1, 2, 1, 3, 'Fabric', 'None', 2100, 79990.00),
(3, 2, 'Long Range', 'Electric', 3, 0.0, 670, 1, 1, 2, 1, 3, 'Leather', 'Standard', 2150, 89990.00),
(3, 3, 'Plaid', 'Electric', 3, 0.0, 1020, 1, 1, 2, 1, 3, 'Leather', 'Sport', 2200, 129990.00),
-- Nissan Juke
(4, 1, 'Base', 'I4', 4, 1.6, 188, 1, 2, 3, 1, 1, 'Fabric', 'None', 1350, 20000.00),
(4, 2, 'Premium', 'I4', 4, 1.6, 188, 1, 2, 3, 1, 1, 'Leather', 'Standard', 1400, 23000.00),
(4, 3, 'Sport', 'Turbo I4', 9, 1.6, 215, 2, 2, 3, 1, 1, 'Leather', 'Sport', 1450, 26000.00),
-- Honda Civic
(5, 1, 'EX', 'I4', 4, 2.0, 158, 1, 2, 3, 1, 1, 'Fabric', 'None', 1300, 18000.00),
(5, 2, 'Touring', 'Turbo I4', 9, 1.5, 174, 1, 2, 3, 1, 1, 'Leather', 'Standard', 1350, 22000.00),
(5, 3, 'Si', 'Turbo I4', 9, 1.5, 205, 2, 2, 1, 6, 1, 'Leather', 'Sport', 1400, 25000.00),
-- BMW X5
(6, 1, 'xDrive40i', 'I6', 6, 3.0, 335, 4, 1, 2, 8, 1, 'Leather', 'Standard', 1900, 55000.00),
(6, 2, 'M50i', 'V8', 2, 4.4, 523, 2, 1, 2, 8, 1, 'Leather', 'Sport', 2000, 75000.00),
(6, 3, 'Base', 'Hybrid', 7, 3.0, 389, 4, 1, 2, 8, 4, 'Leather', 'Luxury', 1950, 65000.00),
-- Audi A4
(7, 1, 'Premium', 'I4', 4, 2.0, 201, 1, 1, 4, 7, 1, 'Leather', 'Standard', 1550, 35000.00),
(7, 2, 'Prestige', 'I4', 4, 2.0, 261, 4, 1, 4, 7, 1, 'Leather', 'Luxury', 1600, 40000.00),
(7, 3, 'S4', 'V6', 1, 3.0, 349, 2, 1, 4, 8, 1, 'Leather', 'Sport', 1650, 50000.00),
-- Mercedes C-Class
(8, 1, 'C300', 'I4', 4, 2.0, 255, 1, 3, 2, 9, 1, 'Leather', 'Standard', 1600, 40000.00),
(8, 2, 'AMG C43', 'V6', 1, 3.0, 385, 2, 1, 2, 9, 1, 'Leather', 'Sport', 1650, 55000.00),
(8, 3, 'C200', 'I4', 4, 1.5, 204, 1, 3, 2, 9, 1, 'Leather', 'Luxury', 1580, 45000.00),
-- Hyundai Tucson
(9, 1, 'SE', 'I4', 4, 2.5, 187, 1, 2, 2, 8, 1, 'Fabric', 'None', 1450, 24000.00),
(9, 2, 'Limited', 'I4', 4, 2.5, 187, 1, 1, 2, 8, 1, 'Leather', 'Standard', 1500, 28000.00),
(9, 3, 'Hybrid', 'Hybrid', 7, 1.6, 226, 4, 1, 2, 6, 4, 'Leather', 'Luxury', 1550, 32000.00),
-- Kia Sportage
(10, 1, 'LX', 'I4', 4, 2.5, 187, 1, 2, 2, 8, 1, 'Fabric', 'None', 1500, 25000.00),
(10, 2, 'EX', 'I4', 4, 2.5, 187, 1, 2, 2, 8, 1, 'Leather', 'Standard', 1550, 28000.00),
(10, 3, 'SX', 'Turbo I4', 9, 1.6, 227, 2, 1, 4, 7, 1, 'Leather', 'Sport', 1600, 32000.00),
-- Volkswagen Golf
(11, 1, 'TSI', 'I4', 4, 1.4, 147, 1, 2, 2, 8, 1, 'Fabric', 'None', 1350, 23000.00),
(11, 2, 'GTI', 'I4', 4, 2.0, 241, 2, 2, 4, 7, 1, 'Leather', 'Sport', 1400, 30000.00),
(11, 3, 'R', 'I4', 4, 2.0, 315, 2, 1, 4, 7, 1, 'Leather', 'Sport', 1450, 40000.00),
-- Subaru Outback
(12, 1, 'Base', 'I4', 4, 2.5, 182, 1, 1, 3, 1, 1, 'Fabric', 'None', 1550, 27000.00),
(12, 2, 'Limited', 'I4', 4, 2.5, 182, 1, 1, 3, 1, 1, 'Leather', 'Standard', 1600, 32000.00),
(12, 3, 'Touring XT', 'Turbo I4', 9, 2.4, 260, 2, 1, 3, 1, 1, 'Leather', 'Luxury', 1650, 37000.00),
-- Porsche 911
(13, 1, 'Carrera', 'I6', 6, 3.0, 379, 2, 3, 4, 8, 1, 'Leather', 'Sport', 1450, 65000.00),
(13, 2, 'Turbo S', 'I6', 6, 3.8, 640, 2, 1, 4, 8, 1, 'Leather', 'Sport', 1550, 95000.00),
(13, 3, 'GT3', 'I6', 6, 4.0, 502, 2, 3, 4, 7, 1, 'Leather', 'Sport', 1500, 85000.00),
-- Chevrolet Camaro
(14, 1, 'LT', 'I4', 4, 2.0, 275, 2, 3, 2, 6, 1, 'Fabric', 'Standard', 1450, 28000.00),
(14, 2, 'SS', 'V8', 2, 6.2, 455, 2, 3, 2, 6, 1, 'Leather', 'Sport', 1550, 40000.00),
(14, 3, 'ZL1', 'V8', 2, 6.2, 650, 2, 3, 2, 6, 1, 'Leather', 'Sport', 1650, 60000.00),
-- Mazda MX-5
(15, 1, 'Sport', 'I4', 4, 2.0, 181, 2, 3, 1, 6, 1, 'Fabric', 'None', 1150, 25000.00),
(15, 2, 'Club', 'I4', 4, 2.0, 181, 2, 3, 1, 6, 1, 'Leather', 'Sport', 1200, 28000.00),
(15, 3, 'Grand Touring', 'I4', 4, 2.0, 181, 2, 3, 2, 6, 1, 'Leather', 'Luxury', 1250, 32000.00),
-- Jeep Wrangler
(16, 1, 'Sport', 'V6', 1, 3.6, 285, 3, 4, 1, 6, 1, 'Fabric', 'Off-Road', 1750, 35000.00),
(16, 2, 'Rubicon', 'V6', 1, 3.6, 285, 3, 4, 1, 6, 1, 'Leather', 'Off-Road', 1800, 45000.00),
(16, 3, 'Sahara', 'I4', 4, 2.0, 270, 3, 4, 2, 8, 1, 'Leather', 'Standard', 1850, 40000.00),
-- Ram 1500
(17, 1, 'Tradesman', 'V8', 2, 5.7, 395, 1, 4, 2, 8, 1, 'Fabric', 'None', 2000, 35000.00),
(17, 2, 'Limited', 'V8', 2, 5.7, 395, 4, 4, 2, 8, 1, 'Leather', 'Luxury', 2100, 55000.00),
(17, 3, 'Rebel', 'V8', 2, 5.7, 395, 3, 4, 2, 8, 1, 'Leather', 'Off-Road', 2050, 50000.00),
-- Dodge Challenger
(18, 1, 'SXT', 'V6', 1, 3.6, 305, 2, 3, 2, 8, 1, 'Fabric', 'Standard', 1550, 30000.00),
(18, 2, 'R/T', 'V8', 2, 5.7, 375, 2, 3, 2, 8, 1, 'Leather', 'Sport', 1650, 40000.00),
(18, 3, 'Hellcat', 'V8', 2, 6.2, 717, 2, 3, 2, 8, 1, 'Leather', 'Sport', 1750, 65000.00),
-- Lexus RX
(19, 1, 'RX 350', 'V6', 1, 3.5, 295, 1, 2, 2, 8, 1, 'Leather', 'Standard', 1750, 45000.00),
(19, 2, 'RX 450h', 'Hybrid', 7, 3.5, 308, 4, 1, 3, 1, 4, 'Leather', 'Luxury', 1800, 55000.00),
(19, 3, 'RX 350 F Sport', 'V6', 1, 3.5, 295, 2, 2, 2, 8, 1, 'Leather', 'Sport', 1780, 50000.00),
-- Volvo XC60
(20, 1, 'T5', 'I4', 4, 2.0, 250, 1, 2, 2, 8, 1, 'Leather', 'Standard', 1650, 40000.00),
(20, 2, 'T6', 'I4', 4, 2.0, 316, 4, 1, 2, 8, 1, 'Leather', 'Luxury', 1700, 48000.00),
(20, 3, 'T8', 'Hybrid', 7, 2.0, 400, 4, 1, 2, 8, 4, 'Leather', 'Sport', 1750, 55000.00);

-- Вставка данных в au_contracts
INSERT INTO au_contracts (c_user_id, c_dealer_id, c_auto_id, c_equip_id, c_warranty_id, c_data) VALUES 
(1, 1, 1, 1, 1, '2024-12-15T10:00:00'), (2, 1, 1, 2, 2, '2024-12-15T11:00:00'),
(3, 1, 1, 3, 3, '2024-12-15T12:00:00'), (4, 2, 2, 1, 4, '2024-12-15T13:00:00'),
(5, 2, 2, 2, 5, '2024-12-15T14:00:00'), (6, 2, 2, 3, 6, '2024-12-15T15:00:00'),
(7, 3, 3, 1, 7, '2024-12-15T16:00:00'), (8, 3, 3, 2, 8, '2024-12-15T17:00:00'),
(9, 3, 3, 3, 9, '2024-12-15T18:00:00'), (10, 4, 4, 1, 10, '2024-12-15T19:00:00'),
(11, 4, 4, 2, 1, '2024-12-16T10:00:00'), (12, 4, 4, 3, 2, '2024-12-16T11:00:00'),
(13, 5, 5, 1, 3, '2024-12-16T12:00:00'), (14, 5, 5, 2, 4, '2024-12-16T13:00:00'),
(15, 5, 5, 3, 5, '2024-12-16T14:00:00'), (16, 6, 6, 1, 6, '2024-12-16T15:00:00'),
(17, 6, 6, 2, 7, '2024-12-16T16:00:00'), (18, 6, 6, 3, 8, '2024-12-16T17:00:00'),
(19, 7, 7, 1, 9, '2024-12-16T18:00:00'), (20, 7, 7, 2, 10, '2024-12-16T19:00:00'),
(21, 7, 7, 3, 1, '2024-12-17T10:00:00'), (22, 8, 8, 1, 2, '2024-12-17T11:00:00'),
(23, 8, 8, 2, 3, '2024-12-17T12:00:00'), (24, 8, 8, 3, 4, '2024-12-17T13:00:00'),
(25, 9, 9, 1, 5, '2024-12-17T14:00:00'), (26, 9, 9, 2, 6, '2024-12-17T15:00:00'),
(27, 9, 9, 3, 7, '2024-12-17T16:00:00'), (28, 10, 10, 1, 8, '2024-12-17T17:00:00'),
(29, 10, 10, 2, 9, '2024-12-17T18:00:00'), (30, 10, 10, 3, 10, '2024-12-17T19:00:00'),
(1, 11, 11, 1, 1, '2024-12-18T10:00:00'), (2, 11, 11, 2, 2, '2024-12-18T11:00:00'),
(3, 11, 11, 3, 3, '2024-12-18T12:00:00'), (4, 12, 12, 1, 4, '2024-12-18T13:00:00'),
(5, 12, 12, 2, 5, '2024-12-18T14:00:00'), (6, 12, 12, 3, 6, '2024-12-18T15:00:00'),
(7, 13, 13, 1, 7, '2024-12-18T16:00:00'), (8, 13, 13, 2, 8, '2024-12-18T17:00:00'),
(9, 13, 13, 3, 9, '2024-12-18T18:00:00'), (10, 14, 14, 1, 10, '2024-12-18T19:00:00'),
(11, 14, 14, 2, 1, '2024-12-19T10:00:00'), (12, 14, 14, 3, 2, '2024-12-19T11:00:00'),
(13, 15, 15, 1, 3, '2024-12-19T12:00:00'), (14, 15, 15, 2, 4, '2024-12-19T13:00:00'),
(15, 15, 15, 3, 5, '2024-12-19T14:00:00'), (16, 1, 16, 1, 6, '2024-12-19T15:00:00'),
(17, 1, 16, 2, 7, '2024-12-19T16:00:00'), (18, 2, 17, 1, 8, '2024-12-19T17:00:00'),
(19, 2, 17, 2, 9, '2024-12-19T18:00:00'), (20, 3, 18, 1, 10, '2024-12-19T19:00:00');
