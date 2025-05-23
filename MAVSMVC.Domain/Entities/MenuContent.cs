public class MenuContent
{
    public int ID { get; set; }
    public string Info { get; set; }
    public int MenuID { get; set; }
    public DateTime? LastUpdate { get; set; }

    public Menu Menu { get; set; }
}
