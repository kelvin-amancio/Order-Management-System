CREATE TABLE Cliente (
    [Id]       INT IDENTITY(1,1) PRIMARY KEY,
    [Nome]     NVARCHAR (50) NOT NULL,
    [Endereco] NVARCHAR (70) NOT NULL,
    [Telefone] NVARCHAR (11) NOT NULL,
    [Email]    NVARCHAR (60) NOT NULL,
);

CREATE TABLE Pedido
(
	[Id]          INT IDENTITY(1,1) PRIMARY KEY, 
    [ClienteId]   INT NOT NULL, 
    [Origem]      NVARCHAR(50) NOT NULL, 
    [Destino]     NVARCHAR(50) NOT NULL, 
    [DataCriacao] DATETIME NOT NULL, 
    [Status]      INT NOT NULL
    FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
)