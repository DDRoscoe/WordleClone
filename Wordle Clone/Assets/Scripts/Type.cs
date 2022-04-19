using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public GameObject[] letters;
    public string stringInput; 
    public KeyCode[] desiredKeys = {KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, 
    KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z};
    public string letterInput = string.Empty;
    public string testWord = "unity";
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


    private bool isALetter()
    {
        foreach (KeyCode keyToCheck in desiredKeys)
        {
            if (Input.GetKeyDown(keyToCheck))
                return true;
        }
        return false;
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && it > 0)
        {
            it--;
        }
        else if (isALetter() && !Input.GetKeyDown(KeyCode.Backspace) && it < 4)
        {
            it++;
            Debug.Log(it);
        }
        else if (it == 4 && Input.GetKeyDown(KeyCode.Return) && placeHolder < 30)
        {
            for (int i = placeHolder; i < placeHolder + 5; i++)     // fill the stringInput with characters
            {
                stringInput += letters[i].GetComponent<InputField>().text[0];
            }

            CheckString(stringInput, letters, placeHolder);

            letters[4].GetComponent<InputField>().DeactivateInputField();
            it = 0;
            numTries++;
            placeHolder += 5;
            stringInput = "";
        }

        // Activate the next input field
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


    private void CheckString(string stringInput, GameObject[] field, int placeHolder)
    {
        // Check for completely right or completely wrong inputs
        for (int i = 0; i < testWord.Length; i++)
        {
            if (stringInput[i] == testWord[i])
            {
                field[i + placeHolder].GetComponent<InputField>().GetComponent<Image>().color = Color.green;
            }
            else
            {
                field[i + placeHolder].GetComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 1);
            }
        }

        // for (int i = 0; i < testWord.Length; i++)
        // {
        //     for (int j = 0; i < testWord.Length; j++)
        //     {
        //         if (stringInput[i] == testWord[j] && stringInput[i] != testWord[i])
        //         {
        //             field[i + placeHolder].GetComponent<InputField>().GetComponent<Image>().color = Color.yellow;
        //         }
        //     }
        // }
    }
}
