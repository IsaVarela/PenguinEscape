using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penguin_Test01.Classes.Entities
{
    public static class GameManager
    {
        public static bool isGameOver = false;

        public static Penguin player = null;
        public static List<Orca> orcaList;
        public static Igloo igloo;  

        public static string[] levels = { "Level0.txt", "Level1.txt", "Level2.txt", "Level3.txt" };
        static int currentLevel = 0;
        const int MAXLevels = 4;

        public static void StartGame()
        {

            GameManager.isGameOver = false;

            Map.LoadData();

            GameManager.player = new Penguin(Map.penguinStartRow, Map.penguinStartColumn);

            GameManager.orcaList = new List<Orca>();
        }

        public static void RestartGame()
        {
            GameManager.player = new Penguin(Map.penguinStartRow, Map.penguinStartColumn);
            GameManager.player.CurrentDirection = Direction.NONE;
            
        }

        public static void LoadLevel()
        {
            currentLevel++;

            if (currentLevel == MAXLevels)
            {
                EndGameForm form = new EndGameForm("Game Over");
                form.Show(); 
            }
            else
            {
                Map.MapFile = levels[currentLevel];
                Map.LoadData();
                StartGame();
                GameManager.player.CurrentDirection = Direction.NONE;
            }
        }

        public static void GameOver()
        {
            if (!GameManager.isGameOver)
            {
                GameManager.isGameOver = true;
                EndGameForm form = new EndGameForm("Game Over");
                form.Show(); 
            }
        }
    }
}
