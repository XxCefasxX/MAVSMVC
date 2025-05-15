public interface IMenuService
{
    Task<MenuDto?> GetMenuByIdAsync(int id);
    Task<MenuContentDto?> GetContentByMenuIdAsync(int menuId);
    Task UpdateMenuAsync(MenuDto dto);
    Task UpdateContentAsync(MenuContentDto dto);
    Task CreateAsync(CreateMenuDto dto);
}
