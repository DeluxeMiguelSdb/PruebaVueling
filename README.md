Instrucciones de ejecución:
---------------------------
1 - Generación de la base de datos
  a) Ejecutar Script PruebaVueling\PruebaVueling.DataBase\PublishScript\PruebaVueling.DataBase.publish.sql
  b) Publicar Proyecto DataBase desde Visual Studio
  
2 - Cambiar ConnectionStrings del appsettings.json

3 - Urls a utilizar
  a) /api/transactions -> Devuelve todas las transacciones
  b) /api/transactions/{sku} -> Devuelve todas las transacciones con esa sku y su total en Euros
  c) /api/rates -> Devuelve todos los rates
