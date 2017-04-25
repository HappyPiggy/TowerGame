using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


//MVC核心
public static class MVC
{
    //储存mvc
    public  static  Dictionary<string,Model>Models    =new Dictionary<string, Model>();
    public static Dictionary<string, View> Views      = new Dictionary<string, View>();
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();





    //注册（存入）
    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterView(View view)
    {
        //防止重复注册
        if (Views.ContainsKey(view.Name))
            Views.Remove(view.Name);

        //注册该view所关心的事件
        view.RegisterEvents();

        //缓存
        Views[view.Name] = view;
    }

    public static void RegisterController(string eventName,Type controllerType)
    {
        CommandMap[eventName] = controllerType;
    }


    //获取
    public static T GetModel<T>()
        where T : Model
    {
        foreach (Model m in Models.Values)
        {
            if (m is T)
                return (T)m;
        }
        return null;
    }

    public static T GetView<T>()
        where T : View
    {
        foreach (View m in Views.Values)
        {
            if (m is T)
                return (T)m;
        }
        return null;
    }
    


    //ps：事件（event）可以和命令（各种Command类）挂钩，也可以和视图（view类）挂钩
    //遍历命令，要找到对应的控制器(controller)
    //遍历视图，视图可以直接处理事件（view基类里有HeadEvent函数）

    //发送事件
    
    public static void SendEvent(string eventName,object data=null)
    {
        //控制器响应事件
        //根据名字找对应事件类型
        if (CommandMap.ContainsKey(eventName))
        {
            Type t = CommandMap[eventName];
            
            //根据类型生成一个controller实例 
            //t是Controller的子类 比如StartUpCommand等各种命令类
            //Controller基类里的Execute方法为抽象，子类去实现
            //所以这里虽然将子类t转换成父类的引用，调用的仍是子类重写的Execute
            Controller c = Activator.CreateInstance(t) as Controller;
            c.Execute(data);  //执行后就不用了，不需要保留它的对象
        }
       
       
       

        //视图响应事件
        foreach (View v in Views.Values)
        {
            if (v.AttentionEvents.Contains(eventName))
            {
                v.HandleEvent(eventName,data);
            }
        }
    }

}