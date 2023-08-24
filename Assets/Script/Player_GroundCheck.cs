using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GroundCheck : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        print("a");
        if(other.tag == "Ground" && PlayerController.isGrounded == false) PlayerController.isGrounded = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground") PlayerController.isGrounded = false;
    }
}
