using Flyoobe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public sealed class ViewNavigator
{
    private ToolTip _toolTip = new ToolTip();

    // OOOBE Views order
    private static readonly string[] DefaultOobeViews =
    {
        "Home",    // first menu item
        "Upgrade",
        "Reinstall",
        "Device",
        "Personalization",
        "Browser",
        "AI",
        "Network",
        "Account",
        "Apps",
        "Experience",
        "Installer",
        "Updates",
        "Extensions"
    };

    private readonly Panel _host;                           // where the active view is shown
    private readonly FlowLayoutPanel _nav;                  // bottom nav bar (scrollable)
    private readonly Button _nextBtn;                       // Next button on the right
    private readonly Action<string> _onViewChanged;         // header/subheader updater

    // View factories and cache for lazy loading
    private readonly Dictionary<string, Func<UserControl>> _factories = new Dictionary<string, Func<UserControl>>();
    private readonly Dictionary<string, UserControl> _cache = new Dictionary<string, UserControl>();
    private readonly Dictionary<string, Button> _buttons = new Dictionary<string, Button>();

    public UserControl CurrentView { get; private set; }

    public ViewNavigator(Panel hostPanel, FlowLayoutPanel navPanel, Button nextButton, Action<string> onViewChanged)
    {
        _host = hostPanel;
        _nav = navPanel;
        _nextBtn = nextButton;
        _onViewChanged = onViewChanged;

        // Wire Next button once
        _nextBtn.Click += (s, e) => ShowNext();
    }

    /// <summary>Register a view factory under a unique name.</summary>
    public void RegisterView(string name, Func<UserControl> factory)
    {
        _factories[name] = factory;
    }

    /// <summary>Show a view by name (lazy loads it on demand).</summary>
    public void ShowView(string name)
    {
        if (!_factories.ContainsKey(name))
            return;

        _host.Controls.Clear();

        if (!_cache.TryGetValue(name, out var control))
        {
            control = _factories[name]();
            control.Dock = DockStyle.Fill;
            _cache[name] = control;
        }

        CurrentView = control;
        _host.Controls.Add(control);

        // Update the MainForm's header label
        if (CurrentView is IView view)
            _onViewChanged?.Invoke(view.ViewTitle);
        else
            _onViewChanged?.Invoke(name);

        HighlightButton(name);
        UpdateNextButtonState();
    }

    /// <summary>
    /// Build the bottom navigation bar with Setup (Home/Upgrade/Reinstall)
    /// and OOBE (Device…Extensions).
    /// </summary>
    public void BuildBottomNavigation(float dpiScale)
    {
        _nav.SuspendLayout();
        _nav.Controls.Clear();
        _buttons.Clear();

        bool isWin11 = Utils.DetectWindows11();

        for (int i = 0; i < DefaultOobeViews.Length; i++)
        {
            string name = DefaultOobeViews[i];
            string caption = name;

            // Upgrade caption
            if (name == "Upgrade")
                caption = isWin11 ? "Upgrade (Done)" : "Upgrade (Required)";

            // Insert OOBE badge before "Device"
            if (i == 3)
                _nav.Controls.Add(CreateBadge("OOBE"));

            var btn = CreateNavButton(caption, name, dpiScale);

            // --- Styling ---
            if (i < 3) // Setup section
            {
                btn.BackColor = Color.White;

                if (name == "Upgrade")
                {
                    if (isWin11)
                        btn.ForeColor = Color.FromArgb(97, 75, 61); // brownish for "Done"
                    else
                    {
                        btn.ForeColor = Color.Red;                 // red for "Required"
                        _toolTip.SetToolTip(btn, "Upgrade to Windows 11 is required");
                    }
                }
                else
                {
                    btn.ForeColor = Color.Black; // default Setup buttons
                }
            }
            else // OOBE section
            {
                btn.BackColor = Color.WhiteSmoke;
                btn.ForeColor = Color.Black;
            }

            _nav.Controls.Add(btn);
            _buttons[name] = btn;
        }

        _nav.ResumeLayout();
    }

    // ---------- UI helpers ----------
    /// <summary>
    /// Creates a navigation button for the bottom navigation bar.
    /// </summary>
    private Button CreateNavButton(string caption, string key, float dpiScale)
    {
        var btn = new Button
        {
            Tag = key,          // logical key (used to ShowView)
            AutoSize = true,
            Height = (int)(50 * dpiScale),
            Margin = new Padding(6, 4, 6, 4),
            FlatStyle = FlatStyle.Flat,
            TextAlign = ContentAlignment.MiddleCenter,
            UseCompatibleTextRendering = true,
            //ImageAlign = ContentAlignment.TopCenter,
            Text = caption
        };
        btn.FlatAppearance.BorderSize = 0;

        // When clicked > show the assigned view
        btn.Click += (s, e) =>
        {
            if (btn.Tag is string viewKey) ShowView(viewKey);
        };

        // hover effect
        btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(237, 234, 231);
        // Reset hover effect when mouse leaves
        btn.MouseLeave += (s, e) => { if (!_buttons[key].Equals(btn) || GetCurrentKey() != key) btn.BackColor = _nav.BackColor; };

        return btn;
    }

    // ---------- navigation helpers ----------

    /// <summary>
    /// Show the next view in order, if one exists.
    /// </summary>
    private void ShowNext()
    {
        int idx = Array.IndexOf(DefaultOobeViews, GetCurrentKey());
        if (idx >= 0 && idx < DefaultOobeViews.Length - 1)
            ShowView(DefaultOobeViews[idx + 1]);
    }

    /// <summary>
    /// Get the logical name of the currently displayed view.
    /// Falls back to the first view if not found.
    /// </summary>
    private string GetCurrentKey()
    {
        // Find by cached view instance
        foreach (var kv in _cache)
            if (kv.Value == CurrentView)
                return kv.Key;

        // Fallback: return first item
        return DefaultOobeViews[0];
    }

    /// <summary>
    /// Highlight the active navigation button and reset all others.
    /// </summary>
    private void HighlightButton(string activeKey)
    {
        foreach (var kv in _buttons)
            kv.Value.BackColor = kv.Key == activeKey
                ? Color.FromArgb(237, 234, 231)   // active highlight
                : _nav.BackColor;                 // reset
    }

    /// <summary>
    /// Update the "Next" button icon depending on position in flow.
    /// </summary>
    private void UpdateNextButtonState()
    {
        int idx = Array.IndexOf(DefaultOobeViews, GetCurrentKey());
        bool hasNext = idx >= 0 && idx < DefaultOobeViews.Length - 1;

        // Use Segoe MDL2 Assets: E76C = forward, E930 = check/accept
        _nextBtn.Text = hasNext ? "\uE76C" : "\uE930";
    }

    /// <summary>Create a OOBE badge label.</summary>
    private Control CreateBadge(string text)
    {
        return new Label
        {
            Text = text,
            AutoSize = true,
            ForeColor = Color.Black,
            BackColor = Color.FromArgb(138, 180, 248), // blue
            Font = new Font("Segoe UI", 7f, FontStyle.Bold),
            Padding = new Padding(8, 4, 8, 4),
            Margin = new Padding(12, 6, 12, 6),
            TextAlign = ContentAlignment.MiddleCenter,
            UseCompatibleTextRendering = true,

        };
    }
}