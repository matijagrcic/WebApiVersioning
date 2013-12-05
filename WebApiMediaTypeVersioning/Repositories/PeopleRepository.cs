using System.Collections.Generic;
using System.Linq;
using WebApiMediaTypeVersioning.Models.People;

namespace WebApiMediaTypeVersioning.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {

        List<PeopleVM> People = new List<PeopleVM> { 
                new PeopleVM{
                   Id = 123,
                    FirstName = "Alice",
                    LastName = "Doe"
                },
                new PeopleVM{
                    Id = 1234,
                    FirstName = "Bob",
                    LastName = "Doe"
                },
                new PeopleVM{
                    Id = 123456,
                    FirstName = "Cathy",
                    LastName = "Doe"
                }
         };

        List<PeopleVM2> PeopleVM2 = new List<PeopleVM2> { 
                new PeopleVM2{
                   Id = 123,
                    FirstName = "Alice",
                    LastName = "Doe",
                    Mobile = "555-123-456",
                    Telephone = "555-123-456",
                    Website = "alice.doe@email.com"
                },
                new PeopleVM2{
                    Id = 1234,
                    FirstName = "Bob",
                    LastName = "Doe",
                    Mobile = "555-123-456",
                    Telephone = "555-123-456",
                    Website = "bob.doe@email.com"
                },
                new PeopleVM2{
                    Id = 123456,
                    FirstName = "Cathy",
                    LastName = "Doe",
                    Mobile = "555-123-456",
                    Telephone = "555-123-456",
                    Website = "cathy.doe@email.com"
                }
         };

        public IEnumerable<PeopleVM> FindPeople()
        {
            return People;
        }

        public PeopleVM FindPeopleById(int id)
        {
            return FindPeople().SingleOrDefault(p => p.Id == id);
        }


        public IEnumerable<PeopleVM2> FindPeopleV2()
        {
            return PeopleVM2;
        }

        public PeopleVM2 FindPeopleV2ById(int id)
        {
            return FindPeopleV2().SingleOrDefault(p => p.Id == id);
        }
    }
}