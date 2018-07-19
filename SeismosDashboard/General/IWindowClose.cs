using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeismosDashboard
{
    interface IWindowClose
    {
        // this property allows the implementer a chance to execute its own code before the window is closed 
        Action CloseWindow { get; }
    }
}
