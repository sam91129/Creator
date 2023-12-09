using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Talk : MonoBehaviour
{
    [Header("UI組件")]
    public GameObject panel;
    public Text textLabel;   //對話框內容

    [Header("文本文件")]
    public TextAsset textFile;  //對話文本
    
    //bool Panel = false;
    bool textFinished;  //對話使否結束
    public int index;   //編號

    public float time;
    //float i;

    List<string> textList = new List<string>();
    // Start is called before the first frame update

    void Start()
    {
        GetTextForFile(textFile);
        index = 0;
    }
    void Update()
    {
        
    }
    /*IEnumerator RunText()
    {
        textFinished = false;
        textLabel.text = "";
        for(int i=0; i<textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];   //往之前已經打出的台詞加新字
            yield return new WaitForSeconds(textspeed);
        }
        textFinished = true;    //跳出循環
        index++;    //放完跳下一句
    }*/
    void GetTextForFile(TextAsset file)
    {
        textList.Clear();   //如過不是第一次跳用對話框，需要清空對話框
        index = 0;  //把顯示第幾句的對話框清零
        var LineData = file.text.Split('\n');   //把文本用回車分割一句句台詞

        foreach(var line in LineData)
        {
            textList.Add(line);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
        if (time<3f)
        {
            index++;
            GameManager.PlayButtonClip();
            Debug.Log("音效");
            
            textLabel.text = textList[index];
            if (textFinished==true )
            {
                
                //index++;
            }
            


            /*StartCoroutine(RunText());
            textFinished = false;
            textLabel.text = "";
            panel.SetActive(true);
            
            if (textFinished) 
            {
                textLabel.text = textList[index];
                time = 5f;
                index++;
            }*/
        }

    }
    void Endtalk()
    {
        panel.SetActive(false);
        index = 0;
        return;
    }
}
