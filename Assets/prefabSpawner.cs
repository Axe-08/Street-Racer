using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawner : MonoBehaviour
{
    [SerializeField] Enemy[] prefabs;
    [SerializeField] Vector2[] spawnpoints;
    public float maxSpawnTime=1f;
    public logicControl logicControl;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(prefabSpawn());
    }
    IEnumerator prefabSpawn()
    {
        while (true)
        {
            var rand = Random.Range(0, prefabs.Length);
            GameObject prefab = Instantiate(prefabs[rand].prefab, spawnpoints[Random.Range(0,spawnpoints.Length)],Quaternion.identity);
            enemycarcontroller thisScript = prefab.GetComponent<enemycarcontroller>();
            thisScript.speedFactor = prefabs[rand].speedFactor;
            thisScript.scoreFactor = logicControl.gameSpeed();
            yield return new WaitForSeconds(Random.Range(0, maxSpawnTime));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
