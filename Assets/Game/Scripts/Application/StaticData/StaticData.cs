using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticData : Singleton<StaticData>
{
    Dictionary<int, LuoboInfo> m_Luobos = new Dictionary<int, LuoboInfo>();
    Dictionary<int, MonsterInfo> m_Monsters = new Dictionary<int, MonsterInfo>();

    protected override void Awake()
    {
        base.Awake();


        //一般项目中 这些数据应该由策划完成
        //需要用工具类将这些数据转换成类
        InitMonsters();
        InitLuobos();
        InitTowers();
        InitBullets();
    }

    void InitMonsters()
    {
        //m_Monsters.Add(0, new MonsterInfo() { Hp = 1, MoveSpeed = 1.5f });
        //m_Monsters.Add(1, new MonsterInfo() { Hp = 2, MoveSpeed = 1f });
        //m_Monsters.Add(2, new MonsterInfo() { Hp = 5, MoveSpeed = 1f });
        //m_Monsters.Add(3, new MonsterInfo() { Hp = 10, MoveSpeed = 1f });
        //m_Monsters.Add(4, new MonsterInfo() { Hp = 10, MoveSpeed = 1f });
        //m_Monsters.Add(5, new MonsterInfo() { Hp = 100, MoveSpeed = 0.5f });

        m_Monsters.Add(0, new MonsterInfo() { ID = 0, Hp = 1, MoveSpeed = 5f });
        m_Monsters.Add(1, new MonsterInfo() { ID = 1, Hp = 2, MoveSpeed = 5f });
        m_Monsters.Add(2, new MonsterInfo() { ID = 2, Hp = 5, MoveSpeed = 5f });
        m_Monsters.Add(3, new MonsterInfo() { ID = 3, Hp = 10, MoveSpeed = 5f });
        m_Monsters.Add(4, new MonsterInfo() { ID = 4, Hp = 10, MoveSpeed = 5f });
        m_Monsters.Add(5, new MonsterInfo() { ID = 5, Hp = 100, MoveSpeed = 5f });
    }

    void InitLuobos()
    {
        m_Luobos.Add(0, new LuoboInfo() { ID = 0, Hp = 4 });
    }


    public LuoboInfo GetLuoboInfo()
    {
        return m_Luobos[0];
    }


    public MonsterInfo GetMonsterInfo(int monsterType)
    {
        return m_Monsters[monsterType];
    }

    void InitTowers()
    {

    }

    void InitBullets()
    {

    }
}