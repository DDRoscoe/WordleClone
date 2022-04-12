using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public GameObject[] letters;
    public string letterInput = string.Empty;
    public string testWord = "world";
    public int placeHolder = 0;
    public int numTries = 0;
    public int currentTry;
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
        else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Backspace) && it < 4)
        {
            it++;
        }
        else if (it == 4 && Input.GetKeyDown(KeyCode.Return) && placeHolder < 30)
        {
            letters[4].GetComponent<InputField>().DeactivateInputField();
            it = 0;
            numTries++;
            placeHolder += 5;

            for (int i = placeHolder - 5; i < placeHolder; i++)
            {
                letters[i].GetComponent<InputField>().GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1);
            }
        }

        if (numTries < 6)
        {
            letters[it + placeHolder].GetComponent<InputField>().ActivateInputField();
        }
        else if (numTries == 6)
        {
            // TODO: Game Over
        }

        if (it >= 0)
        {
            // TODO: convert to uppercase
            // Debug.Log(letters[it-1].GetComponent<InputField>().text[0]);
        }
    }
}
