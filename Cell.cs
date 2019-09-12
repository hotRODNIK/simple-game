// Author: Nick Eekhof
// Description: This class implements a cell

using System;
using System.Collections.Generic;
public class Cell
{
    // Fields
    private Position pos;
    private string id;
    public List<MobileObject> obj = new List<MobileObject>();

    // Properties
    public string ID
    {
        get { return id; }
    }

    public Position Pos {
        get { return pos; }
    }

    public ref List<MobileObject> Obj
    {
        get { return ref obj; }
    }

    // Cell Constructor
    public Cell(string id, float x, float y, float z)
    {
        this.pos = new Position(x, y, z); 
        this.id = id;
    }

    public void PrintCell()
    {
        foreach (var element in obj)
            Console.WriteLine("Objects on Cell: " + element.Name);
    }
}