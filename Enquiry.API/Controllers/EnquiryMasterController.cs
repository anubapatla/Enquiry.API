using Enquiry.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enquiry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryMasterController : ControllerBase
    {
        private readonly EnquiryDbContext _context;

        public EnquiryMasterController(EnquiryDbContext context)
        {
            _context = context; 
        }
        [HttpGet("GetAllStatus")]
        public List<EnquiryStatus> GetEnquiryStatus()
        {
            var list = _context.EnquiryStatuses.ToList();
            return list;
        }
        [HttpGet("GetAllTypes")]
        public List<EnquiryType> GetAllTypes()
        {
            var list = _context.EnquiryTypes.ToList();
            return list;
        }
        [HttpGet("GetAllEnquiry")]
        public List<EnquiryModel> GetAllEnquiry()
        {
            var list = _context.EnquiryModels.ToList();
            return list;
        }
        [HttpPost("CreateNewEnquiry")]
        public EnquiryModel AddNewEnquiry(EnquiryModel obj)
        {
            obj.createdDate = DateTime.Now;
            _context.EnquiryModels.Add(obj);
            _context.SaveChanges();
            return obj;
        }
        [HttpPost("UpdateEnquiry")]
        public EnquiryModel UpdateEnquiry(EnquiryModel obj)
        {
            var record = _context.EnquiryModels.SingleOrDefault(m => m.enquiryId == obj.enquiryId);
            if (record != null)
            {
                record.resolution = obj.resolution;
                record.enquiryStatusId = obj.enquiryStatusId;
                _context.SaveChanges();
            }

            return obj;
        }
        [HttpDelete("DeleteEnquiryById")]
        public bool DeleteEnquiryById( int id)
        {
            var record = _context.EnquiryModels.SingleOrDefault(m => m.enquiryId == id);
            if (record != null)
            {
                _context.EnquiryModels.Remove(record);
                _context.SaveChanges();
                return true;
            }else
            {
                return false;
            }
        }
    }
}
