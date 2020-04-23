using Institution.Interffaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsUnitTests.Stubs
{
   public class StubStudent : StudentRepository
    {
        void StudentRepository.InsertOrUpdate(Institution.Models.Student student)
        {
                 }

        void StudentRepository.save()
        {
                   }
    }
}
