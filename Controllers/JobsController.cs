[RoutePrefix("api/v1/jobs")]
public class JobsController : ApiController
{
    private readonly JobRepository _repo = new JobRepository(new ApplicationDbContext());

    [HttpPost, Route("")]
    public IHttpActionResult CreateJob(Job job)
    {
        _repo.Add(job);
        return Created($"http://localhost/api/v1/jobs/{job.JobId}", job);
    }

    [HttpPut, Route("{id}")]
    public IHttpActionResult UpdateJob(int id, Job job)
    {
        var existing = _repo.GetById(id);
        if (existing == null) return NotFound();

        existing.Title = job.Title;
        existing.Description = job.Description;
        existing.LocationId = job.LocationId;
        existing.DepartmentId = job.DepartmentId;
        existing.ClosingDate = job.ClosingDate;

        _repo.Update(existing);
        return Ok();
    }

    [HttpPost, Route("~/api/jobs/list")]
    public IHttpActionResult ListJobs(JobSearchRequest request)
    {
        var jobs = _repo.GetAll();

        if (!string.IsNullOrEmpty(request.q))
            jobs = jobs.Where(j => j.Title.Contains(request.q));

        if (request.LocationId > 0)
            jobs = jobs.Where(j => j.LocationId == request.LocationId);

        if (request.DepartmentId > 0)
            jobs = jobs.Where(j => j.DepartmentId == request.DepartmentId);

        var total = jobs.Count();
        var data = jobs.Skip((request.PageNo - 1) * request.PageSize)
                       .Take(request.PageSize)
                       .ToList();

        return Ok(new { total = total, data = data });
    }

    [HttpGet, Route("{id}")]
    public IHttpActionResult GetJobDetails(int id)
    {
        var job = _repo.GetById(id);
        if (job == null) return NotFound();
        return Ok(job);
    }
}

public class JobSearchRequest
{
    public string q { get; set; }
    public int PageNo { get; set; }
    public int PageSize { get; set; }
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
}
