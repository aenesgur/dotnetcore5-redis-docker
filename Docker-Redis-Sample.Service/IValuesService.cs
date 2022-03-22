using Docker_Redis_Sample.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker_Redis_Sample.Service
{
    public  interface IValuesService
    {
        ValuesModel getValuesById(int valuesId);
    }
}
