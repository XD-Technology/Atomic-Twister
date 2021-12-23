using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySugar : MonoBehaviour
{
    private bool callOnce;
    private ScoreData sd;

    private void Start()
    {
        sd = GameObject.Find("Score").GetComponent<ScoreData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!callOnce)
        {
            if (other.transform.tag == "Player")
            {
                callOnce = true;
                int amount = Random.Range(4, 6);
                sd.AddScore(amount);
                StartCoroutine(DestroyObj());
            }
        }
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
