using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    public class MainWindowViewModel
    {
        private ProjectWidgetController projectWidgetController;
        private WellWidgetController wellWidgetController;

        public MainWindowViewModel()
        {
            widgetPanelControlViewModel = new WidgetPanelControlViewModel();

            projectWidgetController = new ProjectWidgetController(widgetPanelControlViewModel);
            wellWidgetController = new WellWidgetController(widgetPanelControlViewModel);
        }

        private WidgetPanelControlViewModel widgetPanelControlViewModel;
        public WidgetPanelControlViewModel PanelViewModel
        {
            get { return widgetPanelControlViewModel; }
            set { widgetPanelControlViewModel = value; }
        }
    }
}
