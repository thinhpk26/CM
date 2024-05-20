using Repo.Enums;

namespace BusinessRepo.Models
{
    public class GridCell
    {
        public string Index { get; set; }
        public string? IndexText { get; set; }
        public string LayoutCode { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string? DataUrl { get; set; }
        public string? Placeholder { get; set; }
        public TypeControl TypeControl { get; set; }
        public string? ValueID { get; set; }
        public string? ValueIDText { get; set; }
        public string? FieldID { get; set; }
        public string? FieldText { get; set; }
        public Method Method { get; set; }
        public string? BodyRequest { get; set; }
        public bool IsCustomHost { get; set; }
        public bool Sticky { get; set; }
        public int Width { get; set; }
        public bool IsDisplay { get; set; }
    }
}
