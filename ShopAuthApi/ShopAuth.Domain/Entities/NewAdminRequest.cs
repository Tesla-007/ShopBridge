namespace ShopAuth.Domain.Entities
{
    public enum Approval
    {
        Approved, Pending, Denied
    }
    public class NewAdminRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public IdentityAdmin? Approver { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public Approval ApprovalStatus { get; set; }

        public string Reason { get; set; }
    }
}
