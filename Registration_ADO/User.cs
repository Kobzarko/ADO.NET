using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_ADO
{
    public class User
    {

        //"Insert into Users(Login,  RealName,  PassHash,  Email,   Phone, RegisterDT, ID_Gender) " +
             
        public int Id { get; set; }
        public string Login { get; set; }
        public string RealName { get; set; }
        public string PassHash { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDT { get; set; }
        public int ID_Gender { get; set; }

     



    }
}
