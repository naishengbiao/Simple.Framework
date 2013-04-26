using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Service;
namespace Simple.Bll
{
    public class Demo:BaseService
    {
        public void s()
        {
            this.BeginTransaction();
        }
    }
}
