using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisFII.Models {

    [Table("HistoricoFundo")]
    public class HistoricoFundo {
        [Key]
        public int Id { get; set; }

        public float valor { get; set; }

        public Fundo Fundo { get; set; }

        public DateTime Data { get; set; }

        public HistoricoFundo()
        {

        }

        public List<HistoricoFundo> Listar () {
            return null;
        }

        ///  
        public void Importar () {

        }
    }
}