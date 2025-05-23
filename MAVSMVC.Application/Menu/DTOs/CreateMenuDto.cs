
public class CreateMenuDto
{
    public string Name { get; set; } = null!;
    public byte Lang { get; set; }
    public string? KeyWords { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? MenuPadre { get; set; }
    public bool Visible { get; set; }
    public byte Position { get; set; }
    public string? StaticForm { get; set; }
    public string Slug { get; set; } = null!;
}

