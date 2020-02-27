using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private Rigidbody rigidbody;

   private void Update()
   {
      rigidbody.AddForce(Vector3.right * 10f,ForceMode.Force);

      if (Input.GetKeyDown(KeyCode.Space))
      {
         //mylogs Probably remove this later
         if (Debug.isDebugBuild) Debug.Log($"<color=purple>Pressing</color>");

         rigidbody.AddForce(Vector3.up * 100f,ForceMode.Impulse);
      }
   }

   
}
