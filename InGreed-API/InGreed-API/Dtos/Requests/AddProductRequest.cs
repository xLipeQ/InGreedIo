
public class ProductAddRequest
{
    public int ProducentID { get; set; }

    public string Description { get; set; }

    public string ProductName { get; set; }

    public IFormFile Image { get; set; }

    public int Category { get; set; }

    public List<int> Ingredients { get; set; }
}
