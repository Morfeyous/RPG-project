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

    public int DmgAddItem()
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
public class weapon
{
    public string WpnName { get; set; }
    public int DamageBonus { get; set; }

    public int Hitbonus { get; set; }

    public weapon() { }

    public weapon(string wpnid, int dmgbon, int hitbon)
    {
        WpnName = wpnid;
        DamageBonus = dmgbon;
        Hitbonus = hitbon;
    }
    public int DmgAdd()
    {
        int DamageAdd = DamageBonus;
        return DamageAdd;

    }



}
class Weaponlist
{
    public static List<weapon> Weaponlists = new List<weapon>();


    public static void Iteminfo()
    {
        Items stick = new Items("Stick", 5, 0, 0);
        Itemlistsystem.Itemlist.Add(stick);
    }
}

public class Money
{
    public int Gold { get; set; }

    public Money() { }

    public Money(int golda)
    {
        Gold = golda;
    }


}

