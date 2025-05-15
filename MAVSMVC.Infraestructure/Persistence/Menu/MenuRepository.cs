

using Microsoft.EntityFrameworkCore;

public class MenuRepository : IMenuRepository
{
    private readonly ApplicationDbContext _context;

    public MenuRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async public Task<Menu> CreateAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
        await _context.SaveChangesAsync();
        return menu;
    }

    async public Task<List<Menu>> GetAllAsync()
    {
        return await _context.Menus.OrderBy(m => m.Position).ToListAsync();
    }

    async  public Task<Menu?> GetByIdAsync(int id)
    {
         return await _context.Menus.FindAsync(id);
    }

    async public Task<Menu?> GetBySlugAsync(string slug)
    {
        return await _context.Menus.FirstOrDefaultAsync(m => m.Slug == slug);
    }

   async public Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }
}

