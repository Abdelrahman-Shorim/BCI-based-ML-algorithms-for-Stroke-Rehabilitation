namespace BCI_Project.Models
{
    public class RoleAttributes : BaseModel
    {
        public string RoleId { get; set; }
        public Guid AttributeId { get; set; }

        public Role Role { get; set; }
        public Attribute Attribute { get; set; }
        public ICollection<RoleAttributeValue> RoleAttributeValues { get; set; }

    }
}
