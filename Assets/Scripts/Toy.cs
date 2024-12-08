using Unity.Mathematics;
using UnityEngine;
namespace BallingToy
{
    public class Toy : MonoBehaviour
    {


        bool isplayerOneActive = false;
        bool isplayerTwoActive = false;

        public Transform playerOneball;
        public Transform playerTwoball;

        float vInput;
        float hInput;

        public float speed  ;
        public float rotate ;



        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Play();
            BallRest();

        }



        void PlayerInput(Transform ball)
        {
             speed = 1;
             rotate = 1;
            vInput = Input.GetAxis("Vertical") * speed;
            hInput = Input.GetAxis("Horizontal")*rotate;
            ball.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
            ball.transform.Translate(Vector3.left * hInput * Time.deltaTime);
        }
        void Play()
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                isplayerOneActive = true;
                isplayerTwoActive = false;

                PlayerInput(playerOneball);


                Debug.Log("Player One is active");


            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                isplayerTwoActive = true;
                isplayerOneActive = false;

                PlayerInput(playerTwoball);
                Debug.Log("Player Two is active");

            }
            else if (Input.GetKey(KeyCode.Alpha0))
            {
                isplayerOneActive = true;
                isplayerTwoActive = true;
                PlayerInput(playerOneball);
                PlayerInput(playerTwoball);
                Debug.Log("Player One & Player Two is active");


            }

        }
        void BallRest()
        {
            if (Input.GetButtonDown("Jump")) // space
            {
                speed = 0f;
                rotate = 0f;
                if (isplayerOneActive || isplayerTwoActive)
                {
                    playerOneball.transform.position = new Vector3(0f, 0.379999995f, 3.01600003f);




                    playerTwoball.transform.position = new Vector3(3.75f,0.379999995f,3.01600003f);

                
            
                    

                }


            }
        }
    }
}