using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Helper
{
    interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
