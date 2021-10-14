using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aoutontification.Data.Model
{
    public class Account
    {      
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")] 
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string PhoneNumb { get; set; }

        
    }
}
