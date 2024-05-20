using Repo.Enums;

namespace BusinessRepo.Models
{
    public class GroupBox
    {
        public int GroupBoxKey { get; set; }

        public string LayoutCode { get; set; }

        public string Title { get; set; }
        public int SortOrder { get; set; }
        public List<GroupBoxItem> Items { get; set; }
    }

    public class GroupBoxItem
    {
        public int GroupBoxKey { get; set; }
        public string Index { get; set; }
        public string IndexText { get; set; }
        public string LayoutCode { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
        public string DataUrl { get; set; }
        public string Placeholder { get; set; }
        public TypeControl TypeControl { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
        public string ValueID { get; set; }
        public string ValueIDText { get; set; }
        public string FieldID { get; set; }
        public string FieldText { get; set; }
        public Method Method { get; set; }
        public string BodyRequest { get; set; }
        public bool IsCustomHost { get; set; }
        public int ColumnGrid { get; set; }
        public GroupBox GroupBox { get; set; }

    }
}
