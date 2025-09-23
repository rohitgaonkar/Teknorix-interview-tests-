[RoutePrefix("api/v1/departments")]
public class DepartmentsController : ApiController
{
    private readonly DepartmentRepository _repo = new DepartmentRepository(new ApplicationDbContext());

    // POST /api/v1/departments
    [HttpPost, Route("")]
    public IHttpActionResult CreateDepartment(Department dept)
    {
        _repo.Add(dept);
        return Ok(dept);
    }

    // PUT /api/v1/departments/{id}
    [HttpPut, Route("{id}")]
    public IHttpActionResult UpdateDepartment(int id, Department dept)
    {
        var existing = _repo.GetById(id);
        if (existing == null) return NotFound();

        existing.Title = dept.Title;
        _repo.Update(existing);

        return Ok();
    }

    // GET /api/v1/departments
    [HttpGet, Route("")]
    public IHttpActionResult GetAllDepartments()
    {
        var list = _repo.GetAll();
        return Ok(list);
    }
}
