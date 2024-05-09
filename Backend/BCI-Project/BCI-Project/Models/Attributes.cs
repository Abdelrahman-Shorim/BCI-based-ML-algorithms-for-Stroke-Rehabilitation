namespace BCI_Project.Models
{
    public class Attributes : BaseModel
    {
        public string AttributeName { get; set; }
        public string AttributeType { get; set; }

        public ICollection<RoleAttributes> RoleAttributesAttribute { get; set; }

    }
}
