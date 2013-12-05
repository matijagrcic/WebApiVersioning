using System;

namespace WebApiMediaTypeVersioning.Models.People
{
    public class PeopleVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return String.Format("{0}, {1}", LastName, FirstName);
            }
        }

        public string Url { get; set; }
    }
}
