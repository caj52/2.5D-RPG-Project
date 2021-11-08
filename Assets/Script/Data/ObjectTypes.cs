using System.Collections.Generic;
using UnityEngine;
public enum OverWorldObject
{
    None,
    Tree,
    Rock,
    Flowers
}
public static class ObjectTypes
{
    private static GameObject tree;
    private static GameObject rock;
    private static GameObject flowers;

    private static Dictionary<OverWorldObject, GameObject> OverWorldGameObjects;
    public static void Init()
    {
        tree = Resources.Load<GameObject>("Prefabs/EnviornmentalObjects/Tree");
        rock = Resources.Load<GameObject>("");
        flowers = Resources.Load<GameObject>("");

        OverWorldGameObjects = new Dictionary<OverWorldObject, GameObject>
        {
            {OverWorldObject.None,null},
            {OverWorldObject.Tree,tree},
            {OverWorldObject.Rock,rock}
        };
    }
    
    public static OverWorldObject GetObjectTypeFromPerlinData(float perlinData)
    {
        OverWorldObject returnObject;
        
        if (perlinData<.52)
        {
            returnObject = OverWorldObject.Tree;
        }
        else
        {
            returnObject = OverWorldObject.None;
        }
        return returnObject;
    }

    public static GameObject GetGameObjectFromOverWorldObject(OverWorldObject objectType)
    {
        GameObject returnObject;
        OverWorldGameObjects.TryGetValue(objectType, out returnObject);
        return returnObject;
    }
    
}