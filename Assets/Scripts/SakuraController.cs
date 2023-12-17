using System;
using UnityEngine;
using Fungus;

public class SakuraController : MonoBehaviour
{
    public enum ConversationType
    {
        ByDate,  //日付
        ByDayOfWeek,  //曜日
        CasualTalk,  //雑談

        count,  //enumの要素の数
    }

    [SerializeField] private Flowchart flowchart;

    private DateTime todayNow;


    /// <summary>
    /// 現在の日時を取得して、ランダムな会話イベントを発生させる
    /// </summary>
    public void GetCurrentDateTime()
    {
        todayNow = DateTime.Now;

        //どの会話を行うかランダムに決定
        int conversationNo = UnityEngine.Random.Range(0, (int)ConversationType.count);

        if (conversationNo == 0)
        {
            ConversationByDate();
        }
        else if (conversationNo == 1)
        {
            ConversationByDayOfWeek();
        }
        else if (conversationNo == 2)
        {
            CasualTalk();
        }
    }

    /// <summary>
    /// 日付ごとに違う会話をする
    /// </summary>
    private void ConversationByDate()
    {
        //もうすぐ佳代誕生日(2月15日〜17日)
        if (todayNow.Month == 2 && 15 <= todayNow.Day && todayNow.Day < 18)
        {
            flowchart.SendFungusMessage("soonBirthday_kayo");
        }
        //佳代誕生日(2月18日)
        else if (todayNow.Month == 2 && todayNow.Day == 18)
        {
            flowchart.SendFungusMessage("birthday_kayo");
        }
        //もうすぐさくら誕生日(9月27日〜29日)
        else if (todayNow.Month == 9 && 27 <= todayNow.Day && todayNow.Day < 30)
        {
            flowchart.SendFungusMessage("soonBirthday_sakura");
        }
        //9月30日(さくら誕生日)
        else if (todayNow.Month == 9 && todayNow.Day == 30)
        {
            flowchart.SendFungusMessage("birthday_sakura");
        }
        //雄一誕生日(12月21日)
        else if (todayNow.Month == 12 && todayNow.Day == 21)
        {
            flowchart.SendFungusMessage("birthday_yuichi");
        }

        //クリスマス(12月25日)
        else if (todayNow.Month == 12 && todayNow.Day == 25)
        {
            flowchart.SendFungusMessage("Christmas");
        }
        //年末(12月29〜)
        else if (todayNow.Month == 12 && 29 <= todayNow.Day)
        {
            flowchart.SendFungusMessage("yearEnd");
        }
        //年明け(〜1月4日)
        else if (todayNow.Month == 1 && todayNow.Day < 5)
        {
            flowchart.SendFungusMessage("newYear");
        }

        //上記どれにも当てはまらない場合
        else
        {
            //CasualTalkを実行(これをしないと会話が何も起こらなくなる)
            CasualTalk();
        }

        //TODO 何かイベントがあれば追加する
    }

    /// <summary>
    /// 曜日、時間ごとに違う会話をする
    /// </summary>
    private void ConversationByDayOfWeek()
    {
        //休日の場合
        if (todayNow.DayOfWeek == DayOfWeek.Saturday || todayNow.DayOfWeek == DayOfWeek.Sunday)
        {
            //5時以降22時未満
            if (5 <= todayNow.Hour && todayNow.Hour < 22)
            {
                flowchart.SendFungusMessage("holiday1");
            }
            else if (22 <= todayNow.Hour || todayNow.Hour < 5)
            {
                flowchart.SendFungusMessage("weekday5");
            }
        }
        //平日の場合
        else
        {
            if (4 <= todayNow.Hour && todayNow.Hour < 8)
            {
                flowchart.SendFungusMessage("weekday1");
            }
            else if (8 <= todayNow.Hour && todayNow.Hour < 16)
            {
                flowchart.SendFungusMessage("weekday2");
            }
            else if (16 <= todayNow.Hour && todayNow.Hour < 18)
            {
                flowchart.SendFungusMessage("weekday3");
            }
            else if (18 <= todayNow.Hour && todayNow.Hour < 22)
            {
                flowchart.SendFungusMessage("weekday4");
            }
            else if (22 <= todayNow.Hour || todayNow.Hour < 4)  //ここは&&にしてはいけない。例えば、23時の時、右の式には当てはまらないから。
            {
                flowchart.SendFungusMessage("weekday5");
            }
        }
    }

    /// <summary>
    /// 雑談、軽い会話
    /// </summary>
    private void CasualTalk()
    {
        string[] talkType = { "talk1", "talk2", "talk3" };  //TODO 他にもあれば追加する

        flowchart.SendFungusMessage(talkType[UnityEngine.Random.Range(0, talkType.Length)]);
    }
}
