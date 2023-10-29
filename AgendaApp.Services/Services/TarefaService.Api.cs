using AgendaApp.Services.Dtos;
using AgendaApp.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace AgendaApp.Services.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly string _baseUri = @"http://localhost:5105/api/tarefa";

        public TarefaDto Create(TarefaDto tarefa)
        {
            tarefa.Id = Guid.NewGuid().ToString();
            tarefa.Done = false;

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsync(_baseUri,
                    new StringContent(JsonConvert.SerializeObject(tarefa),
                        Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TarefaDto>(result);
                }
            }

            return null;
        }

        public TarefaDto Update(TarefaDto dto)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PutAsync(_baseUri,
                    new StringContent(JsonConvert.SerializeObject(dto),
                        Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TarefaDto>(result);
                }
            }

            return null;
        }

        public TarefaDto Delete(string id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(_baseUri + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TarefaDto>(result);
                }
            }

            return null;
        }

        public void SetDone(string id, bool done)
        {
            var taskDto = Get(id);
            taskDto.Done = done;

            Update(taskDto);
        }

        public List<TarefaDto> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(_baseUri).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<TarefaDto>>(result);
                }
            }

            return null;
        }

        public TarefaDto Get(string id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(_baseUri + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<TarefaDto>(result);
                }
            }

            return null;
        }
    }
}


