
namespace Application.DTO.Viajes
{
    public class ViajeReportDTO
    {
        public double DistanciaTotal { get; set; }
        public DateOnly Fecha { get; set; }
        public decimal TarifaTotal { get; set; }
        public int TransportistaId { get; set; }
        public string TransportistaNombre { get; set; }
        public int SucursalId { get; set; }
        public string SucursalNombre { get; set; }
    }
}
