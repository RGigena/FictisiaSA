namespace FictisiaSA.Pages.Personas.Models
{
    public class AdicionalesVM
    {
        public int AdicionalesId { get; set; }
        public bool Maneja { get; set; }
        public bool UsaLentes { get; set; }
        public bool EsDiabetico { get; set; }
        public bool OtraEnfermedad { get; set; }
        public string? Comentarios { get; set; }
    }
}
