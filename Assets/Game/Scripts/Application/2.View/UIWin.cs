using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIWin : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    public Text txtCurrent;
    public Text txtTotal;
    public Button btnRestart;
    public Button btnContinue;
    #endregion

    #region 属性
    public override string Name
    {
        get { return Consts.V_Win; }
    }
    #endregion

    #region 方法
    public void Show()
    {
        this.gameObject.SetActive(true);

        RoundModel rm = GetModel<RoundModel>();
        UpdateRoundInfo(rm.RoundIndex + 1, rm.RoundTotal);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void UpdateRoundInfo(int currentRound, int totalRound)
    {
        txtCurrent.text = currentRound.ToString("D2");
        txtTotal.text = totalRound.ToString();
    }
    #endregion

    #region Unity回调
    void Awake()
    {
        UpdateRoundInfo(0, 0);
    }
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {

    }
    public void OnRestartClick()
    {
        GameModel gm = GetModel<GameModel>();
        SendEvent(Consts.E_StartLevel, new StartLevelArgs() { LevelIndex = gm.PlayLevelID });
    }
    public void OnContinueClick()
    {
        GameModel gm = GetModel<GameModel>();
        if (gm.PlayLevelID >= gm.LevelCount - 1)
        {
            //游戏通关
            Game.Instance.LoadScene(4);
        }
        else
        {
            //开始下一关卡
            SendEvent(Consts.E_StartLevel, new StartLevelArgs() { LevelIndex = gm.PlayLevelID + 1 });
        }
    }
    #endregion

    #region 帮助方法
    #endregion
}
