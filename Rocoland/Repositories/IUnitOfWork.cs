namespace Rocoland.Repositories
{
    public interface IUnitOfWork
    {

        void SaveChanges();
        IOrderRepository Orders { get; set; }
        IProductRepository Products { get; set; }
    }
}