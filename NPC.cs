// Author: Nick Eekhof
// Description: This class extends a mobile object to implement an NPC

public class NPC : MobileObject
{
    // Fields
    private float tLength, hHeight, lLength, aLength, mass, height;
    
    // Properties which ensure proper values are set
    public float TLength
    {
        get { return this.tLength; }
        set
        {
            if (value >= 0)
                this.tLength = value;
            else
                this.tLength = 0;
        }
    }

    public float HHeight
    {
        get { return this.hHeight; }
        set
        {
            if (value >= 0)
                this.hHeight = value;
            else
                this.hHeight = 0;
        }
    }

    public float LLength
    {
        get { return this.lLength; }
        set
        {
            if (value >= 0)
                this.lLength = value;
            else
                this.lLength = 0;
        }
    }

    public float ALength
    {
        get { return this.aLength; }
        set
        {
            if (value >= 0)
                this.aLength = value;
            else
                this.aLength = 0;
        }
    }

    public float Mass
    {
        get { return this.mass; }
        set
        {
            if (value >= 0)
                this.mass = value;
            else
                this.mass = 0;
        }
    }

    public float Height
    {
        get { return height; }
    }

    // NPC constructor
    public NPC(string name, int id, Position pos, float torso, float head, float leg, float arm, float mass) : base(name, id, pos)
    {
        this.TLength = torso;
        this.HHeight = head;
        this.LLength = leg;
        this.ALength = arm;
        this.Mass = mass;
        calcHeight();
    }

    // Calculates the NPC's height
    private void calcHeight()
    {
        this.height = this.ALength + this.ALength + this.ALength;
    }

    // Overridden ToString Method
    public override string ToString()
    {
       return "Name: " + this.Name + "\nID: " + this.ID + "\nPosition: " + Pos.ToString() + "\nTorso: " + this.TLength
            + "\nHead: " + this.HHeight + "\nLeg: " + this.LLength + "\nArm: " + this.ALength + "\nMass: " + this.Mass
            + "\nTotal Height: " + this.Height + "\nCellID: " + base.CellID + "\n";
    }
}