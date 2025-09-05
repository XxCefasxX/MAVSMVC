using MAVSMVC.Application.Common.Responses;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepo;
    private readonly IMenuContentRepository _contentRepo;

    public MenuService(IMenuRepository menuRepo, IMenuContentRepository contentRepo)
    {
        _menuRepo = menuRepo;
        _contentRepo = contentRepo;
    }


    public async Task<Response<MenuDto>> CreateAsync(CreateMenuDto dto)
    {
        try
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

            var menuDto = new MenuDto { ID = createdMenu.ID, Name = createdMenu.Name, Slug = createdMenu.Slug };
            return Response<MenuDto>.Ok(menuDto, "Menú creado correctamente.");
        }
        catch (Exception ex)    
        {
            return Response<MenuDto>.Fail("Ocurrió un error", new List<string> { ex.Message });
        }
    }

    public async Task<Response<MenuDto>> GetMenuByIdAsync(int id)
    {
        try
        {
            var menu = await _menuRepo.GetByIdAsync(id);

            if (menu is null)
                return Response<MenuDto>.Fail($"No se encontró un menú con el id: {id}.");

            MenuDto menuDto = new MenuDto
            {
                ID = menu.ID,
                Name = menu.Name,
                Title = menu.Title,
                Description = menu.Description,
                Slug = menu.Slug,
                Visible = menu.Visible
            };
            return Response<MenuDto>.Ok(menuDto, "Menú encontrado correctamente.");
        }
        catch (Exception ex) 
        {
            return Response<MenuDto>.Fail("Ocurrió un error inesperado", new List<string> { ex.Message });
        }
    }

    public async Task<Response<MenuContentDto>> GetContentByMenuIdAsync(int menuId)
    {
        try
        {
            var content = await _contentRepo.GetByMenuIdAsync(menuId);
            if (content is null)
                return Response<MenuContentDto>.Fail($"No se encontró un menú con el id: {menuId}.");

            MenuContentDto menuContentDto = new MenuContentDto
            {
                ID = content.ID,
                MenuID = content.MenuID,
                Info = content.Info
            };
            return Response<MenuContentDto>.Ok(menuContentDto, "Contenido encontrado correctamente.");
        }
        catch (Exception ex) 
        {
            return Response<MenuContentDto>.Fail("Ocurrió un error inesperado", new List<string> { ex.Message });
        }
    }

    public async Task<Response<MenuDto>> UpdateMenuAsync(MenuDto dto)
    {
        try
        {
            var menu = await _menuRepo.GetByIdAsync(dto.ID);
            if (menu is null)
                return Response<MenuDto>.Fail($"No se encontró un menú con el id: {dto.ID}.");

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
            return Response<MenuDto>.Ok(dto, "Contenido encontrado correctamente.");
        }
        catch (Exception ex)
        {
            return Response<MenuDto>.Fail("Ocurrió un error inesperado", new List<string> { ex.Message });
        }
    }

    public async Task<Response<MenuContentDto>> UpdateContentAsync(MenuContentDto dto)
    {
        try
        {
            var content = await _contentRepo.GetByMenuIdAsync(dto.MenuID);
            if (content is null)
                return Response<MenuContentDto>.Fail($"No se encontró un menú con el id: {dto.MenuID}.");

            if (content != null)
            {
                content.Info = dto.Info;
                content.LastUpdate = DateTime.UtcNow;

                await _contentRepo.UpdateAsync(content);
            }
            return Response<MenuContentDto>.Ok(dto, "Contenido encontrado correctamente.");
        }
        catch (Exception ex)
        {
            return Response<MenuContentDto>.Fail("Ocurrió un error inesperado", new List<string> { ex.Message });
        }
    }
}
