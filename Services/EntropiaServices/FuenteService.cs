using Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services;

public class FuenteService : IFuenteService
{
    private readonly EntropiaContext _context;
    public List<Fuente> Fuentes { get; set; } = new List<Fuente>();

    public FuenteService(EntropiaContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task Load()
    {
        Fuentes.Clear();
        var FuentesDb = await _context.Fuentes.ToListAsync();
        foreach (var item in FuentesDb)
        {
            Fuentes.Add(new Fuente(item.CadenaFuente) { IdFuente = item.IdFuente });
        }
    }


    public async Task<Fuente> GetSingle(string id)
    {
        var fuente = await _context.Fuentes.FindAsync(id);
        if (fuente == null)
        {
            return new Fuente();
        }
        return fuente;
    }


    public async Task Create(Fuente fuente)
    {
        foreach (var Letra in fuente.Letras)
        {
            Letra.IdFuente = fuente.IdFuente;
        }
        _context.Fuentes.Add(fuente);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(string id)
    {
        var dbFuente = await _context.Fuentes.FindAsync(id);
        if (dbFuente == null)
        {
            throw new Exception("No hay Fuente con este id.");
        }
        _context.Fuentes.Remove(dbFuente);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Fuente fuente, string id)
    {
        var dbFuente = await _context.Fuentes.FindAsync(id);
        if (dbFuente == null)
        {
            throw new Exception("No hay ninguna fuente con este id.");
        }
        dbFuente.CadenaFuente = fuente.CadenaFuente;

        await _context.SaveChangesAsync();
    }
}