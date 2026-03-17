using UnityEngine;

public class ExitManager : MonoBehaviour
{
    public GameObject confirmPanel;
    
        public void OnExitClicked()
        {
            confirmPanel.SetActive(true);
            Time.timeScale = 0f; // pause game
        }
    
        public void OnYesClicked()
        {
            Debug.Log("Game Exited");
    
            // For mobile or build
            Application.Quit();
    
            // For testing in Unity Editor
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
        }
    
        public void OnNoClicked()
        {
            confirmPanel.SetActive(false);
            Time.timeScale = 1f; // resume game
        }
}
