using Institution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institution.Interffaces
{
    public interface StudentRepository
    {
        void InsertOrUpdate(Student student);
        void save();
    }
}
