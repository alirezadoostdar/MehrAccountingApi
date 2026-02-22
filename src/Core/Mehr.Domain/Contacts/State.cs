namespace Mehr.Domain.Contacts;

public class State
{
    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<City> Cities { get; set; }
}