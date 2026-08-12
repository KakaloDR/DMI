-- ==========================================
-- DISPENSARIO MÉDICO INTELIGENTE (DMI) - GDM
-- SCRIPT DE CONFIGURACIÓN DE BASE DE DATOS
-- ==========================================

-- 1. CREACIÓN DE LA BASE DE DATOS
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'GDM_DB')
BEGIN
    CREATE DATABASE GDM_DB;
END
GO

USE GDM_DB;
GO

-- 2. ELIMINACIÓN DE TABLAS EXISTENTES (Orden inverso para respetar FK)
IF OBJECT_ID('dbo.Registro_Visitas', 'U') IS NOT NULL DROP TABLE dbo.Registro_Visitas;
IF OBJECT_ID('dbo.Medicamentos', 'U') IS NOT NULL DROP TABLE dbo.Medicamentos;
IF OBJECT_ID('dbo.Medicos', 'U') IS NOT NULL DROP TABLE dbo.Medicos;
IF OBJECT_ID('dbo.Pacientes', 'U') IS NOT NULL DROP TABLE dbo.Pacientes;
IF OBJECT_ID('dbo.Ubicaciones', 'U') IS NOT NULL DROP TABLE dbo.Ubicaciones;
IF OBJECT_ID('dbo.Marcas', 'U') IS NOT NULL DROP TABLE dbo.Marcas;
IF OBJECT_ID('dbo.Tipos_Farmacos', 'U') IS NOT NULL DROP TABLE dbo.Tipos_Farmacos;
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL DROP TABLE dbo.Usuarios;
GO

-- 3. CREACIÓN DE TABLAS MAESTRAS (Catálogos Estáticos)

