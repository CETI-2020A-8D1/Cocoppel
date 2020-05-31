USE [Cocoppel]
GO
INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (1, CAST(N'2020-04-07' AS Date), 1000)
GO
INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (2, CAST(N'2020-04-08' AS Date), 700)
GO
INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (3, CAST(N'2020-04-09' AS Date), 800)
GO
INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (4, CAST(N'2020-04-10' AS Date), 500)
GO
INSERT [dbo].[Usuario] ([IDUsuario], [FechaAfiliacion], [PuntajeCredito]) VALUES (5, CAST(N'2020-04-11' AS Date), 750)
GO
SET IDENTITY_INSERT [dbo].[CuentaCheques] ON 
GO
INSERT [dbo].[CuentaCheques] ([IDNumeroDeCuenta], [IDUsuario], [Valida], [Balance], [FechaVencimiento]) VALUES (1, 1, 1, 40000000200.0000, CAST(N'2030-01-01' AS Date))
GO
INSERT [dbo].[CuentaCheques] ([IDNumeroDeCuenta], [IDUsuario], [Valida], [Balance], [FechaVencimiento]) VALUES (2, 2, 1, 39999999800.0000, CAST(N'2022-01-01' AS Date))
GO
INSERT [dbo].[CuentaCheques] ([IDNumeroDeCuenta], [IDUsuario], [Valida], [Balance], [FechaVencimiento]) VALUES (3, 3, 1, 40000000000.0000, CAST(N'2022-01-01' AS Date))
GO
INSERT [dbo].[CuentaCheques] ([IDNumeroDeCuenta], [IDUsuario], [Valida], [Balance], [FechaVencimiento]) VALUES (4, 4, 1, 40000000000.0000, CAST(N'2022-01-01' AS Date))
GO
INSERT [dbo].[CuentaCheques] ([IDNumeroDeCuenta], [IDUsuario], [Valida], [Balance], [FechaVencimiento]) VALUES (5, 5, 1, 40000000000.0000, CAST(N'2022-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[CuentaCheques] OFF
GO
INSERT [dbo].[LineaCredito] ([IDLineaDeCredito], [IDUsuario], [Valida], [FechaVencimiento], [CantidadMaximaDisponible], [SaldoRestante]) VALUES (1, 1, 1, CAST(N'2030-01-01' AS Date), 40000000000.0000, 40000000000.0000)
GO
INSERT [dbo].[LineaCredito] ([IDLineaDeCredito], [IDUsuario], [Valida], [FechaVencimiento], [CantidadMaximaDisponible], [SaldoRestante]) VALUES (2, 2, 1, CAST(N'2022-01-01' AS Date), 40000000000.0000, 40000000000.0000)
GO
INSERT [dbo].[LineaCredito] ([IDLineaDeCredito], [IDUsuario], [Valida], [FechaVencimiento], [CantidadMaximaDisponible], [SaldoRestante]) VALUES (3, 3, 1, CAST(N'2022-01-01' AS Date), 40000000000.0000, 40000000000.0000)
GO
INSERT [dbo].[LineaCredito] ([IDLineaDeCredito], [IDUsuario], [Valida], [FechaVencimiento], [CantidadMaximaDisponible], [SaldoRestante]) VALUES (4, 4, 1, CAST(N'2022-01-01' AS Date), 40000000000.0000, 40000000000.0000)
GO
INSERT [dbo].[LineaCredito] ([IDLineaDeCredito], [IDUsuario], [Valida], [FechaVencimiento], [CantidadMaximaDisponible], [SaldoRestante]) VALUES (5, 5, 1, CAST(N'2022-01-01' AS Date), 40000000000.0000, 40000000000.0000)
GO
INSERT [dbo].[TarjetaDebito] ([IDNumeroDeCuenta], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (1, 1, N'Cocoppel', N'Cocoteca', N'5177015165311949
', CAST(N'2030-01-01' AS Date), 123, 1234, N'Master Card')
GO
INSERT [dbo].[TarjetaDebito] ([IDNumeroDeCuenta], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (2, 1, N'Cocoppel', N'Michele Verduzco', N'5177015165311950', CAST(N'2022-01-01' AS Date), 123, 1234, N'Master Card')
GO
INSERT [dbo].[TarjetaDebito] ([IDNumeroDeCuenta], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (3, 1, N'Cocoppel', N'Leylen Salinas', N'5177015165311951', CAST(N'2022-01-01' AS Date), 123, 1234, N'Master Card')
GO
INSERT [dbo].[TarjetaDebito] ([IDNumeroDeCuenta], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (4, 1, N'Cocoppel', N'Generoso Marquez', N'5177015165311952', CAST(N'2022-01-01' AS Date), 123, 1234, N'Master Card')
GO
INSERT [dbo].[TarjetaDebito] ([IDNumeroDeCuenta], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (5, 1, N'Cocoppel', N'Cecilia Ayala', N'5177015165311953', CAST(N'2022-01-01' AS Date), 123, 1234, N'Master Card')
GO
INSERT [dbo].[TarjetaCredito] ([IDLineaCredito], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (1, 1, N'Cocoppel', N'Cocoteca', N'4485361749026722', CAST(N'2030-01-01' AS Date), 123, 1234, N'VISA')
GO
INSERT [dbo].[TarjetaCredito] ([IDLineaCredito], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (2, 1, N'Cocoppel', N'Michele Verduzco', N'4485361749026723', CAST(N'2022-01-01' AS Date), 123, 1234, N'VISA')
GO
INSERT [dbo].[TarjetaCredito] ([IDLineaCredito], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (3, 1, N'Cocoppel', N'Leylen Salinas', N'4485361749026724', CAST(N'2022-01-01' AS Date), 123, 1234, N'VISA')
GO
INSERT [dbo].[TarjetaCredito] ([IDLineaCredito], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (4, 1, N'Cocoppel', N'Generoso Marquez', N'4485361749026725', CAST(N'2022-01-01' AS Date), 123, 1234, N'VISA')
GO
INSERT [dbo].[TarjetaCredito] ([IDLineaCredito], [Valida], [EntidadEmisora], [Titular], [Numero], [FechaCaducidad], [CVV], [NIP], [MarcaInternacional]) VALUES (5, 1, N'Cocoppel', N'Cecilia Ayala', N'4485361749026726', CAST(N'2022-01-01' AS Date), 123, 1234, N'VISA')
GO
