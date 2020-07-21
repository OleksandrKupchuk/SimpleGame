using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    [Header("Parametrs")]
    [SerializeField] private float minSpawn;
    [SerializeField] private float maxSpawn;
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private int minQuantityMeteors;
    [SerializeField] private int maxQuantityMeteors;
    private Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(MeteorSpawn());
            
            //Debug.Log("N N N N");
        }
    }

    private IEnumerator Spawn()
    {
        float range = Random.Range(minSpawn, maxSpawn);

        GameObject meteor = Instantiate(meteorPrefab);

        meteor.transform.position = new Vector3(range, transform.position.y);

        yield return null;
    }

    private IEnumerator MeteorSpawn()
    {
        int range = Random.Range(minQuantityMeteors, maxQuantityMeteors);
        for (int i = 0; i < range; i++)
        {
            StartCoroutine(Spawn());
            yield return new WaitForSeconds(0.5f);
        }
    }
}
