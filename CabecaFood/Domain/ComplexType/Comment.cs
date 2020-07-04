namespace Domain.ComplexType
{
    public class Comment
    {
        public string Commentary { get; protected set; }
        public int UserId { get; protected set; }
        public bool IsGood { get; protected set; }
        public virtual User User { get; set; }

        public Comment(string commentary, int userId, bool isGood)
        {
            Commentary = commentary?.FormatProps();
            UserId = userId;
            IsGood = isGood;
        }

        public void Update(string commentary, bool isGood)
        {
            Commentary = commentary?.FormatProps();
            IsGood = isGood;
        }
    }
}
