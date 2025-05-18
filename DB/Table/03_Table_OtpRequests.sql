CREATE TABLE OtpRequests (
 Id INT IDENTITY(1,1) PRIMARY KEY,
	CustomerId INT,
	OtpMethod INT,
	Code VARCHAR(4),
	IsUsed BIT,
	ExpiredAt DATETIME2 NOT NULL,
	CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
	ModifiedAt DATETIME2 NULL,

	INDEX idx_receiver (CustomerId)
)

DROP TABLE OtpRequests