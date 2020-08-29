using TemplateFramework.Helpers;

namespace TemplateFramework.Models
{
    public enum Categories
    {
        [DisplayString("Vegetables & Fruits")] VegetablesAndFruits = 1,
        [DisplayString("Fresh food")] FreshFood = 2,
        [DisplayString("Frozen food")] FrozenFood = 3,
        [DisplayString("Groceries")] Groceries = 4,
        [DisplayString("Sweets & snacks")] SweetsAndSnacks = 5,
        [DisplayString("Beauty & hygiene")] BeautyAndHygiene = 6,
        [DisplayString("Home & office")] HomeAndOffice = 7
    }
}