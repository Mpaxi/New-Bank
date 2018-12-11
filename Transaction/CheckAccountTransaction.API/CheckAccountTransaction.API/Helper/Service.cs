using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenPipes.Util;

namespace CheckAccountTransaction.API.Helper
{
    public class Service :
        IService
    {
        public Task ServiceTheThing(string value)
        {
            return TaskUtil.Completed;
        }
    }
}
