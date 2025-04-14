namespace RESTApi.Contacts.Requests;

public class CreateAnimalRequest
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
}