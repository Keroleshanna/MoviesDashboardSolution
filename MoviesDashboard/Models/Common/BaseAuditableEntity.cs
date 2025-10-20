namespace MoviesDashboard.Models.Common
{
    public class BaseAuditableEntity<TKey> : BaseEntity<TKey> 
        where TKey: IEquatable<TKey>
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
