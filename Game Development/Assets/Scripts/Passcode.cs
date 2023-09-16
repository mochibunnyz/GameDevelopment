using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    public Canvas KeypadCanvas;
    public GameObject KeyPad;
    public GameObject Sign;
    public GameObject Fences;
    public GameObject WorkingKeyPad;
    public RawImage ImageBackground;
    string Code = "302";
    string Nr = null;
    int NrIndex = 0;
    string aplha;
    public Text UiText = null;

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if(Nr == Code)
        {
            UiText.text = "Correct";
            StartCoroutine(PuzzleSolved());
            Cursor.visible = false;
            Destroy();
            

        }
        else if(Nr != Code)
        {
            UiText.text = "Try again";
            StartCoroutine(PuzzleWrong());


        }
    }
    public void Destroy()
    {
        Destroy(KeyPad);
        Destroy(Sign);
        Destroy(Fences);
        Destroy(WorkingKeyPad);
        Destroy(ImageBackground);
    }
    private IEnumerator PuzzleSolved()
    {
        yield return new WaitForSeconds(2);
        KeypadCanvas.enabled = false;
    }

    private IEnumerator PuzzleWrong()
    {
        yield return new WaitForSeconds(1);
        Delete();
    }

    public void Delete()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;
    }
}
