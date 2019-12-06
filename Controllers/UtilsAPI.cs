using Microsoft.AspNetCore.Mvc;
using MaisFII.Utils;
using Nancy.Json;
using System.Web.Helpers;

namespace MaisFII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsAPI : ControllerBase
    {
        public UtilsAPI()
        {

        }


        [HttpGet("/about")]
        public string About()
        {
            return "About....";
        }

        [HttpGet("/dados")]
        public string LoadDados()
        {
            DadosPessoasJSON dados = Utils.Utils.obterDados();
            return dados.ToJson();
            
        }
    }
}
