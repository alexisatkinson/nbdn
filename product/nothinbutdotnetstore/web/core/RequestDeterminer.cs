using System.Text.RegularExpressions;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestDeterminer
    {
        bool Result<CommandType>();
    }

    public class DefaultRequestDeterminer : RequestDeterminer
    {
        Request request;

        public DefaultRequestDeterminer(Request request)
        {
            this.request = request;
        }

        public bool Result<CommandType>()
        {
            var match = Regex.Match(request.id, "^\\S*/(\\S+)\\.store$");

            if (!match.Success) return false;

            var page_id_suffix = match.Groups[1].Value;
            return page_id_suffix.Equals(typeof (CommandType).Name);
        }
    }
}