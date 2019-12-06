using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsQuery;
using MaisFII.Data;
using MaisFII.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaisFII.Controllers
{
    [Route("api/[controller]")]
    public class Dados : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("deCadastro")]
        public string Get(int id)
        {
            DadosPessoasJSON dados = Utils.Utils.obterDados();
            return dados.ToJson();
        }

        [HttpGet("deHistorico")]
        public string Get(string sigla)
        {
            string output = "";
            var dom = CQ.CreateFromUrl("http://200.147.99.191/acao/cotacoes-historicas.html?codigo=MXRF11.SA&beginDay=4&beginMonth=12&beginYear=2018&endDay=4&endMonth=12&endYear=2019&size=500&page=1&period=ano");

            var rows = dom.Select("#tblInterday tr");
            //id=tblInterday
            foreach (var row in rows.Has("td"))
            {
                try
                {
                    CQ tdcells = row.Cq().Find("td");

                    System.Collections.Generic.List<IDomObject> td = tdcells.ToList();
                    FundoPocs f = new FundoPocs();
                    f.Data = f.DataBR2US(td[0].InnerText);
                    f.Cotacao = f.MoneyBR2US(td[1].InnerText);
                    f.ValorMinimo = f.MoneyBR2US(td[2].InnerText);
                    f.ValorMaximo = f.MoneyBR2US(td[3].InnerText);
                    f.Variacao = f.MoneyBR2US(td[4].InnerText);
                    f.VariacaoPercent = f.MoneyBR2US(td[5].InnerText);
                    f.Volume = Int32.Parse(td[6].InnerText.Replace(".", ""));

                    output += Newtonsoft.Json.JsonConvert.SerializeObject(f);

                }
                catch (Exception ex)
                {

                }
            }
            return output;
        }
    }
}
