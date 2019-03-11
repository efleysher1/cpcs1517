using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class ContestEntry
    {
        //datafields
        private string _Address2;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Agreement { get; set; }
        public string Answer { get; set; }

        public ContestEntry()
        {
            //default constructor
        }

        public ContestEntry(string firstname, string lastname, string address1, string address2, string city, string province,
            string postalcode, string email, string agreement, string answer)
        {
            //greedy constructor
            FirstName = firstname;
            LastName = lastname;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Province = province;
            PostalCode = postalcode;
            Email = email;
            Agreement = agreement;
            Answer = answer;
        }
    }
}