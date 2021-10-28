USE Velusel

--DELETE FROM Almacen_Material
--DELETE FROM Almacen_Producto
--DELETE FROM OrdenCompra
--DELETE FROM OrdenFabricacion
--DELETE FROM Pedido_Detalle
--DELETE FROM Pedido

SELECT * FROM Almacen
SELECT * FROM Almacen_Material
SELECT * FROM Almacen_Producto
SELECT * FROM Cliente
SELECT * FROM Material
SELECT * FROM OrdenCompra
SELECT * FROM OrdenFabricacion
SELECT * FROM Pedido
SELECT * FROM Pedido_Detalle
SELECT * FROM PlantillaF_Material
SELECT * FROM PlantillaF_SubProducto
SELECT * FROM PlantillaFabricacion
SELECT * FROM Producto
SELECT * FROM Producto_Material
SELECT * FROM Producto_Producto


/*
primero crear un pedido
luego generar las ordenes de fabricacion
generar las ordenes de compra
efectuar una compra
recibir una compra

*/