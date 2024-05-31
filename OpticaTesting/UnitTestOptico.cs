using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OpticaService.Controllers;
using OpticaService.Models;
using OpticaService.Models.DTO;
using OpticaService.Repository;

namespace OpticaTesting
{
    [TestClass]
    public class UnitTestOptico
    {
        // injectamos la dependencia ya que el metodo utiliza automapper
        public readonly  IMapper _mapper;


        // creamos el mapeo para que el metodo pueda devolver la entidad mapeada
        public UnitTestOptico()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Optico, OpticoDTO>();
            });
            _mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task TestMethodGetAllOpticos()
        {

            // Arrange
            var opticosTest = new List<Optico>
            {
                new Optico { Id= 1 , Nombre = "Antonio",Apellido = "Banderas",Contraseña = "1234",Estado = true},
                new Optico {Id= 2 , Nombre = "Juan",Apellido = "Valdez",Contraseña = "4321",Estado = false}
            };

            var mockOpticoRepository = new Mock<IOpticoRepository>();
            mockOpticoRepository.Setup(repo => repo.GetAllOpticos()).ReturnsAsync(opticosTest);
            var controller = new OpticoController(mockOpticoRepository.Object , _mapper);

            // Act

            var result = await controller.Get() as OkObjectResult;
            var opticos = result.Value as IEnumerable<OpticoDTO>;


            // Assert

            Assert.IsNotNull(result);
            Assert.IsNotNull(opticos);
            Assert.AreEqual(2,opticos.Count());


        }
    } 
}