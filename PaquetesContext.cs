using Microsoft.EntityFrameworkCore;
using AdministracionDePaqueteria.Models;
namespace AdministracionDePaqueteria;

public class PaquetesContext : DbContext
{
    public DbSet<Paquete> Paquete {get; set;}
    public DbSet<estadosPaquete> estadosPaquetes {get; set;}
    public PaquetesContext(DbContextOptions<PaquetesContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Paquete> paqueteInit = new List<Paquete>();
        //paqueteInit.Add(new Paquete() {codRastreo = 2040572732, idPaquete = "JD014600010569788723", numPieza = 1, fechaHora = Convert.ToDateTime("02/05/2023"), areaServicio = "MEXICO CITY - MEXICO", estadoActual = "Envío retirado/recolectado."});
        modelBuilder.Entity<Paquete>(paquete =>
        {   
            paquete.ToTable(p => p.HasTrigger("Algun Trigger"));
            //paquete.HasKey(p => p.codRastreo);
            paquete.Property(p => p.codRastreo).ValueGeneratedNever();
            paquete.Property(p => p.idPaquete).IsRequired();
            paquete.Property(p => p.numPieza).IsRequired();
            paquete.Property(p => p.fechaHora).IsRequired();
            paquete.Property(p => p.areaServicio).IsRequired();
            paquete.Property(p => p.estadoActual).IsRequired();
            paquete.HasData(paqueteInit);
        });

        List<estadosPaquete> estadosPaqueteInit = new List<estadosPaquete>();
        //estadosPaqueteInit.Add(new estadosPaquete() {codRastreo = 2040572731, idPaquete = "JD014600010569788723", numPieza = 1, fechaHora = Convert.ToDateTime("02/05/2023"), areaServicio = "MEXICO CITY - MEXICO", estadoActual = "Envío retirado/recolectado."});
        
        modelBuilder.Entity<estadosPaquete>(estadosPaquete =>
        {   
            estadosPaquete.ToTable("estadosDelPaquete");
            estadosPaquete.HasKey(p => p.codRastreo);
            estadosPaquete.Property(p => p.idPaquete).IsRequired();
            estadosPaquete.Property(p => p.numPieza).IsRequired();
            estadosPaquete.Property(p => p.fechaHora).IsRequired(false);
            estadosPaquete.Property(p => p.areaServicio).IsRequired();
            estadosPaquete.Property(p => p.estadoActual).IsRequired();
            estadosPaquete.HasData(estadosPaqueteInit);
        });
    }        
}
