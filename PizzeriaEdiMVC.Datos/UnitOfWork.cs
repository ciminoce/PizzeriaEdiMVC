namespace PizzeriaEdiMVC.Datos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly PizzeriaDbContext _context;

        public UnitOfWork(PizzeriaDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
