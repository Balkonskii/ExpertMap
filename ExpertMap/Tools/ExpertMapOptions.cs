using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ExpertMap.Tools
{
    public class ExpertMapOptions
    {
        private static ExpertMapOptions _currentOptions;

        public bool DeleteMarkerByRegion { get; private set; }
        public float DrawableItemOpacity { get; private set; }
        public float SelectedDrawableItemOpacity { get; private set; }

        private ExpertMapOptions()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                if (property.Name == "CurrentOptions") continue;
                var value = ConfigurationManager.AppSettings[property.Name];
                value = value.Replace('.', ',');
                var castedValue = Convert.ChangeType(value, property.PropertyType);
                property.SetValue(this, castedValue, null);
            }
        }

        public static ExpertMapOptions CurrentOptions
        {
            get
            {
                if (_currentOptions == null)
                {
                    _currentOptions = new ExpertMapOptions();
                }
                return _currentOptions;
            }
        }
    }
}
