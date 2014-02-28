<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

//A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
//
//A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
//
//As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
//
//Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

void Main()
{
  List<int> possibilities = new List<int>();
       
  foreach(var x in Abundants)
    foreach (var y in Abundants)
    {
      int currentVal = x+y;
      if (currentVal <= 28123)
        possibilities.Add(x+y);
    }
  
  Enumerable.Range(1,28123)
            .Except(possibilities.Distinct()).Dump()
            .Sum().Dump();
}

public IEnumerable<int> _abundants = null;
public IEnumerable<int> Abundants 
{
  get
  {
    if (_abundants == null)
      _abundants = Enumerable.Range(1,28123)
                             .Select(x => Tuple.Create(x, Divisors(x)))
                             .Where(x => x.Item2.Sum() > x.Item1)
                             .Select(x => x.Item1)
                             .ToList();
  
    return _abundants;
  }
}

public static IEnumerable<int> Divisors(int x)
{
  for (int i = 1; i < x; i++)
    if (x % i == 0)
      yield return i;
}