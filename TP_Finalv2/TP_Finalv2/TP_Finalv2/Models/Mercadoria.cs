using SQLite;
using System.Collections.Generic;
using System.Linq;
using TP_Finalv2.Data;
using Xamarin.Forms;

namespace TP_Finalv2.Models
{
    [Table("Mercadoria")]
    public class Mercadoria
    {
        #region Propriedades
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeMercadoria { get; set; }
        public string Peso { get; set; }
        public string NomeProdutor { get; set; }
        public string Email { get; set; }
        public string NCM { get; set; }
        #endregion
    }
}