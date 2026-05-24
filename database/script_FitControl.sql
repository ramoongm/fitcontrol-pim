USE [FitControl]
GO
/****** Objeto:  Table [dbo].[Aluno]    Data do Script: 26/04/2026 20:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aluno](
	[AlunoId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cpf] [varchar](14) NOT NULL,
	[Telefone] [varchar](20) NULL,
	[DataNascimento] [date] NOT NULL,
	[DataCadastro] [date] NOT NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AlunoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Matricula]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[MatriculaId] [int] IDENTITY(1,1) NOT NULL,
	[AlunoId] [int] NOT NULL,
	[PlanoId] [int] NOT NULL,
	[DataInicio] [date] NOT NULL,
	[DataFim] [date] NULL,
	[Status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MatriculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Pagamento]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamento](
	[PagamentoId] [int] IDENTITY(1,1) NOT NULL,
	[MatriculaId] [int] NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[DataPagamento] [date] NULL,
	[MesReferencia] [varchar](7) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[MetodoPagamento] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PagamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Plano]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plano](
	[PlanoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DuracaoMeses] [int] NOT NULL,
	[Valor] [decimal](10, 2) NOT NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlanoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Presenca]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presenca](
	[PresencaId] [int] IDENTITY(1,1) NOT NULL,
	[AlunoId] [int] NOT NULL,
	[Data] [date] NOT NULL,
	[Status] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PresencaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Professor]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[ProfessorId] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Especialidade] [varchar](100) NULL,
	[Telefone] [varchar](20) NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfessorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Treino]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treino](
	[TreinoId] [int] IDENTITY(1,1) NOT NULL,
	[AlunoId] [int] NOT NULL,
	[ProfessorId] [int] NOT NULL,
	[Descricao] [varchar](max) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TreinoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Usuario]    Data do Script: 26/04/2026 20:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](255) NOT NULL,
	[TipoUsuario] [varchar](20) NOT NULL,
	[Ativo] [bit] NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aluno] ON 

INSERT [dbo].[Aluno] ([AlunoId], [UsuarioId], [Nome], [Cpf], [Telefone], [DataNascimento], [DataCadastro], [Ativo]) VALUES (1, 1, N'Gustavo', N'123.456.789-00', N'11999999999', CAST(N'2005-01-01' AS Date), CAST(N'2026-04-21' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Aluno] OFF
GO
SET IDENTITY_INSERT [dbo].[Matricula] ON 

INSERT [dbo].[Matricula] ([MatriculaId], [AlunoId], [PlanoId], [DataInicio], [DataFim], [Status]) VALUES (1, 1, 1, CAST(N'2026-04-21' AS Date), NULL, N'Ativa')
SET IDENTITY_INSERT [dbo].[Matricula] OFF
GO
SET IDENTITY_INSERT [dbo].[Pagamento] ON 

INSERT [dbo].[Pagamento] ([PagamentoId], [MatriculaId], [Valor], [DataPagamento], [MesReferencia], [Status], [MetodoPagamento]) VALUES (1, 1, CAST(120.00 AS Decimal(10, 2)), CAST(N'2026-04-21' AS Date), N'2026-04', N'Pago', N'Pix')
SET IDENTITY_INSERT [dbo].[Pagamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Plano] ON 

INSERT [dbo].[Plano] ([PlanoId], [Nome], [DuracaoMeses], [Valor], [Ativo]) VALUES (1, N'Mensal', 1, CAST(120.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Plano] ([PlanoId], [Nome], [DuracaoMeses], [Valor], [Ativo]) VALUES (2, N'Trimestral', 3, CAST(300.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Plano] ([PlanoId], [Nome], [DuracaoMeses], [Valor], [Ativo]) VALUES (3, N'Anual', 12, CAST(1000.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[Plano] OFF
GO
SET IDENTITY_INSERT [dbo].[Presenca] ON 

INSERT [dbo].[Presenca] ([PresencaId], [AlunoId], [Data], [Status]) VALUES (1, 1, CAST(N'2026-04-21' AS Date), N'Presente')
SET IDENTITY_INSERT [dbo].[Presenca] OFF
GO
SET IDENTITY_INSERT [dbo].[Professor] ON 

INSERT [dbo].[Professor] ([ProfessorId], [UsuarioId], [Nome], [Especialidade], [Telefone], [Ativo]) VALUES (2, 3, N'Carlos', N'Musculação', N'11988888888', 1)
SET IDENTITY_INSERT [dbo].[Professor] OFF
GO
SET IDENTITY_INSERT [dbo].[Treino] ON 

INSERT [dbo].[Treino] ([TreinoId], [AlunoId], [ProfessorId], [Descricao], [DataCriacao], [Ativo]) VALUES (9, 1, 2, N'Treino completo teste', CAST(N'2026-04-21T17:59:15.827' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Treino] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [Nome], [Email], [Senha], [TipoUsuario], [Ativo], [DataCriacao]) VALUES (1, N'Gustavo', N'gustavo@email.com', N'123456', N'Aluno', 1, CAST(N'2026-04-21T16:06:27.347' AS DateTime))
INSERT [dbo].[Usuario] ([UsuarioId], [Nome], [Email], [Senha], [TipoUsuario], [Ativo], [DataCriacao]) VALUES (3, N'Carlos', N'carlos@email.com', N'123456', N'Professor', 1, CAST(N'2026-04-21T16:11:09.700' AS DateTime))
INSERT [dbo].[Usuario] ([UsuarioId], [Nome], [Email], [Senha], [TipoUsuario], [Ativo], [DataCriacao]) VALUES (4, N'Administrador', N'admin@email.com', N'123456', N'Admin', 1, CAST(N'2026-04-26T20:31:38.500' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Objeto:  Index [UQ__Aluno__C1FF93096EE717B7]    Data do Script: 26/04/2026 20:35:00 ******/
ALTER TABLE [dbo].[Aluno] ADD UNIQUE NONCLUSTERED 
(
	[Cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Objeto:  Index [UQ__Usuario__A9D1053449B8B0EA]    Data do Script: 26/04/2026 20:35:00 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aluno] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Plano] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Professor] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Treino] ADD  DEFAULT (getdate()) FOR [DataCriacao]
