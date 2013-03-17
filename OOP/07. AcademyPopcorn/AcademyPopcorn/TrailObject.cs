using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class TrailObject : GameObject
    {
        public int Lifetime { get; set; }

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.Lifetime = lifetime;
        }

        public override void Update()
        {
            this.Lifetime--;
            if (this.Lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
            this.topLeft = new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col);
        }

        public void Update(MatrixCoords coords)
        {
            this.Lifetime--;
            if (this.Lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
            this.topLeft = coords;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}