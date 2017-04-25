using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


//MVC入口
public abstract class ApplicationBase<T>:Singleton<T>
    where T:MonoBehaviour
{
    //注册控制器 
    //为了它的衍生类(Game) 可以将初startUpCommand注册进来
    protected void RegisterController(string eventName, Type type)
    {
        MVC.RegisterController(eventName,type);
    }

    //发送命令
    protected void SendEvent(string eventName,object data=null)
    {
        MVC.SendEvent(eventName,data);
    }
}
