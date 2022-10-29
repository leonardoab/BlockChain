using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Application.BlockChain.Service
{
    public class GenericService : IGenericService
    {

        public async Task<IList<String>> BuscarTabela(string url)
        {
            IList<String> linhasTabela = new List<String>();

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                var inicio = responseBody.IndexOf("<tbody>");
                var fim = responseBody.IndexOf("</tbody>");

                responseBody = responseBody.Substring(inicio, (fim - inicio));

                while (responseBody.IndexOf("<tr>") > 0)
                {
                    inicio = responseBody.IndexOf("<tr>");
                    fim = responseBody.IndexOf("</td><tr>") + 9;
                    var linha = responseBody.Substring(inicio, (fim - inicio));
                    responseBody = " " + responseBody.Substring(fim - 4, (responseBody.Length - (fim - 4 + 1)));
                    linhasTabela.Add(linha);

                }

            }

            return linhasTabela;

        }


        public Task<IList<string>> ConverterLinhaEmCampos(String listaTabela)
        {

            IList<String> listaCampos = new List<String>();

            while (listaTabela.IndexOf("<td>") > 0)
            {
                var inicio = listaTabela.IndexOf("<td>");
                var fim = listaTabela.IndexOf("</td>") + 5;
                var linha = listaTabela.Substring(inicio + 4, (fim - inicio) - 9);

                if (linha.IndexOf("c4a?a=") > 0)
                {

                    inicio = listaTabela.IndexOf("c4a?a=");
                    linha = linha.Substring(inicio + 1, 42);

                }

                if (linha.IndexOf(".") > 0)
                {
                    linha = linha.Substring(0, linha.IndexOf("."));

                }

                if (linha.IndexOf(",") > 0)
                {
                    linha = linha.Replace(",", "");

                }


                listaTabela = " " + listaTabela.Substring(fim, (listaTabela.Length - (fim)));
                listaCampos.Add(linha);

            }

            return Task.FromResult(listaCampos);




        }

        public async Task<float> BuscarCotacaoMafaDolar()
        {
            //<div class="priceValue ">


            HttpClient client = new HttpClient();

            //client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.29.2");
            //client.DefaultRequestHeaders.Add("Accept", "*/*");
            //client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            //client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            //client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "fb87ff96-d4b1-41b6-8487-ce1e2d1f6053");

            float valor = 0;

            HttpResponseMessage response = await client.GetAsync("https://bscscan.com/token/0x6dd60afb2586d31bf390450adf5e6a9659d48c4a");
            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                var inicio = responseBody.IndexOf("Price per Token");

                responseBody = responseBody.Substring(inicio + 117, 400);

                //inicio = responseBody.IndexOf("<span class=\"text - success\">$");
                var fim = responseBody.IndexOf(">");

                responseBody = responseBody.Substring(0 , fim -1);
                //responseBody = responseBody.Substring(0, responseBody.IndexOf(".") + 4);


                try
                {
                    //responseBody = responseBody.Replace(".", ",");
                    valor = float.Parse(responseBody);

                    //valor = (float)Math.Truncate((decimal)valor);

                }
                catch
                {

                }


            }

            return valor;


        }

        public async Task<float> BuscarCotacaoMafaReal()
        {



            HttpClient client = new HttpClient();

            //client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.29.2");
            //client.DefaultRequestHeaders.Add("Accept", "*/*");
            //client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            //client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "fb87ff96-d4b1-41b6-8487-ce1e2d1f6053");

            float valor = 0;

            HttpResponseMessage response = await client.GetAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol=MAFA&convert=BRL");
            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                //var inicio = responseBody.IndexOf("<div class=\"priceValue \">");

                //responseBody = responseBody.Substring(inicio, 100);

                var inicio = responseBody.IndexOf("\"price\":");
                var fim = responseBody.IndexOf(",\"volume_24h\"");

                responseBody = responseBody.Substring(inicio + 8 , fim - (inicio + 8));
                responseBody = responseBody.Substring(0, responseBody.IndexOf(".") + 4);


                try
                {
                    //responseBody = responseBody.Replace(".", ",");
                    valor = float.Parse(responseBody);

                    //valor = (float)Math.Truncate((decimal)valor);

                }
                catch
                {

                }


            }

            return valor;

        }


    }
}
