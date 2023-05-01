using System.Collections.Generic;

namespace BioBooker.Dml;

public class Poster
{
    public int Id { get; set; }
    public byte[] Version { get; set; }
    public string posterNumber { get; set; }
    public ICollection<int> MovieIds { get; set; }
    public ICollection<Poster> Posters { get; set; }
}
