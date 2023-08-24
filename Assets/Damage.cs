using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Damage : MonoBehaviour
{
   

    public int demage;
    private Health health;
    //public float hurtingTime;

    
    // Start is called before the first frame update
    void Start()
    {

        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

       
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.K)) 
            StartCoroutine(TakeDamage());*/
    }

    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && other.GetType().ToString() == "UnityEngine.BoxCollider")
        {
            if (health != null)
            {
                
                health.Damageplayer(demage);
                Debug.Log("¨ü¶Ë¤F");
            }
            
            
        }
    }
}
