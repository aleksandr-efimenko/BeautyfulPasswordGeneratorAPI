static class RandomChoices
{
    public static string Choice(this Random rnd, IEnumerable<string> choices, IEnumerable<int> weights)
    {
        var cumulativeWeight = new List<int>();
        int last = 0;
        foreach (var cur in weights)
        {
            last += cur;
            cumulativeWeight.Add(last);
        }
        int choice = rnd.Next(last);
        int i = 0;
        foreach (var cur in choices)
        {
            if (choice < cumulativeWeight[i])
            {
                return cur;
            }
            i++;
        }
        return null;
    }
}