-- A. Tabla: Tipos_Farmacos
CREATE TABLE dbo.Tipos_Farmacos (
    ID_Tipo_Farmaco INT IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Tipos_Farmacos PRIMARY KEY (ID_Tipo_Farmaco),
    CONSTRAINT CK_Tipos_Farmacos_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- B. Tabla: Marcas
CREATE TABLE dbo.Marcas (
    ID_Marca INT IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Marcas PRIMARY KEY (ID_Marca),
    CONSTRAINT CK_Marcas_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- C. Tabla: Ubicaciones
CREATE TABLE dbo.Ubicaciones (
    ID_Ubicacion INT IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Estante VARCHAR(50) NOT NULL,
    Tramo VARCHAR(50) NOT NULL,
    Celda VARCHAR(50) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Ubicaciones PRIMARY KEY (ID_Ubicacion),
    CONSTRAINT CK_Ubicaciones_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- H. Tabla: Usuarios (Módulo de Seguridad)
CREATE TABLE dbo.Usuarios (
    ID_Usuario INT IDENTITY(1,1) NOT NULL,
    Usuario VARCHAR(50) NOT NULL,
    Clave VARCHAR(64) NOT NULL, -- Almacena hash SHA-256 en formato hex
    Nombre VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Usuarios PRIMARY KEY (ID_Usuario),
    CONSTRAINT UQ_Usuarios_Usuario UNIQUE (Usuario),
    CONSTRAINT CK_Usuarios_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- 4. CREACIÓN DE TABLAS DE ENTIDADES (Catálogos Dinámicos)

-- D. Tabla: Medicamentos
CREATE TABLE dbo.Medicamentos (
    ID_Medicamento INT IDENTITY(1,1) NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    FK_Tipo_Farmaco INT NOT NULL,
    FK_Marca INT NOT NULL,
    FK_Ubicacion INT NOT NULL,
    Dosis VARCHAR(150) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Medicamentos PRIMARY KEY (ID_Medicamento),
    CONSTRAINT FK_Medicamentos_Tipos_Farmacos FOREIGN KEY (FK_Tipo_Farmaco) REFERENCES dbo.Tipos_Farmacos (ID_Tipo_Farmaco),
    CONSTRAINT FK_Medicamentos_Marcas FOREIGN KEY (FK_Marca) REFERENCES dbo.Marcas (ID_Marca),
    CONSTRAINT FK_Medicamentos_Ubicaciones FOREIGN KEY (FK_Ubicacion) REFERENCES dbo.Ubicaciones (ID_Ubicacion),
    CONSTRAINT CK_Medicamentos_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- E. Tabla: Pacientes
CREATE TABLE dbo.Pacientes (
    ID_Paciente INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    Cedula VARCHAR(15) NOT NULL,
    No_Carnet VARCHAR(20) NOT NULL,
    Tipo_Paciente VARCHAR(30) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Pacientes PRIMARY KEY (ID_Paciente),
    CONSTRAINT UQ_Pacientes_Cedula UNIQUE (Cedula),
    CONSTRAINT UQ_Pacientes_No_Carnet UNIQUE (No_Carnet),
    CONSTRAINT CK_Pacientes_Tipo_Paciente CHECK (Tipo_Paciente IN ('Estudiante', 'Empleado', 'Profesor', 'Otros')),
    CONSTRAINT CK_Pacientes_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- F. Tabla: Medicos
CREATE TABLE dbo.Medicos (
    ID_Medico INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(150) NOT NULL,
    Cedula VARCHAR(15) NOT NULL,
    Tanda_Labor VARCHAR(30) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Medicos PRIMARY KEY (ID_Medico),
    CONSTRAINT UQ_Medicos_Cedula UNIQUE (Cedula),
    CONSTRAINT CK_Medicos_Tanda_Labor CHECK (Tanda_Labor IN ('Matutina', 'Vespertina', 'Nocturna')),
    CONSTRAINT CK_Medicos_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- 5. CAPA TRANSACCIONAL (Núcleo Operacional)

-- G. Tabla: Registro_Visitas
CREATE TABLE dbo.Registro_Visitas (
    ID_Visita INT IDENTITY(1,1) NOT NULL,
    FK_Medico INT NOT NULL,
    FK_Paciente INT NOT NULL,
    Fecha_Visita DATE NOT NULL DEFAULT GETDATE(),
    Hora_Visita TIME NOT NULL DEFAULT CONVERT(TIME, GETDATE()),
    Sintomas VARCHAR(MAX) NOT NULL,
    FK_Medicamento INT NOT NULL,
    Recomendaciones VARCHAR(MAX) NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT PK_Registro_Visitas PRIMARY KEY (ID_Visita),
    CONSTRAINT FK_Registro_Visitas_Medicos FOREIGN KEY (FK_Medico) REFERENCES dbo.Medicos (ID_Medico),
    CONSTRAINT FK_Registro_Visitas_Pacientes FOREIGN KEY (FK_Paciente) REFERENCES dbo.Pacientes (ID_Paciente),
    CONSTRAINT FK_Registro_Visitas_Medicamentos FOREIGN KEY (FK_Medicamento) REFERENCES dbo.Medicamentos (ID_Medicamento),
    CONSTRAINT CK_Registro_Visitas_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);
GO

-- ==========================================
-- INSERCIÓN DE DATOS DE PRUEBA (DATA INICIAL)
-- ==========================================

-- Usuarios de Seguridad (Clave cifrada: admin123 -> SHA-256)
INSERT INTO dbo.Usuarios (Usuario, Clave, Nombre, Estado) VALUES
('admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'Administrador DMI', 'Activo');

-- Tipos de Fármacos
INSERT INTO dbo.Tipos_Farmacos (Descripcion, Estado) VALUES 
('Tableta', 'Activo'),
('Cápsula', 'Activo'),
('Jarabe', 'Activo'),
('Crema / Pomada', 'Activo'),
('Inyectable', 'Activo');

-- Marcas (Laboratorios)
INSERT INTO dbo.Marcas (Descripcion, Estado) VALUES 
('Laboratorio Rowe', 'Activo'),
('Laboratorio MK', 'Activo'),
('Bayer', 'Activo'),
('Pfizer', 'Activo'),
('Sued Fardesa', 'Activo');

-- Ubicaciones Iniciales
INSERT INTO dbo.Ubicaciones (Descripcion, Estante, Tramo, Celda, Estado) VALUES 
('Almacén A - Vitrina Principal', 'Estante 1', 'Tramo A', 'Celda 1', 'Activo'),
('Almacén A - Vitrina Principal', 'Estante 1', 'Tramo A', 'Celda 2', 'Activo'),
('Almacén B - Refrigerados', 'Estante 2', 'Tramo B', 'Celda 1', 'Activo');

-- Pacientes Iniciales (Prueba)
INSERT INTO dbo.Pacientes (Nombre, Cedula, No_Carnet, Tipo_Paciente, Estado) VALUES 
('Juan Pérez', '001-1234567-8', '2023-0101', 'Estudiante', 'Activo'),
('María Rodríguez', '002-8765432-1', 'EMP-5544', 'Empleado', 'Activo');

-- Médicos Iniciales (Prueba)
INSERT INTO dbo.Medicos (Nombre, Cedula, Tanda_Labor, Especialidad, Estado) VALUES 
('Dr. Carlos Gómez', '001-9988776-5', 'Matutina', 'Medicina General', 'Activo'),
('Dra. Ana Peralta', '001-5544332-2', 'Vespertina', 'Pediatría', 'Activo');

-- Medicamentos Iniciales (Prueba)
INSERT INTO dbo.Medicamentos (Descripcion, FK_Tipo_Farmaco, FK_Marca, FK_Ubicacion, Dosis, Estado) VALUES 
('Acetaminofén 500mg', 1, 2, 1, '1 tableta cada 8 horas', 'Activo'),
('Ibuprofeno 400mg', 1, 1, 1, '1 tableta cada 8 horas con comida', 'Activo'),
('Amoxicilina 500mg (Cápsulas)', 2, 5, 2, '1 cápsula cada 8 horas por 7 días', 'Activo');
GO
