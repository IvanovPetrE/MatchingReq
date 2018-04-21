using System;
using System.Collections.Generic;
using System.Text;

namespace MatchingReq//класс, который будет содержать информацию о заявке
{
    class Request
    {
        public String TName, reqType, psType; //Имя клиента, символ операции, наименование ценной бумаги
        public int cost, qt;//цена, количество
        public Request(String TName, String reqType, String psType, int cost, int qt)
        {
            this.TName = TName;
            this.reqType = reqType;
            this.psType = psType;
            this.cost = cost;
            this.qt = qt;
        }
    }
}
