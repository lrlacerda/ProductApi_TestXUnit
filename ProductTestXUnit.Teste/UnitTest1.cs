using Moq;
using ProuctsApi.Domains;
using ProuctsApi.Interfaces;
using ProuctsApi.Repositories;
using Xunit;

namespace TesteApiXUnit.Test
{
    //Indica que o método é de teste de unidade
    public class ProductsTest
    {
        [Fact]
        public void Get()
        {
            //Arrange: Organizar cenário

            var products = new List<Products>
            {
                new Products {IdProduct = Guid.NewGuid(), Name = "Produto 1", Price = 10 },
                new Products {IdProduct = Guid.NewGuid(), Name = "Produto 2", Price = 30 },
                new Products {IdProduct = Guid.NewGuid(), Name = "Produto 3", Price = 50 }
            };

            //cria um obj de simulação do tipo IProduct (Interface)
            var mockRepository = new Mock<IProduct>();
            //Config o método Listar para retornar a lista de produtos "mock
            mockRepository.Setup(x => x.Listar()).Returns(products);

            //Act: Agir

            //Chama o método Listar() e armazena o resultado em result
            var result = mockRepository.Object.Listar();

            //Assert: Provar

            //Provar se o resultado esperado é igual ao resultado obtido através da busca
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            var product = new Products { IdProduct = Guid.NewGuid(), Name = "Produto 4", Price = 70 };
            var mockRepository = new Mock<IProduct>();

            mockRepository.Setup(x => x.Cadastrar(It.IsAny<Products>()));

            // Act
            mockRepository.Object.Cadastrar(product);

            // Assert
            mockRepository.Verify(x => x.Cadastrar(It.Is<Products>(p => p.Name == "Produto 4" && p.Price == 70)), Times.Once);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { IdProduct = productId, Name = "Produto 5", Price = 90 };
            var mockRepository = new Mock<IProduct>();

            mockRepository.Setup(x => x.BuscarPorId(productId)).Returns(product);

            // Act
            var result = mockRepository.Object.BuscarPorId(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Produto 5", result.Name);
            Assert.Equal(90, result.Price);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var mockRepository = new Mock<IProduct>();

            mockRepository.Setup(x => x.Deletar(productId));

            // Act
            mockRepository.Object.Deletar(productId);

            // Assert
            mockRepository.Verify(x => x.Deletar(productId), Times.Once);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Products { IdProduct = productId, Name = "Produto Atualizado", Price = 100 };
            var mockRepository = new Mock<IProduct>();

            mockRepository.Setup(x => x.Atualizar(productId, It.IsAny<Products>()));

            // Act
            mockRepository.Object.Atualizar(productId, product);

            // Assert
            mockRepository.Verify(x => x.Atualizar(productId, It.Is<Products>(p => p.Name == "Produto Atualizado" && p.Price == 100)), Times.Once);
        }
    }
}