using System.ComponentModel.DataAnnotations.Schema;

namespace SharedClassLibrary.Models
{
    public abstract class BaseModel
    {
       // [NotMapped]
        //public abstract string TableName { get; }
        public DateTime? CreatedAt { get; }
        public string CreatedBy { get; }
        public DateTime? ModifiedAt { get; }
        public string ModifiedBy { get; }
    }

}
