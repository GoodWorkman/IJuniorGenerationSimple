using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
   [SerializeField] private float _speed = 5f;

   private void Start()
   {
      StartCoroutine(Move());
   }

   private IEnumerator Move()
   {
      while (gameObject.activeInHierarchy)
      {
         transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
         yield return null;
      }
   }
}
