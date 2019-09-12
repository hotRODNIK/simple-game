// Author: Nick Eekhof
// Description: This class provides a mechanism by which to generate random numbers
// by utilizing System.Random. A custom seed eliminates the lock statement

using System; 
public static class RNG
{
    // Instantiate the random class using a custom defined seed
    private static Random r = new Random(456);

    // Returns a random value within an upper and lower bound
    public static int getRandom(int low, int high)
    {
        return r.Next(low, high);
    }

    public static int getRandomOneArg(int num)
    {
        return r.Next(num);
    }
}