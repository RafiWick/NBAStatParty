namespace NBAStatParty.Models.DbModels
{
    public class Favorite
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FavoriteId { get; set; }
        public int Rating { get; set; }
        
        public Favorite()
        {

        }
        
        public Favorite(string type, string id)
        {
            Type = type;
            FavoriteId = id;
            Rating = 0;
        }
    }
}
