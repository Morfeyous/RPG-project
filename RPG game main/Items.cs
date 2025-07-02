namespace RPG;

class Weapons
{
    public int DamageBonus { get; set; }

    public Weapons() { }

    public Weapons(int DmgBonus)
    {
        DamageBonus = DmgBonus;

    }

    public int DmgAdd()
    {
        int DamageAdd = DamageBonus;
        return DamageAdd;
    }



}