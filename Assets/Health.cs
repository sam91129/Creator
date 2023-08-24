using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public Image img;
    public float time;
    public Color flashcolor;
    private Color defulcolor;

    private test_hurtplace test_Hurtplace;

    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        defulcolor = img.color;

        test_Hurtplace = GetComponent<test_hurtplace>();

    }

    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        img.color = flashcolor;
        yield return new WaitForSeconds(time);
        /*while (time > 0)
        {
            time -= 0.01f;
            if (time < 0) time = 0;
            yield return new WaitForSeconds(0.1f);
            //img.color = defulcolor;
        }
        img.color = defulcolor;
        yield break;*/
        img.color = defulcolor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damageplayer(int damage)
    {
        test_Hurtplace.FlashScreen();
        //FlashScreen();
        Hp -= damage;
        if (Hp <= 0)
        {
            Debug.Log("§Ú¦º¤F");
           // Destroy(gameObject);
        }
    }
}
