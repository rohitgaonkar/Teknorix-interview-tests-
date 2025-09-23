[RoutePrefix("api/v1/locations")]
public class LocationsController : ApiController
{
    private readonly LocationRepository _repo = new LocationRepository(new ApplicationDbContext());

    // POST /api/v1/locations
    [HttpPost, Route("")]
    public IHttpActionResult CreateLocation(Location loc)
    {
        _repo.Add(loc);
        return Ok(loc);
    }

    // PUT /api/v1/locations/{id}
    [HttpPut, Route("{id}")]
    public IHttpActionResult UpdateLocation(int id, Location loc)
    {
        var existing = _repo.GetById(id);
        if (existing == null) return NotFound();

        existing.Title = loc.Title;
        existing.City = loc.City;
        existing.State = loc.State;
        existing.Country = loc.Country;
        existing.Zip = loc.Zip;

        _repo.Update(existing);

        return Ok();
    }

    // GET /api/v1/locations
    [HttpGet, Route("")]
    public IHttpActionResult GetAllLocations()
    {
        var list = _repo.GetAll();
        return Ok(list);
    }
}
