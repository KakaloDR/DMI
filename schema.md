# Diccionario de Datos y Modelo Relacional (SQL Server) - Sistema GDM

Este archivo contiene la estructura física exacta de la base de datos centralizada que se desplegará en el servidor Ubuntu. Los agentes de IA deben basarse estrictamente en estos tipos de datos y relaciones para escribir el código de la capa DAL en C#.

---

## 1. Tablas Maestras (Catálogos Estáticos)

### A. Tabla: `Tipos_Farmacos`
* **Descripción:** Almacena las presentaciones físicas de los medicamentos (pastillas, cápsulas, jarabes).
* **Campos:**
    * `ID_Tipo_Farmaco` (INT, PK, IDENTITY(1,1)): Identificador único autoincrementable.
    * `Descripcion` (VARCHAR(100), NOT NULL): Nombre de la presentación.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Control de disponibilidad ('Activo' / 'Inactivo').

### B. Tabla: `Marcas`
* **Descripción:** Almacena los laboratorios fabricantes.
* **Campos:**
    * `ID_Marca` (INT, PK, IDENTITY(1,1)): Identificador único autoincrementable.
    * `Descripcion` (VARCHAR(100), NOT NULL): Nombre del laboratorio.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Control de disponibilidad ('Activo' / 'Inactivo').

### C. Tabla: `Ubicaciones`
* **Descripción:** Ubicación física tridimensional de los fármacos en el inventario del dispensario.
* **Campos:**
    * `ID_Ubicacion` (INT, PK, IDENTITY(1,1)): Identificador único autoincrementable.
    * `Descripcion` (VARCHAR(100), NOT NULL): Nombre descriptivo de la zona o área.
    * `Estante` (VARCHAR(50), NOT NULL): Identificación del mueble o estantería.
    * `Tramo` (VARCHAR(50), NOT NULL): Nivel o sección horizontal.
    * `Celda` (VARCHAR(50), NOT NULL): Casilla o compartimiento específico.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Control de disponibilidad.

---

## 2. Tablas de Entidades (Catálogos Dinámicos)

### D. Tabla: `Medicamentos`
* **Descripción:** Inventario general de fármacos disponibles para los pacientes.
* **Campos:**
    * `ID_Medicamento` (INT, PK, IDENTITY(1,1)): Identificador único.
    * `Descripcion` (VARCHAR(200), NOT NULL): Nombre comercial o genérico del medicamento.
    * `FK_Tipo_Farmaco` (INT, FK): Relaciona con `Tipos_Farmacos(ID_Tipo_Farmaco)`.
    * `FK_Marca` (INT, FK): Relaciona con `Marcas(ID_Marca)`.
    * `FK_Ubicacion` (INT, FK): Relaciona con `Ubicaciones(ID_Ubicacion)`.
    * `Dosis` (VARCHAR(150), NOT NULL): Indicación de dosificación estándar recomendada.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Estado del fármaco.

### E. Tabla: `Pacientes`
* **Descripción:** Registro de los miembros de la comunidad de UNAPEC que solicitan atención.
* **Campos:**
    * `ID_Paciente` (INT, PK, IDENTITY(1,1)): Identificador único.
    * `Nombre` (VARCHAR(150), NOT NULL): Nombres y apellidos completos.
    * `Cedula` (VARCHAR(15), NOT NULL, UNIQUE): Documento de identidad nacional.
    * `No_Carnet` (VARCHAR(20), NOT NULL, UNIQUE): Matrícula estudiantil o código de empleado.
    * `Tipo_Paciente` (VARCHAR(30), NOT NULL): Restringido a: 'Estudiante', 'Empleado', 'Profesor', 'Otros'.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Estado del paciente.

### F. Tabla: `Medicos`
* **Descripción:** Personal de salud asignado al dispensario médico de la universidad.
* **Campos:**
    * `ID_Medico` (INT, PK, IDENTITY(1,1)): Identificador único.
    * `Nombre` (VARCHAR(150), NOT NULL): Nombres y apellidos completos.
    * `Cedula` (VARCHAR(15), NOT NULL, UNIQUE): Documento de identidad nacional.
    * `Tanda_Labor` (VARCHAR(30), NOT NULL): Horario asignado (Ej: 'Matutina', 'Vespertina', 'Nocturna').
    * `Especialidad` (VARCHAR(100), NOT NULL): Área de especialización médica.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Estado del médico.

---

## 3. Capa Transaccional (Núcleo Operacional)

### G. Tabla: `Registro_Visitas`
* **Descripción:** Registro histórico de las asistencias médicas y entrega de medicamentos.
* **Campos:**
    * `ID_Visita` (INT, PK, IDENTITY(1,1)): Identificador único de la atención.
    * `FK_Medico` (INT, FK): Relaciona con `Medicos(ID_Medico)`. Muestra qué médico atendió.
    * `FK_Paciente` (INT, FK): Relaciona con `Pacientes(ID_Paciente)`. Paciente receptor.
    * `Fecha_Visita` (DATE, NOT NULL, DEFAULT GETDATE()): Fecha calendario del evento.
    * `Hora_Visita` (TIME, NOT NULL, DEFAULT CONVERT(TIME, GETDATE())): Hora exacta de la entrada.
    * `Sintomas` (VARCHAR(MAX), NOT NULL): Descripción de las dolencias declaradas por el paciente.
    * `FK_Medicamento` (INT, FK): Relaciona con `Medicamentos(ID_Medicamento)`. Medicamento suministrado.
    * `Recomendaciones` (VARCHAR(MAX), NOT NULL): Indicaciones médicas de cuidado posconsulta.
    * `Estado` (VARCHAR(20), NOT NULL, DEFAULT 'Activo'): Estado físico o lógico del registro de la visita.