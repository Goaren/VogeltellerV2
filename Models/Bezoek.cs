using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Bezoek
    {
        private int id;
        private DateTime start;
        private DateTime einde;
        private int accountId;
        private int gebiedId;


        public int Id { get { return id; } set { id = value; } }
        public DateTime Start { get { return start; } set { start = value; } }
        public DateTime Einde { get { return einde; } set { einde = value; } }
        public int AccountId { get { return accountId; } set { accountId = value; } }
        public int GebiedId { get { return gebiedId; } set { gebiedId = value; } }

        public Bezoek(int id, DateTime start, int accountId, int gebiedId)
        {
            this.id = id;
            this.start = start;
            this.accountId = accountId;
            this.gebiedId = gebiedId;
        }


    }
}
