public class Menu
{
    public int ID { get; set; }
    public string Name { get; set; }
    public byte Lang { get; set; }
    public string? KeyWords { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? MenuPadre { get; set; }
    public bool Visible { get; set; }
    public byte Position { get; set; }
    public string? StaticForm { get; set; }
    public DateTime? LastUpdate { get; set; }
    public string Slug { get; set; }

    public ICollection<MenuContent> Contents { get; set; }
}
