using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Dtos;
using application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext Context { get; set; }

        public HttpClient Client { get; set; }

        public IMapper Mapper { get; set; }

        public string HostAPI { get; set; }

        public HttpResponseMessage Respose { get; set; }

        public BaseIntegration()
        {
            HostAPI = "http://localhost:5000/api/";

            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            Context = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            Context.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();

            Client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDTO = new LoginDto()
            {
                Email = "souza.richard33@hotmail.com",
            };

            var resultLogin = await PostJsonAsync(loginDTO, $"{HostAPI}login", Client);

            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDTO>(jsonLogin);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.AccessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, String url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataClass), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            Context.Dispose();
            Client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public void Dispose() { }

        public IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }
    }
}
