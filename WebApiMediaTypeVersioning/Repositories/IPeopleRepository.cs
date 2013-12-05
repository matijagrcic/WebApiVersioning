using System.Collections.Generic;
using WebApiMediaTypeVersioning.Models.People;

namespace WebApiMediaTypeVersioning.Repositories
{
    public interface IPeopleRepository
    {
        IEnumerable<PeopleVM> FindPeople();
        PeopleVM FindPeopleById(int id);

        IEnumerable<PeopleVM2> FindPeopleV2();
        PeopleVM2 FindPeopleV2ById(int id);
    }
}