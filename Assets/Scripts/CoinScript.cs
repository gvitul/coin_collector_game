using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public float rotateSpeed;

   /// <summary>
   /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
   /// </summary>
   void FixedUpdate()
   {
       transform.Rotate(0, 0, rotateSpeed);
   }

    // Update is called once per frame
    void Update()
    {
        
    }


}
