using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class NameDataLoader : MonoBehaviour
{
    public NameData nameData = new NameData();

    private void Start()
    {
        LoadNameData("male.json", ref nameData.maleFirstNames);
        LoadNameData("female.json", ref nameData.femaleFirstNames);
        LoadNameData("last.json", ref nameData.lastNames);
    }

    private void LoadNameData(string fileName, ref List<string> targetList)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Names", fileName);
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            NameListWrapper wrapper = JsonUtility.FromJson<NameListWrapper>(jsonData);
            targetList = wrapper.names;
        }
        else
        {
            Debug.LogError("JSON file not found: " + filePath);
        }
    }

    public string GetRandomLastName()
    {
        if (nameData.lastNames.Count > 0)
        {
            return nameData.lastNames[Random.Range(0, nameData.lastNames.Count)];
        }
        return "";
    }

    public string GetRandomMaleName()
    {
        if (nameData.maleFirstNames.Count > 0)
        {
            return nameData.maleFirstNames[Random.Range(0, nameData.maleFirstNames.Count)];
        }
        return "";
    }

    public string GetRandomFemaleName()
    {
        if (nameData.femaleFirstNames.Count > 0)
        {
            return nameData.femaleFirstNames[Random.Range(0, nameData.femaleFirstNames.Count)];
        }
        return "";
    }

    public string GetRandomAnyName()
    {
        List<string> combinedList = new List<string>(nameData.maleFirstNames);
        combinedList.AddRange(nameData.femaleFirstNames);

        if (combinedList.Count > 0)
        {
            return combinedList[Random.Range(0, combinedList.Count)];
        }
        return "";
    }
}

[System.Serializable]
public class NameListWrapper
{
    public List<string> names;
}
