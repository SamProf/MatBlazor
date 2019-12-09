using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatSelect<TValue> : MatSelectNativeType<TValue>
    {
    }

    public class MatSelectString : MatSelect<string>
    {
    }

    public class MatSelectItem<TValue> : MatSelectType<TValue>
    {
    }
}