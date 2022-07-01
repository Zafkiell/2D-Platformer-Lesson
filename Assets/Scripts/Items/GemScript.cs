using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject ItemAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(ItemAnim, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
