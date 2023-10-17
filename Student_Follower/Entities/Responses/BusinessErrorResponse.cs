namespace Student_Follower.Entities
{
    public class BusinessErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public object Instance { get; set; }
    }
}
