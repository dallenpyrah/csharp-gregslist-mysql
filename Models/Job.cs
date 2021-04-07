namespace gregslist_sql.Models
{
    public class Job
    {
        public string Company { get; set; }
        
        public string Title { get; set; }

        public int Salary { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
    }
}