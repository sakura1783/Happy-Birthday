using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Home : MonoBehaviour
{
    [SerializeField] private Text txtDate;

    [SerializeField] private CanvasGroup menuGroup;  //HomeMenuPop

    [SerializeField] private Button btnButler;

    [SerializeField] private HomeMenu homeMenu;


    /// <summary>
    /// 初期設定
    /// </summary>
    public void SetUpHome()
    {
        SetTodayDate();

        homeMenu.SetUpHomeMenu();

        SetUpButtons();
    }

    /// <summary>
    /// 日付表示
    /// </summary>
    private void SetTodayDate()
    {
        var date = DateTime.Now;

        txtDate.text = date.Month.ToString() + "/" + date.Day.ToString();
    }

    /// <summary>
    /// 各ボタンの設定
    /// </summary>
    private void SetUpButtons()
    {
        btnButler.onClick.AddListener(OnClickBtnButler);
    }

    /// <summary>
    /// btnButlerを押した際の処理
    /// </summary>
    private void OnClickBtnButler()
    {
        homeMenu.ShowHomeMenu();
    }

    /// <summary>
    /// btnButlerのアクティブ状態の切り替え
    /// </summary>
    /// <param name="isActive"></param>
    public void SwitchButlerBtnState(bool isActive)
    {
        btnButler.interactable = isActive;
    }
}
