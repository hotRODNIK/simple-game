// Author: Nick Eekhof
// Description: This class extends mobile object to implement a Vehicle

public class Vehicle : MobileObject
{
    // Fields
    private float length, height, width, mass, bVolume;
    private int wheels;

    // Properties which ensure valid values are set
    public float Length
    {
        get { return this.length; }
        set
        {
            if (value >= 0)
                this.length = value;
            else
                this.length = 0;
        }
    }

    public float Height
    {
        get { return this.height; }
        set
        {
            if (value >= 0)
                this.height = value;
            else
                this.height = 0;
        }
    }

    public float Width
    {
        get { return this.width; }
        set
        {
            if (value >= 0)
                this.width = value;
            else
                this.width = 0;
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

    public int Wheels
    {
        get { return this.wheels; }
        set
        {
            if (value >= 0)
                this.wheels = value;
            else
                this.wheels = 0;
        }
    }

    public float BVolume
    {
        get { return this.bVolume; }
    }

    // Vehicle Constructor
    public Vehicle(string name, int id, Position pos, float l, float h, float w, float m, int wh) : base(name, id, pos)
    {
        this.Length = l;
        this.Height = h;
        this.Width = w;
        this.Mass = m;
        this.Wheels = wh;
        calcBoundVolume();
    }

    // Calculates the Bounding Volume
    private void calcBoundVolume()
    {
        this.bVolume = this.Length * this.Height * this.Width;
    }

    // Overridden ToString Method
    public override string ToString()
    {
        return "Name: " + this.Name + "\nID: " + this.ID + "\nPosition: " + Pos.ToString() + "\nLength: " + this.Length
            + "\nHeight: " + this.Height + "\nWidth: " + this.Width + "\nMass: " + this.Mass + "\nNumber of Wheels: " + this.Wheels
            + "\nBounding Volume: " + this.BVolume + "\nCellID: " + base.CellID + "\n";
    }
}