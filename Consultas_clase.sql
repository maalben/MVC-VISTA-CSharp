CREATE TABLE TblContacto(
	Id int NOT NULL PRIMARY KEY,
	Nombre varchar(50) NULL,
	Telefono varchar(20) NULL
)

INSERT INTO dbo.TblContacto (Id, Nombre, Telefono)
VALUES (1, 'Juana de Arco', '1234567')

SELECT * FROM dbo.TblContacto


CREATE PROC SPContacto
	@opc INT,
	@Id INT = NULL,
	@Nombre VARCHAR(50) = NULL,
	@Telefono VARCHAR(20) = NULL
AS

IF @opc = 1
BEGIN
	SELECT * FROM TblContacto
END
GO



