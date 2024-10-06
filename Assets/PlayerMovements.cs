using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float horizontalVelocity;
    public float verticalVelocity;


    public float speedDecrease = 1.025f;

    // Start is called before the first frame update
    void Start()
    {
        horizontalVelocity = 0;
        verticalVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Movements();
    }

    // Mouvements avec syst�me de glissements
    private void Movements()
    {

        // HORIZONTAL
        if (Input.GetKey(KeyCode.A))
        {

            // Si le mouvement horizontal (gauche) n'a pas atteint sa vitesse maximum
            if (horizontalVelocity > -1f)
            {
                horizontalVelocity -= .1f;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Si le mouvement horizontal (droite) n'a pas atteint sa vitesse maximum
            if (horizontalVelocity < 1f)
            {
                horizontalVelocity += .1f;
            }
        }

        // Si aucune touche de mouvement n'est press�e
        else
        {

            // Si il existe un mouvement horizontal vers la gauche, r�duit la vitesse du personnage jusqu'� s'arr�ter

            // Si le mouvement existe (vers la gauche) 
            if (horizontalVelocity < 0f)
            {

                // R�duit la vitesse du joueur
                horizontalVelocity = horizontalVelocity / speedDecrease;

                // Si la vitesse est inf�rieure � -0.1
                if (horizontalVelocity > -0.1)
                {
                    // Stop le joueur
                    horizontalVelocity = 0;
                }
            }
            else if (horizontalVelocity > 0f)
            {
                horizontalVelocity = horizontalVelocity / speedDecrease;
                if (horizontalVelocity < 0.1)
                {
                    horizontalVelocity = 0;
                }
            }
            
        }

        // VERTICAL
        if (Input.GetKey(KeyCode.W))
        {
            if (verticalVelocity < 1f)
            {
                verticalVelocity += .1f;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (verticalVelocity > -1f)
            {
                verticalVelocity -= .1f;
            }
        }
        else
        {
            if (verticalVelocity < 0f)
            {
                verticalVelocity = verticalVelocity / speedDecrease;
                if (verticalVelocity > -0.1)
                {
                    verticalVelocity = 0;
                }
            }
            else if (verticalVelocity > 0f)
            {
                verticalVelocity = verticalVelocity / speedDecrease;
                if (verticalVelocity < 0.1)
                {
                    verticalVelocity = 0;
                }
            }

        }




        Vector2 direction = new Vector2(horizontalVelocity, verticalVelocity);

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
