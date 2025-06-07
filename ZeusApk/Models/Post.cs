using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusApk.Models
{
    internal class Post
    {
        public string   UserEmail   { get; set; }
        public DateTime InicioQueda { get; set; }
        public string   Bairro      { get; set; }
        public string   Cidade      { get; set; }
        public string   Descricao   { get; set; }
    }
}

