using Microsoft.EntityFrameworkCore;

namespace SharedClassLibrary.Data
{
    public class DataContext : DbContext
    {
        //private readonly string _connection;

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //public DataContext(string connection) : base()
        //{
        //    _connection = connection;
        //}
       // public List<Action<ModelBuilder>> RegisterModels { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) {
        //        optionsBuilder.UseSqlServer(_connection);
        //    }
        //}
        //private bool _isModelCreated;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (!_isModelCreated) {
            //    foreach (var registermodel in RegisterModels)
            //        registermodel.Invoke(modelBuilder);
            //    _isModelCreated = true;
            //}
            if (!DomainRegister.Instance.IsModelCreated) {
                foreach (var registermodel in DomainRegister.Instance.RegisterModels)
                    registermodel.Invoke(modelBuilder);
                DomainRegister.Instance.IsModelCreated = true;
            }
        }
    }
}
