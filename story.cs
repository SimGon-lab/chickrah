using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story : MonoBehaviour
{
        void Update ()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("story");
            }

        }
   
}
