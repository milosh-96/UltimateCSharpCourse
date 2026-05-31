using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.Extensions;
public static class PropertyInfoExtensions
{
    public static string GetDisplayNameValue(this PropertyInfo property)
    {
        DisplayNameAttribute? displayNameAttribute = property.GetCustomAttribute<DisplayNameAttribute>();
        if(displayNameAttribute is not null)
        {
            return displayNameAttribute.DisplayName;
        }
        return property.Name;
    }
}
