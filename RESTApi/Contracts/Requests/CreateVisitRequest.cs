namespace RESTApi.Contacts.Requests;

public class CreateVisitRequest
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}