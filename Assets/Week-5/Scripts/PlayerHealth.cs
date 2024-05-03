using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 20;

    public void TakeDamage(int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
