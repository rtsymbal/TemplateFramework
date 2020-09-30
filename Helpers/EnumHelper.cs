using System;

namespace TemplateFramework.Helpers
{
    public class EnumHelper
    {
        public static T FromDisplayString<T>(string displayValue)
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DisplayStringAttribute)) is DisplayStringAttribute attribute)
                {
                    if (attribute.DisplayString == displayValue)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == displayValue)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new NotImplementedException($"Enumeration not found.");
        }

        public static T GetRandomValue<T>(int minValue = 0)
        {
            var values = Enum.GetValues(typeof(T));
            var randomValue = (T)values.GetValue(new Random().Next(minValue, values.Length));

            return randomValue;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayStringAttribute : Attribute
    {
        public DisplayStringAttribute(string displayString)
        {
            DisplayString = displayString;
        }

        public string DisplayString { get; }
    }
}
