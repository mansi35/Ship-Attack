using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Projectile : NetworkBehaviour
{
    public GameObject bulletPrefabs;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    // public GameObject[] levels;
    // public Color myColor;

    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {   
        if (GetComponent<NetworkIdentity>().hasAuthority)
        {
            // levels = GameObject.FindGameObjectsWithTag("level");
            // Debug.Log(levels.Length);
            cam.SetActive(true);
            GameObject.Find("Ocean").GetComponent<Crest.OceanRenderer>().Viewpoint = cam.transform;
            // myMaterial = new Material(Shader.Find("Standard"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NetworkIdentity>().hasAuthority)
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile() {
        Ray camRay = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 10000f, layer))
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point + Vector3.up * 0.1f;

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 4f);
            // foreach (GameObject level in levels)
            // {
            //     Debug.Log("Paagal");
            //     if (level.transform.parent.GetComponent<NetworkIdentity>().hasAuthority) {
            //         if (level.transform.GetComponent<QuesLevel>().myText == 0) {
            //             Debug.Log("I am easy");
            //             myColor = new Color(0, 0, 1, 1);
            //             Debug.Log(myColor);
            //         }
            //         else if (level.transform.GetComponent<QuesLevel>().myText == 1) {
            //             Debug.Log("I am medium");
            //             myColor = new Color(0, 1, 0, 1);
            //             Debug.Log(myColor);
            //         }
            //         else if (level.transform.GetComponent<QuesLevel>().myText == 2) {
            //             Debug.Log("I am hard");
            //             myColor = new Color(1, 0, 0, 1);
            //             Debug.Log(myColor);
            //         }
            //     }
            // }

            if (Input.GetMouseButtonDown(0))
            {
                CmdFire(Vo);
            }
        }

        else 
        {
            cursor.SetActive(false);
        }


    }

    [Command]
    void CmdFire(Vector3 Vo)
    {
        GameObject obj = (GameObject)Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
        shootPoint.transform.rotation = Quaternion.LookRotation(Vo);
        obj.GetComponent<Rigidbody>().velocity = Vo;
        // Renderer rend = obj.GetComponent<Renderer>();
        // rend.material = new Material(Shader.Find("Standard"));
        // rend.material.color = myColor;
        // Debug.Log(myColor);

        NetworkServer.Spawn(obj);
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;

        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
