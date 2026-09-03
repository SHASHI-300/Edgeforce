using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet1 : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.Translate(5f * Vector3.forward * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Enemy"))
        {
           Debug.Log("Enemy hit");
        }
       else
        {
           Destroy(gameObject);
        }
    }
}