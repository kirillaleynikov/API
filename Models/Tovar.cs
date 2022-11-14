using warehouse;

namespace WebApplication1.Models
{
    public class Tovar
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public decimal Razmer { get; set; }
        /// <summary>
        /// Материал
        /// </summary>
        public material Material { get; set; }
        /// <summary>
        /// Кол-во на складе
        /// </summary>
        public decimal kolvo { get; set; }
        /// <summary>
        /// Минимальный предел кол-ва
        /// </summary>
        public decimal minpr { get; set; }
        /// <summary>
        /// Цена (без НДС)
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// общая сумма товаров на складе
        /// </summary>
        public decimal summa { get; set; }
    }
}
