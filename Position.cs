// Author: Nick Eekhof
// Description: This class provdides a framework to keep track of an object's position

public class Position
{
    // Fields which hold the x, y, z position on the grid
    private float x, y, z;
   
    // X Position on the grid (Cartesian Coordinates obviously)
    public float X
    {
        get { return x; }
        set { x = value; }
    }

    // Y Position on the grid (Cartesian Coordinates obviously)
    public float Y
    {
        get { return y; }
        set { y = value; }
    }

    // Z Position on the grid (Cartesian Coordinates obviously)
    public float Z
    {
        get { return z; }
        set { z = value; }
    }

    // Position Constructor
    public Position(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    // Overridden ToString Method
    public override string ToString()
    {
        return "X:" + this.X + " Y:" + this.Y + " Z:" + this.Z;
    }
}