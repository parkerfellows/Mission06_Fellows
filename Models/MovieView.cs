namespace Mission06_Fellows.Models
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string CategoryName { get; set; }
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public bool CopiedToPlex { get; set; }
        public string? LentTo { get; set; }
        public string? Notes { get; set; }
    }
}
