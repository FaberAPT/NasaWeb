using NasaWeb.Api.Interfaces;

using NasaWeb.Api.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NasaWeb.Api.Repositories
{
    public class AsteroidsRepository : IAsteroidRepository
    {
        private readonly ApiHelper _apiHelper;

        public AsteroidsRepository(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<IEnumerable<Asteroids>> GetAsteroids(string planeta)
        {
            string url = $"?api_key=zdUP8ElJv1cehFM0rsZVSQN7uBVxlDnu4diHlLSb";

            _apiHelper.InitializeClient();

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(url))
            {
                List<Asteroids> listAsteroids = new List<Asteroids>();

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    Root root = JsonConvert.DeserializeObject<Root>(result);

                    foreach (NearEarthObject nearEarthObject in root.NearEarthObjects)
                    {
                        foreach (CloseApproachData closeApproachData in nearEarthObject.CloseApproachData)
                        {
                            if (nearEarthObject.IsPotentiallyHazardousAsteroid)
                            {
                                if (planeta == closeApproachData.OrbitingBody)
                                {
                                    Asteroids asteroid = new Asteroids()
                                    {
                                        Nombre = nearEarthObject.Name,
                                        Diametro = (nearEarthObject.EstimatedDiameter.Kilometers.EstimatedDiameterMin + nearEarthObject.EstimatedDiameter.Kilometers.EstimatedDiameterMax) / 2,

                                        Velocidad = Convert.ToDouble(closeApproachData.RelativeVelocity.KilometersPerHour),
                                        Fecha = closeApproachData.CloseApproachDate,
                                        Planeta = closeApproachData.OrbitingBody
                                    };

                                    listAsteroids.Add(asteroid);
                                }
                            }
                        }
                    }
                }

                return listAsteroids.Take(3)
                                    .OrderByDescending(asteroid => asteroid.Diametro)
                                    .GroupBy(asteroid => asteroid.Nombre)
                                    .Select(asteroid => asteroid.First());
            }
        }
    }
}
