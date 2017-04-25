using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public abstract class Controller
{
    public abstract void Execute(object data);

    //获取模型
    protected T GetModel<T>()
        where T : Model
    {
        return MVC.GetModel<T>();
    }

    //获取视图
    protected T GetView<T>()
    where T : View
    {
        return MVC.GetView<T>();
    }


    //注册模型
    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }

    //注册视图
    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }

    //注册控制器
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName,controllerType);
    }

}