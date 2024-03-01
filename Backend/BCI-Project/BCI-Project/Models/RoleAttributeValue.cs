namespace BCI_Project.Models
{
    public class RoleAttributeValue : BaseModel
    {
        public Guid RoleAttributeId { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }


        public RoleAttributes RoleAttributes { get; set; }

        public User User { get; set; }
    }
}
