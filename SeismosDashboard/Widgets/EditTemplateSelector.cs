using System;
using System.Windows;
using System.Windows.Controls;
using SeismosServices;

namespace SeismosDashboard
{
    // this class is used in xaml to switch between and textbox or datepicker
    // the xaml defines the templates to use, this just provides the logic of detecting the type
    public class EditTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextEditDataTemplate
        { get; set; }

        public DataTemplate DateEditDataTemplate
        { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is KeyValueMutable<string, object> keyValue)
            {
                switch (keyValue.Text)
                {
                    case string _:
                        return TextEditDataTemplate;
                    case DateTime _:
                        return DateEditDataTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}