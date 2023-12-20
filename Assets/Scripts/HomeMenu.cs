using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class HomeMenu : MonoBehaviour
{
    /// <summary>
    /// 生成されたbtnStoryのデータ
    /// </summary>
    //public class StoryButtonData
    //{
    //    public int btnNo;
    //    public string btnName;
    //}

    [SerializeField] private StoryDataSO storyDataSO;

    [SerializeField] private Home home;

    [SerializeField] private CanvasGroup menuGroup;  //HomeMenuPop
    [SerializeField] private CanvasGroup descliptionGroup;  //GameDescliptionPop
    [SerializeField] private CanvasGroup storyGroup;  //StoryListPop
    [SerializeField] private CanvasGroup desideStoryGroup;  //DesideStoryPop

    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnGameDescliption;
    [SerializeField] private Button btnReturn_descliption;
    [SerializeField] private Button btnStoryList;
    [SerializeField] private Button btnReturn_story;
    [SerializeField] private Button btnStory;
    [SerializeField] private Button btnReturn_desideStory;
    [SerializeField] private Button btnEnter;  //TODO これを押した際の処理＝指定されたストーリー開始

    [SerializeField] private Text txtTitle;

    [SerializeField] private Image imgStorySprite;

    [SerializeField] private Transform storiesPlace;

    [SerializeField] private Clickable2D clickableSakura;
    [SerializeField] private Clickable2D clickableKayo;

    //private List<StoryButtonData> storyButtonDataList = new();

    private bool isDisplayMenu = false;


    /// <summary>
    /// 初期設定
    /// </summary>
    public void SetUpHomeMenu()
    {
        InitializeHomeMenu();

        SetUpButtons();

        //ストーリー一覧のbtnStoryを作成
        CreateBtnStory();
    }

    /// <summary>
    /// 各ボタンの初期設定
    /// </summary>
    private void SetUpButtons()
    {
        btnClose.onClick.AddListener(OnClickBtnClose);
        btnGameDescliption.onClick.AddListener(OnClickBtnGameDescliption);
        btnStoryList.onClick.AddListener(OnClickBtnStoryList);
        btnReturn_descliption.onClick.AddListener(OnClickBtnReturn);
        btnReturn_story.onClick.AddListener(OnClickBtnReturn);
        btnReturn_desideStory.onClick.AddListener(OnClickBtnReturn_SelectStory);
    }

    /// <summary>
    /// isDisplayMenuと各ボタンの押下反応の切り替え
    /// </summary>
    private void SwitchMenuVisibility(bool isSwitch)
    {
        isDisplayMenu = isSwitch;

        //ボタンの押下反応の切り替え
        clickableSakura.ClickEnabled = !isDisplayMenu;
        clickableSakura.ClickEnabled = !isDisplayMenu;

        home.SwitchButlerBtnState(!isDisplayMenu);
    }

    /// <summary>
    /// メニュー画面の初期化
    /// </summary>
    private void InitializeHomeMenu()
    {
        menuGroup.alpha = 0;
        menuGroup.blocksRaycasts = false;

        descliptionGroup.alpha = 0;
        descliptionGroup.blocksRaycasts = false;

        storyGroup.alpha = 0;
        storyGroup.blocksRaycasts = false;

        desideStoryGroup.alpha = 0;
        desideStoryGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// btnCloseを押した際の処理
    /// </summary>
    private void OnClickBtnClose()
    {
        HideHomeMenu();
    }

    /// <summary>
    /// btnGameDescliptionを押した際の処理
    /// </summary>
    private void OnClickBtnGameDescliption()
    {
        descliptionGroup.alpha = 1;
        descliptionGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// btnStoryListを押した際の処理
    /// </summary>
    private void OnClickBtnStoryList()
    {
        storyGroup.alpha = 1;
        storyGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// btnReturnを押した際の処理
    /// </summary>
    private void OnClickBtnReturn()
    {
        descliptionGroup.alpha = 0;
        descliptionGroup.blocksRaycasts = false;

        storyGroup.alpha = 0;
        storyGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// btnStoryを押した際の処理
    /// </summary>
    private void OnClickBtnStory(int btnNo)
    {
        //DesideStoryポップアップにタイトルと画像を設定
        SetDesideStoryPop(btnNo);

        storyGroup.blocksRaycasts = false;

        desideStoryGroup.alpha = 1;
        desideStoryGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// btnReturn_selectStoryを押した際の処理
    /// </summary>
    private void OnClickBtnReturn_SelectStory()
    {
        desideStoryGroup.alpha = 0;
        desideStoryGroup.blocksRaycasts = false;

        storyGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// メニュー画面の表示
    /// </summary>
    public void ShowHomeMenu()
    {
        SwitchMenuVisibility(true);

        menuGroup.alpha = 1;
        menuGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// メニュー画面の非表示
    /// </summary>
    private void HideHomeMenu()
    {
        SwitchMenuVisibility(false);

        InitializeHomeMenu();
    }

    /// <summary>
    /// StoryListPopに表示するストーリーのボタンを作成
    /// </summary>
    private void CreateBtnStory()
    {
        for (int i = 0; i < storyDataSO.storyDataList.Count; i++)
        {
            //var data = new StoryButtonData
            //{
            //    btnNo = i,
            //    btnName = storyDataSO.storyDataList[i].storyName,
            //};

            //storyButtonDataList.Add(data);

            var button = Instantiate(btnStory, storiesPlace);

            //子オブジェクトのTextを設定
            button.transform.GetComponentInChildren<Text>().text = storyDataSO.storyDataList[i].storyName; //data.btnName

            //ボタンの初期設定
            button.onClick.AddListener(() => OnClickBtnStory(i));  //data.btnNo  //AddListenerに引数を伴ったメソッドを渡す場合、ラムダ式を利用する
        }
    }

    /// <summary>
    /// DesideStoryポップアップに必要な情報をセット
    /// </summary>
    private void SetDesideStoryPop(int btnNo)
    {
        txtTitle.text = storyDataSO.storyDataList[btnNo].storyName;
        imgStorySprite.sprite = storyDataSO.storyDataList[btnNo].storySprite;
    }
}
