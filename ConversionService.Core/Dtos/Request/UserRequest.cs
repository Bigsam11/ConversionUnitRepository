using ConversionService.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Dtos.Request
{
    public class UserRequest
    {
        public string Username { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Password { get; set; }
       
    }
}
