# 🆕 Setup Extensions: Host + Options Support

The **Setup Extensions** system now supports extended script metadata in the header.  
This allows script authors to define dropdown menus and control how the script is executed.

---

## ✅ New Metadata Parameters

### `# Description: <string>`
- Short, user-friendly description of what the script does.
- Displayed in the Extensions page below the title.

### `# Host: embedded | console`
- **embedded** = run inside OOBE, output is captured and shown in the app.  
- **console** = run in an external PowerShell window with `-NoExit`.  
- **Default:** `embedded` (if not specified).

### `# Options: value1; value2; value3; ...`
- Defines multiple selectable actions for a single script.
- A dropdown is automatically shown in the Extensions page.
- The selected value is passed to the script as `$choice`.

---

## 📄 Example Script Header

```powershell
# Description: File Explorer tweaks
# Host: embedded
# Options: Show file extensions; Hide file extensions; Open This PC

param([string]$choice)
switch ($choice) {
    "Show file extensions" { ... }
    "Hide file extensions" { ... }
    "Open This PC" { ... }
}
