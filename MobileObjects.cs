// Author: Nick Eekhof
// Description: This class defines a mobile object

public class MobileObject
{
    // Fields
    private string name;
    private int id;
    private Position pos;
    private string cellID;

    // Properties
    public string Name
    {
        get { return this.name; }
    }

    public int ID
    {
        get { return this.id; }
    }

    public Position Pos
    {
        get { return this.pos; }
    }

    public string CellID
    {
        get { return this.cellID; }
    }

    // MobileObject Constructor
    public MobileObject(string name, int id, Position pos)
    {
        this.name = name;
        this.id = id;
        this.pos = pos;
        this.cellID = Grid.GetCellID(this.pos);
        Grid.AddToCell(this);
    }

    // "Moves" a MobileObject
    public void move(float x, float y, float z)
    {
        // Set x,y,z to input values and calculate which cell we are on
        Grid.RemoveFromCell(this);
        this.pos.X = x;
        this.pos.Y = y;
        this.pos.Z = z;
        this.cellID = Grid.GetCellID(this.pos);
        Grid.AddToCell(this);
    }
}