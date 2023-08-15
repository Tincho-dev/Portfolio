using Data;
using Model;

namespace Services;

public class ProfessionalService : IProfessionalService
{

    private readonly Repositorio<Professional> _repositorio;

    public ProfessionalService(Repositorio<Professional> repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Professional?> GetProfessionalAsync(int id)
    {
        var professional = _repositorio.Get(id);
        return professional;
    }

}

