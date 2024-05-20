using Repo.Entities;

namespace BusinessRepo.Models
{
    public class Layout : MethodBase
    {
        public long ID { get; set; }
        public string LayoutCode { get; set; }

        private string _layoutName;
        public string LayoutName { get { return GetResource(_layoutName); } set => _layoutName = value; }

        public string SortOrder { get; set; }
        public string Icon { get; set; }
    }
}
