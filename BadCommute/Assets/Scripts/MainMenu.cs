using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        {
            SceneManager.LoadScene(sceneName: "proof_of_concept 1");
        }
    }
}
