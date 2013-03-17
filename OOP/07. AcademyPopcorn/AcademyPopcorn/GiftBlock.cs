using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
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
                List<Gift> gifts = new List<Gift>();
                gifts.Add(new Gift(this.topLeft, new char[,] { { '@' } }));

                return gifts;
            }
            else
            {
                return base.ProduceObjects();
            }
        }


    }
}