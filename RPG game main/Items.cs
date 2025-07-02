namespace RPG;

public class Items
{
    public int DamageBonus { get; set; }
    public string ItemType { get; set; }
    public int ItemAC { get; set; }
    public int ItemHeal { get; set; }

    public Items() { }

    public Items(string itemtype, int itemdmgbonus, int itemacbonus, int itemheal)
    {
        DamageBonus = itemdmgbonus;
        ItemType = itemtype;
        ItemAC = itemacbonus;
        ItemHeal = itemheal;
    }

    public int DmgAdd()
    {
        int DamageAdd = DamageBonus;
        return DamageAdd;
    }

    public int AcAdd()
    {
        int acadded = ItemAC;
        return acadded;
    }
    public int heal()
    {
        int hphealed = ItemHeal;
        return hphealed;
    }
    public string ItemName()
    {
        string itemname = ItemType;
        return itemname;
    }





}

class Itemlistsystem
{
    public static List<Items> Itemlist = new List<Items>();


    public static void Iteminfo()
    {
        Items stick = new Items("Stick", 5, 0, 0);
        Itemlistsystem.Itemlist.Add(stick);
    }
}