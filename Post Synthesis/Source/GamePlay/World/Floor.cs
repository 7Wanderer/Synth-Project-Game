#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Post_Synthesis.Source;
using SharpDX.MediaFoundation;
#endregion

namespace Post_Synthesis
{
    public class Floor
    {
        readonly Point mapTileSize = new(128, 8);
        readonly Basic2D[,] tiles;
        public Point tileSize, mapSize;
        public Vector2 position;
        public readonly int distance;

        public Floor(int distance)
        {
            this.distance = distance;
            tiles = new Basic2D[mapTileSize.X, mapTileSize.Y];
            tileSize = new(50, 50);
            mapSize = new(tileSize.X*mapTileSize.X,tileSize.Y*mapTileSize.Y);
            position = new(tileSize.X/2, distance + tileSize.X/2);
            for (int i = 0; i < mapTileSize.X; i++)
            {
                for(int j = 0; j < mapTileSize.Y; j++)
                {
                    tiles[i, j] = new("Assets\\World\\Tiles\\Alpha Level\\Alpha 1", new(i * tileSize.X + position.X, j * tileSize.Y+position.Y),tileSize.ToVector2());
                }
            }
        }

        public void Draw(Vector2 OFFSET)
        {
            for (int i = 0; i < mapTileSize.X; i++)
            {
                for (int j = 0; j < mapTileSize.Y; j++) tiles[i, j].Draw(OFFSET);
            }
        }

    }
}
