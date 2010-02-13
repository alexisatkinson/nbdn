using System;

namespace nothinbutdotnetstore.web.core
{
    public interface View
    {
        string path { get; set; }
        Type model { get; set; }
    }
}