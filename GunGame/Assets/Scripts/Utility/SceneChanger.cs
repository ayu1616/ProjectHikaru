using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    private static string TitleSceneName = "Title";
    private static string SelectSceneName = "Select";
    private static string RobbySceneName = "Robby";
    private static string GameSceneName = "GameScene";
    private static string ResultSceneName = "Result";

    enum SceneTable
    {
        TITLE,
        SELECT,
        ROBBY,
        GAME,
        RESULT
    };

    [SerializeField] SceneTable loadSceneEnum;

    public void ChangeScene()
    {
        string sceneName = "";

        switch (loadSceneEnum)
        { 
            case SceneTable.TITLE:
                sceneName = TitleSceneName;
                break;

            case SceneTable.SELECT:
                sceneName = SelectSceneName;
                break;

            case SceneTable.ROBBY:
                sceneName = RobbySceneName;
                break;

            case SceneTable.GAME:
                sceneName = GameSceneName;
                break;

            case SceneTable.RESULT:
                sceneName = ResultSceneName;
                break;

            default:
                break;
        }

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
