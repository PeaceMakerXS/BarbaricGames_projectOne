using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : Entity
{
    public Transform hero;
    public GameObject barrel;

    public GameObject Explosion;
    public Transform explousionParent;
    private List<GameObject> Explosions = new List<GameObject>();

    private void Awake()
    {
        if (!hero)
            hero = FindObjectOfType<Hero>().transform;
    }

    private void Update()
    {
        CheckExpl();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Invoke("Boom", 2);
            Debug.Log("��� � ������ ��� ���...");
        }
    }

    void Boom()
    {
        if (hero.transform.position.x - barrel.transform.position.x < 5)
        {
            Hero.Instance.GetDamage();
            Debug.Log("��� � ������ ��� ��� 2...");
        }

        var explosionRef = Instantiate(Explosion,explousionParent);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Explosions.Add(explosionRef); //��� �� �����������????
        Destroy(this.gameObject);
    }

    private void CheckExpl()
    {
        Debug.Log("�� ������!");
        Debug.Log(Explosions.Count);
        if (Explosions.Count > 1)
        {
            Debug.Log("�� ������!2");
            Destroy(Explosions[0]);
            Explosions.RemoveAt(0);
        }
    }
}
