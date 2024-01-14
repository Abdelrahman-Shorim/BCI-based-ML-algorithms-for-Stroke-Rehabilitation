namespace BCI_Project.Models
{
    public class RoleAttributes : BaseModel
    {
        public string RoleId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

        public Role Role { get; set; }
    }
}
