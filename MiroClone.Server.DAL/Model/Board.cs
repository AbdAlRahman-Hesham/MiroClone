namespace MiroClone.Server.DAL.Model
{
    public class Board
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime DateTime { get; set; }   = DateTime.Now;

        public string? Data { get; set; }

    }
}
