CREATE TABLE users
(
id INT PRIMARY KEY IDENTITY(1,1),
username VARCHAR(MAX) NULL,
password VARCHAR(MAX) NULL, 
role VARCHAR(MAX) NULL, 
status VARCHAR(MAX) NULL, 
date_reg DATE NULL
)
SELECT * FROM users
INSERT INTO users (username, password, role, status, date_reg) VALUES('admin', 'admin123', 'Admin', 'Active','2025-04-24')

CREATE TABLE Movie
(
    id INT PRIMARY KEY IDENTITY(1,1),
    movie_id VARCHAR(MAX) NULL,
    movie_name VARCHAR(MAX) NULL,
    genre VARCHAR(MAX) NULL,
    price FLOAT NULL,
    capacity INT NULL,
    movie_image VARCHAR(MAX) NULL,
    status VARCHAR(MAX) NULL,
    created_at DATETIME NULL,
    update_date DATE NULL,
    delete_date DATE NULL
);

drop table Movie

SELECT * FROM Movie;

CREATE TABLE customers
(
id INT PRIMARY KEY IDENTITY(1,1), 
movie_id VARCHAR(MAX) NULL, 
seat_type VARCHAR(MAX) NULL, 
available_seat INT NULL, 
totalPrice FLOAT NULL, 
foods VARCHAR(MAX) NULL, 
drinks VARCHAR(MAX) NULL, 
amount FLOAT NULL,
change FLOAT NULL,
status VARCHAR(MAX) NULL, 
date_buy DATETIME NULL
)

SELECT * FROM customers

CREATE TABLE buy_tickets
(
    id INT PRIMARY KEY IDENTITY(1,1),
    movie_id VARCHAR(MAX) NULL,
    seat_number INT NULL,
    price FLOAT,
    amount FLOAT,
    change FLOAT,
    status VARCHAR(MAX) NULL,
    created_at DATETIME
);

DROP TABLE buy_tickets;

SELECT * FROM buy_tickets;

SELECT capacity FROM Movie WHERE delete_date IS NULL and status != 'Deleted';

SELECT movies.capacity, buy_tickets.* 
FROM movies 
LEFT JOIN buy_tickets 
ON movies.movie_id = buy_tickets.movie_id 
WHERE movies.movie_id = 'MID-001';

SELECT movie_id, price FROM movies;

SELECT COUNT (id) as avMovie FROM movies WHERE status = 'Available'
SELECT COUNT (id) as totalStaff FROM users WHERE role = 'Staff' AND status ='Active'
SELECT COUNT (id) as totalBuys FROM buy_tickets WHERE status = 'PAID'