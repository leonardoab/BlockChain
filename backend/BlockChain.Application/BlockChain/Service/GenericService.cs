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

            client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.29.2");
            //client.DefaultRequestHeaders.Add("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,zh-CN;q=0.6,zh;q=0.5");
            //client.DefaultRequestHeaders.Add("Accept", "text/html");
            //client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            float valor = 0;

            HttpResponseMessage response = await client.GetAsync("https://coinmarketcap.com/currencies/mafagafo/");
            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();


                var inicio = responseBody.IndexOf("<div class=\"priceValue \">");

                responseBody = responseBody.Substring(inicio, 100);

                inicio = responseBody.IndexOf("$");
                var fim = responseBody.IndexOf("</span>");

                responseBody = responseBody.Substring((inicio + 1), fim - (inicio + 1));


                try
                {
                    responseBody = responseBody.Replace(".", ",");
                    valor = float.Parse(responseBody);

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

            client.DefaultRequestHeaders.Add("User-Agent", "PostmanRuntime/7.29.2");
            //client.DefaultRequestHeaders.Add("Accept", "*/*");
            //client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            //client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            float valor = 0;

            HttpResponseMessage response = await client.GetAsync("https://coinmarketcap.com/pt-br/currencies/mafagafo");
            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                var inicio = responseBody.IndexOf("<div class=\"priceValue \">");

                responseBody = responseBody.Substring(inicio, 100);

                inicio = responseBody.IndexOf("R$");
                var fim = responseBody.IndexOf("</span>");

                responseBody = responseBody.Substring((inicio + 2), fim - (inicio + 2));


                try
                {
                    responseBody = responseBody.Replace(".", ",");
                    valor = float.Parse(responseBody);

                }
                catch
                {

                }


            }

            return valor;

        }


    }
}
