using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaisFII.Data
{
    class FundoPocs
    {
        public DateTime Data { get; set; }
        public float Cotacao { get; set; }

        public float ValorMinimo { get; set; }

        public float ValorMaximo { get; set; }

        public float Variacao { get; set; }

        public float VariacaoPercent { get; set; }

        public int Volume { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public DateTime DataBR2US(String data)
        {
            string[] dt = data.Split("/");
            try
            {
                return new DateTime(Int32.Parse(dt[2]), Int32.Parse(dt[1]), Int32.Parse(dt[0]));
            }
            catch (Exception e)
            {
                throw;
            }
            return new DateTime();
        }

        public float MoneyBR2US(String m)
        {
            return float.Parse(m.Replace(",", "."));
        }
    }
}
