// Author: Nick Eekhof
// Description: This is simply the main program which makes everything work

using System;
using System.Collections.Generic;
public static class MainClass
{
    public static void Main()
    {
        // Variables and objects required for program run-time
        Grid g = new Grid(10);
        List<MobileObject> mobs = new List<MobileObject>();
        mobs.Add(new NPC("Nick Eekhof", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3));
        mobs.Add(new NPC("Bill Eekhof", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3));
        mobs.Add(new NPC("Tracey Eekhof", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3));
        mobs.Add(new NPC("Sri", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3));
        mobs.Add(new Vehicle("Dodge Charger R/T", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4));
        mobs.Add(new Vehicle("Chevy Camaro SS", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4));
        mobs.Add(new Vehicle("BMW 3-Series", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4));
        mobs.Add(new Vehicle("Toyota Matrix", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4));
        string input = "A";
        MobileObject[] arr = new MobileObject[8];
        arr[0] = new NPC("Bill Smith", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3);
        arr[1] = new NPC("Joe Collins", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3);
        arr[2] = new NPC("Jim Finnigan", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3);
        arr[3] = new NPC("Brian Jury", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 3, 4, 2, 1, 3);
        arr[4] = new Vehicle("Pontiac GTO", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4);
        arr[5] = new Vehicle("Chevy Corvette", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4);
        arr[6] = new Vehicle("Toyota Supra", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4);
        arr[7] = new Vehicle("Olds 88", RNG.getRandom(1, 1000), new Position(RNG.getRandom(1, 99), RNG.getRandom(1, 99), RNG.getRandom(1, 99)), 5, 2, 3, 1000, 4);

        // Ridiculous opening
        Console.WriteLine("Welcome, strike any key to continue.");
        Console.ReadKey();
        Console.WriteLine("If you actually tried to look for a key called any, you might be in the wrong place. Strike any key to proceed.");
        Console.ReadKey();

        // Run program logic provided the user doesn't want to quit
        while (input.ToUpper() != "Q")
        {
            // Prompt user to do something
            Console.Write("'PL' - Print list Mobile Objects, 'PA' - Print array of mobile objects 'C'reate a new object, 'M'ove an existing object," +
                "'R'andomize array, 'PG' - Print the Grid, or 'Q'uit => ");
            input = Console.ReadLine();
            input = input.ToUpper();

            // Do something based on the input
            switch (input.ToUpper())
            {
                case "PG":
                    g.PrintGrid();
                    break;
                case "PL":
                    // Call the print function
                    Print(mobs);
                    break;
                case "PA":
                    // Call the print function
                    PrintArr(arr);
                    break;
                case "C":
                    // Call the create function
                    Create(mobs, ref arr);
                    break;
                case "M":
                    // Call the move function
                    Move(mobs, arr);
                    break;
                case "R":
                    // Call the randomize function
                    arr = RandomizeArr(arr);
                    break;
                case "Q":
                    // Do nothing, loop will handle it
                    break;
                default:
                    // Ridiculous Error Message
                    Console.WriteLine("Invalid Input... do you need to have your eyes checked?");
                    break;
            }
        }
    }

