using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PerlinArrays : MonoBehaviour
{//////////////////////////////////height&width,scale,coordx,coordy,frequency,lacunarity,persistance,octaves,amplitude
    private const float UnitCoordinatesBase = 10;
    private const float seed = 420;
    private static float[] _heightMapArray =       { 200, .3f, 10, 10, 0.1f,   3,    .7f,  2 ,1};
    private static float[] _heightIntensityArray = { 200, .2f, 10, 10, 0.1f, 1.15f, 1.25f, 4 ,1};
    private static float[] _zonesArray =           { 200, .1f, 10, 10, 0.01f,  2f,   1f,   6 ,0};
    private static float[] _forestArray =           { 200, 1, 10, 10, 0.18f,  1f,  .44f,   6 ,0};
    private static readonly Dictionary<OverWorldZone, float[]> OverWorldZonePerlinArrays = new Dictionary<OverWorldZone, float[]>
    {
        {OverWorldZone.Forest,_forestArray},
    };
    public static float[] GetHeightMapArray()
    {   
        return _heightMapArray;   
    }   
    public static float[] GetHeightIntensityArray()
    {    
        return _heightIntensityArray;  
    }
    public static float[] GetZonesArray()
    {   
        return _zonesArray;   
    }

    public static float[] GetZoneArrayFromZoneType(OverWorldZone zoneType)
    {
        float[] returnZone = new float[8];
        OverWorldZonePerlinArrays.TryGetValue(zoneType, out returnZone);
        return returnZone;
    }
    public static void SetPerlinSize(int size)
    {
        _heightMapArray[0] = size+1;//these are modifying vertices, so they are larger than the number of tiles
        _heightIntensityArray[0] = size+1;//these are modifying vertices, so they are larger than the number of tiles
        _zonesArray[0] = size+1;
    }
    
    public static void AdjustHeightMapPerlinCoordinates(Vector3 perlinCoordinates)
    {
        perlinCoordinates += new Vector3(seed, 0, seed);
        var heightMapScale = _heightMapArray[1];
        var heightIntensityScale = _heightIntensityArray[1];

         _heightMapArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * heightMapScale;
         _heightMapArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * heightMapScale;
         
         _heightIntensityArray[2] = perlinCoordinates.x/UnitCoordinatesBase* heightIntensityScale;
         _heightIntensityArray[3] = perlinCoordinates.z / UnitCoordinatesBase * heightIntensityScale;
    }
    public static void AdjustZonesPerlinCoordinates(Vector3 perlinCoordinates)
    {
        perlinCoordinates += new Vector3(seed, 0, seed);
        var zoneScale = _zonesArray[1];
        var forestScale = _forestArray[1];
        
        _zonesArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * zoneScale;
        _zonesArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * zoneScale;
        
        _forestArray[2] = perlinCoordinates.x/ UnitCoordinatesBase * forestScale;
        _forestArray[3] = perlinCoordinates.z/ UnitCoordinatesBase * forestScale;

    }
}
