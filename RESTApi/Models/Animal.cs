namespace RESTApi.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // e.g., dog, cat
    public double Weight { get; set; }
    public string FurColor { get; set; }
}