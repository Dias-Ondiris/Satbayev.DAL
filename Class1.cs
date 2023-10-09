using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Satbayev.DAL
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Middle_name { get; set; }
        public string Short_name
        {
            get
            {
                if (string.IsNullOrEmpty(Middle_name))
                {
                    return string.Format("[0] [1]", First_name, Last_name[0]);
                }
                return string.Format("[0] [1] [2]", First_name, Middle_name[0], Last_name[0]);
            }
        }
        
        public DateTime DateB { get; set; }
        public int GetAge
        {
            get
            {
                return DateTime.Now.Year - DateB.Year;
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address Address{ get; set; }

    }

    
}
