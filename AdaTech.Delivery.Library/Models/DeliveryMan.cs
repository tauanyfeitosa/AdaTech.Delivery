using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Delivery.Library.Models
{
    public class DeliveryMan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CPF { get; set; }
        public DateTime DateBirth { get; set; }
        public bool IsSuperUser { get; set; } = false;
        public bool IsDeliveryMan { get; set; } = true;
        public bool IsStaff { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
