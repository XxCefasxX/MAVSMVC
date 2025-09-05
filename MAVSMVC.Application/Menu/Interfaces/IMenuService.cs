using MAVSMVC.Application.Common.Responses;

public interface IMenuService
{
    Task<Response<MenuDto>> GetMenuByIdAsync(int id);
    Task<Response<MenuContentDto>> GetContentByMenuIdAsync(int menuId);
    Task<Response<MenuDto>> UpdateMenuAsync(MenuDto dto);
    Task<Response<MenuContentDto>> UpdateContentAsync(MenuContentDto dto);
    Task<Response<MenuDto>> CreateAsync(CreateMenuDto dto);
}
