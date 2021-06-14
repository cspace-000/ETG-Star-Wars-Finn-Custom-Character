using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
 
    public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2,
                                                  T3 arg3, T4 arg4, T5 arg5);

    public delegate ReturnT Action<ReturnT, T1, T2, T3, T4, T5>(T1 arg1,
                                               T2 arg2, T3 arg3, T4 arg4, T5 arg5);


    public delegate void Action6<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2,
                                          T3 arg3, T4 arg4, T5 arg5, T6 arg6);

    public delegate ReturnT Action6<ReturnT, T1, T2, T3, T4, T5, T6>(T1 arg1,
                                           T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
}
