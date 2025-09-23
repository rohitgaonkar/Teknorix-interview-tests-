public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Job> GetAll()
    {
        return _context.Jobs.Include("Department").Include("Location").ToList();
    }

    public Job GetById(int id)
    {
        return _context.Jobs.Include("Department").Include("Location")
            .FirstOrDefault(j => j.JobId == id);
    }

    public void Add(Job job)
    {
        job.PostedDate = DateTime.Now;
        job.Code = "JOB-" + (_context.Jobs.Count() + 1).ToString("D2");
        _context.Jobs.Add(job);
        _context.SaveChanges();
    }

    public void Update(Job job)
    {
        _context.Entry(job).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
