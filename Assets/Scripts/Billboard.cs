using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera cam;
    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
