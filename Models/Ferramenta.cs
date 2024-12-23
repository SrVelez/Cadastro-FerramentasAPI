namespace Cadastro_de_Ferramentas.Models
{
    public class Ferramenta
    {
        public int Id { get; set; }

        public string NomeDaFerramenta { get; set; } = string.Empty;

        public int ClienteId { get; set; }

        public int? Quantidade { get; set; }

        public Cliente? Cliente { get; set; } = null!;

        public string Descricao { get; set; } = string.Empty;

        public DateTime? DataPedido { get; set; }

    }
}
