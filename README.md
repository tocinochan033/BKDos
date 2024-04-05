# # BkDos

Bienvenido a **BkDos**, programa de registro de becas

![](https://raw.githubusercontent.com/tocinochan033/BKDos/master/Imagenes/Logo.png)

## Instalación y uso

1. Abre  Visual Studio 
2. Haz clic en "Clonar repositorio" y pega la URL del repositorio: `https://github.com/tocinochan033/BKDos.git`
3. Selecciona la ubicación donde deseas clonar el repositorio y haz clic en "Clonar".
4. Abre la solución (`Proyecto_AdministracionOrgDatos.sln`) en Visual Studio.
5. Presiona F5 para compilar y ejecutar el proyecto en modo de depuración.

**Nota:** Asegurate de tener instalada las [dependencias] necesarias y leer la [configuracion](#configurar).

## Dependencias
- [.NET Framework](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
- [SQL Server](https://www.microsoft.com/es-MX/sql-server/sql-server-downloads)


- iTextSharp [5.5.13.3]()
- itextsharp.xmlworker [5.5.13]()

Puedes verificar las dependencias de ITextSharp puede consultar dentro de **Administrador de paquetes NuGet** en Visual Studio.

## Guía de Uso

1. Ejecuta la aplicación desde Visual Studio.
2. Ingresa como administrador con el usuario predeterminado (usuario: admin, contraseña: 123456).
	- Puede crear nuevos usuarios con "Registrar". La confirmacion de contraseña es "2"
3. Selecciona la opción "Registrar y modificar" en el menú principal.
4. Completa el formulario con los datos del becario y guarda la información.


## Configurar
Para que el proyecto funcione correctamente es necesario realizar los siguientes pasos:

1. Abre el explorador de archivos y navega hasta el directorio del proyecto, o utiliza el atajo `Ctrl + O` dentro de Visual Studio y dirigete al directorio `~\BKDos\Proyecto_AdministracionOrgDatos\Resources` 
2. Copia la carpeta `Fuentes`
3. Pega la carpeta en la direccion especificada `~\BKDos\Proyecto_AdministracionOrgDatos\bin\Debug\`

## Créditos

- Jesus Mejia (@Sujez)
- Cesar Garcia (@ArdillaTragona)
- Sandra Megumi (@MegumiUwU)
- Carlos Noberto (@cxrlosL15)
- Zeus Andrade(@DonChampi)
- Abraham Estrada (@Aleluyo)
- Omar Sanchez (@IngeOmar)

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.