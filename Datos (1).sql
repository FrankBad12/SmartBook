INSERT INTO Clientes (Identificacion, Nombre, Email, Celular, FechaNacimiento)
VALUES
('1001', 'Carlos Lopez', 'carlos.lopez@example.com', '3001234567', '2000-01-10'),
('1002', 'Ana Ramirez', 'ana.ramirez@example.com', '3001234568', '1999-02-15'),
('1003', 'Luis Torres', 'luis.torres@example.com', '3001234569', '1998-03-20'),
('1004', 'Maria Gutierrez', 'maria.gutierrez@example.com', '3001234570', '1997-04-25'),
('1005', 'Jorge Perez', 'jorge.perez@example.com', '3001234571', '2001-05-30'),
('1006', 'Lucia Mendoza', 'lucia.mendoza@example.com', '3001234572', '2002-06-12'),
('1007', 'Esteban Rios', 'esteban.rios@example.com', '3001234573', '1997-07-18'),
('1008', 'Sofia Herrera', 'sofia.herrera@example.com', '3001234574', '1996-08-22'),
('1009', 'Daniela Silva', 'daniela.silva@example.com', '3001234575', '1995-09-11'),
('1010', 'Mateo Castillo', 'mateo.castillo@example.com', '3001234576', '2003-10-04');


INSERT INTO Usuarios (Identificacion, Nombre, Email, ContrasenaHash, Rol, CuentaConfirmada, Activo)
VALUES
('9001', 'Admin CDI', 'admin1@cecar.edu.co', 'HASH1', 'Admin', 1, 1),
('9002', 'Maria Perez', 'maria.perez1@cecar.edu.co', 'HASH2', 'Vendedor', 1, 1),
('9003', 'Jorge Ruiz', 'jorge.ruiz1@cecar.edu.co', 'HASH3', 'Vendedor', 1, 1),
('9004', 'Andrea Lopez', 'andrea.lopez@cecar.edu.co', 'HASH4', 'Vendedor', 1, 1),
('9005', 'Santiago Rios', 'santiago.rios@cecar.edu.co', 'HASH5', 'Vendedor', 1, 1),
('9006', 'Laura Torres', 'laura.torres@cecar.edu.co', 'HASH6', 'Vendedor', 1, 1),
('9007', 'Pedro Mendoza', 'pedro.mendoza@cecar.edu.co', 'HASH7', 'Vendedor', 1, 1),
('9008', 'Valentina Diaz', 'valentina.diaz@cecar.edu.co', 'HASH8', 'Vendedor', 1, 1),
('9009', 'Daniel Muñoz', 'daniel.munoz@cecar.edu.co', 'HASH9', 'Vendedor', 1, 1),
('9010', 'Carolina Rivas', 'carolina.rivas@cecar.edu.co', 'HASH10', 'Vendedor', 1, 1);


INSERT INTO Libros (Nombre, Nivel, Tipo, Editorial, Edicion)
VALUES
('Super Minds 1', 'KIDS A1.1', 'Student''s Book', 'Cambridge', '1'),
('Super Minds 2', 'KIDS A1.2', 'Student''s Book', 'Cambridge', '2'),
('Super Minds 3', 'KIDS A1.3', 'Student''s Book', 'Cambridge', '1'),
('English File Beginner', 'A1', 'Workbook', 'Oxford', '3'),
('English File Intermediate', 'B1', 'Workbook', 'Oxford', '4'),
('Face2Face Starter', 'A1', 'Student''s Book', 'Cambridge', '2'),
('Face2Face Elementary', 'A2', 'Student''s Book', 'Cambridge', '3'),
('Cutting Edge Starter', 'A1', 'Workbook', 'Pearson', '1'),
('Cutting Edge Intermediate', 'B1', 'Student''s Book', 'Pearson', '2'),
('Speak Now 1', 'A1', 'Student''s Book', 'Oxford', '1');


INSERT INTO Lotes (Codigo)
VALUES
('2025-1'),
('2025-2'),
('2025-3'),
('2025-4'),
('2025-5'),
('2025-6'),
('2025-7'),
('2025-8'),
('2025-9'),
('2025-10');


INSERT INTO Ingresos (LibroId, LoteId, Unidades, ValorCompra, ValorVentaPublico)
VALUES
(1, 1, 50, 30000, 50000),
(2, 2, 40, 32000, 52000),
(3, 3, 80, 35000, 55000),
(4, 4, 60, 25000, 40000),
(5, 5, 45, 27000, 42000),
(6, 6, 30, 29000, 45000),
(7, 7, 70, 31000, 48000),
(8, 8, 55, 26000, 43000),
(9, 9, 65, 33000, 51000),
(10, 10, 75, 34000, 52000);


UPDATE Libros 
SET StockTotal = (
    SELECT COALESCE(SUM(Unidades),0) 
    FROM Ingresos 
    WHERE Ingresos.LibroId = Libros.Id
)
WHERE Id > 0;



INSERT INTO Ventas (NumeroReciboPago, ClienteId, UsuarioId, Observaciones)
VALUES
('REC-001', 1, 9002, 'Sin novedades'),
('REC-002', 2, 9003, NULL),
('REC-003', 3, 9004, 'Cliente satisfecho'),
('REC-004', 4, 9005, NULL),
('REC-005', 5, 9006, 'Pago en efectivo'),
('REC-006', 6, 9007, NULL),
('REC-007', 7, 9008, 'Entregado'),
('REC-008', 8, 9009, NULL),
('REC-009', 9, 9010, 'Compra rápida'),
('REC-010', 10, 9001, 'Atendido por el administrador');
