using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Sound:Singleton<Sound>
{
    protected override void Awake()
    {
        base.Awake();


        //创建音效播放器和bg播放器
        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_bgSound.loop = true;
        m_bgSound.playOnAwake = false;

        m_effectSound = this.gameObject.AddComponent<AudioSource>();

    }

    

    public string ResourceDir = "";
    
    AudioSource m_bgSound;
    AudioSource m_effectSound;


    //音乐大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }

    //音效大小
    public float EffectVolume
    {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }
    }

    //音乐打开
    public void PlayBg(String audioName)
    { 


            //音乐文件路径
            string path;

            if (string.IsNullOrEmpty(ResourceDir))
                path = "";
            else
                path = ResourceDir + "/" + audioName;    

            //加载音频
            AudioClip clip = Resources.Load<AudioClip>(path);


            //播放音乐
            if (clip != null)
                m_effectSound.PlayOneShot(clip);
        
    }

    //音乐关闭
    public void StopBg() {
        m_bgSound.Stop();
        m_bgSound.clip = null;
    }

    //音效打开

    public void PlayEffect(String audioName)
    {
        //如果当前音乐和要播放音乐相同则不理会
        string oldName;
        if (m_bgSound.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_effectSound.clip.name;
        }

        if (audioName != oldName)
        {

            //音乐文件路径
            string path;

            if (string.IsNullOrEmpty(ResourceDir))
                path = "";
            else
                path = ResourceDir + "/" + audioName;

            //加载音频
            AudioClip clip = Resources.Load<AudioClip>(path);


            //播放音乐
            if (clip != null)
            {

                m_effectSound.clip = clip;
                m_effectSound.Play();
            }
        }
    }




}
