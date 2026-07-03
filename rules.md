# Reglas Absolutas de Codificación (.cursorrules / .idxrules) - Sistema GDM

Este archivo contiene las restricciones algorítmicas y de arquitectura de software que ningún LLM o agente automatizado debe violar al programar en C# o SQL para este proyecto.

---

## 1. Restricciones de C# (.NET 8 Windows Forms)
* **Separación de Capas Obligatoria:** * Está estrictamente prohibido escribir consultas SQL directas o lógica de negocio dentro de los eventos de los formularios (`Form.cs`). Los eventos solo invocan métodos de la clase controladora en la capa BLL.
* **Manejo Seguro de Memoria:**
    * Todo objeto que implemente `IDisposable` (tales como `SqlConnection`, `SqlCommand`, `SqlDataReader`) debe inicializarse dentro de bloques `using` para forzar la liberación de recursos inmediatamente al terminar la consulta.
* **Conversión Segura de Datos:**
    * Queda prohibido el uso de casteos directos peligrosos como `(int)Input` o `Convert.ToInt32()` en datos volátiles de formularios. Utiliza exclusivamente la validación condicional con bloques `if (int.TryParse(...))`.

---

## 2. Restricciones de Acceso a Datos (DAL) y Seguridad
* **Prevención de Inyección SQL (Mandatorio):**
    * Ninguna instrucción SQL dinámica puede contener strings concatenados (ej: `WHERE Id = '` + txt + `'`). Todas las sentencias deben parametrizarse de forma mandatoria mediante la colección `Parameters.AddWithValue()` o especificando el tipo explícito con `SqlParameter`.
* **Centralización de Credenciales:**
    * La cadena de conexión (`ConnectionString`) no debe escribirse directamente en las clases de datos. Debe centralizarse en un archivo de configuración único (`appsettings.json` o `App.config`) y leerse de forma dinámica. La IP destino siempre debe corresponder a la subred privada de Tailscale (`100.X.X.X`).

---

## 3. Restricciones del Comportamiento del Agente de IA
* **No Generar Código Parcial:** No utilices marcadores de posición como `// El resto del código va aquí...` o estructuras incompletas. Todo bloque de código generado debe ser completamente funcional, compilar a la primera y estar listo para producción.
* **Comentarios Técnicos Compactos:** Documenta brevemente el propósito de las funciones críticas de la capa de negocio y acceso a datos utilizando comentarios tipo XML (`/// <summary>`) estándar de C#.