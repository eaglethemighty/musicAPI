namespace MusicAPIMVC.Repository.Interfaces
{
    public interface IRepositoryDelete<T>
    {
        Task DeleteAsync (T obj);
        void Delete(T obj);
        Task DeleteByIDAsync(int ID);
        void DeleteByID(int ID);

    }
}
