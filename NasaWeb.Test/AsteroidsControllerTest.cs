using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NasaWeb.Api;
using NasaWeb.Api.Controllers;
using NasaWeb.Api.Interfaces;
using NasaWeb.Api.Models;
using NasaWeb.Api.Repositories;

using System.Collections.Generic;

namespace NasaWeb.Test
{
    class AsteroidsControllerTest
    {
        static ApiHelper apiHelper = new ApiHelper();
        static AsteroidsRepository asteroidRepository = new AsteroidsRepository(apiHelper);
        static AsteroidsController asteroidsController = new AsteroidsController(asteroidRepository);

        [TestMethod]
        [DataRow("Earth")]
        public void GetAsteroids_Integration_ShouldReturnOk(string planeta)
        {
            var response = asteroidsController.GetAsteroids(planeta).Result;

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult)response.Result).Value, typeof(List<Asteroids>));
        }

        [TestMethod]
        [DataRow("Earth")]
        public void GetAsteroids_Integration_ShouldReturnNotFound(string planeta)
        {
            var response = asteroidsController.GetAsteroids(planeta).Result;

            Assert.IsInstanceOfType(response.Result, typeof(NotFoundResult));
        }
    }
}
