using MatBlazor.Demo.Models;
using System.Linq;

namespace MatBlazor.Demo.Services
{
    public class DemoNavModel
    {
        public static NavModel Default()
        {
            return GetDefaultNavModel();

        }
        private static NavModel GetDefaultNavModel()
        {
            var groups = new
            {
                FormControls = new NavGroup("Form Controls", 1),
                Navigation = new NavGroup("Navigation", 2),
                Layout = new NavGroup("Layout", 3),
                ButtonsAndIndicators = new NavGroup("Buttons & Indicators", 4),
                PopupsAndModals = new NavGroup("Popups & Modals", 5),
                DataTable = new NavGroup("Data Table", 6),
                Other = new NavGroup("Other", 10),
            };
            var navItems = new[]
            {
            new NavItem()
            {
                Name = "Validation via EditContext",
                Url = "EditContext",
                Group = groups.FormControls,
                Order = 1
            },
                new NavItem()
                {
                    Name = "Autocomplete",
                    Url = "Autocomplete",
                    Group = groups.FormControls,
                },
            new NavItem()
            {
                Name = "AutocompleteList",
                Url = "AutocompleteList",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "Checkbox",
                Url = "Checkbox",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "TextField",
                Url = "TextField",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "RadioButton",
                Url = "RadioButton",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "Select",
                Url = "Select",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "SelectItem",
                Url = "SelectItem",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "SelectValue",
                Url = "SelectValue",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "Slider",
                Url = "Slider",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "SlideToggle",
                Url = "SlideToggle",
                Group = groups.FormControls,
            },
            new NavItem()
            {
                Name = "Drawer",
                Url = "Drawer",
                Group = groups.Navigation
            },
            new NavItem()
            {
                Name = "AppBar",
                Url = "AppBar",
                Group = groups.Navigation
            },
            new NavItem()
            {
                Name = "ButtonLink",
                Url = "ButtonLink",
                Group = groups.Navigation
            },
            new NavItem()
            {
                Name = "Dialog",
                Url = "Dialog",
                Group = groups.PopupsAndModals
            },
            new NavItem()
            {
                Name = "Snackbar",
                Url = "Snackbar",
                Group = groups.PopupsAndModals
            },
            new NavItem()
            {
                Name = "Menu",
                Url = "Menu",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Card",
                Url = "Card",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Divider",
                Url = "Divider",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "List",
                Url = "List",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "TreeView",
                Url = "TreeView",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Button",
                Url = "Button",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "Ripple",
                Url = "Ripple",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "IconButton",
                Url = "IconButton",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "Icon",
                Url = "Icon",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "Chip",
                Url = "Chip",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "ProgressBar",
                Url = "ProgressBar",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "ProgressCircle",
                Url = "ProgressCircle",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "Paper & Elevation",
                Url = "Paper",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Typography",
                Url = "Typography",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Layout Grid",
                Url = "LayoutGrid",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Tab",
                Url = "Tab",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "DatePicker",
                Url = "DatePicker",
                Group = groups.FormControls
            },
            new NavItem()
            {
                Name = "FileUpload",
                Url = "FileUpload",
                Group = groups.FormControls
            },
            new NavItem()
            {
                Name = "Themes",
                Url = "Themes",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "FAB",
                Url = "FAB",
                Group = groups.ButtonsAndIndicators
            },
            new NavItem()
            {
                Name = "Expansion Panel",
                Url = "ExpansionPanel",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "Toast",
                Url = "Toast",
                Group = groups.PopupsAndModals
            },
            new NavItem()
            {
                Name = "Tooltip",
                Url = "Tooltip",
                Group = groups.PopupsAndModals
            },
            new NavItem()
            {
                Name = "Hidden",
                Url = "Hidden",
                Group = groups.Layout
            },
            new NavItem()
            {
                Name = "NumericUpDownField",
                Url = "NumericUpDownField",
                Group = groups.FormControls
            },
            new NavItem()
            {
                Name = "Nav Menu",
                Url = "NavMenu",
                Group = groups.Navigation
            },
            new NavItem()
            {
                Name = "Table",
                Url = "Table",
                Group = groups.DataTable
            },
            new NavItem()
            {
                Name = "Paginator",
                Url = "Paginator",
                Group = groups.DataTable
            },
            new NavItem()
            {
                Name = "SortHeader",
                Url = "SortHeader",
                Group = groups.DataTable
            },
            // new NavItem()
            // {
            //     Name = "DataTable",
            //     Url = "DataTable",
            //     Group = groups.DataTable
            // },
            new NavItem()
            {
                Name = "BaseComponent",
                Url = "BaseComponent",
                Group = groups.Other
            },
            new NavItem()
            {
                Name = "ForwardRef & RefBack",
                Url = "ForwardRef",
                Group = groups.Other
            },
            new NavItem()
            {
                Name = "Virtual Scroll",
                Url = "VirtualScroll",
                Group = groups.Layout
            },

            new NavItem()
            {
                Name = "ForwardRefContext",
                Url = "ForwardRefContext",
                Group = groups.Other
            },

            new NavItem()
            {
                Name = "DialogService",
                Url = "DialogService",
                Group = groups.PopupsAndModals
            },
    // new NavItem()
    // {
    //     Name = "Test",
    //     Url = "Test",
    //     Group = groups.Other
    // },
        };


            var model = new NavModel
            {
                NavGroups = navItems
                .GroupBy(i => i.Group)
                .OrderBy(i => i.Key.Order)
                .ThenBy(i => i.Key.Name)
                .Select(g =>
                {
                    return new NavGroupModel()
                    {
                        Group = g.Key,
                        Items = g
                            .OrderBy(i => i.Order)
                            .ThenBy(i => i.Name)
                            .ToArray(),
                    };
                })
                .ToArray()
            };
            return model;
        }

    }
    public class DemoUserService
    {
        public int activeTabIndex = 0;

        public int ActiveTabIndex
        {
            get { return activeTabIndex; }
            set { activeTabIndex = value; }
        }
    }
}