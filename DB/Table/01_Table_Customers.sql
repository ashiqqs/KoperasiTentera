CREATE TABLE Customers (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(255) NOT NULL,
	IcNumber VARCHAR(12) NOT NULL,
	ContactNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(255) NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	ModifiedAt DATETIME2 NULL,

	INDEX idx_customer_icNumber (IcNumber),
	INDEX idx_customer_contact (ContactNumber),
	INDEX idx_customer_email (Email)
)