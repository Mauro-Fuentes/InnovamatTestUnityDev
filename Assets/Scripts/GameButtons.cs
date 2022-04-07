// Maybe this should be base class... or it should be an static... or go in controller?
public class GameButtons
{
    public int min;
    public int max;

    public bool ButtonHasAnAcceptableValue(int x, int y)
    {
        return (x - min) * (max - x) >= 0;
    }
}
