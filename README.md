# N5.UserPermissions.BackEnd
## Ejecutar el BackEnd

1. Expandir la capa WebApi, seleccionar el proyecto de N5.UserPermissions.WebApi y establecerlo como proyecto de inicio.

![unnamed](https://user-images.githubusercontent.com/71679195/173403198-2e5fe96d-be27-46b0-9094-a6f102ca0c42.png)

2. En en la barra de título ubicar la pestaña de Herramientas, seleccionar el administrador de paquetes NuGet y seleccionar la Consola de Administrador de paquetes. 

![unnamed](https://user-images.githubusercontent.com/71679195/173403291-5e4eb400-facd-4f06-bf83-7f48a4a3a288.png)

3. En la consola digitar el comando: update-database (para generar la base de datos).

![unnamed](https://user-images.githubusercontent.com/71679195/173403352-18b88b01-250f-4994-a98d-229190edd719.png)

4. Ahora para correr el proyecto solo hace falta darle en Iniciar sin Depturar o presionar Ctrl+F5.

![unnamed](https://user-images.githubusercontent.com/71679195/173403447-032ea59d-1618-4e0a-a0dd-4636133ebb80.png)

![unnamed](https://user-images.githubusercontent.com/71679195/173404403-aa9932da-d09f-4061-b0fd-04409031e631.png)

5. Para realizar las pruebas unitarias ubicarse en la capa Test, ahí podrá realizar las pruebas unitarias de los controladores Api hasta los modelos DTOs (Para realizar las pruebas no es necesario crear la base de datos). 

![unnamed](https://user-images.githubusercontent.com/71679195/173404488-1ae728b7-d7d9-4bc4-aa2d-61925bfadab8.png)

## Notas
El proyecto de FrontEnd se ejecuta en el puerto localhost:44371
Las apis solicitadas en el backend son Permission Post/Put/Get.
