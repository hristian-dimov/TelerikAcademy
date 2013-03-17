using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                if (i == 7) // first hit is that brick
                {
                    currBlock = new ExplodeBlock(new MatrixCoords(startRow, i));
                }
                
                if (i == 17)  // adding gift object
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                }

                engine.AddObject(currBlock);
            }

            // Adding Unpassable Blocks
            for (int i = 10; i < 15; i++)
            {
                UnpassableBlock unpassableBlock = new UnpassableBlock(new MatrixCoords(5, i));
                engine.AddObject(unpassableBlock);
            }

            // Adding Unstoppable Ball
            //UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(unstoppableBall);

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            //MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            //engine.AddObject(meteoriteBall);
            //engine.AddObject(meteoriteBall.Tail);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(leftWall);

                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(rightWall);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(ceiling);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 150);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
