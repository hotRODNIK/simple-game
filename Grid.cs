// Author: Nick Eekhof
// Description: This class implements the grid functionality

using System;
using System.Collections.Generic;
public class Grid
{
    // The Grid
    private static Cell[,] cellGrid;
    private static int gridSize;

    // Grid Property
    public Cell[,] CellGrid
    {
        get { return cellGrid; }
    }

    // Grid Constructor
    public Grid(int size)
    {
        // Data used for construction of the grid
        gridSize = size;
        float xPos, yPos;
        int id = 0;
        cellGrid = new Cell[size, size];

        // Iterate through the array and create new Cells, and CellIDs
        for (int i = 0; i < size; ++i)
        {
            yPos = i * 10.0F;
            for (int j = 0; j < size; ++j)
            {
                xPos = j * 10.0F;
                ++id;
                Grid.cellGrid[j, i] = new Cell(Convert.ToString(id), xPos, yPos, 0);
            }
        }
    }

    // Returns the cell ID when passed a position
    public static string GetCellID(Position pos)
    {
        // Extract the x and y coordinates
        int x, y;
        x = (int)Math.Floor(pos.X);
        y = (int)Math.Floor(pos.Y);

        // Calculate the specific array index at which the cell is located at
        if (x >= 0 && y >= 0)
        {
            x /= 10;
            y /= 10;
        }
        else
            return "Out of Bounds";

        // If the Cell is within the grid, return the CellID, else return a negative value to indicate the object is out of bounds
        if (x <= gridSize - 1 && y <= gridSize - 1)
            return cellGrid[x, y].ID;
        else
            return "Out of Bounds";
    }

    public static void AddToCell(MobileObject toAdd)
    {
        // Required variables
        string id = toAdd.CellID;
        float min, max;
        int sentinel = 0;
        MobileObject one, two;
        MobileObject[] sort;

        // Add object to the list, create an array to sort, and delete the list
        cellGrid[(int)toAdd.Pos.X / 10, (int)toAdd.Pos.Y / 10].Obj.Add(toAdd);
        sort = cellGrid[(int)toAdd.Pos.X / 10, (int)toAdd.Pos.Y / 10].Obj.ToArray();
        cellGrid[(int)toAdd.Pos.X / 10, (int)toAdd.Pos.Y / 10].Obj = null;


        // A Bubble Sort Algorithm I had written for 2300H (Assignment Four - Merge Two Arrays)
        // I had already written it and found it on my machine... repurposed it for this
        // Sorts the array
        if (sort.Length != 0)
        {
            while (sentinel != sort.Length - 1)
            {
                sentinel = 0;
                for (int i = 0; i < sort.Length - 1; ++i)
                {
                    // Get the data to sort and the z-index
                    min = sort[i].Pos.Z;
                    max = sort[i + 1].Pos.Z;
                    one = sort[i];
                    two = sort[i + 1];
                    ++sentinel;
                    if (min > max)
                    {
                        // If the one term is larger, swap them out
                        sort[i] = two;
                        sort[i + 1] = one;
                        sentinel = 0;
                    }
                }
            }
        }

        // Create a new list, and add the sorted elements back to it
        cellGrid[(int)toAdd.Pos.X / 10, (int)toAdd.Pos.Y / 10].Obj = new List<MobileObject>();
        foreach (var element in sort)
          cellGrid[(int)toAdd.Pos.X / 10, (int)toAdd.Pos.Y / 10].Obj.Add(element);
    }

    public static void RemoveFromCell(MobileObject toRemove)
    {
        // Required variables
        string id = toRemove.CellID;
        float min, max;
        int sentinel = 0;
        MobileObject one, two;
        MobileObject[] sort;

        // Remove object from the list, create an array to sort, then delete the list
        cellGrid[(int)toRemove.Pos.X / 10, (int)toRemove.Pos.Y / 10].Obj.Remove(toRemove);
        sort = cellGrid[(int)toRemove.Pos.X / 10, (int)toRemove.Pos.Y / 10].Obj.ToArray();
        cellGrid[(int)toRemove.Pos.X / 10, (int)toRemove.Pos.Y / 10].Obj = null;

        // A Bubble Sort Algorithm I had written for 2300H... I had already written it
        // and found it on my machine... repurposed it for this
        // Sorts the list
         if (sort.Length != 0)
         {
             while (sentinel != sort.Length - 1)
             {
                 sentinel = 0;
                 for (int i = 0; i < sort.Length - 1; ++i)
                 {
                     // Get the data to sort and the z-index
                     min = sort[i].Pos.Z;
                     max = sort[i + 1].Pos.Z;
                     one = sort[i];
                     two = sort[i + 1];
                     ++sentinel;
                     if (min > max)
                     {
                         // If the one z-index is larger, swap out the objects
                         sort[i] = two;
                         sort[i + 1] = one;
                         sentinel = 0;
                     }
                 }
             }
         }

        // Create a new list and add elements back to it
        cellGrid[(int)toRemove.Pos.X / 10, (int)toRemove.Pos.Y / 10].Obj = new List<MobileObject>();
        foreach (var element in sort)
            cellGrid[(int)toRemove.Pos.X / 10, (int)toRemove.Pos.Y / 10].Obj.Add(element);
    }

    // Overridden ToString Method
    public void PrintGrid()
    {
        // Iterate through the grid and print all properties
        for (int i = 0; i < gridSize; ++i)
        {
            for (int j = 0; j < gridSize; ++j)
            {
                Console.WriteLine("\nID: " + cellGrid[j, i].ID);
                cellGrid[j, i].PrintCell();
            }
        }
    }
}