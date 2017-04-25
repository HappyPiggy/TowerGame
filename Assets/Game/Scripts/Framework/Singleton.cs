using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


//实例化 保存T类型的类 （泛型）
public abstract class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T m_instance = null;

    public static T Instance
    {
        get { return m_instance; }
    }


    //设置成virtual 子类可以重写  protect可以被继承到子类
    protected virtual void Awake()
    {
        m_instance = this as T;
    }
}