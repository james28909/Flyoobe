using Flyoobe;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class ViewNavigator
{
    // Default OOBE/Workload view names
    private static readonly string[] DefaultOobeViews =
    {
        "Upgrade",
        "Device",
        "Personalization",
        "Browser",
        "Network",
        "Account",
        "Apps",
        "Experience",
        "Installer",
        "Updates",
        "Extensions"
    };

    private readonly Panel _hostPanel;              // Panel where the active UserControl is displayed
    private readonly TreeView _navigationTree;      // Navigation tree
    private readonly Action<string> _onViewChanged; // Callback for updating the header/title in MainForm

    // View factories and cache for lazy loading
    private readonly Dictionary<string, Func<UserControl>> _factories;
    private readonly Dictionary<string, UserControl> _cache;

    public UserControl CurrentView { get; private set; }

    public ViewNavigator(Panel hostPanel, TreeView navigationTree, Action<string> onViewChanged)
    {
        _hostPanel = hostPanel;
        _navigationTree = navigationTree;
        _onViewChanged = onViewChanged;

        _factories = new Dictionary<string, Func<UserControl>>();
        _cache = new Dictionary<string, UserControl>();

        // Event: Handle navigation when a TreeView node is clicked
        _navigationTree.AfterSelect += NavigationTree_AfterSelect;
    }

    /// <summary>
    /// Registers a view with a unique name and a factory function for lazy loading.
    /// </summary>
    public void RegisterView(string name, Func<UserControl> factory)
    {
        _factories[name] = factory;
    }

    /// <summary>
    /// Displays the specified view. Creates it if not already loaded.
    /// </summary>
    public void ShowView(string name)
    {
        if (!_factories.ContainsKey(name))
            return;

        _hostPanel.Controls.Clear();

        // Lazy-load the view
        if (!_cache.ContainsKey(name))
        {
            var control = _factories[name]();
            control.Dock = DockStyle.Fill;
            _cache[name] = control;
        }

        CurrentView = _cache[name];
        _hostPanel.Controls.Add(CurrentView);

        // Update the MainForm's header label
        if (CurrentView is IView view)
            _onViewChanged?.Invoke(view.ViewTitle);
        else
            _onViewChanged?.Invoke(name);
    }

    /// <summary>
    /// Builds the tree: "Upgrade" category contains status + Upgrade + Repair.
    /// "OOBE" category contains the rest. Special entries get a gray subtext child node.
    /// Only nodes with Tag are clickable.
    /// </summary>
    public void LoadDefaultNavigation()
    {
        _navigationTree.Nodes.Clear();

        bool isWindows11 = Utils.DetectWindows11();

        // --- Upgrade category ---
        var upgradeNode = new TreeNode("Upgrade");

        // Status (info only)
        var statusNode = new TreeNode(isWindows11 ? "✔ Windows 11 detected" : "❌ Upgrade required")
        {
            ForeColor = isWindows11 ? Color.FromArgb(97, 75, 61): Color.Red
        };
        upgradeNode.Nodes.Add(statusNode);

        // Upgrade step 
        string upgradeDisplay = isWindows11 ? "✔ Upgrade (Done)" : "Upgrade";
        upgradeNode.Nodes.Add(new TreeNode(upgradeDisplay) { Tag = "Upgrade" });

        // Reinstall step
        upgradeNode.Nodes.Add(new TreeNode("Install only (Custom)") { Tag = "Install only" });

        // --- OOBE category ---
        var oobeNode = new TreeNode("OOBE");

        foreach (var name in DefaultOobeViews)
        {
            // Skip those that belong to Upgrade category 
            if (name == "Upgrade" || name == "Install only")
                continue;

            var mainNode = new TreeNode(name); // main node: not clickable by default
            oobeNode.Nodes.Add(new TreeNode(name) { Tag = name });
        }

        _navigationTree.Nodes.Add(upgradeNode);
        _navigationTree.Nodes.Add(oobeNode);
        _navigationTree.ExpandAll();
    }


    /// <summary>
    /// Handles TreeView selection changes and loads the corresponding view if registered.
    /// </summary>
    private void NavigationTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Tag is string viewKey)
        {
            ShowView(viewKey); // Use the key stored in Tag
        }
    }

}
