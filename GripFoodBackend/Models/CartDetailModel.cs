namespace GripFoodBackend.Models
{
    public class CartDetailModel
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
