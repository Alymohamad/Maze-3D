using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{

    [SerializeField]
    [Range(4, 50)]
    public int width = 10;

    private float size = 3f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform floorPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        DrawWalls();
        DrawFloor();

    }

    private void DrawFloor()
    {
        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width, 1, width);
    }

    public void DrawWalls()
    {
        if(width < 50 && width > 0)
        {
            width++;
        }
        WallState[,] maze = MazeGenerator.Generate(width, width);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < width; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + (i*size), 0, -width / 2 + (j*size));

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                    System.Console.WriteLine("The position = " + topWall.position + "  The locale" + topWall.localScale);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                    System.Console.WriteLine("The position = " + leftWall.position + "  The locale" + leftWall.localScale);

                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                        System.Console.WriteLine("The position = " + rightWall.position + "  The locale" + rightWall.localScale);

                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                        System.Console.WriteLine("The position = " + bottomWall.position + "  The locale" + bottomWall.localScale);

                    }
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        //walls[0].localScale = walls[0].localScale + new Vector3(1*Time.deltaTime , 1 * Time.deltaTime, 0);     private List<Transform> walls = new List<Transform>();

    }
}
