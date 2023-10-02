using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO; 

namespace Penguin_Test01.Classes.Entities
{
    public static class Map
    {
        public static readonly int TileSize = 25;

        public static Color backColor = Color.LightBlue;

        public static string Path = "../../Classes/Resources/";
        public static string MapFile = "Level0.txt";
        
        public static AbstractEntity[,] arrayEntities = null;

        public static List<Orca> ListOrca = new List<Orca>();

        public static List<EmptyTile> EmptyTileList = new List<EmptyTile>(); 

        public static int maxRows = 10;
        public static int maxColumns = 10;

        // variables for the position of the penguin 
        public static int penguinStartRow = 0;
        public static int penguinStartColumn = 0; 

        public static void LoadData()
        {
            string[] lines = File.ReadAllLines(Map.Path + MapFile);

            Map.maxRows = lines.Length;
            Map.maxColumns = lines[0].ToCharArray().Length;
            Map.arrayEntities = new AbstractEntity[Map.maxRows, Map.maxColumns];

            int row = 0;
            foreach (string line in lines)
            {
                char[] chars = line.ToCharArray();
                int column = 0;

                foreach (char character in chars)
                {
                    // get penguin position from map 
                    // set rows and columns for game manager 
                    if (character == 'P')
                    {
                        penguinStartRow = row;
                        penguinStartColumn = column; 
                    }

                    AbstractEntity obj;
                    switch (character)
                    {
                        case '#': // create a wall 
                            obj = new Wall(row, column);
                            break;
                        case 'F': // create food 
                            obj = new Food(row, column);
                            break;
                        case 'E': // create enemy 
                            obj = new Orca(row, column);
                            break;
                        case 'I': // create igloo 
                            obj = new Igloo(row, column);
                            GameManager.igloo = (obj as Igloo);
                            break;
                        case '.': // create empty tile 
                            obj = new EmptyTile(row, column);
                            EmptyTileList.Add(obj as EmptyTile); 
                            break;
                        default:
                            obj = new EmptyTile(row, column);
                            EmptyTileList.Add(obj as EmptyTile); 
                            break; 
                    }
                    Map.arrayEntities[row, column] = obj;
                    column++; 
                }
                row++; 
            }
        }
    }
}
