using Diet.Domain.Common;

namespace Diet.Domain.Entity
{
    public class MenuAction:BaseEntity
    {
        public string ActionName { get; set; }
        public string MenuName { get; set; }
    }
}
