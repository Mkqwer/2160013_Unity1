using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour

{
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void Infinity()
   {
        SceneManager.LoadScene("GameScene");
   }

    public void Classic()
    {
        SceneManager.LoadScene("ClassicScene");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

  
}
