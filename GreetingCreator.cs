using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionDISample
{
    public class GreetingCreator : IGreetingCreator
    {
        public async Task<string> CreateGreeting(int hourOfDay)
        {
            return await Task.FromResult(GetGreeting(hourOfDay));
        }

        private string GetGreeting(int hourOfDay)
        {
            if(hourOfDay >= 5 && hourOfDay < 12)
            {
                return "Good morning";
            }
            else if(hourOfDay >= 12 && hourOfDay < 17)
            {
                return "Good afternoon";
            }
            else if(hourOfDay > 17 && hourOfDay < 22)
            {
                return "Good evening";
            }
            else
            {
                return "Hello";
            }
        }
    }
}
