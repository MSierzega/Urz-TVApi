namespace TvApiLabUr.DAL
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public short Rate { get; set; }
        public virtual Movie Movie { get; set; }
    }
}