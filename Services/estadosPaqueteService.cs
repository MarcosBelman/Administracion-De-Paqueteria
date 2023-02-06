using AdministracionDePaqueteria.Models;
namespace AdministracionDePaqueteria.Services;

public class estadosPaqueteService : IestadosPaqueteService
{
    PaquetesContext context;

    public estadosPaqueteService(PaquetesContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<estadosPaquete> Get()
    {
        return context.estadosPaquetes;
    }

    public void Save(estadosPaquete estadosPaquete)
    {
        context.Add(estadosPaquete);
        context.SaveChanges();
    }

    public void Update(long codRastreo, estadosPaquete estadosPaquete)
    {
        var estadosPaqueteActual = context.estadosPaquetes.Find(codRastreo);
        if(estadosPaqueteActual != null)
        {
            estadosPaqueteActual.idPaquete = estadosPaqueteActual.idPaquete;
            estadosPaqueteActual.numPieza = estadosPaqueteActual.numPieza;
            estadosPaqueteActual.fechaHora = estadosPaqueteActual.fechaHora;
            estadosPaqueteActual.areaServicio = estadosPaqueteActual.areaServicio;
            estadosPaqueteActual.estadoActual = estadosPaqueteActual.estadoActual;

            context.SaveChanges();
        }
    }

    public void Delete(long codRastreo)
    {
        var estadosPaqueteActual = context.estadosPaquetes.Find(codRastreo);
        if(estadosPaqueteActual != null)
        {
            context.Remove(estadosPaqueteActual);
            context.SaveChanges();
        }
    }
}

public interface IestadosPaqueteService
{
    IEnumerable<estadosPaquete>Get();
    void Save(estadosPaquete estadosPaquete);
    void Update(long codRastreo, estadosPaquete estadosPaquete);
    void Delete(long codRastreo);
}
