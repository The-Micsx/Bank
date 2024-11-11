CREATE TABLE "home_adres"(
id serial PRIMARY KEY NOT NULL,
country varchar(50),
city varchar(50),
adres varchar(100),
home varchar(50),
apartment integer
);

CREATE TABLE "user_role"(
id serial PRIMARY KEY NOT NULL,
name varchar (50) NOT NULL
);

CREATE TABLE "user" (
id serial PRIMARY KEY NOT NULL,
name varchar (150) NOT NULL,
telephone varchar (15) NOT NULL,
email varchar (255) NOT NULL,
password varchar (255) NOT NULL,
role_id integer REFERENCES user_role (id) NOT NULL,
home_adres integer REFERENCES home_adres (id) NOT NULL,
image text
);

CREATE TABLE "exchange_rate"(
id serial PRIMARY KEY NOT NULL,
name varchar(50),
price numeric
);

CREATE TABLE "card_type"(
id serial PRIMARY KEY NOT NULL,
name varchar(50)
);

CREATE TABLE "card"(
id serial PRIMARY KEY NOT NULL,
number varchar(50),
date_start date,
date_end date,
cvv integer,
balance bigint,
card_type_id integer REFERENCES card_type (id) NOT NULL,
user_id integer REFERENCES "user" (id) NOT NULL
);

CREATE TABLE "transaction_type"(
id serial PRIMARY KEY NOT NULL,
name varchar(50)
);

CREATE TABLE "transaction_history"(
id serial PRIMARY KEY NOT NULL,
send_card_id integer REFERENCES card (id) NOT NULL,
recipient_card_id integer REFERENCES card (id) NOT NULL,
sun_of_money numeric,
datetime_dearture timestamp without time zone,
transaction_id integer REFERENCES transaction_type (id)
);