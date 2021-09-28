USE [FernandoGranados1]
GO
/****** Object:  Table [dbo].[HIJOS]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HIJOS](
	[IdDerhab] [int] IDENTITY(1,1) NOT NULL,
	[IdPersonal] [int] NULL,
	[ApPaterno] [varchar](50) NULL,
	[ApMaterno] [varchar](50) NULL,
	[Nombre1] [varchar](50) NULL,
	[Nombre2] [varchar](50) NULL,
	[NombreCompleto] [varchar](50) NULL,
	[FchNac] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONAL]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONAL](
	[IdPersonal] [int] IDENTITY(1,1) NOT NULL,
	[ApPaterno] [varchar](50) NULL,
	[ApMaterno] [varchar](50) NULL,
	[Nombre1] [varchar](50) NULL,
	[Nombre2] [varchar](50) NULL,
	[FchNac] [date] NULL,
	[FchIngreso] [date] NULL,
	[Dni] [varchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PERSONAL] ON 

INSERT [dbo].[PERSONAL] ([IdPersonal], [ApPaterno], [ApMaterno], [Nombre1], [Nombre2], [FchNac], [FchIngreso], [Dni]) VALUES (1, N'Granados', N'Navarro', N'Fernando', N'', CAST(N'9999-01-01' AS Date), CAST(N'9999-01-01' AS Date), N'545664645')
SET IDENTITY_INSERT [dbo].[PERSONAL] OFF
GO
/****** Object:  StoredProcedure [dbo].[spconsultarpersona]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spconsultarpersona]
AS begin
SELECT * from PERSONAL
end

GO
/****** Object:  StoredProcedure [dbo].[speliminarpersonal]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[speliminarpersonal]
@IdPersona int
AS begin
delete from PERSONAL
where IdPersonal=@IdPersona
end
GO
/****** Object:  StoredProcedure [dbo].[spguardarpersona]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spguardarpersona]
@ApPaterno varchar(20),
@ApMaterno varchar (20),
@Nombre1 varchar (20),
@Nombre2 varchar (20),
@FchNac date,
@FchIngreso date,
@Dni varchar (9)

AS begin
insert into PERSONAL(ApPaterno,ApMaterno,Nombre1,Nombre2,FchNac,FchIngreso,Dni)
values (@ApPaterno,@ApMaterno,@Nombre1,@Nombre2,@FchNac,@FchIngreso,@Dni)

end

GO
/****** Object:  StoredProcedure [dbo].[splistartodo]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[splistartodo]
AS
BEGIN
 SELECT * , [Nombre1]+' '+[Nombre2]+' '+ [ApPaterno]+' '+[ApMaterno] as NombreCompleto from   PERSONAL
END
GO
/****** Object:  StoredProcedure [dbo].[spmodificarpersona]    Script Date: 28/09/2021 11:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spmodificarpersona]
@IdPersonal int,
@ApPaterno varchar(20),
@ApMaterno varchar (20),
@Nombre1 varchar (20),
@Nombre2 varchar (20),
@FchNac date,
@FchIngreso date,
@Dni varchar (9)

AS begin
update PERSONAL set
ApPaterno=@ApPaterno,
ApMaterno=@ApMaterno,
Nombre1=@Nombre1,
Nombre2=@Nombre2,
FchNac=@FchNac,
FchIngreso=@FchIngreso,
Dni=@Dni
where IdPersonal=@IdPersonal

end
GO
