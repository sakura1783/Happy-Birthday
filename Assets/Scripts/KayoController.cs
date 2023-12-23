using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class KayoController : MonoBehaviour
{
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
        //TODO 無くすならコメントアウト
        //もうすぐ佳代誕生日(2月15日〜17日)
        if (todayNow.Month == 2 && 15 <= todayNow.Day && todayNow.Day < 18)
        {
            flowchart.SendFungusMessage("kEvent1");
        }
        //佳代誕生日(2月18日)
        else if (todayNow.Month == 2 && todayNow.Day == 18)
        {
            flowchart.SendFungusMessage("kEvent2");
        }
        //もうすぐさくら誕生日(9月27日〜29日)
        else if (todayNow.Month == 9 && 27 <= todayNow.Day && todayNow.Day < 30)
        {
            flowchart.SendFungusMessage("kEvent3");
        }
        //9月30日(さくら誕生日)
        else if (todayNow.Month == 9 && todayNow.Day == 30)
        {
            flowchart.SendFungusMessage("kEvent4");
        }
        //雄一誕生日(12月21日)
        else if (todayNow.Month == 12 && todayNow.Day == 21)
        {
            flowchart.SendFungusMessage("kEvent5");
        }

        //クリスマス(12月25日)
        else if (todayNow.Month == 12 && todayNow.Day == 25)
        {
            flowchart.SendFungusMessage("kEvent6");
        }
        //年末(12月29〜)
        else if (todayNow.Month == 12 && 29 <= todayNow.Day)
        {
            flowchart.SendFungusMessage("kEvent7");
        }
        //年明け(〜1月4日)
        else if (todayNow.Month == 1 && todayNow.Day < 5)
        {
            flowchart.SendFungusMessage("kEvent8");
        }

        //TODO 何かイベントがあれば追加する

        //上記どれにも当てはまらない場合
        else
        {
            //CasualTalkを実行(これをしないと会話が何も起こらなくなる)
            CasualTalk();
        }
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
                flowchart.SendFungusMessage("kHoliday1");
            }
            else if (22 <= todayNow.Hour || todayNow.Hour < 5)
            {
                flowchart.SendFungusMessage("kHoliday2");
            }
        }
        //平日の場合
        else
        {
            if (4 <= todayNow.Hour && todayNow.Hour < 8)
            {
                flowchart.SendFungusMessage("kWeekday1");
            }
            else if (8 <= todayNow.Hour && todayNow.Hour < 16)
            {
                flowchart.SendFungusMessage("kWeekday2");
            }
            else if (16 <= todayNow.Hour && todayNow.Hour < 18)
            {
                flowchart.SendFungusMessage("kWeekday3");
            }
            else if (18 <= todayNow.Hour && todayNow.Hour < 22)
            {
                flowchart.SendFungusMessage("kWeekday4");
            }
            else if (22 <= todayNow.Hour || todayNow.Hour < 4)
            {
                flowchart.SendFungusMessage("kWeekday5");
            }
        }
    }

    /// <summary>
    /// 雑談、軽い会話
    /// </summary>
    private void CasualTalk()
    {
        string[] talkType = { "kTalk1", "kTalk2", "kTalk3", "kTalk4", "kTalk5" };

        flowchart.SendFungusMessage(talkType[UnityEngine.Random.Range(0, talkType.Length)]);
    }
}
