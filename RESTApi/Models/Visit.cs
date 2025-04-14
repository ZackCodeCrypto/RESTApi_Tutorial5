namespace RESTApi.Models;

public class Visit
{
    public int AnimalId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}