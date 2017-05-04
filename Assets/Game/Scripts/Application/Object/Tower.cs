using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class Tower : ReusbleObject
{
    #region 常量
    #endregion

    #region 事件

    #endregion

    #region 字段
    Animator m_Animator;
    [SerializeField]
    int m_Level;
    Monster m_Target = null;
    float m_lastShotTime = 0;
    #endregion

    #region 属性
    public Tile Tile { get; private set; }

    public int ID { get; private set; }

    public int Level
    {
        get { return m_Level; }
        set
        {
            m_Level = Mathf.Clamp(value, 0, MaxLevel);
            transform.localScale = Vector3.one * (1 + m_Level * 0.25f);
        }
    }
    public int MaxLevel { get; private set; }
    public bool IsTopLevel { get { return Level >= MaxLevel; } }
    public float ShotRate { get; private set; }
    public float GuardRange { get; private set; }
    private int BasePrice { get; set; }
    private int UseBulletID { get; set; }
    public int Price { get { return BasePrice * Level; } }
    #endregion

    #region 方法
    public virtual void Load(int towerID, Tile tile)
    {
        TowerInfo info = Game.Instance.StaticData.GetTowerInfo(towerID);
        MaxLevel = info.MaxLevel;
        ShotRate = info.ShotRate;
        BasePrice = info.BasePrice;
        GuardRange = info.GuardRange;
        UseBulletID = info.UseBulletID;
        Level = 1;

        Tile = tile;
    }

    protected virtual void Shot(Monster monster)
    {
        //print("test");
        m_Animator.SetTrigger("IsAttack");
    }

    public override void OnSpawn()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("Idle");
    }

    public override void OnUnspawn()
    {
        
        m_Animator = null;
        m_Target = null;
        m_lastShotTime = 0;

        Tile = null;

        Level = 0;
        MaxLevel = 0;
        ShotRate = 0;
        BasePrice = 0;
    }
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    void Update()
    {
        if (m_Target == null)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Monster");
            foreach (GameObject go in objects)
            {
                Monster monster = go.GetComponent<Monster>();

                if (!monster.IsDead && Vector3.Distance(transform.position, monster.transform.position) <= GuardRange)
                {
                    m_Target = monster;
                    break;
                }
            }
        }
        else
        {
            if (m_Target.IsDead || Vector3.Distance(transform.position, m_Target.transform.position) > GuardRange)
            {
                m_Target = null;
                LookAt(null);
                return;
            }

            //朝向目标
            LookAt(m_Target);

            //
            if (Time.time >= m_lastShotTime + 1f / ShotRate)
            {
                //创建子弹
                Shot(m_Target);

                //记录发射时间
                m_lastShotTime = Time.time;
            }
        }
    }
    #endregion

    #region 帮助方法
    void LookAt(Monster target)
    {
        if (target == null)
        {
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.z = 0;
            transform.eulerAngles = eulerAngles;
        }
        else
        {
            Vector3 vec = (target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(vec.y, vec.x);
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.z = angle * Mathf.Rad2Deg - 90;
            transform.eulerAngles = eulerAngles;
        }
    }
    #endregion
}