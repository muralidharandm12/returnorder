using ReturnOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnOrder.Repositories
{
    public interface IAuthRepo
    {
        public string GetToken(User user);
    }
}
