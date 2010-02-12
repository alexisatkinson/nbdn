using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestDeterminer
    {
        bool Result<CommandType>();
    }

    public class DefaultRequestDeterminer : RequestDeterminer
    {
        Request request;
       // IDictionary<string, Type> mappings;

        public DefaultRequestDeterminer(Request request)
        {
            this.request = request; 

        }

        public bool Result<CommandType>()
        {
            var match = System.Text.RegularExpressions.Regex.Match(request.id, "^\\S*/(\\S+)\\.store$");
            
            if(!match.Success) return false;

            String page_id_suffix = match.Groups[1].Value;
            return page_id_suffix.Equals(typeof (CommandType).Name);
  
        }
    }
}