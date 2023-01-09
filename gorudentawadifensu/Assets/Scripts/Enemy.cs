using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitData data;

    public Transform LifeBar;

    public Animator Anim;

    private SpriteRenderer sprite;

    private float speed;
    private float MaxLife;
    private float Life;
    private float Damage;
    private float EnemyCost;
    private float FireCooldown;
    public GameObject[] checkPoints;
    private GameObject target;
    private int targNum = 0;

    void Start()
    {
        LoadEnemy();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        target = checkPoints[targNum];
    }

    public void LoadEnemy()
    {
        MaxLife = data.life + GeneralVars.BonusHp;
        Life = MaxLife;
        speed = data.speed;
        Damage = data.Damage;
        EnemyCost = data.UnitPrice;
    }

    private void Update()
    {
        if(FireCooldown > 0)
        {
            FireCooldown -= Time.deltaTime;
        }
        if (Life <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.transform.position - transform.position;
        Anim.SetFloat("MovementX", direction.x);
        Anim.SetFloat("MovementY", direction.y);
        if (direction.x < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } else if (transform.localScale.x > 0 && direction.x >= 0)
        {
            transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("checkPoint"))
        {
            targNum++;
            if (targNum < checkPoints.Length)
            {
            target = checkPoints[targNum];
            } else
            {
                GeneralVars.throneHealth--;
                Destroy(gameObject);
            }
        } else if (collision.CompareTag("Wall"))
        {
            collision.GetComponent<Wall>().life--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (FireCooldown <= 0 && other.CompareTag("Fire"))
        {
            Damaged(other.GetComponent<Bullet>().Damage);
            FireCooldown += 0.2f;
        }
    }

    public void Damaged(int damaged)
    {
        if (damaged > 0)
        {
            StartCoroutine(Hurt());
        }
        else
        {
            StartCoroutine(Healed());
        }
        if (Life - damaged <= MaxLife)
        {
        Life -= damaged;
        }
        LifeBar.localScale = new Vector3(Life / MaxLife, 0.75f);
    }

    public IEnumerator Hurt()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    } 
    
    public IEnumerator Healed()
    {
        sprite.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        sprite.color = Color.white;
    }

    public void Die()
    {
       GeneralVars.Money += 1000 + 100 * ((int)EnemyCost) + ((int)GeneralVars.BonusHp);
        GeneralVars.score += ((int)EnemyCost * 100);

        Destroy(this.gameObject);
    }


}
