using System;
using System.Collections.Generic;
using System.Text;

public class Level
{
    public string Name;
    public string CardImage;
    public string Background;
    public string Road;
    public int InitScore;
    public List<Point> Holder =new List<Point>();//能放置塔的位置
    public List<Point> Path=new List<Point>();//怪物走得路径
    public List<Round> Rounds=new List<Round>();


}
