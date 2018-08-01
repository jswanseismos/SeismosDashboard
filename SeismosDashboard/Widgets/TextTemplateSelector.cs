using System;
using System.Windows;
using System.Windows.Controls;
using SeismosServices;

namespace SeismosDashboard
{
    // this class is used in xaml to switch between and textbox or datepicker
    // the xaml defines the templates to use, this just provides the logic of detecting the type
    public class TextTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextDataTemplate
        { get; set; }

        public DataTemplate DateDataTemplate
        { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is KeyValueMutable<string, object> keyValue)
            {
                if (keyValue.Text == null)
                    return TextDataTemplate;
                switch (keyValue.Text)
                {
                    case string _:
                        return TextDataTemplate;
                    case DateTime _:
                        return DateDataTemplate;
                }

            }

            return base.SelectTemplate(item, container);
        }

    }
}