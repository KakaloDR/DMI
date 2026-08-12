# Lista de Tareas Activas (Task Tracking) - Sprint 1: Infraestructura y Cimientos

Este archivo rastrea el progreso en tiempo real del MVP del Dispensario Médico de UNAPEC. El agente de IA debe leer la primera tarea pendiente, ejecutarla al 100%, marcarla con una `[x]` y proceder con la siguiente.

---

## 📋 Lista de Control de Ingeniería

### [ ] Fase 1: Base de Datos Relacional (Centralizada en SQL Server)
- [x] Crear el script completo de inicialización en formato T-SQL (`Database_Setup.sql`) usando las especificaciones exactas descritas en `schema.md`.
- [ ] Ejecutar el script remotamente en la base de datos alojada en el servidor Ubuntu.
- [x] Realizar una inserción de prueba (`INSERT INTO`) en las tablas maestras (`Tipos_Farmacos` y `Marcas`) para comprobar restricciones de llaves primarias.

### [x] Fase 2: Configuración de la Solución de C#
- [x] Generar la estructura de la solución (.sln) de Windows Forms orientada a .NET 8.
- [x] Crear la estructura modular de directorios para la arquitectura en capas:
    - [x] `GDM.Presentation/` (Interfaz de usuario y formularios).
    - [x] `GDM.Business/` (Reglas del dispensario y validaciones lógicas).
    - [x] `GDM.Data/` (Conexiones y consultas parametrizadas ADO.NET).
- [x] Configurar el archivo de configuración global (`App.config`) incluyendo la cadena de conexión cifrada (`Encrypt=True`) apuntando a la IP privada de Tailscale del servidor Ubuntu.

### [x] Fase 3: Pruebas de Integración Base
- [x] Desarrollar la clase base estática `Conexion BD` en la capa de datos (`GDM.Data`).
- [x] Programar un test de conexión rápido en el formulario de inicio (`Form1`) que cambie un control visual de color a verde (utilizando la paleta de `styles.md`) si logra abrir la conexión con SQL Server de forma exitosa.

---

## 📋 [x] Sprint 2: Catálogos Maestros y CRUDs (Semana 2)

### [x] Fase 1: Catálogos Estáticos (Tipos de Fármacos, Marcas y Ubicaciones)
- [x] Desarrollar la capa DAL y BLL para `Tipos_Farmacos`, `Marcas` y `Ubicaciones` en `GDM.Data` y `GDM.Business`.
- [x] Desarrollar formularios y lógica visual en C# para `FormTiposFarmacos.cs`, `FormMarcas.cs` y `FormUbicaciones.cs` según `styles.md`.
- [x] Desarrollar formularios para Pacientes y Médicos (incluyendo validaciones de cédula y campos vacíos).
- [x] Desarrollar formulario de Medicamentos uniendo las relaciones anteriores mediante `ComboBox` dinámicos.

---

## 📋 [ ] Sprint 3: Core Transaccional - Registro de Visitas

### [ ] Fase 1: Capa de Datos y Negocio para Visitas
- [ ] Crear el modelo de entidad `Visita.cs` (con mapeo a la tabla `Registro_Visitas`).
- [ ] Desarrollar la capa de datos `VisitaDAL.cs` (métodos ObtenerTodos, Guardar, Eliminar con prevención de SQL Injection).
- [ ] Desarrollar la capa de negocio `VisitaBLL.cs` con validación de estados de médicos, pacientes y medicamentos (no permitir transaccionar con entidades inactivas).

### [ ] Fase 2: Interfaz de Usuario (CRUD Visitas)
- [ ] Diseñar el formulario `FormVisitas.cs` utilizando la paleta de colores corporativa e institucional fría.
- [ ] Integrar campos de texto para Síntomas y Recomendaciones, selectores de fecha/hora y ComboBoxes para Médico, Paciente y Medicamento.
- [ ] Enlazar el módulo de Visitas al Menú Principal (`Form1.cs`).