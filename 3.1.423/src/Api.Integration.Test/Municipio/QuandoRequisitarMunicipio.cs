using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Municipio
{
    public class QuandoRequisitarMunicipio : BaseIntegration
    {
        [Fact]
        public async void E_Possivel_Realizar_Crud_Municipio()
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
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<MunicipioDTOCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Sao Joao da Boa Vista", registroPost.Nome);
            Assert.Equal(3549102, registroPost.CodIBGE);
            Assert.True(registroPost.Id != new Guid());

            //GetAll
            response = await Client.GetAsync($"{HostAPI}municipios");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<MunicipioDTO>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.Contains(listaFromJson, x => x.Id == registroPost.Id);

            var updateMunicipioDTO = new MunicipioDTOUpdate()
            {
                Id = registroPost.Id,
                Nome = "São João da Boa Vista",
                CodIBGE = 3549102,
                UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };

            //Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateMunicipioDTO), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostAPI}municipios", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<MunicipioDTOUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("São João da Boa Vista", registroAtualizado.Nome);
            Assert.Equal(3549102, registroAtualizado.CodIBGE);

            //Get Id
            response = await Client.GetAsync($"{HostAPI}municipios/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<MunicipioDTO>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionado.CodIBGE, registroAtualizado.CodIBGE);

            //Get Complete/Id
            response = await Client.GetAsync($"{HostAPI}municipios/complete/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDTOCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoCompleto);
            Assert.Equal(registroSelecionadoCompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoCompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto.UF);
            Assert.True(registroSelecionadoCompleto.UF.Id != Guid.Empty);

            //Get byIBGE/CodIBGE
            response = await Client.GetAsync($"{HostAPI}municipios/byIBGE/{registroAtualizado.CodIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoIBGECompleto = JsonConvert.DeserializeObject<MunicipioDTOCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoIBGECompleto);
            Assert.Equal(registroSelecionadoIBGECompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoIBGECompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoIBGECompleto.UF);
            Assert.True(registroSelecionadoIBGECompleto.UF.Id != Guid.Empty);

            //Delete
            response = await Client.DeleteAsync($"{HostAPI}municipios/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //Get Id depois do Delete
            response = await Client.GetAsync($"{HostAPI}municipios/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
