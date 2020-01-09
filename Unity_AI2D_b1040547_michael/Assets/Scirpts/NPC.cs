using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
     #region 欄位
    public enum state
    {
        start,notComplete,complete
    }

    public state _state;

    [Header("對話")]
    public string sayStart = "Hi，可以請你幫我收集十枚硬幣嗎?";
    public string sayNotComplete = "你還沒收集十枚硬幣喔....";
    public string sayComplete = "謝謝你幫我收集十枚硬幣";
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "肉球")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "肉球")
            SayClose();
    }

    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;

        switch (_state)
        {
            case state.start:
                textSay.text=sayStart;
                _state = state.notComplete;
                break;
            case state.notComplete:
                textSay.text = sayNotComplete;
                break;
            case state.complete:
                textSay.text = sayComplete;
                break;
        }
    }

  

    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    public void Playerget()
    {
        countPlayer++;
    }
}
