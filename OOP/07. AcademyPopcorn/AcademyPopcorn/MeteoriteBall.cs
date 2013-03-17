using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public TrailObject Tail { get; set; }
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            Tail = new TrailObject(new MatrixCoords(5, 5), new char[,] { { '|' }, {'|'}, {'^'} }, 39);
        }

        protected override void UpdatePosition()
        {
            base.UpdatePosition();
            this.Tail.Update(this.TopLeft);
        }
    }
}