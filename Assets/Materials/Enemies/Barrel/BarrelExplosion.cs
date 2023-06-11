using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : Entity
{
    public GameObject hero;
    public GameObject barrel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Invoke("Test", 3);
            Debug.Log("��� � ������ ��� ���...");
        }
    }

    void Test()
    {
        Destroy(this.gameObject);
        if (hero.transform.position.x - barrel.transform.position.x < 5)
        {
            Hero.Instance.GetDamage();
            Debug.Log("��� � ������ ��� ��� 2...");
        }
    }
}
