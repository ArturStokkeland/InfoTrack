CREATE TABLE History
(
	ID int NOT NULL IDENTITY(1, 1),
	Rankings nvarchar(255) NOT NULL,
	SearchTerm nvarchar(255) NOT NULL,
	SearchEngine nvarchar(255) NOT NULL,
	DateSearched DateTime NOT NULL
	PRIMARY KEY(ID)
)