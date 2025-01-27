using EntitiesInterface.Users;

namespace EntitiesInterface.Bills
{
    public interface IBill
    {
        int IdBill { get; set; }
        IUser Client { get; set; }
        /*ICollaborator*/object Collaborator { get; set; }
        DateTime DateBill { get; set; }
        DateTime WarrantyDate { get; set; }
        int Iva { get; set; }
        int TotalAmount { get; set; }
        bool IsEnabled { get; set; }
    }
}
