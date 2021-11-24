namespace MusicAPIMVC.Repository.Interfaces
{
    public interface IRepositoryRead<T>
    {
        public Task<T> GetByIdAsync(int id);
        public T GetById(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public IEnumerable<T> GetAll();
    }
}
