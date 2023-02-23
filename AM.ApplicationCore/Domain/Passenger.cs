using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        [Key]//annotation
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        //prop de navigation
        public virtual IList<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "BirthDate = "+ BirthDate+ " , PassportNumber = "+ PassportNumber+
                " , EmailAddress = "+ EmailAddress+ ", FirstName = "+ FirstName+
                " ,  LastName = "+ LastName+ " , TelNumber = "+ TelNumber;
        }
        public bool CheckProfile(string firstName,string lastName)
        {
            /*if (this.FirstName == firstName && this.LastName == lastName)
                return true;
            return false;*/

            return this.FirstName == firstName && this.LastName == lastName;
        }
        public bool CheckProfile(string firstName, string lastName,string email)
        {
            /*if (this.FirstName == firstName && this.LastName == lastName && this.EmailAddress==email )
                return true;
            return false;*/

            return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress==email;
        }

        public bool CheckProfile2(string firstName, string lastName, string? email=null)//? : nullable
        {
            if(email==null)
                return CheckProfile(firstName,lastName);
            return CheckProfile(firstName,lastName,email);
        }

        public virtual string PassengerType()
        {
            return "I am a passenger ";
        }
    }
}
