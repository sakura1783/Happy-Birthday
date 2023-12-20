using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryDataSO", menuName = "Create StoryDataSO")]
public class StoryDataSO : ScriptableObject
{
    public List<StoryData> storyDataList = new();

    [System.Serializable]
    public class StoryData
    {
        public int storyNo;
        public string storyName;
        public Sprite storySprite;
    }
}
