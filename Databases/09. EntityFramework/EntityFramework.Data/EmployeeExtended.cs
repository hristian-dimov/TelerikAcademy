using System;
using System.Linq;
using System.Data.Linq;

namespace EntityFramework.Data
{
    public partial class Employee
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTerritories);

                return entityTerritories;
            }
        }
    }
}
