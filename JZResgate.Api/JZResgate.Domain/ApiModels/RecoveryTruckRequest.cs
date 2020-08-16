using System.ComponentModel.DataAnnotations;

namespace JZResgate.Infra.Data.ApiModels
{
    public class RecoveryTruckRequest
    {
        public string Alias { get; set; }

        [Required(ErrorMessage = "É obrigatório informar uma placa.")]
        public string Plate { get; set; }

        public string Model { get; set; }
    }
}