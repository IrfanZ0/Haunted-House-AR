using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Slider lifeSlider;
    private float current_health;
    private float total_health;
    private GameObject gameOverCanvas;
    private CanvasGroup gameOverCanvasGroup;
    private AudioSource gameOverMusic;
    private Image fill;
    private Animator playerAnim;

    // Use this for initialization
    private void Start ( )
    {
        gameOverCanvas = GameObject.Find ( "Game Over Canvas" );

        if ( gameOverCanvas != null )
        {
            gameOverMusic = gameOverCanvas.GetComponent<AudioSource> ( );
            gameOverCanvasGroup = gameOverCanvas.GetComponent<CanvasGroup> ( );
        }

        lifeSlider = GetComponent<Slider> ( );
        fill = lifeSlider.transform.Find ( "Fill Area" ).transform.Find ( "Fill" ).GetComponent<Image> ( );
        total_health = 100f;
        current_health = total_health;
        playerAnim = GetComponent<Animator> ( );
    }

    private void Update ( )
    {
        fill.fillAmount = current_health;
    }

    public void Damage ( float damage )
    {
        current_health -= damage;

        if ( current_health <= 0 )
        {
            PlayerDeath ( );

        }

    }

    private void PlayerDeath ( )
    {
        playerAnim.SetBool ( "isDead" , true );
        float playerDeathTime = playerAnim.GetCurrentAnimatorStateInfo ( 0 ).length;
        Destroy ( gameObject , 2f );
    }

}