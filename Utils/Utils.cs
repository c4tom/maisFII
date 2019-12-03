using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace MaisFII.Utils
{
    public class Utils
    {
        public static DadosPessoasJSON obterDados()
        {
            string url = "https://www.4devs.com.br/ferramentas_online.php";
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["acao"] = "gerar_pessoa";
                data["sexo"] = "I";
                data["pontuacao"] = "S";
                data["idade"] = "0";
                data["cep_estado"] = "PR";
                data["txt_qtde"] = "1";
                data["cep_cidade"] = "";

                var response = wb.UploadValues(url, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);

                var result = JsonConvert.DeserializeObject<DadosPessoasJSON>(responseInString);


                return result;
            }
        }
    }
}
