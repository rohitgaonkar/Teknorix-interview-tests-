public class DepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // get all departments
    public IEnumerable<Department> GetAll()
    {
        return _context.Departments.ToList();
    }

    // get single department
    public Department GetById(int id)
    {
        return _context.Departments.Find(id);
    }

    // add new department
    public void Add(Department dept)
    {
        _context.Departments.Add(dept);
        _context.SaveChanges();
    }

    // update department
    public void Update(Department dept)
    {
        _context.Entry(dept).State = EntityState.Modified;
        _context.SaveChanges();
    }
}
