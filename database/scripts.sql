CREATE DATABASE [Masterchef]

GO
USE [Masterchef]
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [uniqueidentifier] NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Receita]    Script Date: 12/09/2017 22:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receita](
	[Id] [uniqueidentifier] NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Descricao] [nvarchar](150) NOT NULL,
	[Ingredientes] [nvarchar](500) NOT NULL,
	[Preparo] [nvarchar](1000) NOT NULL,
	[Foto] [nvarchar](100) NOT NULL,
	[Tags] [nvarchar](200) NULL,
	[Favorita] [bit] NOT NULL,
	[CategoriaId] [uniqueidentifier] NOT NULL,
	[TempoPreparo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Receita] ADD  DEFAULT ((0)) FOR [Favorita]
GO
USE [master]
GO
ALTER DATABASE [Masterchef] SET  READ_WRITE 
GO
