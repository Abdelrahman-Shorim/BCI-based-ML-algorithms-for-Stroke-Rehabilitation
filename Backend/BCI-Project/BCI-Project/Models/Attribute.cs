namespace BCI_Project.Models
{
    public class Attribute : BaseModel
    {
        public string AttributeName { get; set; }
        public string AttributeType { get; set; }

        public ICollection<RoleAttributes> RoleAttributesAttribute { get; set; }

    }
}
