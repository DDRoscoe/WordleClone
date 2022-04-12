using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public GameObject[] letters;
    public string letterInput = string.Empty;
    public string testWord = "world";
    public int it = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && it > 0)
        {
            it--;
        }
        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Backspace) && it < 29)
        {
            it++;
        }

        letters[it].GetComponent<InputField>().ActivateInputField();

        if (it >= 0)
        {
            // TODO: convert to uppercase
            // Debug.Log(letters[it-1].GetComponent<InputField>().text[0]);
        }

        if (it%5 == 0)
        {
            
        }
        
        Debug.Log(it);
    }
}
