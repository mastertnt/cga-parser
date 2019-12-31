using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGACompute
{
    /// <summary>
    /// Interface for all algorithms
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface Algorithm<TSource, TResult> where TSource : class, new() where TResult : class, new()
    {
        TResult Compute(TSource pSource);
    }
}
