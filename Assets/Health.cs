using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int Hp;

    test_hurtplace test_Hurtplace;
    void Start()
    {
        test_Hurtplace = GetComponent<test_hurtplace>();
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
