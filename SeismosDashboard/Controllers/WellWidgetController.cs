using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    public class WellWidgetController
    {
        private WidgetPanelControlViewModel widgetPanelControlVm;
        private WellVolumesWidgetViewModel wellVolumesWidgetViewModel;

        public WellWidgetController(WidgetPanelControlViewModel widgetPanelControlVm)
        {
            this.widgetPanelControlVm = widgetPanelControlVm;

            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.NavProjectSelected, HandleProjectChange);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.NavStageSelected, HandleStageChange);
            DashboardStorage.Instance.RegisterAction(DashboardEventsEnum.NavWellSelected, HandleWellChange);

            Initialize();
        }

        private void HandleWellChange()
        {
            wellVolumesWidgetViewModel.ChangeSleepMode(false);
        }

        private void HandleStageChange()
        {
            wellVolumesWidgetViewModel.ChangeSleepMode(true);
        }

        private void HandleProjectChange()
        {
            wellVolumesWidgetViewModel.ChangeSleepMode(true);
        }

        private void Initialize()
        {
            wellVolumesWidgetViewModel = new WellVolumesWidgetViewModel();
            
            widgetPanelControlVm.AddWidget(wellVolumesWidgetViewModel);

            wellVolumesWidgetViewModel.ChangeSleepMode(true);

        }
    }
}
