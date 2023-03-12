using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    const float scale = 0.5f;

    public GameObject attackType;
    public GameObject[] CanLevel;
    private List<GameObject> targets = new List<GameObject>();

    public Animator Anim;

    private CircleCollider2D trigger;

    public SpriteRenderer sprite;

    public string nametag;

    public int LevelMax = 10;
    public int Level = 0;
    public int Cost;
    public float damage;

    public float AttackRange;
    public float attackSpeed;
    public bool isKrauss;
    private float attackCooldown;


    private void Start()
    {
        trigger = gameObject.GetComponent<CircleCollider2D>();
        trigger.radius = AttackRange + 0.5f;
        transform.localPosition = Vector3.zero;
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0)
        {
            StartCoroutine(Shoot());
        }

        if (GeneralVars.Money >= Cost * Level && Level < 10)
        {
            CanLevel[0].SetActive(true);
            CanLevel[1].SetActive(false);
        } else if (Level == 10)
        {
            CanLevel[0].SetActive(false);
            CanLevel[1].SetActive(true);
        } else
        {
            CanLevel[0].SetActive(false);
            CanLevel[1].SetActive(false);
        }

        if (isKrauss)
        {
            int nbEnnemy = GeneralVars.ennemyNumber;
            Debug.Log(nbEnnemy);
            damage = 1 * GeneralVars.ennemyNumber;
        }
    }

    public IEnumerator Shoot()
    {
        if (targets != null)
        {
            GameObject[] targetsintab = targets.ToArray();
            GameObject closestTarget = null;
            for (int i = 0; i < targetsintab.Length; i++)
            {
                if (closestTarget != null)
                {
                    float dist1 = Vector2.Distance(targetsintab[i].transform.position, transform.position);
                    float dist2 = Vector2.Distance(closestTarget.transform.position, transform.position);
                    if (dist1 < dist2)
                    {
                        closestTarget = targetsintab[i];
                    }
                } else
                {
                    if (targetsintab[i] != null)
                    {
                        closestTarget = targetsintab[i];
                    }
                }
            }
            if (closestTarget !=null)
            {
                if (closestTarget.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(-scale, scale, 1);
                } else
                {
                    transform.localScale = new Vector3(scale,  scale, 1);
                }
                Anim.SetTrigger("Attack !");
                attackCooldown = attackSpeed;
                yield return new WaitForSeconds(0.3f);
                GameObject newBullet = Instantiate(attackType, transform.position, transform.rotation, null);
                newBullet.GetComponent<Bullet>().Damage = damage;
                newBullet.GetComponent<Bullet>().target = closestTarget;
            }
        }
    }

    #region(collisions)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!targets.Contains(collision.gameObject) && collision.CompareTag("Enemy"))
        {
            targets.Add(collision.gameObject); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targets.Contains(collision.gameObject) && collision.CompareTag("Enemy"))
        {
            targets.Remove(collision.gameObject);
        }
    }
    #endregion
}
