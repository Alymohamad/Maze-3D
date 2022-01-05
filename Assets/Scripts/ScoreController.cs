
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public MazeRenderer mazeRendender;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject mazeObject = GameObject.Find("MazeRenderer");
        //mazeRendender = mazeObject.GetComponent<MazeRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level Size: " + mazeRendender.width + "x" + mazeRendender.width;
    }
}
