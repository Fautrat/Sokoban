using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MoveBlock[] list;
    public void onRestart()
    {
        Debug.Log("reload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void onUndo()
    {
        foreach(MoveBlock block in list)
        {
            Debug.Log(block.lastPos);
            if(block.lastPos.x != 0.0f)
                block.transform.Translate(block.lastPos - block.transform.position);
                //block.transform.Translate(block.transform.position + block.lastPos);
        }
    }
}
