namespace Mehr.Domain.Entities.Contacts;

public class City
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int StateId { get; set; }
    public State State { get; set; }
}