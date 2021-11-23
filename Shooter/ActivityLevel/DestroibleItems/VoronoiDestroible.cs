using System;
using UnityEngine;

namespace ActivityLevel.DestroibleItems
{
    public class VoronoiDestroible : DestroybleItem
    {
        protected override void Explosive()
        {
            foreach (var voronoiPiece in _voronoiPieces)
            { 
                voronoiPiece.EnablePhysics();
            }
        }
    }
}