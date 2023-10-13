#region
using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Synth_Project.Source.GamePlay;
using Synth_Project.Source.Engine;
#endregion

namespace Synth_Project
{
    public class Floor
    {
        readonly Point mapTileSize = new(16, 4);
        readonly Basic2D[,] tiles;
        public Point tileSize, mapSize;

        public Floor()
        {
            tiles = new Basic2D[mapTileSize.X, mapTileSize.Y];
            tileSize = new(100, 100);
            mapSize = new(tileSize.X*mapTileSize.X,tileSize.Y*mapTileSize.Y);
            for(int i = 0; i < mapTileSize.X; i++)
            {
                for(int j = 0; j < mapTileSize.Y; j++)
                {
                    tiles[i, j] = new("Assets\\Tiles\\Floor\\Alpha 1", new(i * tileSize.X, j * tileSize.Y+400),tileSize.ToVector2());
                    tiles[i, j].scale = 1f;
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
