INSERT [dbo].[Usuario] ([IdUsuario], [Nombre]) VALUES (N'9f18afb2-e7f1-4a05-aab4-663318371b58', N'Pedro Rodriguez')
GO
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'73e24248-f0f2-4c33-9b63-377fcd292813', N'Rol Ventas')
GO
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'c3cb0322-ee8f-40c2-8496-03eb1a714706', N'Rol de Consulta de Ventas')
GO
INSERT [dbo].[Usuario_Familia] ([IdUsuario], [IdFamilia]) VALUES (N'9f18afb2-e7f1-4a05-aab4-663318371b58', N'73e24248-f0f2-4c33-9b63-377fcd292813')
GO
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [Vista]) VALUES (N'3106275D-9878-4629-8EE1-44157892A51E', N'Formulario Gestión de ventas', N'frmGestionVentas')
GO
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [Vista]) VALUES (N'5bd7188d-1269-4621-9a16-d9051779ff5c', N'Pantalla de Administración de Perfil del Usuario', N'frmPerfiles')
GO
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [Vista]) VALUES (N'5f1a9d40-1ded-424f-ae21-dbf46588e602', N'Pantalla de Consulta de Ventas', N'frmConsultaVentas')
GO
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [Vista]) VALUES (N'bb223fca-ca07-4fad-89a3-c3bc0f2e49ae', N'Pantalla de Ventas', N'frmVentas')
GO
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'9f18afb2-e7f1-4a05-aab4-663318371b58', N'5bd7188d-1269-4621-9a16-d9051779ff5c')
GO
INSERT [dbo].[Familia_Familia] ([IdFamilia], [IdFamiliaHijo]) VALUES (N'73e24248-f0f2-4c33-9b63-377fcd292813', N'c3cb0322-ee8f-40c2-8496-03eb1a714706')
GO
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'73e24248-f0f2-4c33-9b63-377fcd292813', N'bb223fca-ca07-4fad-89a3-c3bc0f2e49ae')
GO
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'c3cb0322-ee8f-40c2-8496-03eb1a714706', N'5f1a9d40-1ded-424f-ae21-dbf46588e602')
GO
