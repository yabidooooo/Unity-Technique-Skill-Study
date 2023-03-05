using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asynchronous
{
    public class LobbyManager : MonoBehaviour
    {
        public void _OnClickNextStage()
        {
            SceneManager.LoadScene(1);
        }
    }
}