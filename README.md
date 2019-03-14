# Shop
Shop es un aplicativo de ejemplo, el cual consume las APIs de MercadoLibre expuestas para desarrolladores.

## Ejercicio
Desarrollar una app utilizando las APIs de Mercado Libre, que le permita a un usuario ver los detalles de un producto.
Para lograr esto, Mercado Libre posee APIs abiertas a la comunidad para que cualquier desarrollador las consuma y pueda tener búsquedas y compras en su aplicación.
La app debería contar con tres pantallas:
* Campo de búsqueda.
* Visualización de resultados de la búsqueda.
* Detalle de un producto.
Puedes entregar un listado y detalle de productos que sea puro texto, o un buscador con imágenes, iconos y texto, y un detalle completo del producto, como el que se muestra en la web.
Requerimientos
Cada pantalla deberíamos poder rotarla y debería mantenerse el estado de la vista.

## Arquitectura del Proyecto

La definición de la arquitectura se representa en el siguiente diagrama:

[LINK AL DIAGRAMA](https://www.draw.io/?lightbox=1&highlight=0000ff&edit=_blank&layers=1&nav=1&title=Artquitectura#Uhttps://drive.google.com/uc?id=1quTlMJ5caot2nrSwU1SPy6FFF6DlcFLY&export=download)


- **Presentation**
	> **Shop.WebForms**: Capa de presentación ASP.NET WebForm, utilizando Boostrap en los componentes visuales. Interfaces responsive adaptables a cualquier dispositivo. Se priorizó la experiencia del usuario utilizando controles y layouts similares a los utilizados en la página oficial. 
	
	> **Shop.MVC**: Capa de presentación ASP.NET Core MVC, desarrollado para aplicar patrón MVC, mostrando texto solamente. El objetivo fue realizar otro tipo de aplicación para consumir la estructura desarrollada, pero sin hacer foco en las partes visuales. La implementación no estaría completada pero es funcional.

	> **Shop.Xamarin**: Capa de presentación Xamarin la cual no está disponible, ya que aún no se realiza su implementación.

- **Application Core**
	> **Shop.Application**: El objetivo de esta capa es desacoplar la presentación de nuestro Modelo para aplicar tareas de coordinación y conversiones. Principalmente se utilizó para mapear las Entidades del Dominio a DTOs que se devuelven a la presentación (se utilizó Automapper)
	
	> **Shop.Models**: Esta capa de Modelo contiene las clases con nuestros métodos de negocio. Por cada entidad, encontraremos EntidadDomain.cs. 

	> **Shop.Entities**: Contiene las entidades con las que trabajamos en nuestro modelo, principalmente generadas a partir del descubrimiento de las APIs.
	
	> **Shop.DTOs**: Contiene los DTOs que usaremos para enviar a los consumidores aislando las entidades que usamos en el modelo.

- **Infraestructure**
	> **Shop.CrossCutting.Log**: Contiene una implementación de un Logger, el cual se provee de forma transversal a cualquier capa que necesite implementarlo a través de la interfaz definida en Shop.CrossCutting.
	> **Shop.ExternalServices**: Contiene la implementación de la comunicación hacia la API de MercadoLibre utilizando librería de Refit.

## Demos del Aplicativo

- **Shop.WebForms**: Se implementó una Máquina virtual en Azure instalando IIS para montar el aplicativo y que sea accesible para su visualización.
URL:  http://shopdemo.eastus.cloudapp.azure.com
- **Shop.MVC**: sin implementar en producción.

## Autor

* **Osvaldo Cabrera**
