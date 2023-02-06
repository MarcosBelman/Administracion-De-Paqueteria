using AdministracionDePaqueteria.Models;

namespace AdministracionDePaqueteria.Services;

public class PaqueteService : IPaqueteService
{
    PaquetesContext context;

    public PaqueteService(PaquetesContext dbContext)
    {
        context = dbContext;
    }        

    public IEnumerable <Paquete> Get()
    {
        return context.Paquete;
    }

    public void Save(Paquete paquete)
    {
        Console.WriteLine("ENTRA AL MÉTODO SAVE");
        Console.WriteLine(paquete.codRastreo);
        Console.WriteLine(paquete.idPaquete);
        Console.WriteLine(paquete.numPieza);
        Console.WriteLine(paquete.fechaHora);
        Console.WriteLine(paquete.areaServicio);
        Console.WriteLine(paquete.estadoActual);
        Console.WriteLine("SALE DEL MÉTODO SAVE");
        context.Add(paquete);
        context.SaveChanges();
    }

    public void Update(long codRastreo, Paquete paquete)
    {
        var paqueteActual = context.Paquete.Find(codRastreo);
        if(paqueteActual != null)
        {
            paqueteActual.idPaquete = paquete.idPaquete;
            paqueteActual.numPieza = paquete.numPieza;
            paqueteActual.fechaHora = paquete.fechaHora;
            paqueteActual.areaServicio = paquete.areaServicio;
            paqueteActual.estadoActual = paquete.estadoActual;

            context.SaveChanges();
        }
    }

    public void Delete(long codRastreo)
    {
        var paqueteActual = context.Paquete.Find(codRastreo);
        if(paqueteActual != null)
        {
            context.Remove(paqueteActual);
            context.SaveChanges();
        }
    }
}

public interface IPaqueteService
    {
        IEnumerable<Paquete> Get();
        void Save(Paquete paquete);
        void Update(long codRastreo, Paquete paquete);
        void Delete(long codRastreo);
    }