    // Function Handles Move Logic
    public static void Move(List<MobileObject> mobs, MobileObject [] arr)
    {
        // Required Variables
        string input;
        NPC n = null;
        Vehicle v = null;
        bool valid = false;
        float x = 0, y = 0, z = 0;
        int index = 0;
        string id = null;

        // Move logic 
        while (!valid)
        {
            // Prompt the user to enter a valid ID, then search both lists for the Object
            Console.WriteLine("Please enter a valid object ID => ");
            id = Console.ReadLine();

            // Extract from the list
            for (int i = 0; i < arr.Length; ++i)
            {
                var item = arr[i];
                if (id.Equals(Convert.ToString(item.ID)))
                {
                    // Remove the item from the array, and store it
                    if (item.GetType().ToString().Equals("NPC"))
                    {
                        n = (NPC)item;
                        arr[i] = null;
                        index = i;
                        valid = true;
                        break;
                    }
                    else if (item.GetType().ToString().Equals("Vehicle"))
                    {
                        v = (Vehicle)item;
                        arr[i] = null;
                        index = i;
                        valid = true;
                        break;
                    }
                }
            }
            
            // Extract from the list
            foreach (var element in mobs)
            {
                if (id.Equals(Convert.ToString(element.ID)))
                {
                    // Remove the item from the list, and store it
                    if (element.GetType().ToString().Equals("NPC"))
                    {
                        n = (NPC)element;
                        mobs.Remove(n);
                        valid = true;
                        break;
                    }
                    else if (element.GetType().ToString().Equals("Vehicle"))
                    {
                        v = (Vehicle)element;
                        mobs.Remove(v);
                        valid = true;
                        break;
                    }
                }
            }
        }
        valid = false;

        // Prompt the user for x,y,z positions
        while (!valid)
        {
            try
            {
                Console.WriteLine("Please enter an X position => ");
                input = Console.ReadLine();
                x = (float)Convert.ToDouble(input);
                Console.WriteLine("Please enter a Y position => ");
                input = Console.ReadLine();
                y = (float)Convert.ToDouble(input);
                Console.WriteLine("Please enter a Z position => ");
                input = Console.ReadLine();
                z = (float)Convert.ToDouble(input);
                valid = true;
            }
            catch (FormatException e)
            {
                // Handle any errors which may occur
                Console.WriteLine(e.Message);
                valid = false;
            }
        }
        valid = false;

        // If the object exists, set the new position, then add it back to the list
        if (v != null)
        {
            v.move(x, y, z);
            mobs.Add(v);
            arr[index] = v;
        }
        else if (n != null)
        {
            n.move(x, y, z);
            mobs.Add(n);
            arr[index] = n;
        }
    }

    // Prints off all of the objects and their properties
    public static void Print(List<MobileObject> mobs)
    {
        // Iterate through each list and print off each object's properties
        Console.WriteLine("List of MOBs");
        foreach (var element in mobs)
            Console.WriteLine(element.ToString());
    }

