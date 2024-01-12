using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishSpawner : MonoBehaviour
{
    public static FishSpawner instance;
    private GameObject[] prefabFishes;
    private Transform myTransform;
    private int randomFish;
    private float randomFishXPosition;
    [SerializeField]
    private float _delaySpawnFishTime;
    public float DelaySpawnFishTime { set => _delaySpawnFishTime = value; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    public void GetFishes()
    {
        prefabFishes = GameObject.FindGameObjectsWithTag("Fish");
        foreach(var item in prefabFishes)
        {
            item.SetActive(false);
            item.transform.parent = myTransform;
        }
    }

    private void SpawnFish()
    {
        randomFish = Random.Range(0, prefabFishes.Length);
        randomFishXPosition = Random.value;
        GameObject tempFishPrefab = Instantiate(prefabFishes[randomFish],
                                                new Vector3(
                                                    Camera.main.ViewportToWorldPoint(new Vector3(randomFishXPosition,0,0)).x,
                                                    Camera.main.ViewportToWorldPoint(Vector3.one).y + 2f, 
                                                    0),
                                                Quaternion.identity);
        tempFishPrefab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFishes()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnFish();
            yield return new WaitForSeconds(_delaySpawnFishTime);
        }
    }

    public void StartSpawnFishes()
    {
        StartCoroutine("SpawnFishes");
    }

    public void StopSpawnFishes()
    {
        StopCoroutine("SpawnFishes");
    }
}
