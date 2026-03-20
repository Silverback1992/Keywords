namespace Keywords.Base;

public class EnergyDrinkLover : Human
{
    public void DrinkEnergyDrink()
    {
        base.Drink();
        Console.WriteLine("an energy drink");
    }
}
