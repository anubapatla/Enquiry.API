using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Enquiry.API.Models
{
    public class EnquiryModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int enquiryId { get; set; }
        public int enquiryTypeId { get; set; } 
        public int enquiryStatusId { get; set; } 
        public string customerName { get; set; } = string.Empty;
        public string mobielNo { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public DateTime createdDate { get; set; }
        public string resolution { get; set; } = string.Empty;


    }
}
