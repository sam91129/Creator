using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground") PlayerController.isGrounded = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground") PlayerController.isGrounded = false;
    }
}
