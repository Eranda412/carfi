
create table cars(
car_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
owner_id varchar(8),
brand varchar,
model_na varchar,
model_yr int
);

create table users(
user_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
f_name varchar (100),
L_name varchar(100),
gender varchar(5),
stat varchar(8),
fam_num int
);

create table login(
login_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
user_id int ,
username varchar(20),
passwd varchar(20),
constraint fk_usrid foreign key(user_id)
references users(user_id)
);

create table rating(
rating_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
user_id int,
car_id int,
rating int,

constraint fk_usrid_rating foreign key(user_id)
references users(user_id),

constraint fk_carid_rating foreign key(car_id)
references cars(car_id)
);

create table cars_watched(
cars_watched_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
user_id int,
car_id int,
Iswatched bit,

constraint fk_usrid_watched foreign key(user_id)
references users(user_id),

constraint fk_carid_watched foreign key(car_id)
references cars(car_id)
);

create table location(
location_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
user_id int ,
car_id int,
location varchar(50),

constraint fk_usrid_location foreign key(user_id)
references users(user_id),

constraint fk_carid_location foreign key(car_id)
references cars(car_id)
);

