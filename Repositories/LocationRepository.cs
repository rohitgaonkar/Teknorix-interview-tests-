public class LocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // get all locations
    public IEnumerable<Location> GetAll()
    {
        return _context.Locations.ToList();
    }

    // get single location
    public Location GetById(int id)
    {
        return _context.Locations.Find(id);
    }

    // add new location
    public void Add(Location loc)
    {
        _context.Locations.Add(loc);
        _context.SaveChanges();
    }

    // update location
    public void Update(Location loc)
    {
        _context.Entry(loc).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
