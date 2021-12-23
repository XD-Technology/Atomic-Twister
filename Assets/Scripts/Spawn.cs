using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private GameObject Base;    

    public bool isSpawn;

    private Egg egg;

    private void Start()
    {
        egg = GameObject.Find("Egg").GetComponent<Egg>();
    }

    public void CreateBase()
    {
        GameObject bs = Instantiate(Base);
        bs.transform.SetParent(transform);
        bs.transform.localPosition = new Vector3(0, egg.counter, 0);
        bs.transform.localEulerAngles = new Vector3(0, 0, 0);

        egg.counter -= 11.133f;
    }
}
