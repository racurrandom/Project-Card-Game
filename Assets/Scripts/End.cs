using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Finish());

    }

    

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Scenes/Scene Menu/Menu");
    }

}
