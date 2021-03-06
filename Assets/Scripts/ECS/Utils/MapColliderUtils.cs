﻿using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

public static class MapColliderUtils
{
    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static void SetCostValue (MapColliderInfo map, int x, int y, byte value)
    {
        if (x >= map.MapWidth || x < 0) return;
        if (y >= map.MapHeight || y < 0) return;

        map.CostField[x, y] = value;
    }

    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static void AddCost (MapColliderInfo map, int x, int y, byte value)
    {
        if (x >= map.MapWidth || x < 0) return;
        if (y >= map.MapHeight || y < 0) return;

        map.CostField[x, y] = (byte) math.clamp (map.CostField[x, y] + value, 0, 0xff);
    }

    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static void SubtracCost (MapColliderInfo map, int x, int y, byte value)
    {
        if (x >= map.MapWidth || x < 0) return;
        if (y >= map.MapHeight || y < 0) return;

        map.CostField[x, y] = (byte) math.clamp (map.CostField[x, y] - value, 0, 0xff);
    }

    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static bool UnReachable (MapColliderInfo map, int x, int y)
    {
        if (x >= map.MapWidth || x < 0) return true;
        if (y >= map.MapHeight || y < 0) return true;

        return map.CostField[x, y] == 0xff;
    }

    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static bool UnReachable (MapColliderInfo map, int2 coordinate)
    {
        return UnReachable (map, coordinate.x, coordinate.y);
    }

    [MethodImpl (MethodImplOptions.AggressiveInlining)]
    public static bool IsWall (MapColliderInfo map, int x, int y)
    {
        if (x >= map.MapWidth || x < 0) return false;
        if (y >= map.MapHeight || y < 0) return false;

        return map.CostField[x, y] == 0xff;
    }
}