using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    interface IWidgetIdentity
    {
        Guid WidgetId { get; set; }
    }
}
