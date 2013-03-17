using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodeBlock : Block
    {
        public ExplodeBlock(MatrixCoords topLeft)
            : base(topLeft)
        {

        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<Explosion> Explosions = new List<Explosion>();

                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { '<' } }, new MatrixCoords(-1, -1)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { '<' } }, new MatrixCoords(-1, 0)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { '>' } }, new MatrixCoords(-1, 1)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { '>' } }, new MatrixCoords(0, -1)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { '^' } }, new MatrixCoords(0, 1)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { '^' } }, new MatrixCoords(1, -1)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { 'v' } }, new MatrixCoords(1, 0)));
                Explosions.Add(new Explosion(this.TopLeft, new char[,] { { 'v' } }, new MatrixCoords(1, 1)));

                return Explosions;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}