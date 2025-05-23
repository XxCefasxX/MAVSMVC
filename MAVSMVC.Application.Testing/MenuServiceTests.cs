using Moq;

public class MenuServiceTests
{
    [Fact]
    public async Task CreateAsync_Should_Create_Menu_And_Content()
    {
        // Arrange
        var menuRepoMock = new Mock<IMenuRepository>();
        var contentRepoMock = new Mock<IMenuContentRepository>();

        var fakeMenu = new Menu { ID = 1, Name = "Test", Slug = "test", Lang = 1 };
        var fakeContent = new MenuContent { ID = 1, MenuID = fakeMenu.ID, Info = "" };

        menuRepoMock
            .Setup(m => m.CreateAsync(It.IsAny<Menu>()))
            .ReturnsAsync(fakeMenu);

        contentRepoMock
            .Setup(c => c.CreateAsync(It.IsAny<MenuContent>()))
            .ReturnsAsync(fakeContent);

        var service = new MenuService(menuRepoMock.Object, contentRepoMock.Object);

        var dto = new CreateMenuDto
        {
            Name = "Test",
            Lang = 1,
            Slug = "test",
            MenuPadre = 0,
            Position = 1,
            Visible = true
        };

        // Act
        await service.CreateAsync(dto);

        // Assert
        menuRepoMock.Verify(m => m.CreateAsync(It.IsAny<Menu>()), Times.Once);
        contentRepoMock.Verify(c => c.CreateAsync(It.Is<MenuContent>(mc => mc.MenuID == 1 && mc.Info == "")), Times.Once);
    }
}
