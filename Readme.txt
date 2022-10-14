############ Pasos para la compilación de la solución Back-end ##############

Es necesario tener Microsoft Visual Studio 2019 para correr el proyecto,
y tener instalada las herramientas "Desarrollo de ASP.NET y web" y "Desarrollo multiplataforma de .NET"
esto es cuando se instala el IDE.

1. Crear una base de datos llamda "DbJuguetes" en SqlServer preferentemente 2014 o superior

2. Ejecutar el siguiente comando:
Update-Database -Context JugueteContext

**Nota** 
Si se recibe el siguiente error:
----------------------------------------------------------------
El término "Update-Database" no se reconoce como el nombre de un cmdlet, 
una función, un archivo de script o un programa ejecutable. 
Compruebe si escribió correctamente el nombre o, si incluyó una ruta de acceso, 
compruebe que dicha ruta es correcta e inténtelo de nuevo.
-------------------------------------------------------------------

*Cerrar el IDE y reiniciar Visual Studio.

*Después de abrir de nuevo la solución y clic derecho sobre el proyecto WebApi y
seleccionar > Administrar Paquetes NuGet (Management NuGet Packages...)

*En el explorador Examinar (browser) buscar los siguientes paquetes, desinstalarlos y volver a instalar
la versión para este proyecto es 3.1.30 y con esto ya debería solucionarse el error.

*Volver a ejecutar el comando del paso 2.

3. Ejecutar el proyecto
