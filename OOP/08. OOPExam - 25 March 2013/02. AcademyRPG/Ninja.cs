using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone || resource.Type == ResourceType.Lumber)
            {
                if (resource.Type == ResourceType.Stone)
                    this.AttackPoints += resource.Quantity * 2;
                else
                    this.AttackPoints += resource.Quantity;

                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int highestHP = int.MinValue;
            int whoHasHighestHPid = 0;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > highestHP)
                    {
                        highestHP = availableTargets[i].HitPoints;
                        whoHasHighestHPid = i;
                    }
                }
            }
            if(whoHasHighestHPid != 0)
                return whoHasHighestHPid;
            else
                return -1;
        }
    }
}
