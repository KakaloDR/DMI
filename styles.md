# Guía de Estilos Visuales e Interfaz (UI) - Sistema DMI (Clinical Light & Navy SPA)

Este archivo establece los lineamientos estéticos, de diseño gráfico y de accesibilidad para la interfaz de usuario moderna basada en un panel contenedor tipo SPA (Single Page Application) y una paleta de colores clínico-empresarial optimizada para el sector salud.

---

## 1. Filosofía de Diseño
* **Enfoque:** SPA Dashboard (Single Page Application). Los submódulos se incrustan dinámicamente dentro de un contenedor principal (`panelWorkspace`) del formulario `Form1`.
* **Estética:** Clean Clinical Medical. Combina la pulcritud y claridad del blanco sanitario con el azul semi-oscuro institucional y acentos clínicos (celeste o cian) que transmiten confianza, tecnología y orden.
* **Diseño Plano Moderno:** Eliminación de relieves tridimensionales en favor de bordes planos finos, espacios generosos y contrastes suaves pero legibles.

---

## 2. Paleta de Colores de Salud (RGB)

| Rol de Color | Código Hex | Código RGB (C#) | Uso en Componentes |
| :--- | :--- | :--- | :--- |
| **Page Background** | `#F8FAFC` | `248, 250, 252` | Fondo general de las pantallas (Gris/Azul clínico muy suave). |
| **Card / Canvas Background** | `#FFFFFF` | `255, 255, 255` | Fondo de GroupBoxes, tarjetas de datos e inputs. |
| **Medical Navy (Azul Semi-Oscuro)** | `#0F294A` | `15, 41, 74` | Sidebar izquierdo, cabeceras principales y textos destacados. |
| **Clinical Accent (Celeste)** | `#0EA5E9` | `14, 165, 233` | Botones de guardar, selecciones activas y estados "Activo". |
| **Accent Hover** | `#0284C7` | `2, 132, 199` | Color para hover en botones principales. |
| **Danger / Alert (Crimson)** | `#EF4444` | `239, 68, 68` | Botones de eliminar, advertencias y estados "Inactivo". |
| **Text Primary (Dark Slate)** | `#0F172A` | `15, 23, 42` | Texto principal de datos, tablas y títulos internos. |
| **Text Secondary (Slate Muted)** | `#64748B` | `100, 116, 139` | Labels descriptivos, placeholders e integrantes del grupo. |
| **Border Light (Sanitario)** | `#E2E8F0` | `226, 232, 240` | Bordes finos de TextBoxes, grillas y contenedores. |

---

## 3. Tipografía y Jerarquía
Se utiliza la fuente **Segoe UI** para garantizar un renderizado limpio:
* **Títulos de Módulo:** `14F, FontStyle.Bold` | Color: `#0F294A` (Azul semi-oscuro).
* **Agrupadores (GroupBox):** `11F, FontStyle.Bold` | Color: `#0F294A`.
* **Etiquetas y Inputs:** `9.75F, FontStyle.Regular` | Color: `#0F172A`.
* **DataGridView (Celdas):** `9.5F, FontStyle.Regular` | Color: `#0F172A`.

---

## 4. Estilización de Controles WinForms

### A. Sidebar Izquierdo (Menú Lateral)
* **Contenedor:** `BackColor = Color.FromArgb(15, 41, 74)` (Azul Semi-Oscuro Corporativo).
* **Botones:**
  * `FlatStyle = FlatStyle.Flat`
  * `FlatAppearance.BorderSize = 0`
  * `BackColor = Color.Transparent`
  * `ForeColor = Color.FromArgb(226, 232, 240)` (Blanco/Gris suave).
  * `Font = new Font("Segoe UI", 10F, FontStyle.Bold)`
  * `TextAlign = ContentAlignment.MiddleLeft`
  * **Efecto Hover (MouseEnter / MouseLeave):**
    * Al entrar: `BackColor = Color.FromArgb(14, 165, 233)` (Celeste), `ForeColor = Color.White`
    * Al salir: `BackColor = Color.Transparent`, `ForeColor = Color.FromArgb(226, 232, 240)`

### B. Botones de Acción
* `FlatStyle = FlatStyle.Flat`
* `FlatAppearance.BorderSize = 1`
* `Cursor = Cursors.Hand`
* **Guardar/Nuevo:** `BackColor = Color.FromArgb(14, 165, 233)`, `ForeColor = Color.White`, `FlatAppearance.BorderColor = Color.FromArgb(14, 165, 233)`.
* **Eliminar:** `BackColor = Color.FromArgb(239, 68, 68)`, `ForeColor = Color.White`, `FlatAppearance.BorderColor = Color.FromArgb(239, 68, 68)`.
* **Cancelar/Limpiar/Retroceder:** `BackColor = Color.Transparent`, `ForeColor = Color.FromArgb(100, 116, 139)`, `FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240)`.

### C. Campos de Texto y Listas Desplegables
* `BorderStyle = BorderStyle.FixedSingle`
* `BackColor = Color.White`
* `ForeColor = Color.FromArgb(15, 23, 42)`
* **Eventos Enter/Leave:**
  * Al hacer foco: `BackColor = Color.FromArgb(248, 250, 252)` (Suave fondo clínico), restaurar a `Color.White` al salir.

### D. DataGridView (Diseño Clínico Limpio)
* `BackgroundColor = Color.White`
* `GridColor = Color.FromArgb(226, 232, 240)`
* `BorderStyle = BorderStyle.None`
* `CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal`
* `EnableHeadersVisualStyles = false`
* **Encabezados:** `BackColor = Color.FromArgb(15, 41, 74)`, `ForeColor = Color.White`, `Font = 9.5F, FontStyle.Bold`
* **Filas:** `DefaultCellStyle.BackColor = Color.White`, `DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42)`
* **Filas Alternas:** `AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)`
* **Selección:** `DefaultCellStyle.SelectionBackColor = Color.FromArgb(14, 165, 233)`, `DefaultCellStyle.SelectionForeColor = Color.White`

---

## 5. Arquitectura SPA de Trabajo
* El área de trabajo `panelWorkspace` de `Form1` tendrá un color de fondo `#F8FAFC`.
* Cada submódulo cargado ocupará la totalidad del panel, mostrando su título en un encabezado superior limpio (`#FFFFFF`) y el diseño en tarjetas de datos blancas sobre el fondo azul-grisáceo suave.