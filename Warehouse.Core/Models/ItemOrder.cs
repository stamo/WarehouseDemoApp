namespace Warehouse.Core.Models
{
    /// <summary>
    /// Поръчан продукт
    /// </summary>
    public class ItemOrder
    {
        /// <summary>
        /// Баркод на продукта
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Брой поръчани продукти
        /// </summary>
        public int Count { get; set; }
    }
}