    public static void Create(List<MobileObject> mobs, ref MobileObject[] arr)
    {
        // Required Variables
        string input;
        NPC n = null;
        Vehicle v = null;
        int id, numWheels;
        float length, height, width, mass, tLength, hHeight, lLength, aLength;
        string name;
        float x, y, z;
        bool valid = false;
        Array.Resize(ref arr, arr.Length + 1);

        // Creation Logic - (So God made them all and He was pleased with what he saw - Genesis 1:25)
        Console.WriteLine("Create a 'V'ehicle, or 'N'PC? => ");
        input = Console.ReadLine();
        switch (input.ToUpper())
        {
            case "V":
                while (!valid)
                {
                    try
                    {
                        // Prompt the user for alot of input
                        Console.WriteLine("All invalid values will be set to zero be default.\nTo eliminate any undesired " +
                            "values, please ensure the value you enter is >=0. You will be prompted to enter a valid value." +
                            " If the prompt does not mention the need for a valid value, you may enter a value <0."
                            + " Press any key to continue.");
                        Console.ReadKey();
                        Console.WriteLine("Generated a unique ID");
                        id = RNG.getRandom(1,10000);
                        Console.WriteLine("Pleae enter a vehicle name => ");
                        input = Console.ReadLine();
                        name = input;
                        Console.WriteLine("Please enter an X position => ");
                        input = Console.ReadLine();
                        x = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a Y position => ");
                        input = Console.ReadLine();
                        y = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a Z position => ");
                        input = Console.ReadLine();
                        z = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid length => ");
                        input = Console.ReadLine();
                        length = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid width => ");
                        input = Console.ReadLine();
                        width = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid height => ");
                        input = Console.ReadLine();
                        height = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid mass => ");
                        input = Console.ReadLine();
                        mass = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid number of wheels => ");
                        input = Console.ReadLine();
                        numWheels = Convert.ToInt32(input);
                        valid = true;

                        // Create a new vehicle and add it to the list
                        v = new Vehicle(name, id, new Position(0, 0, 0), length, height, width, mass, numWheels);
                        mobs.Add(v);
                        v.move(x, y, z);
                        arr[arr.Length - 1] = v;
                        Console.WriteLine("Vehicle successfully created.");
                    }
                    catch (FormatException e)
                    {
                        // Handle any errors
                        valid = false; // I know this is mostly redundant, but just for safety's sake
                        Console.WriteLine(e.Message);
                    }
                }
                break;
            case "N":
                while (!valid)
                {
                    try
                    {
                        // Prompt the user for alot of input
                        Console.WriteLine("All invalid values will be set to zero be default.\nTo eliminate any undesired " +
                            "values, please ensure the value you enter is >=0. You will be prompted to enter a valid value." +
                            " If the prompt does not mention the need for a valid value, you may enter a value <0."
                            + " Press any key to continue.");
                        Console.ReadKey();
                        Console.WriteLine("Generated a unique ID");
                        id = RNG.getRandom(1, 10000);
                        Console.WriteLine("Pleae enter an NPC name => ");
                        input = Console.ReadLine();
                        name = input;
                        Console.WriteLine("Please enter an X position => ");
                        input = Console.ReadLine();
                        x = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a Y position => ");
                        input = Console.ReadLine();
                        y = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a Z position => ");
                        input = Console.ReadLine();
                        z = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid torso length => ");
                        input = Console.ReadLine();
                        tLength = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid head length => ");
                        input = Console.ReadLine();
                        hHeight = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid leg length => ");
                        input = Console.ReadLine();
                        lLength = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid arm length => ");
                        input = Console.ReadLine();
                        aLength = (float)Convert.ToDouble(input);
                        Console.WriteLine("Please enter a valid mass => ");
                        input = Console.ReadLine();
                        mass = (float)Convert.ToDouble(input);
                        valid = true;

                        // Create a new NPC and add it to the list
                        n = new NPC(name, id, new Position(0, 0, 0), tLength, hHeight, lLength, aLength, mass);
                        n.move(x, y, z);
                        mobs.Add(n);
                        arr[arr.Length - 1] = n;
                        Console.WriteLine("NPC successfully created.");
                    }
                    catch (FormatException e)
                    {
                        // Handle any errors
                        valid = false; // I know this is mostly redundant, but just for safety's sake
                        Console.WriteLine(e.Message);
                    }
                }
                break;
            default:
                // Ridiculous Error Message
                Console.WriteLine("Invalid Input... do you need to have your eyes checked?");
                break;
        }
    }
    
    public static void PrintArr(MobileObject [] arr)
    {
        for (int i = 0; i < arr.Length; ++i)
            Console.WriteLine(arr[i].ToString());
    }


    // Function randomizes the array by creating a new array
    // Part of the mini-challenge
    public static MobileObject[] RandomizeArr(MobileObject [] arr)
    {
        // Create a new array and two arrays of numbers
        MobileObject[] newArr = new MobileObject[arr.Length];
        int[] randOne = new int[arr.Length];
        int[] randTwo = new int[arr.Length];
        int arrLength = arr.Length;
        for (int i = 0; i < randOne.Length; ++i)
        {
            randOne[i] = i;
            randTwo[i] = i;
        }

        // Shuffle the arrays of numbers using Fisher Yates => Referred to Lecture 3, slide 36
        while (arrLength > 1)
        {
            int rNum = RNG.getRandomOneArg(--arrLength);
            int holder = randOne[arrLength];
            randOne[arrLength] = randOne[rNum];
            randOne[rNum] = holder;
        }

        while (arrLength > 1)
        {
            int rNum = RNG.getRandomOneArg(--arrLength);
            int holder = randTwo[arrLength];
            randTwo[arrLength] = randTwo[rNum];
            randTwo[rNum] = holder;
        }

        // Use the random indexes to transfer values randomly
        for (int i = 0; i < arr.Length; ++i)
            newArr[randOne[i]] = arr[randTwo[i]];

        return newArr;
    }
}