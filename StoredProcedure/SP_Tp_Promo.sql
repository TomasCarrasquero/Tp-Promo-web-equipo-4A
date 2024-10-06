
--Buscar Cliente por DNI

CREATE PROCEDURE storedProcedureBuscarClientePorDNI
    @documento VARCHAR(50)
AS
BEGIN
    SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP 
    FROM Clientes 
    WHERE Documento = @documento
END

GO

-- Listar Clientes

CREATE PROCEDURE storedProcedureListarClientes AS
SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes

GO

-- Alta cliente 

CREATE PROCEDURE storedAltaCliente
@documento varchar(50),
@nombre varchar(50),
@apellido varchar(50),
@email varchar(50),
@direccion varchar(50),
@ciudad varchar(50),
@codigoPostal int 
AS
INSERT INTO Clientes VALUES(@documento, @nombre, @apellido, @email, @direccion, @ciudad, @codigoPostal)

GO
