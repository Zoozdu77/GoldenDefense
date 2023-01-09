using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succubus : MonoBehaviour
{
    public float cooldown;
    private float LeftCooldown;
    public float Range;
    public int heal;

    private void Start()
    {
        LeftCooldown = cooldown;
    }

    void Update()
    {
        LeftCooldown -= Time.deltaTime;
        if (LeftCooldown <= 0)
        {
            Heal();
        }
    }

    public void Heal()
    {
        GameObject[] targetsintab = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < targetsintab.Length; i++)
        {
            if (Vector2.Distance(transform.position, targetsintab[i].transform.position) < Range)
            {
               targetsintab[i].GetComponent<Enemy>().Damaged(-heal);
            }
        }
            LeftCooldown = cooldown;;
    }
}
