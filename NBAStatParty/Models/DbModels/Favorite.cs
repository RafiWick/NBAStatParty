namespace NBAStatParty.Models.DbModels
{
    public class Favorite
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string FavoriteId { get; set; }
        public int rating { get; set; }
        
        public Favorite(string type, string id)
        {
            Type = type;
            FavoriteId = id;
            rating = 0;
        }
    }
}
