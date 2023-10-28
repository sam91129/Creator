using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_MovePlatform : MonoBehaviour
{
    public float speed;
    public float WaitTime;
    public Transform[] movPos;  //移動的點

    private int i;  //定位點的取值
    private Transform playerDefTransform;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movPos[i].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movPos[i].position) < 0.1f)
        {
            if (WaitTime < 0f)
            {
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                WaitTime = 0.3f;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;   //把tag是Player設定成平台的子對象
            Debug.Log("o");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;   //把tag是Player設定成平台的子對象
            Debug.Log("i");
        }
    }
}
