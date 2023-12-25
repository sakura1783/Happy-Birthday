using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Flowchart flowchart;

    [SerializeField] private Home home;

    //[SerializeField] private AudioSource bgmSource;


    void Start()
    {
        //PlayBGM();

        //まだメインストーリーを1回も見ていない場合
        if (PlayerPrefs.GetInt("isDisable_Key") == 0)
        {
            //メインストーリーを見る
            flowchart.SendFungusMessage("メインストーリー(誕生日)");
        }
        //すでにメインストーリーを見ている場合
        else
        {
            //ホーム画面に移る
            flowchart.SendFungusMessage("Go_Home");
        }

        home.SetUpHome();
    }

    /// <summary>
    /// メインストーリーを見るのは最初のみで、2回目以降の起動では再度表示しない。
    /// </summary>
    public void DisableMainStory()
    {
        PlayerPrefs.SetInt("isDisable_Key", 1);  //0をfalse、1をtrueとする。
        PlayerPrefs.Save();

        Debug.Log("isDisableをtrueに切り替えました。");

        //ホーム画面に移る
        flowchart.SendFungusMessage("Go_Home");
    }

    /// <summary>
    /// BGM再生
    /// </summary>
    //private void PlayBGM()
    //{
    //    bgmSource.Play();
    //}
}
