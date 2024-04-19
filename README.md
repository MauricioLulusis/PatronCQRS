🚀 Proyecto CQRS en .NET C# con base de datos en memoria 🚀

Este repositorio es una implementación de Command Query Responsibility Segregation (CQRS) utilizando .NET C# como lenguaje principal y una base de datos en memoria para almacenar datos transitorios. El patrón CQRS separa las operaciones de lectura y escritura, permitiendo una arquitectura más escalable y flexible para aplicaciones que gestionan un gran volumen de datos.

Características:

Implementación CQRS: Utiliza el patrón CQRS para separar las responsabilidades de lectura y escritura, mejorando la escalabilidad y mantenibilidad del sistema.
Lenguaje Principal: Desarrollado principalmente en C# para la plataforma .NET, aprovechando su robustez y flexibilidad.
Base de Datos en Memoria: Utiliza una base de datos en memoria para almacenar datos transitorios durante la ejecución del sistema, lo que permite pruebas rápidas y eficientes sin depender de una base de datos persistente.
Estructura del Proyecto:


1) Commands: Contiene los comandos utilizados para realizar operaciones de escritura en el sistema.

2) Queries: Contiene las consultas utilizadas para obtener datos del sistema.

3) Handlers: Implementa los manejadores de comandos y consultas para ejecutar las operaciones correspondientes.

4) Models: Define los modelos de datos utilizados en el sistema.

5) Services: Contiene servicios auxiliares utilizados en la lógica de negocio.


