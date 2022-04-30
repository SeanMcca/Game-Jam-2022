using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    public LevelLoader loader;
    int sceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = loader.GetScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            switch(sceneIndex)
            {
                case 0:
                    StartCoroutine(loader.LoadLevel(1));
                    break;
                case 1:
                    StartCoroutine(loader.LoadLevel(0));
                    break;

            }
        }
    }
}
