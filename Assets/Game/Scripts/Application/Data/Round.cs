using System;
using System.Collections.Generic;
using System.Text;

public class Round
{
    public int Monster;//怪物对应的ID
    public int Count;

  public  Round(int id, int count)
    {
        this.Monster = id;
        this.Count = count;
    }
}
