using Model;

namespace Services;
public interface IFuenteService
{
    List<Fuente> Fuentes { get; }
    Task Delete(string id);
    Task Create(Fuente fuente);
    Task<Fuente> GetSingle(string id);
    Task Load();
    Task Update(Fuente fuente, string id);
}
