using System.Collections.Generic;

namespace Student_Follower.Entities
{
    public class ValidationErrorResponse
    {
        public List<ValidationError> Errors { get; set; } = null;
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public object Instance { get; set; }

    }
}
