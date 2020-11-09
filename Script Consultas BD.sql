/*-- -----------------------------------------------------
Objetivo: Creacion de Database [Facturacion]  
	Desarrollador: Juan Pablo Camelo
	Fecha: 29/10/2020
-- -----------------------------------------------------*/

--3. El modelo de datos anterior debe suplir las siguientes consultas:

-- Obtener la lista de precios de todos los productos.

	SELECT NombreProducto,Precio 
	FROM Producto

-- Obtener la lista de productos cuya existencia en el inventario haya llegado al
--mínimo permitido (5 unidades).
	
	SELECT NombreProducto,Precio,Stock 
	FROM Producto
	WHERE Stock = 5

-- Obtener una lista de clientes no mayores de 35 años que hayan realizado
--compras entre el 1 de febrero de 2000 y el 25 de mayo de 2000.
	
	SELECT		
		 A.Nombre
		, A.Apellido
		, DATEDIFF(YEAR,A.FechaNacimiento, GETDATE()) AS Edad 
	FROM Cliente AS A
	WHERE IdCliente IN(
		SELECT IdCliente FROM Factura 
		WHERE FechaFactura BETWEEN '2000-02-01 00:00:00' AND '2000-05-01 23:59:59')
	AND DATEDIFF(YEAR,A.FechaNacimiento, GETDATE()) <= 35


-- Obtener el valor total vendido por cada producto en el año 2000.
	
	SELECT 
		SUM(A.PrecioVenta) AS TotalVenta 
		,C.NombreProducto AS Producto		
	
	FROM Detalle AS A
	INNER JOIN Factura AS B ON B.IdFactura = A.IdFactura
	INNER JOIN Producto AS C ON C.IdProducto = A.IdProducto
	WHERE DATEPART(YEAR,B.FechaFactura) = 2000	
	GROUP BY A.IdProducto, C.NombreProducto
	
-- Obtener la última fecha de compra de un cliente y según su frecuencia de compra
--	estimar en qué fecha podría volver a comprar.

--- INSERTAR EN UNA TABLA TEMPORAL , LOS DIAS TRANSCURRIDOS, ENTRE LA COMPRA ACTUAL, Y LA ULTIMA COMPRA POR CLIENTE
	SELECT 
	DATEDIFF(DAY, FechaUltimaCompra,FechaFactura) AS Dias
	,A.IdCliente	
	INTO #TEMP
	FROM Factura A
	WHERE FechaUltimaCompra IS NOT NULL

-- REALIZAR EL CALCULO DE LA PROXIMA COMPRA, DE ACUERDO A LA ULTIMA COMPRA REALIZADA
	SELECT 
	B.Nombre
	, B.Apellido
	,MAX(A.FechaFactura) AS UltimaCompra
	,DATEADD(DAY,FreCompra.Frecuencia,MAX(A.FechaFactura)) AS ProximaCompra
	
	FROM Factura AS A
	INNER JOIN Cliente AS B ON B.IdCliente = A.IdCliente
	INNER JOIN (SELECT 
				IdCliente
				,SUM(Dias) / COUNT(*) AS Frecuencia
				FROM  #TEMP
				group by IdCliente) AS FreCompra ON FreCompra.IdCliente = A.IdCliente
	GROUP BY FreCompra.Frecuencia, B.Nombre	, B.Apellido
