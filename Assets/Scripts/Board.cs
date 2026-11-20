using UnityEngine;
using UnityEngine.InputSystem;

public class Board : MonoBehaviour {
    //Variables:
    [SerializeField] GameObject tileprefab;
    [SerializeField] int gridwidth = 8;
    [SerializeField] int gridheight = 8;
    [SerializeField] Color[] tilecolors;

    GameObject[][] grid;
    Vector2 mouseposition;
    Vector3 mouseworldposition;
    float offsetx;
    float offsety;
    int row = 0;
    int column = 0;
    int selectedrow = -1;
    int selectedcolumn = -1;

    //Functions:
    void Start() {
        offsetx = (gridwidth - 1) / 2f;
        offsety = (gridheight - 1) / 2f;

        //Create a jagged matrix
        grid = new GameObject[gridheight][];
        for(int row = 0; row < gridheight; ++row) {
            grid[row] = new GameObject[gridwidth];
        }
        //Create the prefab grid
        for(int row = 0; row < gridheight; ++row) {
            for(int column = 0; column < gridwidth; ++column) {
                Vector3 tileposition = new Vector3(column - offsetx, row - offsety, 0) + transform.position;
                grid[row][column] = Instantiate(tileprefab, tileposition, Quaternion.identity, transform);
                grid[row][column].GetComponent<SpriteRenderer>().color = tilecolors[Random.Range(0, tilecolors.Length)];
            }
        }
    }

    void Update() {
        if(!Mouse.current.leftButton.wasPressedThisFrame) {
            return;
        }

        mouseposition = Mouse.current.position.ReadValue();
        mouseworldposition = Camera.main.ScreenToWorldPoint(new Vector3(mouseposition.x, mouseposition.y, 0.0f));
        column = Mathf.RoundToInt(mouseworldposition.x - transform.position.x + offsetx);
        row = Mathf.RoundToInt(mouseworldposition.y - transform.position.y + offsety);
        if(column < 0 || column >= gridwidth || row < 0 || row >= gridheight) {
            return;
        }
        Debug.Log("row " + row + " column " + column);

        if (selectedrow > -1) {
            grid[selectedrow][selectedcolumn].transform.localScale = Vector3.one;
        }
        grid[row][column].transform.localScale = new Vector3(0.8f, 0.8f, 0.0f);
        selectedrow = row;
        selectedcolumn = column;
    }
}