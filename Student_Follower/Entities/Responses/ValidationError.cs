using System.Collections.Generic;

namespace Student_Follower.Entities
{
    public class ValidationError
    {
        public string Property { get; set; }
        public List<string> Errors { get; set; }
    }
}
