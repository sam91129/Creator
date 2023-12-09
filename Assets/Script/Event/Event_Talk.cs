using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Talk : MonoBehaviour
{
    [Header("UI�ե�")]
    public GameObject panel;
    public Text textLabel;   //��ܮؤ��e

    [Header("�奻���")]
    public TextAsset textFile;  //��ܤ奻
    
    //bool Panel = false;
    bool textFinished;  //��ܨϧ_����
    public int index;   //�s��

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
            textLabel.text += textList[index][i];   //�����e�w�g���X���x���[�s�r
            yield return new WaitForSeconds(textspeed);
        }
        textFinished = true;    //���X�`��
        index++;    //�񧹸��U�@�y
    }*/
    void GetTextForFile(TextAsset file)
    {
        textList.Clear();   //�p�L���O�Ĥ@�����ι�ܮءA�ݭn�M�Ź�ܮ�
        index = 0;  //����ܲĴX�y����ܮزM�s
        var LineData = file.text.Split('\n');   //��奻�Φ^�����Τ@�y�y�x��

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
            Debug.Log("����");
            
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
