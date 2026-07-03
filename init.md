# Definición de Arquitectura y Requerimientos - Sistema GDM (Gestión Dispensario Médico)

## 1. Stack Tecnológico y Arquitectura
* [cite_start]**Frontend (UI):** Aplicación de escritorio desarrollada en C# bajo Windows Forms (WinForms) utilizando .NET 8[cite: 16].
* **Base de Datos:** Microsoft SQL Server centralizado.
* **Infraestructura de Hosting:** Servidor de base de datos alojado en Ubuntu Server.
* **Red y Conectividad:** Túnel de conexión VPN cifrada mediante Tailscale (Zero-Trust Network) para comunicar el cliente WinForms local con el servidor Ubuntu.
* **Arquitectura de Software:** N-Capas (Capa de Presentación, Capa de Lógica de Negocio [BLL] y Capa de Acceso a Datos [DAL] vía ADO.NET).

---

## 2. Requerimientos Funcionales y Estructura de Datos
El sistema debe gestionar los siguientes módulos con sus datos mínimos requeridos:

* [cite_start]**Tipos de Fármacos (pastillas, cápsulas, jarabe, etc.) [cite: 7][cite_start]:** Identificador, Descripción, Estado[cite: 17, 18, 19, 20].
* [cite_start]**Marcas (laboratorios fabricantes) [cite: 8][cite_start]:** Identificador, Descripción, Estado[cite: 21, 22, 23, 24].
* [cite_start]**Ubicaciones [cite: 9][cite_start]:** Identificador, Descripción, Estante, Tramo, Celda (casilla), Estado[cite: 25, 26, 27, 28, 29, 30, 31].
* [cite_start]**Medicamentos [cite: 10][cite_start]:** Identificador, Descripción, Tipo Fármaco (Relación), Marca (Relación), Ubicación (Relación), Dosis, Estado[cite: 32, 33, 34, 35, 36, 37, 38, 39].
* [cite_start]**Pacientes [cite: 11][cite_start]:** Identificador, Nombre, Cédula, No. Carnet, Tipo Paciente (Estudiante, Empleado, Profesor, Otros), Estado[cite: 40, 41, 42, 43, 44, 45, 46].
* [cite_start]**Médicos (empleados que asisten) [cite: 12][cite_start]:** Identificador, Nombre, Cédula, Tanda labor, Especialidad, Estado[cite: 47, 48, 49, 50, 51, 52, 53].
* [cite_start]**Registro de Visitas (Núcleo Transaccional) [cite: 13][cite_start]:** Identificador Visita, Médico que le atendió, Paciente, Fecha Visita, Hora Visita, Síntomas (dolencias), Medicamento suministrado, Recomendaciones, Estado[cite: 54, 55, 56, 57, 58, 59, 60, 61, 62, 63].
* [cite_start]**Módulo Analítico:** * Consulta por criterios (ej: Visitas filtradas por Médico, paciente, fecha, etc.)[cite: 14].
    * [cite_start]Reporte de visitas exportable (entre fechas, por médico, por paciente, etc.)[cite: 15].

---

## 3. Requerimientos de Seguridad (Validaciones)
Para garantizar la integridad y seguridad del sistema, se deben implementar las siguientes capas de validación desde la Interfaz hasta la Base de Datos:

1.  **Prevención de Inyección SQL:** Todas las consultas en la capa DAL deben ejecutarse utilizando parámetros tipados (`SqlParameter`), prohibiendo la concatenación directa de strings.
2.  **Validación de Entradas (Frontend):** * Uso de máscaras de entrada (`MaskedTextBox`) para forzar el formato de Cédulas y Carnets.
    * Control estricto de tipos de datos utilizando `TryParse` antes de enviar datos a la BLL.
    * Bloqueo de campos vacíos obligatorios.
3.  **Integridad Referencial (Backend):** No permitir el registro de una Visita Médica si el Paciente, Médico o Medicamento asociado tienen el campo `Estado` marcado como Inactivo.
4.  **Cifrado en Tránsito:** Asegurar que la cadena de conexión de C# (`ConnectionString`) incluya el cifrado nativo hacia el servidor SQL (`Encrypt=True`), aprovechando el túnel seguro de Tailscale.

---

## 4. Plan de Ejecución: Sprints para el MVP

### Sprint 1: Infraestructura y Cimientos (Semana 1)
* **Objetivo:** Establecer la base de datos y la conexión.
* **Tareas:**
    * Crear los scripts DDL en SQL Server (Tablas maestras y relaciones).
    * Configurar Tailscale en el Ubuntu Server y la máquina de desarrollo.
    * Crear la solución en C# WinForms (.NET 8).
    * Desarrollar la clase base de Conexión en la capa DAL y probar ping con la BD.

### Sprint 2: Catálogos Maestros y CRUDs (Semana 2)
* **Objetivo:** Poder registrar y gestionar las entidades estáticas.
* **Tareas:**
    * Desarrollar formularios y lógica para Tipos de Fármacos, Marcas y Ubicaciones.
    * Desarrollar formularios para Pacientes y Médicos (incluyendo validaciones de cédula y campos vacíos).
    * Desarrollar formulario de Medicamentos uniendo las relaciones anteriores mediante `ComboBox` dinámicos.

### Sprint 3: Core Transaccional (Semana 3)
* **Objetivo:** Operacionalizar el dispensario.
* **Tareas:**
    * Diseñar y codificar el formulario de **Registro de Visitas**.
    * Programar la lógica transaccional: Al registrar una visita, validar que el médico y paciente estén activos.

### Sprint 4: Cierre, Reportes y Auditoría (Semana 4)
* **Objetivo:** Cumplir con los entregables de análisis y validación final de seguridad.
* **Tareas:**
    * Crear la pantalla de "Consulta por Criterios" (Filtros dinámicos usando GridViews).
    * Diseñar el formato de exportación/impresión para el Reporte de Visitas.
    * Auditoría de código general para confirmar la prevención de SQL Injection en todas las consultas.