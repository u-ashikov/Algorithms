using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var result = new Dictionary<int, int>();
        coins = coins.OrderByDescending(c => c).Distinct().ToList();
        int index = 0;
        int currentSum = 0;

        while (index < coins.Count && currentSum < targetSum)
        {
            var currentCoin = coins[index];
            var coinsCount = (targetSum - currentSum) / currentCoin;
            var currentCoinsSum = currentCoin * coinsCount;

            index++;

            if (coinsCount > 0 && currentSum + currentCoinsSum <= targetSum)
            {
                result[currentCoin] = coinsCount;
                currentSum += currentCoinsSum;
            }
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}