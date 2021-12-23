using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlane : MonoBehaviour
{
    private GameObject Round;
    [SerializeField] private List<GameObject> branch = new List<GameObject>();
    [SerializeField] private List<GameObject> branchHolder = new List<GameObject>();

    public Material red;
    private static float placementValue;

    private bool wentIn;


    private void Start()
    {
        Round = Resources.Load("Round") as GameObject;
        placementValue = 0f;        
            
        GameObject gm = Instantiate(Round);
        gm.transform.SetParent(transform);
        gm.transform.localPosition = new Vector3(0, placementValue, 0);
        gm.transform.localEulerAngles = new Vector3(0, 0, 0);
        wentIn = false;

        foreach (Transform child in gm.transform)
        {
            branchHolder.Add(child.gameObject);
        }

        for (int i = 0; i < 4; i++)
        {
            branch.Clear();
            wentIn = false;

            foreach (Transform child in branchHolder[i].transform)
            {
                branch.Add(child.gameObject);
            }

            int disableCount = Random.Range(1, 3);
            for (int j = 0; j < branch.Count; j++)
            {
                int selectActiveRandom = Random.Range(0, 5);
                if (selectActiveRandom < 2 && disableCount > 0)
                {
                    branch[j].SetActive(false);
                    branch.RemoveAt(j);
                    wentIn = true;
                    disableCount--;
                }
            }

            int redCount = Random.Range(1, 3);
            for (int k = 0; k < branch.Count; k++)
            {
                int selectActiveRandom = Random.Range(0, 5);
                if (selectActiveRandom < 2 && redCount > 0)
                {
                    branch[k].GetComponent<Renderer>().material = red;
                    branch[k].transform.tag = "Red";
                    redCount--;
                }
            }

            if (!wentIn)
            {
                Debug.Log("wentIn");
                int x = Random.Range(0, 6);
                branch[x].SetActive(false);
                wentIn = true;
            }

            placementValue -= 11.133f;
        }
    }

    public void DestroyMe()
    {
        Destroy(this.gameObject);
    }


}
