using NetTopologySuite.Geometries;
namespace Mehr.Domain.Entities.Contacts;

public class Zone
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? PolygonStr { get; set; }
    public Geometry? Polygon { get; set; }
}