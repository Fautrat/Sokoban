using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<MoveBlock> listAllMovements = new List<MoveBlock>();

    public void onRestart()
    {
        Debug.Log("reload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void onUndo()
    {
        if(listAllMovements.Count > 0)
        {
            listAllMovements[listAllMovements.Count - 1].UndoLastMove();
            listAllMovements.RemoveAt(listAllMovements.Count - 1);
        }
    }
}
