##Sistema de Gestión de Tareas

Este proyecto consiste en una prueba técnica, la cual está estructurada de la siguiente forma:

DB - Objetos creados en base de datos (SQL) TaskClient - Cliente desarrollado en AngularJS (versión 16) y PrimeNG (versión 16). TaskAPI - API Desarrollada con NetCore 6 Se desarrolla este proyecto teniendo en cuenta las versiones más actuales y estables de las tecnologías anteriormente mencionadas. Se tienen en cuenta patrones de desarrollo y código limpio para que sea escalable en el futuro. Además, se realiza el proyecto en inglés para una mejor comprensión.

Desarrollo de la prueba Para que la aplicación funcione correctamente, es necesario tener en cuenta los siguientes pasos:

#Pasos de ejecución:

1.Ejecutar Script se sql "PruebaPactia.sql" En este scripts se encuentra la creación de la base de datos y de la tabla.

TaskAPI En este proyecto se encuentra el backend de la aplicación, desarrollado implementando la arquitectura hexagonal. Esta arquitectura nos expone una aplicación totalmente independiente que puede ser usada de la misma forma por usuarios, programas, pruebas automatizadas o scripts, y puede ser desarrollada y probada de forma aislada de sus eventuales dispositivos y bases de datos en tiempo de ejecución.

Estructura del proyecto Task.WebAPI, Task.Models, Task.Domain y Task.DataInfrastructure

Se comienza a crear el proyecto desde la capa de Domain, ya que así es como se orienta en la arquitectura hexagonal.

Se integra el ORM (Object Relational Mapping) Entity Framework, el cual nos ayuda a mapear las entidades de la base de datos en nuestra API.

El archivo encargado de realizar este proceso se encuentra en la capa Task.Domain/Bat TaskContext.bat

Ejecutar la aplicación para que el cliente pueda recibir las peticiones. En la API, se evidencia la estructura completa de la Arquitectura Hexagonal.
