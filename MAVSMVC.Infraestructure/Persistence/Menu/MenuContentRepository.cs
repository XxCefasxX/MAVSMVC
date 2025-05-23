

using Microsoft.EntityFrameworkCore;

public class MenuContentRepository : IMenuContentRepository
{
    private readonly ApplicationDbContext _context;

    public MenuContentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    async public Task<MenuContent> CreateAsync(MenuContent content)
    {
        await _context.MenuContents.AddAsync(content);
        await _context.SaveChangesAsync();
        return content;
    }

    public async Task<MenuContent?> GetByMenuIdAsync(int menuId)
    {
        return await _context.MenuContents
            .FirstOrDefaultAsync(m => m.MenuID == menuId);
    }

    public async Task UpdateAsync(MenuContent content)
    {
        _context.MenuContents.Update(content);
        await _context.SaveChangesAsync();
    }
}

