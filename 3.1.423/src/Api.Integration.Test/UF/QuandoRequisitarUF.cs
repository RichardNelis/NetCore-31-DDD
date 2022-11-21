using System.Collections.Generic;
using System.Linq;
using System.Net;
using Api.Domain.Dtos.UF;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.UF
{
    public class QuandoRequisitarUF : BaseIntegration
    {
        [Fact]
        public async void E_Possivel_Realizar_Crud_UF()
        {
            await AdicionarToken();

            var response = await Client.GetAsync($"{HostAPI}ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UFDTO>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() == 27);
            Assert.Contains(listaFromJson, x => x.Sigla == "SP");


            var id = listaFromJson.FirstOrDefault(x => x.Sigla == "SP").Id;
            response = await Client.GetAsync($"{HostAPI}ufs/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UFDTO>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal("SP", registroSelecionado.Sigla);
            Assert.Equal("São Paulo", registroSelecionado.Nome);
        }
    }
}
