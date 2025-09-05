using Microsoft.AspNetCore.Mvc;

public class MenuController : Controller
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await _menuService.CreateAsync(dto);
        TempData["SuccessMessage"] = "Elemento de menú creado correctamente.";
        return RedirectToAction("create"); 
    }


    public async Task<IActionResult> Edit(int id)
    {
        var menu = await _menuService.GetMenuByIdAsync(id);
        var content = await _menuService.GetContentByMenuIdAsync(id);

        if (menu == null || content == null)
            return NotFound();

        var viewModel = new MenuEditViewModel
        {
            Menu = menu.Data,
            Content = content.Data
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MenuEditViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _menuService.UpdateMenuAsync(model.Menu);
        await _menuService.UpdateContentAsync(model.Content);

        return RedirectToAction("Edit", new { id = model.Menu.ID });
    }
}
