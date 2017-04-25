using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class Luobo : Role
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    Animator m_Animator;
    #endregion

    #region 属性
    #endregion

    #region 方法
    public override void Damage(int hit)
    {
        if (IsDead)
            return;

        base.Damage(hit);
        m_Animator.SetTrigger("IsDamage");

        Debug.Log("Damage");
    }

    protected override void Die(Role role)
    {
        base.Die(role);
        m_Animator.SetBool("IsDead", true);
      //  Game.Instance.ObjectPool.Unspawn(luobo.gameObject);
        Debug.Log("Die");
    }

    public override void OnSpawn()
    {
        //初始化
        base.OnSpawn();
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("Idle");

        LuoboInfo info = Game.Instance.StaticData.GetLuoboInfo();
        MaxHp = info.Hp;
        Hp = info.Hp;
    }

    public override void OnUnspawn()
    {
        //还原
        base.OnUnspawn();
        m_Animator.SetBool("IsDead", false);
        m_Animator.ResetTrigger("IsDamage");
    }
    #endregion

    #region Unity回调
    #endregion

    #region 帮助方法
    #endregion
}