using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multimedia
{
    interface IDBrepository<T>
    {
        public List<T> Fetch();
        public List<T> FetchStaticList();
    }
}
