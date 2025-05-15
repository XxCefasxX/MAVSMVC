public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepo;
    private readonly IMenuContentRepository _contentRepo;

    public MenuService(IMenuRepository menuRepo, IMenuContentRepository contentRepo)
    {
        _menuRepo = menuRepo;
        _contentRepo = contentRepo;
    }


    public async Task CreateAsync(CreateMenuDto dto)
    {
        var menu = new Menu
        {
            Name = dto.Name,
            Lang = dto.Lang,
            KeyWords = dto.KeyWords,
            Title = dto.Title,
            Description = dto.Description,
            MenuPadre = dto.MenuPadre,
            Visible = dto.Visible,
            Position = dto.Position,
            StaticForm = dto.StaticForm,
            LastUpdate = DateTime.UtcNow,
            Slug = dto.Slug
        };

        var createdMenu = await _menuRepo.CreateAsync(menu);

        var content = new MenuContent
        {
            Info = "",
            MenuID = createdMenu.ID,
            LastUpdate = DateTime.UtcNow
        };

        await _contentRepo.CreateAsync(content);
    }

    public async Task<MenuDto?> GetMenuByIdAsync(int id)
    {
        var menu = await _menuRepo.GetByIdAsync(id);
        return menu == null ? null : new MenuDto
        {
            ID = menu.ID,
            Name = menu.Name,
            Title = menu.Title,
            Description = menu.Description,
            Slug = menu.Slug,
            Visible = menu.Visible
        };
    }

    public async Task<MenuContentDto?> GetContentByMenuIdAsync(int menuId)
    {
        var content = await _contentRepo.GetByMenuIdAsync(menuId);
        return content == null ? null : new MenuContentDto
        {
            ID = content.ID,
            MenuID = content.MenuID,
            Info = content.Info
        };
    }

    public async Task UpdateMenuAsync(MenuDto dto)
    {
        var menu = await _menuRepo.GetByIdAsync(dto.ID);
        if (menu != null)
        {
            menu.Name = dto.Name;
            menu.Title = dto.Title;
            menu.Description = dto.Description;
            menu.Slug = dto.Slug;
            menu.Visible = dto.Visible;
            menu.LastUpdate = DateTime.UtcNow;

            await _menuRepo.UpdateAsync(menu);
        }
    }

    public async Task UpdateContentAsync(MenuContentDto dto)
    {
        var content = await _contentRepo.GetByMenuIdAsync(dto.MenuID);
        if (content != null)
        {
            content.Info = dto.Info;
            content.LastUpdate = DateTime.UtcNow;

            await _contentRepo.UpdateAsync(content);
        }
    }
}
