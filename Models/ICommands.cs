namespace CommanderGQL.Models
{
    public interface ICommands
    {
        public IEnumerable<Platform> GetCommands();
        public String AddCommands(IEnumerable<Platform> platforms);

        public bool SaveChanges();
    }
}