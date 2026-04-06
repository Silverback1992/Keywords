namespace Keywords.Virtual;

public class SavingsAccount : BankAccount
{
    private decimal _balance;

    public override decimal BalancingAmount
    {
        get => _balance;
        set
        {
            if (value < 100)
            {
                throw new ArgumentException("must be 100+");
            }

            _balance = value;
        }
    }
}
