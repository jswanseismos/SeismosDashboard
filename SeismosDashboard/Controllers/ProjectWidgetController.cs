using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    public class ProjectWidgetController
    {
        private WidgetPanelControlViewModel widgetPanelControlVm;
        private WidgetViewModelBase clientWidget;
        private WidgetViewModelBase projectWidget;
        private WidgetViewModelBase wellsWidget;


        public ProjectWidgetController(WidgetPanelControlViewModel widgetPanelControlVm)
        {
            this.widgetPanelControlVm = widgetPanelControlVm;

            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.NavProjectSelected, HandleProjectChange);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.NavStageSelected, HandleStageChange);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.NavWellSelected, HandleWellChange);

            Initialize();
        }

        private void Initialize()
        {
            clientWidget = new ClientWidgetViewModel();
            projectWidget = new ProjectWidgetViewModel();
            wellsWidget = new WellsGeneralWidgetViewModel();

            widgetPanelControlVm.AddWidget(clientWidget);
            widgetPanelControlVm.AddWidget(projectWidget);
            widgetPanelControlVm.AddWidget(wellsWidget);

//            wellsWidget.ChangeSleepMode(true);
        }

        private void HandleProjectChange()
        {
            clientWidget.ChangeSleepMode(false);
            projectWidget.ChangeSleepMode(false);
            wellsWidget.ChangeSleepMode(false);

        }

        private void HandleWellChange()
        {
            clientWidget.ChangeSleepMode(true);
            projectWidget.ChangeSleepMode(true);
            wellsWidget.ChangeSleepMode(true);

        }

        private void HandleStageChange()
        {
            clientWidget.ChangeSleepMode(true);
            projectWidget.ChangeSleepMode(true);
            wellsWidget.ChangeSleepMode(true);


        }
    }
}
