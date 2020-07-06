using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionDISample
{
    public interface IGreetingCreator
    {
        Task<string> CreateGreeting(int hourOfDay); 
    }
}
