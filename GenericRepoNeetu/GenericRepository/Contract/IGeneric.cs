namespace GenericRepoNeetu.GenericRepository.Contract
{
    public interface IGeneric<T> where T:class
    {
        List<T> GetAll();
        bool Add(T obj);
        T Get(int id);
        bool Update(T obj);
        bool Delete(int id);
    }
}
