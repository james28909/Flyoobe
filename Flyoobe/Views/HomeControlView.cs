using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class HomeControlView : UserControl, IView
    {
        private readonly ViewNavigator _navigator;
        private Label _statusLabel; // bottom info label

        public string ViewTitle => "Home";

        private readonly Color[] _colorPalette = new[]
        {
            Color.FromArgb(0, 209, 178),  // teal
            Color.FromArgb(91, 141, 239), // blue
            Color.FromArgb(155, 93, 229), // purple
            Color.FromArgb(241, 91, 181), // pink
            Color.FromArgb(0, 187, 249),  // cyan
            Color.FromArgb(84, 220, 132), // green
        };
        private int _nextColorIndex = 0;
        private Color NextAccent() => _colorPalette[_nextColorIndex++ % _colorPalette.Length];

        public HomeControlView(ViewNavigator navigator)
        {
            _navigator = navigator;
            BuildLayout();
        }

        private void BuildLayout()
        {
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var layout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(20)
            };

            // Upgrade tile: disable if already Windows 11
            if (!Utils.DetectWindows11())
            {
                layout.Controls.Add(CreateTile(
                    "🚀 Upgrade Windows",
                    "Upgrade to Windows 11",
                    "Here you can apply a bypass patch and upgrade to Windows 11 even if your hardware is not officially supported.",
                    () => _navigator.ShowView("Upgrade")));
            }
            else
            {
                layout.Controls.Add(CreateTile(
                    "✔ Windows 11 Installed",
                    "Your system is already on Windows 11",
                    "No upgrade required – you're up to date.",
                    null, true)); // disabled tile
            }

            layout.Controls.Add(CreateTile("🎨 Customize OOBE", "Personalize and streamline your Out-of-Box Experience",
                "On the right side you will find the OOBE section. After a Windows 11 installation you can debloat, tweak and personalize your system.",
                () => _navigator.ShowView("Personalization")));

            layout.Controls.Add(CreateTile("🛠 Install && Repair", "Install or repair Windows 10/11",
                "Choose repair or reinstall options such as in-place upgrade, reset this PC, or custom installation media.",
                () => _navigator.ShowView("Install only")));

            layout.Controls.Add(CreateTile("🧩 Setup Extensions", "Enhance your Windows setup",
                "Browse community-driven PowerShell scripts and extensions to automate, debloat, or customize your system after installation.",
                () => _navigator.ShowView("Extensions")));

            // Status bar
            float dpiScale = this.CreateGraphics().DpiX / 96f;
            _statusLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = (int)(34 * dpiScale),
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.Black,
                BackColor = Color.WhiteSmoke,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8),
                Text = "Welcome to Flyoobe"
            };

            root.Controls.Add(layout, 0, 0);
            root.Controls.Add(_statusLabel, 0, 1);
            Controls.Add(root);
        }
        /// <summary>
        /// Creates a tile with title, description and optional action.
        /// If disabled=true, the tile is shown lighter and not clickable.
        /// </summary>
        private Control CreateTile(string title, string description, string detailedDescription, Action onClick, bool disabled = false)
        {
            // Colors: normal, hover, pressed
            var baseBack = disabled ? Color.FromArgb(245, 247, 250) : Color.FromArgb(248, 250, 252);
            var hoverBack = Color.FromArgb(242, 245, 255);
            var downBack = Color.FromArgb(235, 240, 255);

            var accent = NextAccent();
            float dpiScale = this.CreateGraphics().DpiX / 96f;

            // Main tile panel
            var panel = new Panel
            {
                Width = (int)(280 * dpiScale),
                Height = (int)(100 * dpiScale),
                BackColor = baseBack,
                Margin = new Padding(10),
                Cursor = disabled ? Cursors.Default : Cursors.Hand
            };

            // Colored accent bar on the left
            var leftBar = new Panel
            {
                Dock = DockStyle.Left,
                Width = (int)(5 * dpiScale),
                BackColor = accent
            };

            // Title
            var lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                Height = (int)(36 * dpiScale),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = disabled ? Color.Gray : Color.Black
            };

            // Short description
            var lblDesc = new Label
            {
                Text = description,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, disabled ? FontStyle.Italic : FontStyle.Regular),
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(6, 4, 6, 6),
                ForeColor = disabled ? Color.DarkGray : Color.Black
            };

            // Compose tile
            panel.Controls.Add(lblDesc);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(leftBar);

            if (!disabled)
            {
                // Make tile clickable
                void WireClick(Control c) => c.Click += (s, e) => onClick?.Invoke();
                WireClick(panel); WireClick(lblTitle); WireClick(lblDesc);

                // Hover effect + update bottom label
                void SetHover(bool on)
                {
                    panel.BackColor = on ? hoverBack : baseBack;
                    leftBar.Width = on ? 7 : 5;
                    _statusLabel.Text = on ? detailedDescription : "Welcome to Flyoobe";
                }

                void WireHover(Control c)
                {// Hover/press visual feedback (bar grows a bit on hover)
                    c.MouseEnter += (s, e) => SetHover(true);
                    c.MouseLeave += (s, e) =>
                    {// Only reset if pointer actually left the tile area
                        var inside = panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position));
                        if (!inside) SetHover(false);
                    };
                    c.MouseDown += (s, e) => panel.BackColor = downBack;
                    c.MouseUp += (s, e) =>
                    {
                        var inside = panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position));
                        panel.BackColor = inside ? hoverBack : baseBack;
                    };
                }

                WireHover(panel); WireHover(lblTitle); WireHover(lblDesc);
            }

            return panel;
        }


        public void RefreshView() { }
    }
}
