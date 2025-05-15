public interface IMenuContentRepository
{
    Task<MenuContent?> GetByMenuIdAsync(int menuId);
    Task UpdateAsync(MenuContent content);
    Task<MenuContent> CreateAsync(MenuContent content);
}
