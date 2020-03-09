using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class MyComp : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.FirstName} {x.LastName} {x.Index}",
            $"{y.FirstName} {y.LastName} {y.Index}");
        }

        public int GetHashCode(Student obj)
        {
           return StringComparer.CurrentCultureIgnoreCase.GetHashCode($"{obj.FirstName} {obj.LastName} {obj.Index}");
        }
    }
}
