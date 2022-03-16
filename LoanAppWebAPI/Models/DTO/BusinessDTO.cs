using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAppWebAPI.Models.DTO
{
    public class BusinessDTO
    {
        [Key]
        public int Id { get; set; }
        public string BusinessCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public DemographicModel? Owner { get; set; }
        public List<LoanAppModel>? LoanApps { get; set; }
    }
}
