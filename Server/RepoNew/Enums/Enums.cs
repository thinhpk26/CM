using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Enums
{
    public enum CMEnvironment
    {
        Development = 1,
        Production = 2
    }
    public enum Operator
    {
        Null = 1,
        NotNull = 2,
        Like = 3,
        NotLike = 4,
        As = 5,
        NotAs = 6
    }
    /// <summary>
    /// Operator giữa các condition với nhau
    /// </summary>
    public enum NestOperator
    {
        AND = 1,
        OR = 2
    }
    public enum OrderPaging
    {
        Ascending = 1,
        Descending = 2,
    }
    public enum TypeControl
    {
        Text = 1,
        Number = 2,
        Boolean = 3,
        DateTime = 4,
        Radio = 5,
        Combobox = 6
    }

    public enum Method
    {
        GET = 1,
        POST = 2
    }
}
