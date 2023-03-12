using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemylist;
    public GameObject[] checkPoints;
    public float WaveMoney;

    private void Start()
    {
        StartCoroutine(EnnemySpawner());
    }

    public IEnumerator EnnemySpawner()
    {
        yield return new WaitForSeconds(3);
        int usedMoney = 0;
        int compteur = 0;
        while (usedMoney < WaveMoney && compteur < 20)
        {
            compteur++;
            int randomSpawn = ((int)Random.Range(0, enemylist.Length));
            if (enemylist[randomSpawn].GetComponent<Enemy>().data.UnitPrice <= WaveMoney - usedMoney)
            {
                GameObject newMob = Instantiate(enemylist[randomSpawn], transform.position, transform.rotation, null);
                GeneralVars.ennemyNumber++;
                newMob.GetComponent<Enemy>().checkPoints = checkPoints;
                usedMoney += enemylist[randomSpawn].GetComponent<Enemy>().data.UnitPrice;
                yield return new WaitForSeconds(1f);
            }
        }
        yield return new WaitForSeconds(10f);
        if (WaveMoney < 2)
        {
            WaveMoney += 0.34f;
        } else if (WaveMoney < 3)
        {
            WaveMoney += 0.5f;
        }else if (WaveMoney < 15)
        {
            WaveMoney++;
        }else
        {
            WaveMoney += 2;
        }
        StartCoroutine(EnnemySpawner());
    }
}
