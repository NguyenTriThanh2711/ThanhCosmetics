using ThanhCometics.Repository.Models.OrderDetailModel;
using ThanhCometics.Repository.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository.Models.OrderModel
{
    public class OrderCreateRequest
    {
        [Required]
        public int PaymentMethodId { get; set; }
        [Required]
        public bool InRegion { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }     
        public List<OrderDetailCreateRequest> OrderDetailRequests { get; set; }
        
    }
}
