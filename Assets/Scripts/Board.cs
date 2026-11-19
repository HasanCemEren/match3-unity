using UnityEngine;

public class Board : MonoBehaviour
{
    //Variables:
    [SerializeField] GameObject tileprefab;
    [SerializeField] int gridwidth = 8;
    [SerializeField] int gridheight = 8;

    GameObject[][] grid;

    //Functions:
    void Start()
    {
        //Create a jagged matrix
        grid = new GameObject[gridheight][];
        for(int row = 0; row < gridwidth; ++row) {
            grid[row] = new GameObject[gridwidth];
        }
        //Create the prefab grid
        for(int row = 0; row < gridheight; ++row) {
            for(int column = 0; column < gridwidth; ++column) {
                grid[row][column] = Instantiate(tileprefab, new Vector3(column, row, 0), Quaternion.identity, transform);
            }
        }
    } 
}
