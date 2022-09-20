using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public SceneManager sceneManager = new SceneManager();
    public Block block;



    private void Awake()
    {
        sceneManager.AddXBlocksH(block.pathg, new Vector3(0, 1), 70);

        sceneManager.AddXBlocksH(block.pathb, new Vector3(21, 5), 5);
        sceneManager.AddBlock(block.pathb, new Vector3(23, 9));

        sceneManager.AddXBlocksV(block.pathp, new Vector3(29, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(30, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(39, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(40, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(47, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(48, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(58, 2), 2);
        sceneManager.AddXBlocksV(block.pathp, new Vector3(59, 2), 2);
    }
}
