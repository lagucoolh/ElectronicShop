using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Stock.Models
{
    interface IModelStock
    {
        List<dynamic> GetAll();
        dynamic Get(string id);
        string Add(string id);
        string Remove(string id);
        bool Update(string id);
    }
}
