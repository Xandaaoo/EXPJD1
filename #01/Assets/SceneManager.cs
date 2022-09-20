using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneManager
{

    
    public void AddBlock(string path)
    {
        GameObject go = NewBlock(path);
    }
    public void AddBlock(string path, Vector3 pos)
    {
        GameObject go = NewBlock(path, pos);
    }
    public void AddXBlocksH(string path, Vector3 initialPos, int numberOfBlocks)
    {
        for (int i = 0; i < numberOfBlocks; i++)
        {
            NewBlock(path, initialPos);
            initialPos.x++;
        }
    }
    public void AddXBlocksV(string path, Vector3 initialPos, int numberOfBlocks)
    {
        for (int i = 0; i < numberOfBlocks; i++)
        {
            NewBlock(path, initialPos);
            initialPos.y++;
        }
    }

    public GameObject NewBlock(string path)
    {
        var content = File.ReadAllText(path);
        var fjson = JsonUtility.FromJson<Block>(content);
        //setando parametros de acordo com json carregado
        GameObject go = SetObj(fjson.objType);
        go.transform.localScale = fjson.SCALE;
        SetCollider(fjson.col, go);

        go.transform.position = fjson.POS;
        go.transform.rotation = fjson.ROTATION;

        Material mat = NewMaterial(fjson.color);
        go.GetComponent<Renderer>().material = mat;
        return go;
    }

    //AlteraPosição
    public GameObject NewBlock(string path, Vector3 initialPos)
    {
        var content = File.ReadAllText(path);
        var fjson = JsonUtility.FromJson<Block>(content);

        GameObject go = SetObj(fjson.objType);
        go.transform.localScale = fjson.SCALE;
        SetCollider(fjson.col, go);

        go.transform.position = initialPos;
        go.transform.rotation = fjson.ROTATION;


        Material mat = NewMaterial(fjson.color);
        go.GetComponent<Renderer>().material = mat;
        return go;
    }

    static public Material NewMaterial(Enums.Colors color)
    {
        Material mat = new Material(Shader.Find("Standard"));
        Color c;
        switch (color)
        {
            case Enums.Colors.yellow:
                c = Color.yellow;
                break;
            case Enums.Colors.brown:
                c = new Color32(191, 90, 0, 255);
                break;
            case Enums.Colors.green:
                c = Color.green;
                break;
            default:
                c = Color.black;
                break;
        }
        mat.color = c;
        return mat;
    }

    private void SetCollider(Enums.collider col, GameObject go)
    {
        switch (col)
        {
            case Enums.collider.None:
                //nada
                break;
            case Enums.collider.Collider:
                go.AddComponent<BoxCollider>();
                break;
            case Enums.collider.Trigger:
                go.AddComponent<BoxCollider>().isTrigger = true;
                break;
            default:
                break;
        }
    }

    private GameObject SetObj(Enums.objType objtype)
    {
        GameObject go;
        switch (objtype)
        {
            case Enums.objType.GameObject:
                //Criando GO (utilizado Sphere para haver atribuição em todos os casos)
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case Enums.objType.Primitive:
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case Enums.objType.Prefab:
                //Carregando um prefab Prefab (utilizado Sphere para haver atribuição em todos os casos)
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            default:
                //Jogando Erro (utilizado Sphere para haver atribuição em todos os casos)
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Debug.LogError("Parece que ta faltando alguma coisa aqui");
                break;
        }
        return go;

    }
}