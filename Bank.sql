CREATE TABLE users(
userID SERIAL PRIMARY KEY,
first_name VARCHAR(255),
last_name VARCHAR(255),
date_of_birth DATE,
phone_number INT 
); 

CREATE TABLE account(
accountID SERIAL PRIMARY KEY,
userID INT,
transferID INT UNIQUE,
cardID INT UNIQUE,
savingsID INT UNIQUE,
FOREIGN KEY (userID) REFERENCES users(userID)
);

CREATE TABLE transfer(
transferID SERIAL PRIMARY KEY,
history_of_operationsID INT UNIQUE,
transfers_to_usersID INT UNIQUE,
from_card_to_cardID INT UNIQUE,
transfer_amount DOUBLE PRECISION,
FOREIGN KEY (transferID) REFERENCES account(transferID)
);

CREATE TABLE from_card_to_card(
from_card_to_cardID SERIAL PRIMARY KEY,
transfer_amount DOUBLE PRECISION,
date_amount DATE,
cardID INT UNIQUE,
FOREIGN KEY (from_card_to_cardID) REFERENCES transfer(from_card_to_cardID)
);

CREATE TABLE transfers_to_users(
transfers_to_usersID SERIAL PRIMARY KEY,
transfer_amount DOUBLE PRECISION,
date_amount DATE,
userID INT UNIQUE,
FOREIGN KEY (userID) REFERENCES transfer(transfers_to_usersID)
);

CREATE TABLE card(
cardID SERIAL PRIMARY KEY,
card_number INT,
first_name VARCHAR(255),
last_name VARCHAR(255),
opening_date DATE,
balance DOUBLE PRECISION,
FOREIGN KEY (cardID) REFERENCES account(cardID)
);

CREATE TABLE savings( 
savingsID SERIAL PRIMARY KEY,
bank_accountID INT UNIQUE,
currency_rateID INT UNIQUE,
creditID INT UNIQUE,
portfolioID INT UNIQUE,
FOREIGN KEY (savingsID) REFERENCES account(savingsID)
);

CREATE TABLE bank_account(
bank_accountID SERIAL PRIMARY KEY,
balance DOUBLE PRECISION,
opening_date DATE,
closing_date DATE,
percent_rate DOUBLE PRECISION,
FOREIGN KEY (bank_accountID) REFERENCES savings(bank_accountID )
);

CREATE TABLE currency_rate(
currency_rateID SERIAL PRIMARY KEY,
currency_name VARCHAR(255),
buying_currencies DOUBLE PRECISION,
sale_of_currency DOUBLE PRECISION,
FOREIGN KEY (currency_rateID) REFERENCES savings(currency_rateID)
);

CREATE TABLE credit(
creditID SERIAL PRIMARY KEY,
credit_informationID INT UNIQUE,
credit_historyID INT UNIQUE,
FOREIGN KEY (creditID) REFERENCES savings(creditID)
);

CREATE TABLE credit_information(
credit_informationID SERIAL PRIMARY KEY,
credit_opening_date DATE,
percent_rate DOUBLE PRECISION,
credit_closing_date DATE,
amount_of_contributions DOUBLE PRECISION,
FOREIGN KEY (credit_informationID) REFERENCES credit(credit_informationID)
);

CREATE TABLE credit_history(
credit_historyID SERIAL PRIMARY KEY,
credit_number INT,
credit_closing_date DATE,
FOREIGN KEY (credit_historyID) REFERENCES credit(credit_historyID)
);

CREATE TABLE portfolio(
portfolioID SERIAL PRIMARY KEY,
actionsID INT UNIQUE,
FOREIGN KEY (portfolioID) REFERENCES savings(portfolioID)
);

CREATE TABLE actions(
actionsID SERIAL PRIMARY KEY,
amount_of_actions INT,
FOREIGN KEY (actionsID) REFERENCES portfolio(actionsID)
);

CREATE TABLE history_of_operations(
history_of_operationsID SERIAL PRIMARY KEY,
transferID INT UNIQUE,
receivingID INT UNIQUE,
expensesID INT UNIQUE, 
FOREIGN KEY (history_of_operationsID) REFERENCES transfer(history_of_operationsID)
);

CREATE TABLE expenses(
expensesID SERIAL PRIMARY KEY,
monthly_expenses INT,
FOREIGN KEY (expensesID) REFERENCES history_of_operations(expensesID )
);

 CREATE TABLE receiving(
receivingID SERIAL PRIMARY KEY,
userID INT,
cardID INT,
amount_received DOUBLE PRECISION,
FOREIGN KEY (receivingID) REFERENCES history_of_operations(receivingID),
FOREIGN KEY (cardID) REFERENCES from_card_to_card(cardID),
FOREIGN KEY (userID) REFERENCES transfers_to_users(userID)
);