# Guía de Configuración del Proyecto ProductsManagement

Este documento provee una guía paso a paso para configurar y desplegar el proyecto ProductsManagement en un entorno local.

## Pre-requisitos

- SQL Server (se utilizó una instancia de SQLEXPRESS para la prueba).

## Configuración de la Base de Datos

1. **Creación de la Base de Datos:**
   - Abrir SQL Server Management Studio (SSMS) y conectar a la instancia de SQL Server.
   - Ejecutar el siguiente comando para crear la base de datos `ProductsDB`:

     ```sql
     CREATE DATABASE ProductsDB;
     ```

2. **Creación de la Tabla de Productos:**
   - Asegurarse de que la base de datos `ProductsDB` esté seleccionada.
   - Ejecutar el siguiente script para crear la tabla `Products`:

     ```sql
     USE [ProductsDB]
     GO

     SET ANSI_NULLS ON
     GO

     SET QUOTED_IDENTIFIER ON
     GO

     CREATE TABLE [dbo].[Products](
         [ProductId] [int] NOT NULL,
         [Name] [nvarchar](256) NOT NULL,
         [Status] [tinyint] NOT NULL,
         [Stock] [int] NOT NULL,
         [Description] [nvarchar](1024) NOT NULL,
         [Price] [money] NOT NULL,
         [Discount] [tinyint] NOT NULL,
         [FinalPrice] [money] NOT NULL,
      CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
     (
         [ProductId] ASC
     )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
     ) ON [PRIMARY]
     GO
     ```

## Configuración del Proyecto

1. **Clonación del Repositorio:**
   - Clonar el proyecto al entorno local usando Git:

     ```
     git clone <url-del-repositorio>
     ```

2. **Configuración de la Cadena de Conexión:**
   - Navegar al archivo `appsettings.json` dentro del proyecto clonado.
   - Modificar la cadena de conexión para que coincida con la configuración del servidor de base de datos local.

3. **Compilación y Ejecución:**
   - Abrir el proyecto en Visual Studio.
   - Compilar y ejecutar `ProductsManagement.Api` bajo IIS Express.
