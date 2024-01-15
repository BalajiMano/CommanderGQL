using CommanderGQL.Data;

namespace   CommanderGQL.Models
{
    public class CommandsService : ICommands

    {
        private readonly PlatformDBContext _platformDBContext;

       public CommandsService(PlatformDBContext platformDBContext)
        {
            _platformDBContext=platformDBContext;
        }
   public IEnumerable<Platform>  GetCommands()
   {
      return _platformDBContext.platforms;
   }

   public string AddCommands(IEnumerable<Platform> _Commands)
   {
 if (_Commands == null)
            {
                throw new ArgumentNullException(nameof(_Commands));
            }
            foreach(var com in _Commands)
            {
    _platformDBContext.platforms.Add(com);
            }
    return "Success";
   }
    public bool SaveChanges()
        {
            return (_platformDBContext.SaveChanges() >= 0);
        }

    }
}