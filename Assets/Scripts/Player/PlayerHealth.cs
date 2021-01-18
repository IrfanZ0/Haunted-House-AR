using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider lifeSlider;
    GameObject tmp;
    GameObject playerPanel;
    float currentHealth;
    float totalHealth;
    GameObject gameOverCanvas;
    CanvasGroup gameOverCanvasGroup;
    AudioSource gameOverMusic;

    // Use this for initialization
    void Start()
    {
        gameOverMusic = gameOverCanvas.GetComponent<AudioSource> ( );
        gameOverCanvas = GameObject.Find ( "Game Over Canvas" );
        gameOverCanvasGroup = gameOverCanvas.GetComponent<CanvasGroup> ( );
        lifeSlider = GameObject.Find("Player Life Canvas").transform.Find("Player Health Bar").GetComponent<Slider>();
        tmp = GameObject.FindGameObjectWithTag("Player").transform.Find("Canvas").transform.Find("Panel").transform.Find("Game Over Text").gameObject;
        playerPanel = GameObject.FindGameObjectWithTag("Player").transform.Find("Canvas").transform.Find("Panel").gameObject;
        totalHealth = 100f;
        currentHealth = totalHealth;
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullets"))
        {
            Damage(1f);

        }

        if (coll.collider.CompareTag("Magic Sword"))
        {
            Damage(1f);

        }

        if (coll.collider.CompareTag("Lightning Bolt"))
        {
            Damage(3f);

        }

       
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth % 10.0f == 0)
        {
            Image lifeBarImage = lifeSlider.transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( );
            lifeBarImage.fillAmount -= 0.1f;
        }
      

        if (lifeSlider.value < 1f)
        {
            gameOverCanvasGroup.alpha = 1f;

            if (!gameOverMusic.isPlaying)
            {
                gameOverMusic.Play ( );
            }
            Destroy(gameObject, 2f);
        }

    }

   
}