GO
ALTER TABLE [dbo].[Treino] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [DataCriacao]
GO
ALTER TABLE [dbo].[Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Aluno_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Aluno] CHECK CONSTRAINT [FK_Aluno_Usuario]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Aluno] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Aluno] ([AlunoId])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Aluno]
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD  CONSTRAINT [FK_Matricula_Plano] FOREIGN KEY([PlanoId])
REFERENCES [dbo].[Plano] ([PlanoId])
GO
ALTER TABLE [dbo].[Matricula] CHECK CONSTRAINT [FK_Matricula_Plano]
GO
ALTER TABLE [dbo].[Pagamento]  WITH CHECK ADD  CONSTRAINT [FK_Pagamento_Matricula] FOREIGN KEY([MatriculaId])
REFERENCES [dbo].[Matricula] ([MatriculaId])
GO
ALTER TABLE [dbo].[Pagamento] CHECK CONSTRAINT [FK_Pagamento_Matricula]
GO
ALTER TABLE [dbo].[Presenca]  WITH CHECK ADD  CONSTRAINT [FK_Presenca_Aluno] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Aluno] ([AlunoId])
GO
ALTER TABLE [dbo].[Presenca] CHECK CONSTRAINT [FK_Presenca_Aluno]
GO
ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_Usuario]
GO
ALTER TABLE [dbo].[Treino]  WITH CHECK ADD  CONSTRAINT [FK_Treino_Aluno] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Aluno] ([AlunoId])
GO
ALTER TABLE [dbo].[Treino] CHECK CONSTRAINT [FK_Treino_Aluno]
GO
ALTER TABLE [dbo].[Treino]  WITH CHECK ADD  CONSTRAINT [FK_Treino_Professor] FOREIGN KEY([ProfessorId])
REFERENCES [dbo].[Professor] ([ProfessorId])
GO
ALTER TABLE [dbo].[Treino] CHECK CONSTRAINT [FK_Treino_Professor]
GO
