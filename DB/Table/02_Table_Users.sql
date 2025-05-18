CREATE TABLE Users (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	CustomerId INT,
	PIN NVARCHAR(6) NULL,
	BiometricEnabled BIT,
	ContactVerified BIT,
	EmailVerified BIT,
	CreatedAt DATETIME2 DEFAULT GETDATE(),
	ModifiedAt DATETIME2 NULL,

	FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	INDEX idx_customer_id (CustomerId)
)