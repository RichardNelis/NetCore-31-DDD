using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Api.Domain.Dtos.CEP;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.CEP
{
    public class QuandoRequisitarCEP : BaseIntegration
    {
        [Fact]
        public async void E_Possivel_Realizar_Crud_CEP()
        {
            await AdicionarToken();

            var municipioDTOCreate = new MunicipioDTOCreate
            {
                Nome = "Sao Joao da Boa Vista",
                CodIBGE = 3549102,
                UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //Post
            var response = await PostJsonAsync(municipioDTOCreate, $"{HostAPI}municipios", Client);
            var municipioPostResult = await response.Content.ReadAsStringAsync();
            var municipioRegistroPost = JsonConvert.DeserializeObject<MunicipioDTOCreateResult>(municipioPostResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Sao Joao da Boa Vista", municipioRegistroPost.Nome);
            Assert.Equal(3549102, municipioRegistroPost.CodIBGE);
            Assert.True(municipioRegistroPost.Id != new Guid());

            var cepDTOCreate = new CEPDTOCreate()
            {
                CEP = "13876",
                Logradouro = "JoseJorgeda Rosa",
                Numero = "1591",
                MunicipioId = municipioRegistroPost.Id
            };

            //Post
            response = await PostJsonAsync(cepDTOCreate, $"{HostAPI}ceps", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CEPDTOCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(cepDTOCreate.CEP, registroPost.CEP);
            Assert.Equal(cepDTOCreate.Logradouro, registroPost.Logradouro);
            Assert.Equal(cepDTOCreate.Numero, registroPost.Numero);
            Assert.Equal(cepDTOCreate.MunicipioId, registroPost.MunicipioId);

            var cepDTOUpdate = new CEPDTOUpdate()
            {
                Id = registroPost.Id,
                CEP = "13876591",
                Logradouro = "Jose Jorge da Rosa",
                Numero = "1591",
                MunicipioId = municipioRegistroPost.Id
            };

            //Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(cepDTOUpdate), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostAPI}ceps", stringContent);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CEPDTOUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("13876591", registroAtualizado.CEP);

            //Get Id
            response = await Client.GetAsync($"{HostAPI}ceps/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CEPDTO>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroAtualizado.CEP, registroSelecionado.CEP);

            //Get CEP
            response = await Client.GetAsync($"{HostAPI}ceps/byCep/{registroAtualizado.CEP}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            registroSelecionado = JsonConvert.DeserializeObject<CEPDTO>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroAtualizado.CEP, registroSelecionado.CEP);

            //Delete
            Respose = await Client.DeleteAsync($"{HostAPI}ceps/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get Id depois do Delete
            response = await Client.GetAsync($"{HostAPI}ceps/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
