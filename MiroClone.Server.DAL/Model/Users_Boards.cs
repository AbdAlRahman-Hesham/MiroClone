using System.ComponentModel.DataAnnotations.Schema;


namespace MiroClone.Server.DAL.Model
{
    public class Users_Boards
    {
        public int Id {  get; set; }
        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }

        public Board Board { get; set; }
        public AppUser AppUser { get; set; }
    }
}
