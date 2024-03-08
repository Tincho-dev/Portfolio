using Model;

namespace Services;
public interface IFuenteService
{
    List<Fuente> Fuentes { get; }
    Task<Fuente> GetSingle(string id);
    Task Load();
    Task Create(Fuente fuente);
    Task Update(Fuente fuente, string id);
    Task Delete(string id);
}
