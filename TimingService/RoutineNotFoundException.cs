using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingService
{
	public class RoutineNotFoundException : Exception
	{
        public RoutineNotFoundException()
        {
             
        }

        public RoutineNotFoundException(string message) : base(message) 
        {
            
        }
    }
}
