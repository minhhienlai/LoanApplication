using System.ComponentModel.DataAnnotations.Schema;

namespace SharedClassLibrary.Models
{
    public abstract class BaseModel
    {
       // [NotMapped]
        //public abstract string TableName { get; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }

}
