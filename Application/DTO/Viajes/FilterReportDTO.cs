
namespace Application.DTO.Viajes
{
    public class FilterReportDTO
    {
        public int? TransportistaId { get; set; }
        public int? SucursalId { get; set; }
        public DateOnly? MinFecha { get; set; }
        public DateOnly? MaxFecha { get; set; }
        public decimal? MinTarifaTotal { get; set; }
        public decimal? MaxTarifaTotal { get; set; }
    }
}
