using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunMouth;

    public void Fire()
    {
        Instantiate(bullet, gunMouth.transform.position, gunMouth.transform.rotation);
    }
}