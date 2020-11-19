using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    class DAOtransactions
    {
        private Dbal _dbal;

        public DAOtransactions(Dbal dbal)
        {
            _dbal = dbal;
        }
    }
}
