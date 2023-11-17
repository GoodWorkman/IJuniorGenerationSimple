using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
   [SerializeField] private float _speed = 5f;

   private Vector3 _direction;

   public void SetDirection(Vector3 direction)
   {
      _direction = direction.normalized;
   }

   private void Start()
   {
      StartCoroutine(Move());
   }

   private IEnumerator Move()
   {
      while (gameObject.activeInHierarchy)
      {
         transform.Translate(_direction * (_speed * Time.deltaTime));
         
         yield return null;
      }
   }
}
