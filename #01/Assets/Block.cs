using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Block 
{
    public Vector3 POS;
    public Vector3 SCALE;
    public Quaternion ROTATION;
    public Enums.objType objType;
    public Enums.collider col;
    public Enums.Colors color;


    public string pathb = "Assets/Blocks.txt";
    public string pathg = "Assets/Ground.txt";
    public string pathp = "Assets/Pipe.txt";

    public void save(string path, object obj)
    {
        var content = JsonUtility.ToJson(obj, true);
        File.WriteAllText(path, content);
    }

    //public void BlockSample()
    //{
    //    var block = new Block();
    //    block.POS = Vector3.zero;
    //    block.SCALE = new Vector3(1, 1, 1);
    //    block.ROTATION = Quaternion.identity;
    //    block.objType = Enums.objType.Primitive;
    //    block.col = Enums.collider.Collider;
    //    block.color = Enums.Colors.yellow;
    //    save(pathb, block);
    //}

    //public void GroundSample()
    //{
    //    var ground = new Block();
    //    ground.POS = Vector3.zero;
    //    ground.SCALE = new Vector3(1, 1, 1);
    //    ground.ROTATION = Quaternion.identity;
    //    ground.objType = Enums.objType.Primitive;
    //    ground.col = Enums.collider.Collider;
    //    ground.color = Enums.Colors.brown;
    //    save(pathg, ground);
    //}
    //public void PipeSample()
    //{
    //    var pipe = new Block();
    //    pipe.POS = Vector3.zero;
    //    pipe.SCALE = new Vector3(1, 1, 1);
    //    pipe.ROTATION = Quaternion.identity;
    //    pipe.objType = Enums.objType.Primitive;
    //    pipe.col = Enums.collider.Collider;
    //    pipe.color = Enums.Colors.green;
    //    save(pathp, pipe);
    //}
    
}
