############ Pasos para la compilación de la solución Back-end ##############

Es necesario tener Microsoft Visual Studio 2019 para correr el proyecto,
y tener instalada las herramientas "Desarrollo de ASP.NET y web" y "Desarrollo multiplataforma de .NET"
esto es cuando se instala el IDE.

1. Crear una base de datos llamada "DbJuguetes" en SqlServer preferentemente 2014 o superior, y preferentemente que el manejador de 
base de datos tenga el modo de acceder al gestor con la autenticación de Windows, caso contrario colocar el 
User Id y el Password en la cadena de conexión en el archivo appsettings.json del ConnectionStrings 

2. Abrir la terminal de la consola de administrador de paquetes desde 
la pestaña, Herramientas => Administrador de paquetes NuGet => Consola del Administrador de paquetes
y ejecutar el siguiente comando:
Update-Database -Context JugueteContext

**Nota** 
Si se recibe el siguiente error:
----------------------------------------------------------------
El término 'update-database' no se reconoce como nombre de un cmdlet, función, archivo de script o programa 
ejecutable. Compruebe si escribió correctamente el nombre o, si incluyó una ruta de acceso, 
compruebe que dicha ruta es correcta e 
inténtelo de nuevo.
-------------------------------------------------------------------

*Cerrar el IDE y volver a abrir la solución con Visual Studio.

*Después de abrir de nuevo la solución, dar clic derecho sobre el proyecto WebApi y
seleccionar la opción "Administrar Paquetes NuGet" (Management NuGet Packages...)

*Una vez abierto el explorador, dirigirse en la sección Examinar (browser) y buscar los paquetes que se mencionan
debajo de este paso, la cual deberán ser desintalados e instalados nuevamente
con la versión de este proyecto 3.1.30 y con esto ya debería solucionarse el error.

Paquetes a desintalar e instalar con la versión 3.1.30:
-> Microsoft.EntityFrameworkCore.SqlServer
-> Microsoft.EntityFrameworkCore.Tools

*Volver a ejecutar el comando del paso 2.

3. Ejecutar el proyecto con el botón IIS Express y 
ver que se muestre la palabra "success" en el navegador con la siguiente ruta:
https://localhost:44355/api/juguetes/test
