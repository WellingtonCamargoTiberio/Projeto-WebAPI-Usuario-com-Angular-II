using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Usuario.Entidades
{
    [Table("Funcao")]
    public class Funcao
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NomeFuncao")]
        public string NomeFuncao { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        [Column("Foto")]
        public string Foto { get; set; }
    }
}

