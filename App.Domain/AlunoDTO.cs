using System.ComponentModel.DataAnnotations;

namespace App.Domain
{
    public class AlunoDTO
    {
        public int id { get; set; }
        //Data annotation
        [Required(ErrorMessage = "O nome é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "Tem no minimo 2 e no máximo 50 ", MinimumLength = 2)]
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        [RegularExpression(@"[0-9]{4}\-[0-9]{2}", ErrorMessage = "A data está fora do padrão (YYYY-MM)")]
        public string data { get; set; }
        [Required(ErrorMessage = "O R.A. é de preenchimento obrigatório")]
        [Range(1, 500, ErrorMessage = "Só pode cadastrar RA de 1 a 500" )]
        public int ra { get; set; }
        public string descricao { get; set; }
    }
}