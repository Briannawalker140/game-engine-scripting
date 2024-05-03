using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Lava : MonoBehaviour
{
    [SerializeField] Collision collision;
    public PlayerControls playerControls;
    public int damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerControls.TakeDamage(damage);
        }
    }
}










