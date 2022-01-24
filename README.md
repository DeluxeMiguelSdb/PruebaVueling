Instrucciones de ejecución:
---------------------------
1 - Generación de la base de datos</br>
  a) Ejecutar Script PruebaVueling\PruebaVueling.DataBase\PublishScript\PruebaVueling.DataBase.publish.sql</br>
  b) Publicar Proyecto DataBase desde Visual Studio</br>
  
2 - Cambiar ConnectionStrings del appsettings.json</br>

3 - Urls a utilizar</br>
  a) /api/transactions -> Devuelve todas las transacciones</br>
  b) /api/transactions/{sku} -> Devuelve todas las transacciones con esa sku y su total en Euros</br>
  c) /api/rates -> Devuelve todos los rates
