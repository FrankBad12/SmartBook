-- ============================================================
-- CREAR BASE DE DATOS SMARTBOOK DESDE CERO
-- ============================================================

DROP DATABASE IF EXISTS SmartBook;
CREATE DATABASE SmartBook;
USE SmartBook;

-- ============================================================
-- TABLA CLIENTES
-- ============================================================
CREATE TABLE Clientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Identificacion VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(150) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Celular VARCHAR(10) NOT NULL UNIQUE,
    FechaNacimiento DATETIME NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion DATETIME NULL
);

-- ============================================================
-- TABLA USUARIOS (con nombres de columnas en snake_case)
-- ============================================================
CREATE TABLE Usuarios (
    id VARCHAR(50) PRIMARY KEY,
    identificacion VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,
    rol ENUM('Admin','Vendedor') NOT NULL,
    cuenta_confirmada TINYINT(1) NOT NULL DEFAULT 0,
    activo ENUM('Activo','Inactivo') NOT NULL DEFAULT 'Activo',
    fecha_creacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fecha_actualizacion DATETIME NULL
);

-- ============================================================
-- TABLA LIBROS
-- ============================================================
CREATE TABLE Libros (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(200) NOT NULL,
    Nivel VARCHAR(50) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Editorial VARCHAR(100),
    Edicion VARCHAR(50),
    StockTotal INT NOT NULL DEFAULT 0,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion DATETIME NULL,
    CONSTRAINT UQ_Libro UNIQUE(Nombre, Nivel, Tipo, Edicion)
);

-- ============================================================
-- TABLA LOTES
-- ============================================================
CREATE TABLE Lotes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL UNIQUE
);

-- ============================================================
-- TABLA INGRESOS
-- ============================================================
CREATE TABLE Ingresos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    LibroId INT NOT NULL,
    LoteId INT NOT NULL,
    Unidades INT NOT NULL,
    ValorCompra DECIMAL(12,2) NOT NULL,
    ValorVentaPublico DECIMAL(12,2) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (LibroId) REFERENCES Libros(Id),
    FOREIGN KEY (LoteId) REFERENCES Lotes(Id)
);

-- ============================================================
-- TABLA VENTAS (UsuarioId como VARCHAR(50))
-- ============================================================
CREATE TABLE Ventas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NumeroReciboPago VARCHAR(50) NOT NULL UNIQUE,
    Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ClienteId INT NOT NULL,
    UsuarioId VARCHAR(50) NOT NULL,
    Observaciones TEXT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(id)
);

