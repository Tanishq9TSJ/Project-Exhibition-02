using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float repeatRate = 2.0f;
    //public GameObject EnemyContainer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
    void EnemySpawner(/*int nEnemy*/)
    {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);
       /* for (int i =0; i<nEnemy; i++)
        {
            GameObject EnemySp = Instantiate(enemy, enemyPos.position, enemyPos.rotation);
            EnemySp.transform.parent = EnemyContainer.transform;
            EnemySp.name = "ZombieClone" + (i + 1);

        }*/

    }

   /* public void DestroyEnemy()
    {
        var Eni = new List<GameObject>();
        foreach (Transform child in EnemyContainer.transform) Eni.Add(child.gameObject);
        Eni.ForEach(child => Destroy(child));
    }*/
}


