using Repo.Enums;

namespace BusinessApplication.DTO
{
    public class LayoutColumnGetDTO
    {
        public long ID { get; set; }
        public long LayoutID { get; set; }
        public string LayoutCode { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public TypeControl Type { get; set; }
        public int Width { get; set; }
        public bool Sticky { get; set; }
        public bool IsDisplay { get; set; }
        public int Order { get; set; }
    }
}
