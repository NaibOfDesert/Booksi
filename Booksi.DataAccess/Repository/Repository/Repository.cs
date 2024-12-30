using System.Linq.Expressions; 
public class Repository<T> : IRepository<T> where T : class
{
    // Dependency Injection

    T Get(Expression<Func<T, bool>> filter){
        return Get(filter, null);
    }
    IEnumerable <T> GetAll(){
        return GetAll(null);
    }
    void Add(T item){

    }
    void Update(T item){

    }
    void Delete(T item){

    }
    void DeleteMany(IEnumerable<T> items){
        
    }
}