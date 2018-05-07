using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is for cube groups rotation 
 */
public class Rotation : MonoBehaviour
{
    public bool isActive;
    int rotAngel = 0;
    Vector3[][] rotation;
    public Transform[] blocks;
    public string type;

    bool isRotating = false;

    // Use this for initialization
    void Awake()
    {
        //Assign the 4 blocks of each group 
        blocks = new Transform[4];
        for (int i = 0; i < transform.childCount; i++)
        {
            blocks[i] = transform.GetChild(i);
        }
        getRotByType(type);
    }

    //Perform rotation to left side
    public void rotateLeft(bool back)
    {
        rotAngel = getRotAngle(rotAngel + 90);
        rotate(rotAngel / 90);
        if (!back && !GridPlayground.UpdateCellState())
        {
            rotateRight(true);
        }
    }

    //Perform rotation clockwards
    public void rotateRight(bool back)
    {
        if (!isRotating || back)
        {
            isRotating = true;
            rotAngel = getRotAngle(rotAngel - 90);
            rotate(rotAngel / 90);
            if (!back && !GridPlayground.UpdateCellState())
            {
                rotateLeft(true);
            }
            isRotating = false;
        }
    }

    int getRotAngle(int angle)
    {
        if (angle < 0)
            return 360 + angle;
        else if (angle > 270)
            return 0;
        return angle;
    }

    //Rotate the blocks to position pos
    void rotate(int pos)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].localPosition = rotation[pos][i];
        }
    }

    //Get the rotation pattern by type of the group 
    void getRotByType(string type)
    {
        if (type == "I")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (3,0,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (2,1,0),
                new Vector3 (2,0,0),
                new Vector3 (2,-1,0),
                new Vector3 (2,-2,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot0, rot90 };
        }
        else if (type == "T")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (1,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (2, 0, 0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot180 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, -1, 0),
                new Vector3 (2,-1,0)
            };
            Vector3[] rot270 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot180, rot270 };
        }
        else if (type == "L")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (0,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (1,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, -1, 0),
                new Vector3 (2,-1,0)
            };
            Vector3[] rot180 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, -1, 0),
                new Vector3 (2, -1, 0),
                new Vector3 (2,0,0)
            };
            Vector3[] rot270 = new Vector3[] {
                new Vector3 (0,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot180, rot270 };
        }
        else if (type == "J")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (2,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (1,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, -1, 0),
                new Vector3 (2,1,0)
            };
            Vector3[] rot180 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, -1, 0),
                new Vector3 (2, -1, 0),
                new Vector3 (0,0,0)
            };
            Vector3[] rot270 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot180, rot270 };
        }
        else if (type == "S")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (0,-1,0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1, 0, 0),
                new Vector3 (0, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot0, rot90 };
        }
        else if (type == "Z")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (1,0,0),
                new Vector3 (0,0,0),
                new Vector3 (2,-1,0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (2,0,0),
                new Vector3 (1, 0, 0),
                new Vector3 (2,1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot0, rot90 };
        }
        else if (type == "O")
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(1,1,0),
                new Vector3(0,1,0)
            };
            rotation = new Vector3[][] { rot0, rot0, rot0, rot0 };
        }
    }
}
