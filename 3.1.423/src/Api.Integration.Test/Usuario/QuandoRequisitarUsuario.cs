using System.Text;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Usuario
{
    public class QuandoRequisitarUsuario : BaseIntegration
    {
        private string _name { get; set; }

        private string _email { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            await AdicionarToken();

            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDTO = new UserDtoCreate()
            {
                Name = _name,
                Email = _email,
            };

            //Post
            var response = await PostJsonAsync(userDTO, $"{HostAPI}users", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPOST = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, registroPOST.Name);
            Assert.Equal(_email, registroPOST.Email);
            Assert.True(registroPOST.Id != default(Guid));

            //GetALL
            response = await Client.GetAsync($"{HostAPI}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count() > 0);
            Assert.Contains(listFromJson, x => x.Id == registroPOST.Id);

            //Put
            var updateUserDTO = new UserDtoUpdate()
            {
                Id = registroPOST.Id,
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email(),
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDTO), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostAPI}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();

            var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPOST.Name, registroAtualizado.Name);
            Assert.NotEqual(registroPOST.Email, registroAtualizado.Email);

            //Get ID
            response = await Client.GetAsync($"{HostAPI}users/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Name, registroAtualizado.Name);

            //Delete
            response = await Client.DeleteAsync($"{HostAPI}users/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await Client.GetAsync($"{HostAPI}users/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
