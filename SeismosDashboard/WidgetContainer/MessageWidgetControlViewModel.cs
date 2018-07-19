using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeismosDashboard.Annotations;

namespace SeismosDashboard
{
    public class MessageWidgetControlViewModel : WidgetViewModelBase
    {

        public MessageWidgetControlViewModel()
        {
            TestWidgetMessage = "This is my mini message";
        }

        private string testWidgetMessage;
        public string TestWidgetMessage
        {
            get { return testWidgetMessage; }
            set
            {
                testWidgetMessage = value;
                OnPropertyChanged(nameof(TestWidgetMessage));
            }
        }

        

    }
}
