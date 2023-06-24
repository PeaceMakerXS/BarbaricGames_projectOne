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
     private GameObject explosionRef;

    private GameObject[] Squares;


    private void Awake()
    {
        if (!hero)
            hero = FindObjectOfType<Hero>().transform;
    }

    private void Update()
    {
        Squares = GameObject.FindGameObjectsWithTag("Square");
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
        if (Mathf.Abs(hero.transform.position.x - barrel.transform.position.x) < 5)
        {
            Hero.Instance.GetDamage();
            Debug.Log("��� � ������ ��� ��� 2...");
        }

        for (int i = 0; i< Squares.Length; i++)
        {
            if (Mathf.Abs(Squares[i].transform.position.x - barrel.transform.position.x) < 5)
                Destroy(Squares[i]);
        }

        explosionRef = Instantiate(Explosion,explousionParent);
        explosionRef.transform.localPosition = new Vector3(barrel.transform.position.x, barrel.transform.position.y, barrel.transform.position.z);
        Explosions.Add(explosionRef); //��� �� �����������????
        Debug.Log(Explosions.Count);
        Destroy(this.gameObject);
        Invoke("CheckExpl", 1);
    }

    private void CheckExpl()
    {
        Destroy(explosionRef);

        Debug.Log("�� ������!");
        Destroy(Explosions[0]);
        Explosions.RemoveAt(0);

    }
}
