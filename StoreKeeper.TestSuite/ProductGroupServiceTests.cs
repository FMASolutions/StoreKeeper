using System;
using Xunit;
using StoreKeeper.Core.Models;
using StoreKeeper.Services.DTOs;
using StoreKeeper.Services;
using Moq;
using StoreKeeper.Data;

namespace StoreKeeper.TestSuite
{
    public class ProductGroupServiceTests
    {   
        public ProductGroupServiceTests()
        {
            _sut = new ProductGroupService(_uowMock.Object);
        }
        [Fact]
        public async void CreateProductGroup_ShouldCreate_WithValidModel()
        {
            //Arrange
            var dummyProdGroup = GetDummyProductGroup();
            _uowMock.Setup(x => x.ProductGroups.GetByCodeAsync(dummyProdGroup.Code)).ReturnsAsync(dummyProdGroup);
            
            //Act
            var prodGroupDTOResult = await _sut.CreateProductGroup(GetDummyProductGroupSaveDTO());

            //Assert
            CompareFullProductGroupToProductGroupDTO(dummyProdGroup, prodGroupDTOResult);
        }
        [Fact]
        public async void CreateProductGroup_TestErrorMessages_WithBlankInvalidModel()
        {
            //Arrange
            var dummyProdGroup = GetDummyProductGroup();
            _uowMock.Setup(x => x.ProductGroups.GetByCodeAsync(dummyProdGroup.Code)).ReturnsAsync(dummyProdGroup);
            var invalidProdModel = new ProductGroupSaveDTO() { Code = "", Name = "", Description = "" };
            
            //Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _sut.CreateProductGroup(invalidProdModel));
            //Assert
            Assert.Contains("Name must not be empty", exception.Message);
            Assert.Contains("Code must not be empty", exception.Message);
            Assert.Contains("Description must not be empty", exception.Message);
        }
        [Fact]
        public async void CreateProductGroup_TestErrorMessages_WithIvalidModelLength()
        {
            //Arrange
            var dummyProdGroup = GetDummyProductGroup();
            _uowMock.Setup(x => x.ProductGroups.GetByCodeAsync(dummyProdGroup.Code)).ReturnsAsync(dummyProdGroup);
            var invalidProdModel = new ProductGroupSaveDTO() { Code = "AAAAAAAA"
                , Name = "MoreThan50CharsMoreThan50CharsMoreThan50Chars505050"
                , Description = "MoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreThan500CharsMoreT" 
            };
            
            //Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _sut.CreateProductGroup(invalidProdModel));
            //Assert
            Assert.Contains("Name must not exceed " + ProductGroup.NameMaxLength + " characters", exception.Message);
            Assert.Contains("Code must not exceed " + ProductGroup.CodeMaxLength + " characters", exception.Message);
            Assert.Contains("Description must not exceed " + ProductGroup.DescriptionMaxLength + " characters", exception.Message);
        }
        [Fact]
        public async void GetProductGroupByID_ShouldReturnProductGroup_WhenExists()
        {
            //Arrange
            var dummyProdGroup = GetDummyProductGroup();
            _uowMock.Setup(x => x.ProductGroups.GetByIDAsync(_testID))
              .ReturnsAsync(dummyProdGroup);

            //Act
            var prodGroupDTOResult = await _sut.GetProductGroupByID(_testID);

            //Assert
            CompareFullProductGroupToProductGroupDTO(dummyProdGroup, prodGroupDTOResult);
        }
        [Fact]
        public async void GetProductGroupByID_ShouldReturnNull_WhenNotExists()
        {
            //Arrange
            _uowMock.Setup(x => x.ProductGroups.GetByIDAsync(_testID))
              .ReturnsAsync((ProductGroup)null);

            //Act
            var prodGroupDTOResult = await _sut.GetProductGroupByID(_testID);

            //Assert
            Assert.Null(prodGroupDTOResult);
        }
        [Fact]
        public async void GetProductGroupByCode_ShouldReturnProductGroup_WhenExists()
        {
            //Arrange
            var dummyProdGroup = GetDummyProductGroup();
            _uowMock.Setup(x => x.ProductGroups.GetByCodeAsync(_testCode))
                .ReturnsAsync(dummyProdGroup);
            
            //Act
            var prodGroupDTOResult = await _sut.GetProductGroupByCode(_testCode);
            
            //Assert
            CompareFullProductGroupToProductGroupDTO(dummyProdGroup, prodGroupDTOResult);
        }
        [Fact]
        public async void GetProductGroupByCode_ShouldReturnNull_WhenNotExists()
        {
            //Arrange
            _uowMock.Setup(x => x.ProductGroups.GetByCodeAsync(_testCode))
                .ReturnsAsync((ProductGroup)null);

            //Act
            var prodGroupDTOResult = await _sut.GetProductGroupByCode(_testCode);

            //Arrange
            Assert.Null(prodGroupDTOResult);
        }

        private ProductGroupDTO GetDummyProductGroupDTO()
        {
            return new ProductGroupDTO { ID = _testID, Name = _testName, Code = _testCode, Description = _testDesc, IsVisible = _testVis };
        }
        private ProductGroup GetDummyProductGroup()
        {
            return new ProductGroup {ID = _testID, Name = _testName, Code = _testCode, Description = _testDesc, IsVisible = _testVis};
        }
        private ProductGroupSaveDTO GetDummyProductGroupSaveDTO()
        {
            return new ProductGroupSaveDTO { Name = _testName, Code = _testCode, Description = _testDesc, IsVisible = _testVis };
        }
        private void CompareFullProductGroupToProductGroupDTO(ProductGroup expected, ProductGroupDTO actual)
        {
            Assert.Equal(expected.Code, actual.Code);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.ID, actual.ID);
            Assert.Equal(expected.IsVisible, actual.IsVisible);
        }
        private readonly ProductGroupService _sut;
        private readonly Mock<IUnitOfWork> _uowMock = new Mock<IUnitOfWork>();
        private readonly int _testID = 20;
        private readonly string _testName = "Test Name";
        private readonly string _testCode = "TCode";
        private readonly string _testDesc = "TDesc";
        private readonly bool _testVis = false;
    }
}
