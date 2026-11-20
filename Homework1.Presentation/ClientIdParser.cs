namespace Homework1.Presentation;

public class ClientIdParser
{
    public IEnumerable<(string Input, long? ClientId)> Parse(string input)
    {
        var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var value in values)
        {
            if (long.TryParse(value, out long clientId))
            {
                yield return (value, clientId);
            }
            else
            {
                yield return (value, null);
            }
        }
    }
}
