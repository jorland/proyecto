USE [master]
GO
/****** Object:  Database [AEROLINEA_UAM]    Script Date: 18/08/2015 9:52:44 ******/
CREATE DATABASE [AEROLINEA_UAM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AEROLINEA_UAM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AEROLINEA_UAM.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AEROLINEA_UAM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AEROLINEA_UAM_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AEROLINEA_UAM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AEROLINEA_UAM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AEROLINEA_UAM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET ARITHABORT OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AEROLINEA_UAM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AEROLINEA_UAM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AEROLINEA_UAM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AEROLINEA_UAM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AEROLINEA_UAM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET RECOVERY FULL 
GO
ALTER DATABASE [AEROLINEA_UAM] SET  MULTI_USER 
GO
ALTER DATABASE [AEROLINEA_UAM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AEROLINEA_UAM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AEROLINEA_UAM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AEROLINEA_UAM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AEROLINEA_UAM]
GO
/****** Object:  StoredProcedure [dbo].[OBT_ULTIMO_AVION_INGRESADO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SELECCIONA EL ULTIMO AVION INGRESADO
CREATE PROCEDURE [dbo].[OBT_ULTIMO_AVION_INGRESADO]
AS
BEGIN
	SELECT TOP 1 ID_AVION
	  FROM AVION
	ORDER BY ID_AVION DESC;
END;


GO
/****** Object:  StoredProcedure [dbo].[PRDB_AGREGAR_MILLAS]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_AGREGAR_MILLAS]
@pMILLAS INT,
@pID_CLIENTE INT
AS
BEGIN
	UPDATE CLIENTE
	SET MILLAS += @pMILLAS
	WHERE CEDULA = @pID_CLIENTE;
END

GO
/****** Object:  StoredProcedure [dbo].[PRDB_CAMBIA_COND_CLIENTE]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_CAMBIA_COND_CLIENTE]
@pCONDICION VARCHAR(50),
@pID_CLIENTE INT
AS
BEGIN
	UPDATE CLIENTE
	SET CONDICION = @pCONDICION
	WHERE ID_CLIENTE = @pID_CLIENTE;
END


GO
/****** Object:  StoredProcedure [dbo].[PRDB_CAMBIO_ESTADO_AVION]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_CAMBIO_ESTADO_AVION]
@pID_AVION INT,
@pESTADO   CHAR(1)
AS
BEGIN
	UPDATE AVION
	   SET ESTADO = @pESTADO
	WHERE ID_AVION  = @pID_AVION;
END;


GO
/****** Object:  StoredProcedure [dbo].[PRDB_CAMBIO_ID_VUELO_ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_CAMBIO_ID_VUELO_ASIENTO]
@pIdAvion INT,
@PIdVuelo INT
AS
BEGIN
	UPDATE ASIENTO
	SET ID_VUELO = @PIdVuelo
	WHERE ID_AVION=@pIdAvion

END

GO
/****** Object:  StoredProcedure [dbo].[PRDB_ELIMINAR_ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_ELIMINAR_ASIENTO]
@pID_AVION int
AS
BEGIN
	DELETE FROM ASIENTO
	WHERE ID_AVION = @pID_AVION;
END


GO
/****** Object:  StoredProcedure [dbo].[PRDB_ELIMINAR_AVION]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_ELIMINAR_AVION]
@pID_AVION int
AS
BEGIN

	BEGIN
		EXEC PRDB_ELIMINAR_ASIENTO @pID_AVION;
	END;

	DELETE FROM AVION
	WHERE ID_AVION = @pID_AVION;

	DELETE FROM VUELO
	WHERE ID_AVION = @pID_AVION;

	Delete from ASIENTO 
	where ID_AVION = @pID_AVION
END;

GO
/****** Object:  StoredProcedure [dbo].[PRDB_INGRESA_ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_INGRESA_ASIENTO]
@pID_AVION int,
@CONTADOR_ASIENTO int
AS
BEGIN
	INSERT INTO ASIENTO(CONS_ASIENTO,ESTADO,ID_AVION) VALUES (@CONTADOR_ASIENTO,'D',@pID_AVION)
END


GO
/****** Object:  StoredProcedure [dbo].[PRDB_INGRESA_NUEVO_AVION]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_INGRESA_NUEVO_AVION]
@pID_AVION int,
@pNOMBRE_AVION VARCHAR (50),
@pCANT_ASIENTOS int
AS
BEGIN
	INSERT INTO AVION (ID_AVION,NOMBRE_AVION,ESTADO)
	VALUES (@pID_AVION,@pNOMBRE_AVION, 'D')

	DECLARE @CONTADOR_ASIENTO INT = 1;

	WHILE @CONTADOR_ASIENTO <= @pCANT_ASIENTOS

	BEGIN
	   EXEC PRDB_INGRESA_ASIENTO @pID_AVION, @CONTADOR_ASIENTO
	   SET @CONTADOR_ASIENTO = @CONTADOR_ASIENTO + 1;
	END;

END;



GO
/****** Object:  StoredProcedure [dbo].[PRDB_INGRESA_TIQUETE]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_INGRESA_TIQUETE]
@pFechaVuelo varchar(50),
@pIdCliente INT
AS
BEGIN
		INSERT INTO TICKET(FEC_VUELO,FEC_COMPRA,ID_CLIENTE)
		VALUES(@pFechaVuelo,GETDATE(),@pIdCliente)
END

GO
/****** Object:  StoredProcedure [dbo].[PRDB_INGRESAR_CLIENTE]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_INGRESAR_CLIENTE]
@pCEDULA VARCHAR(50),
@pNOMBRE VARCHAR(50),
@pAPELLIDO1 VARCHAR(50),
@pAPELLIDO2 VARCHAR(50),
@pCONTRASENA VARCHAR(50),
@pTIPO VARCHAR(50),
@pPRIVILEGIO VARCHAR(50)
AS
BEGIN
	INSERT INTO CLIENTE(CEDULA,NOMBRE,APELLIDO1,APELLIDO2,CONTRASENA,TIPO,CONDICION,MILLAS,PRIVILEGIO,ID_TICKET)
	VALUES(@pCEDULA,@pNOMBRE,@pAPELLIDO1,@pAPELLIDO2,@pCONTRASENA,@pTIPO,'Activo',0,@pPRIVILEGIO,0)
END
GO
/****** Object:  StoredProcedure [dbo].[PRDB_N_ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_N_ASIENTO]
@pID_ASIENTO int
AS
BEGIN
	UPDATE ASIENTO
	SET ESTADO = 'N'
	WHERE CONS_ASIENTO = @pID_ASIENTO;
END

GO
/****** Object:  StoredProcedure [dbo].[PRDB_NUEVO_VUELO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_NUEVO_VUELO]
@pIDVuelo INT,
@pOrigenVuelo VARCHAR (50),
@pDestinoVuelo VARCHAR (50),
@pMillasVuelo INT,
@pFechaVuelo VARCHAR(50),
@pID_AVION    INT,
@pPrecioDolares float
AS
BEGIN
	INSERT INTO VUELO(ID_VUELO, ORIGEN , DESTINO, MILLAS, FECHA, ID_AVION,PRECIO_DOLARES)
	VALUES (@pIDVuelo, @pOrigenVuelo, @pDestinoVuelo, @pMillasVuelo, @pFechaVuelo, @pID_AVION,@pPrecioDolares)
	UPDATE AVION
	SET ID_VUELO =@pIDVuelo
	WHERE ID_AVION = @pID_AVION
	
END

GO
/****** Object:  StoredProcedure [dbo].[PRDB_OBT_CANTIDAD_ASIENTOS_DISPONIBLES]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_OBT_CANTIDAD_ASIENTOS_DISPONIBLES]
@pIDVuelo INT
AS
BEGIN
SELECT COUNT(*)
   FROM ASIENTO
WHERE ESTADO = 'D'
  AND ID_VUELO = @pIDVuelo;
END;


GO
/****** Object:  StoredProcedure [dbo].[PRDB_OBT_ESTADO_AVION]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_OBT_ESTADO_AVION]
@pID_AVION INT
AS
BEGIN
	SELECT ESTADO
	  FROM AVION
	WHERE ID_AVION = @pID_AVION
END


GO
/****** Object:  StoredProcedure [dbo].[PRDB_OBTIENE_ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_OBTIENE_ASIENTO]
AS
BEGIN
		SELECT * FROM ASIENTO
END


GO
/****** Object:  StoredProcedure [dbo].[PRDB_OBTIENE_PAIS]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_OBTIENE_PAIS]
AS
BEGIN
SELECT DESCRIPCION FROM PAIS
END


GO
/****** Object:  StoredProcedure [dbo].[PRDB_R_ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PRDB_R_ASIENTO]
@pID_ASIENTO int
AS
BEGIN
	UPDATE ASIENTO
	SET ESTADO = 'R'
	WHERE CONS_ASIENTO = @pID_ASIENTO;
END

GO
/****** Object:  Table [dbo].[ASIENTO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASIENTO](
	[ID_ASIENTO] [int] IDENTITY(1,1) NOT NULL,
	[CONS_ASIENTO] [int] NULL,
	[ID_AVION] [int] NULL,
	[ESTADO] [nchar](1) NULL,
	[ID_VUELO] [int] NULL,
 CONSTRAINT [PK_ASIENTO] PRIMARY KEY CLUSTERED 
(
	[ID_ASIENTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AVION]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AVION](
	[ID_AVION] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE_AVION] [varchar](100) NULL,
	[ID_VUELO] [int] NULL,
	[ESTADO] [char](1) NULL,
 CONSTRAINT [PK_ID_AVION] PRIMARY KEY CLUSTERED 
(
	[ID_AVION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[ID_CLIENTE] [int] IDENTITY(1,1) NOT NULL,
	[CEDULA] [varchar](50) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[APELLIDO1] [varchar](50) NOT NULL,
	[CONTRASENA] [varchar](50) NOT NULL,
	[TIPO] [varchar](50) NOT NULL,
	[CONDICION] [varchar](50) NOT NULL,
	[MILLAS] [int] NULL,
	[PRIVILEGIO] [varchar](50) NULL,
	[ID_TICKET] [int] NULL,
	[APELLIDO2] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ID_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[ID_CLIENTE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PAIS]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PAIS](
	[COD_PAIS] [int] NOT NULL,
	[DESCRIPCION] [varchar](300) NULL,
 CONSTRAINT [PK_COD_PAIS] PRIMARY KEY CLUSTERED 
(
	[COD_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TICKET]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TICKET](
	[ID_TICKET] [int] IDENTITY(1,1) NOT NULL,
	[FEC_VUELO] [varchar](50) NULL,
	[FEC_COMPRA] [varchar](50) NULL,
	[ID_CLIENTE] [int] NULL,
 CONSTRAINT [PK_ID_TICKET] PRIMARY KEY CLUSTERED 
(
	[ID_TICKET] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VUELO]    Script Date: 18/08/2015 9:52:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VUELO](
	[ID_VUELO] [int] NOT NULL,
	[MILLAS] [int] NULL,
	[ORIGEN] [varchar](50) NULL,
	[DESTINO] [varchar](50) NULL,
	[FECHA] [varchar](50) NULL,
	[ID_TICKET] [int] NULL,
	[ID_AVION] [int] NULL,
	[PRECIO_DOLARES] [Decimal] NULL,
 CONSTRAINT [PK_ID_VUELO] PRIMARY KEY CLUSTERED 
(
	[ID_VUELO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [AEROLINEA_UAM] SET  READ_WRITE 
GO
