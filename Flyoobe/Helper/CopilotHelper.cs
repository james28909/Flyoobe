using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public static class CopilotHelper
{
    // Path to the Copilot icon file
    private static readonly string IconPath = Path.Combine("app", "copilot.png");


    // The Shell URI to launch the Copilot app
    private const string CopilotAppUri = "shell:AppsFolder\\Microsoft.Copilot_8wekyb3d8bbwe!App";

    /// <summary>
    /// Loads and scales the Copilot icon if available.
    /// </summary>
    /// <param name="baseSize">Base size for the icon</param>
    /// <returns>Scaled icon image or null if icon file missing</returns>
    public static Image LoadScaledIcon(int baseSize)
    {
        if (!File.Exists(IconPath))
            return null;

        using (var img = Image.FromFile(IconPath))
        {
            int scaledSize = GetScaledIconSize(baseSize);
            return new Bitmap(img, new Size(scaledSize, scaledSize));
        }
    }

    /// <summary>
    /// Calculates the scaled icon size based on current screen DPI.
    /// </summary>
    public static int GetScaledIconSize(int baseSize)
    {
        using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            return (int)(baseSize * (g.DpiX / 96f));
    }

    /// <summary>
    /// Attempts to launch the Copilot app.
    /// </summary>
    public static void LaunchCopilot()
    {
        string appFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Packages",
            "Microsoft.Copilot_8wekyb3d8bbwe"
        );

        if (!Directory.Exists(appFolder))
        {
            MessageBox.Show(
                "Copilot is currently unavailable. You're the captain now...",
                "Copilot Launch Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = "explorer.exe",
            Arguments = CopilotAppUri,
            UseShellExecute = true
        });
    }

    /// <summary>
    /// Sets up the Copilot button with the icon and tooltip.
    /// </summary>
    /// <param name="btn"></param>
    /// <param name="iconBaseSize"></param>
    public static void SetupCopilotButton(Button btn, int iconBaseSize)
    {
        if (File.Exists(IconPath))
        {
            btn.Visible = true;
            btn.Image = LoadScaledIcon(iconBaseSize);

            var tooltip = new ToolTip();
            tooltip.SetToolTip(btn, "Ask Copilot");
        }
        else
        {
            btn.Visible = false;
        }
    }
}