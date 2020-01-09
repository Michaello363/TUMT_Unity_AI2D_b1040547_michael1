using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Michael
{
    public class GameManger : MonoBehaviour
    {
     public void Replay()
        {
            SceneManager.LoadScene("遊戲");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }

}
