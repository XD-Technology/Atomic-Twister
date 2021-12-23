using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
    private Spawn spawn;
    private bool callOnce;

    void Start ()
    {
        spawn = GameObject.Find("Reference").GetComponent<Spawn>();
        callOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.name == "DeleteRef") this.transform.parent.GetComponent<SpawnPlane>().DestroyMe();

        if (!callOnce)
        {
            if (other.transform.tag == "Player")
            {
                spawn.CreateBase();
                Destroy(this.gameObject);
            }
        }
    }
}