using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
        {
        
            if (Input.anyKeyDown)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Chickrah");
    }
}
}
