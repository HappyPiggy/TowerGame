using System;
using System.Collections.Generic;
using System.Text;

public class Tile
{
    public int X;
    public int Y;
    public bool CanHold;
    public object data;

   public Tile(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}