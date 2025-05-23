public interface IMenuRepository
{
    Task<Menu?> GetByIdAsync(int id);
    Task<Menu?> GetBySlugAsync(string slug);
    Task<List<Menu>> GetAllAsync();
    Task UpdateAsync(Menu menu);
    Task<Menu> CreateAsync(Menu menu);
}
