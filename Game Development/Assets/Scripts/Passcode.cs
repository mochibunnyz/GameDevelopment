using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    int WrongCounter = 0;
    int Case = 0;
    string aplha;
    public Text UiText = null;
    string TheCode = "HEW";
    public Text CodeText;
    public TextMeshProUGUI OnSceneCode_Text;

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
            WrongCounter++;

        }

        if(Nr!=Code & WrongCounter == 3&Case==0)
        {
            UiText.text = "All Attempts used";
            Code = "581";
            TheCode = "QVU";
            CodeText.text = TheCode;
            OnSceneCode_Text.text = TheCode;
            WrongCounter = 0;
            Case++;
            
        }
        if (Nr != Code & WrongCounter == 3 & Case == 1)
        {
            UiText.text = "All Attempts used";
            Code = "102";
            TheCode = "UEW";
            CodeText.text = TheCode;
            OnSceneCode_Text.text = TheCode;
            WrongCounter = 0;
            Case++;

        }
        if (Nr != Code & WrongCounter == 3 & Case == 2)
        {
            UiText.text = "All Attempts used";
            Code = "810";
            TheCode = "VUE";
            CodeText.text = TheCode;
            OnSceneCode_Text.text = TheCode;
            WrongCounter = 0;
            Case=0;

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
