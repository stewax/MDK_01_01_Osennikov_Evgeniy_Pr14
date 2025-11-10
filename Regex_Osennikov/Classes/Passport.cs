using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regex_Osennikov.Classes
{
    public class Passport
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Issued {  get; set; }
        public string DateOfIssued {  get; set; }
        public string DepartamentCode { get; set; }
        public string SeriesAndNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth {  get; set; }
    }
}
