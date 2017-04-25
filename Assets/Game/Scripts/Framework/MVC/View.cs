using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


//只有继承monobehavior才能绑定在游戏物体上
public abstract class View:MonoBehaviour
{
    //抽象属性..
    public abstract string Name { get; }

    //存储view关注的事件
    [HideInInspector]
    public List<string> AttentionEvents = new List<string>();

    //处理事件
    public abstract void HandleEvent(string eventName, object data);

    //ps:抽象函数子类必须去实现，虚函数子类可以不实现
    //这里每个子类（View效果的类）必须能做到有处理事件的能力，所以用抽象
    //注册关心的事件就不是子类必须的了

    //注册关心的事件
    public virtual void RegisterEvents()
    {

    }

    //获取模型
    protected T GetModel<T>()
        where T : Model
    {
        return MVC.GetModel<T>();
    }


    //发送消息

    protected void SendEvent(string eventName,object data=null)
    {
        MVC.SendEvent(eventName,data);
    }
}