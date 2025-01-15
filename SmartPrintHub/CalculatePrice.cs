public class CalculatePrice
{
    public float Calculate(float weight, string TipImprimanta)
    {
        if (TipImprimanta == "Filament")
        {
            return weight * 2f;
        }
        else if (TipImprimanta == "Resin")
        {
            return weight * 3f;
        }
        else
        {
            return -1;
        }
    }
}
