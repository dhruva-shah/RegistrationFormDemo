using Language;
using System;
using System.ComponentModel.DataAnnotations;

namespace RegistrationFormDemo.Utilities
{
    public class RequiredIfAttribute : RequiredAttribute
    {
        private String PropertyName { get; set; }
        private Object DesiredValue { get; set; }

        public RequiredIfAttribute(String propertyName, Object desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
        }
        public RequiredIfAttribute(String propertyName, string desiredvalue, int val)
        {
            PropertyName = propertyName;
            DesiredValue = Locale.ResourceManager.GetString(desiredvalue);
        }


        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue.ToString() == DesiredValue.ToString())
            {
                ValidationResult result = base.IsValid(value, context);
                return result;
            }
            return ValidationResult.Success;
        }
    }
}
