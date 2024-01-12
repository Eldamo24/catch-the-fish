using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager.instance.AddScore();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "FishDestroyer")
        {
            LivesManager.instance.RemoveLife();
            Destroy(gameObject);
        }

    }
}
