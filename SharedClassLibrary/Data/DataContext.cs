using Microsoft.EntityFrameworkCore;

namespace SharedClassLibrary.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (!DomainRegister.Instance.IsModelCreated) {
                foreach (var registermodel in DomainRegister.Instance.RegisterModels)
                    registermodel.Invoke(modelBuilder);
                DomainRegister.Instance.IsModelCreated = true;
            }
        }
    }
}
