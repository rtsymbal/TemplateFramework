using TemplateFramework.Helpers;

namespace TemplateFramework.Base.Enums
{
    public enum Alerts
    {
        [DisplayString("Product successfully created.")] ProductCreated,
        [DisplayString("Product successfully updated.")] ProductUpdated
    }
}