using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Exceptions
{
    public class EntityDublicatedException : Exception
    {
        public EntityDublicatedException()
        {
                
        }

        public EntityDublicatedException(string message) : base(message)
        {

        }
    }
}
