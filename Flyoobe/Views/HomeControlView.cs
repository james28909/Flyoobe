using System;
using System.Drawing;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class HomeControlView : UserControl, IView
    {
        private readonly ViewNavigator _navigator;


        public string ViewTitle => "Home";

        public HomeControlView(ViewNavigator navigator)
        {
            _navigator = navigator;
            BuildLayout();
        }

        // MDL2 glyphs 
        private const string GLYPH_WINDOWS = "\uE9F3";  // Upgrade
        private const string GLYPH_MEDIA = "\uE8A5";    // Install
        private const string GLYPH_OOBE = "\uE790";    // OOBE
        private const string GLYPH_EXT = "\uE71D";    // Extension

        private void BuildLayout()
        {
            float dpi = this.CreateGraphics().DpiX / 96f;

            // Root layout: tiles + status bar
            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Tile container
            var tiles = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding((int)(20 * dpi))
            };

            bool isWin11 = Utils.DetectWindows11();

            // Get/Windows Installed tile
            if (!isWin11)
            {
                tiles.Controls.Add(CreateMdl2Tile(
                    GLYPH_WINDOWS,
                    "Get Windows 11",
                    "Download or upgrade to Windows 11",
                    () => _navigator.ShowView("Upgrade"),
                    dpi));
            }
            else
            {
                tiles.Controls.Add(CreateMdl2Tile(
                    GLYPH_WINDOWS,
                    "Windows 11 Installed",
                    "You're already on Windows 11",
                    null, // disabled
                    dpi,
                    disabled: true));
            }

            // Re-Install from ISO and repair
            tiles.Controls.Add(CreateMdl2Tile(
                GLYPH_MEDIA,
                "Install from image",
                 "Install Windows from ISO, do an in-place upgrade, or repair this PC.",
                () => _navigator.ShowView("Reinstall"),
                dpi));

            // OOBE
            tiles.Controls.Add(CreateMdl2Tile(
                GLYPH_OOBE,
                "Customize OOBE",
                "Tweak and personalize after install",
                () => _navigator.ShowView("Personalization"),
                dpi));

            // Setup Extensions
            tiles.Controls.Add(CreateMdl2Tile(
                GLYPH_EXT,
                "Setup Extensions",
                "Enhance your setup with community tools",
                () => _navigator.ShowView("Extensions"),
                dpi));


            root.Controls.Add(tiles, 0, 0);

            Controls.Add(root);
        }

        /// <summary>
        /// Creates a tile with a big Segoe MDL2 icon, title, subtitle and optional click action.
        /// </summary>
        private Control CreateMdl2Tile(string mdl2Glyph, string title, string subtitle, Action onClick, float dpi, bool disabled = false)
        {
            // Base colors
            Color baseBack = disabled ? Color.FromArgb(245, 247, 250) : Color.White;
            Color hoverBack = disabled ? baseBack : Color.FromArgb(242, 245, 255);
            Color downBack = disabled ? baseBack : Color.FromArgb(235, 240, 255);

            // Card
            var card = new Panel
            {
                Width = (int)(280 * dpi),
                Height = (int)(170 * dpi),
                BackColor = baseBack,
                Margin = new Padding((int)(8 * dpi)),
                Cursor = disabled ? Cursors.Default : Cursors.Hand
            };

            // Icon (Segoe MDL2 Assets)
            var icon = new Label
            {
                Dock = DockStyle.Top,
                Height = (int)(74 * dpi),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe MDL2 Assets", 36f * dpi, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = disabled ? Color.Gray : Color.FromArgb(32, 56, 100),
                Text = mdl2Glyph
            };

            // Title
            var lblTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = (int)(32 * dpi),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = disabled ? Color.Gray : Color.Black,
                Text = title
            };

            // Subtitle
            var lblSub = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                Font = new Font("Segoe UI", 9f, disabled ? FontStyle.Italic : FontStyle.Regular),
                ForeColor = disabled ? Color.DarkGray : Color.Black,
                Padding = new Padding((int)(10 * dpi), (int)(2 * dpi), (int)(10 * dpi), (int)(8 * dpi)),
                AutoEllipsis = true,
                Text = subtitle
            };

            // Compose
            card.Controls.Add(lblSub);
            card.Controls.Add(lblTitle);
            card.Controls.Add(icon);

            if (!disabled)
            {
                // Click = navigate
                void WireClick(Control c) { c.Click += (s, e) => onClick?.Invoke(); }
                WireClick(card); WireClick(icon); WireClick(lblTitle); WireClick(lblSub);

                // Hover/press feedback + status text
                void SetHover(bool on)
                {
                    card.BackColor = on ? hoverBack : baseBack;

                }

                void WireHover(Control c)
                {
                    c.MouseEnter += (s, e) => SetHover(true);
                    c.MouseLeave += (s, e) =>
                    {
                        var inside = card.ClientRectangle.Contains(card.PointToClient(Cursor.Position));
                        if (!inside) SetHover(false);
                    };
                    c.MouseDown += (s, e) => card.BackColor = downBack;
                    c.MouseUp += (s, e) =>
                    {
                        var inside = card.ClientRectangle.Contains(card.PointToClient(Cursor.Position));
                        card.BackColor = inside ? hoverBack : baseBack;
                    };
                }

                WireHover(card); WireHover(icon); WireHover(lblTitle); WireHover(lblSub);
            }

            // Light border for card look
            card.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(225, 228, 232)))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            return card;
        }

        public void RefreshView() { }
    }
}
