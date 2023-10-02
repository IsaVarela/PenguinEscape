using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Penguin_Test01.Classes.States;
using Penguin_Test01.Classes.Pathfinding; 


namespace Penguin_Test01.Classes.Entities
{
    public class Penguin : AbstractEntity
    {
        public static string[] imageFiles = {"PenguinNone.png", "PenguinUp.png", "PenguinDown.png",
                                             "PenguinLeft.png", "PenguinRight.png" };
        // Variables 
        private int MaxLives = 3;
        private int MaxHammer = 3;
        private int MaxEnergy = 100; 

        private int lives;
        private int hammer;
        private int energy;

        private bool canUseHammer;
        private Direction currentDirection;
        private IState currentState;

        private List<Node> path;

        // Properties 
        public int Lives { get => lives; set => lives = value; }
        public int Hammer { get => hammer; set => hammer = value; }
        public int Energy { get => energy; set => energy = value; }
        public IState CurrentState { get => currentState; set => currentState = value; }
        public bool CanUseHammer { get => canUseHammer; set => canUseHammer = value; }
        public Direction CurrentDirection { get => currentDirection; set => currentDirection = value; }
        public List<Node> Path { get => path; set => path = value; }

        public Penguin(int row, int column) : base (row, column)
        {            
            this.lives = MaxLives;
            this.hammer = MaxHammer;
            this.energy = MaxEnergy;
            CanUseHammer = false;
            this.CurrentDirection = Direction.NONE;
            this.currentState = NormalState.GetInstance();

        }

        public override void Draw(Graphics g)
        {
            Rectangle myRectangle = base.GetRectangle();

            int index = (int)CurrentDirection;
            string myFileName = imageFiles[index];

            using (Image myImage = Image.FromFile(Map.Path + myFileName))
            {
                g.DrawImage(myImage, myRectangle); 
            }
        }

        public List<Node> FindPath(Penguin penguin)
        {
            Node IglooNode = new Node(GameManager.igloo.Row, GameManager.igloo.Column, null, null);
            Node PenguinNode = new Node(this.Row, this.Column, IglooNode, null);

            return AStar.Find_Path(PenguinNode, IglooNode);
        }

        public void UpdatePath()
        {
            this.path = this.FindPath(this);
            this.path.RemoveAt(0); 
        }

        public void DrawPath(Graphics g)
        {
            UpdatePath();
            for (int i = 0; i < path.Count - 1; i++)
            {
                Node startNode = this.path[i];
                Node endNode = this.path[i + 1];

                int StartPointX = (startNode.Column * Map.TileSize) + (2 * Map.TileSize) / 5;
                int StartPointY = (startNode.Row * Map.TileSize) + (2 * Map.TileSize) / 5;

                int EndPointX = (endNode.Column * Map.TileSize) + (2 * Map.TileSize) / 5;
                int EndPointY = (endNode.Row * Map.TileSize) + (2 * Map.TileSize) / 5;

                Point startPoint = new Point(StartPointX, StartPointY);
                Point endPoint = new Point(EndPointX, EndPointY);

                Pen myPen = new Pen(Color.DarkSlateBlue, 1);
                g.DrawLine(myPen, startPoint, endPoint);

                myPen.Dispose();
            }
        }

        public Point GetVelocity()
        {
            Point velocity = new Point(0, 0);

            switch (this.CurrentDirection)
            {
                case Direction.UP:
                    velocity = new Point(0, -1);
                    break;
                case Direction.DOWN:
                    velocity = new Point(0, 1);
                    break;
                case Direction.LEFT:
                    velocity = new Point(-1, 0);
                    break;
                case Direction.RIGHT:
                    velocity = new Point(1, 0);
                    break;
                default:
                    velocity = new Point(0, 0);
                    break; 
            }
            return velocity; 
        }

        public void Move()
        {
            Point velocity = this.GetVelocity();

            int nextRow = this.Row + velocity.Y;
            int nextColumn = this.Column + velocity.X;
            AbstractEntity obj = Map.arrayEntities[nextRow, nextColumn];

            if (this.CanPassThrough(obj))
            {
                this.Row = nextRow;
                this.Column = nextColumn;

                if (obj is Igloo)
                {
                    GameManager.LoadLevel(); // NextLevel 
                }
                else
                {
                    LooseEnergy(5);
                    if (this.CanEat(obj))
                    {
                        this.Eat(obj);
                    }

                    if (obj is Orca)
                    {
                        this.CurrentState.Attack(this, obj as Orca);
                    }
                }
            }
            else // if Penguin cannot PassThrough the tile
            {
                if (this.hammer > 0 && this.CanUseHammer == true)
                {
                    Map.arrayEntities[obj.Row, obj.Column] = new EmptyTile(obj.Row, obj.Column);
                    this.hammer--;
                    this.CanUseHammer = false; 
                }
            }
        }

        public void LooseEnergy(int damage)
        {
            this.energy -= damage;
            if (this.energy <= 0)
            {
                if (this.lives > 0)
                {
                    this.lives--;
                    this.energy = MaxEnergy;
                }
                else
                {
                    GameManager.GameOver(); 
                }
            }
        }

        public bool CanPassThrough(AbstractEntity entity)
        {
            return !(entity is Wall);  
        }

        public void Eat(AbstractEntity entity)
        {
            if (entity is Food)
            {
                Map.arrayEntities[entity.Row, entity.Column] = new EmptyTile(entity.Row, entity.Column);
                this.currentState = FightState.GetInstance();
                this.energy += (entity as Food).BonusEnergy;
            }
        }

        public bool CanEat(AbstractEntity entity)
        {
            return entity is Food; 
        }
    }
}
