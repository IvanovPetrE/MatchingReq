using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingReqClassLibrary
{
    public class Trader
    {
        //private String name;
        private String id; //имя
        private int money;//Баланс клиента по долларам 
        private int qtA, qtB, qtC, qtD;//балланс по ценным бумагам
        public Trader(String id, int money, int qtA, int qtB, int qtC, int qtD)
        {
            this.id = id;
            this.money = money;
            this.qtA = qtA;
            this.qtB = qtB;
            this.qtC = qtC;
            this.qtD = qtD;
        }
        public Trader (String[] vals) //метод для простоты создания нового объекта.
        {
            this.id = vals[0];
            Int32.TryParse(vals[1], out this.money);
            Int32.TryParse(vals[2], out this.qtA);
            Int32.TryParse(vals[3], out this.qtB);
            Int32.TryParse(vals[4], out this.qtC);
            Int32.TryParse(vals[5], out this.qtD);
        }

        public void buyOrSellPS(String reqType, String psType, int cost, int qt)
        {
            switch (psType)
            {
                case "A":
                    if (reqType == "b")
                        buyA(cost, qt);
                    else
                        sellA(cost, qt);
                    break;

                case "B":
                    if (reqType == "b")
                        buyB(cost, qt);
                    else
                        sellB(cost, qt);
                    break;

                case "C":
                    if (reqType == "b")
                        buyC(cost, qt);
                    else
                        sellC(cost, qt);
                    break;

                case "D":
                    if (reqType == "b")
                        buyD(cost, qt);
                    else
                        sellD(cost, qt);
                    break;
            }
        }
        private void buyA(int cost, int qt)
        {
            qtA += qt;
            money -= (cost * qt);
        }
        private void buyB(int cost, int qt)
        {
            qtB += qt;
            money -= (cost * qt);
        }
        private void buyC(int cost, int qt)
        {
            qtB += qt;
            money -= (cost * qt);
        }
        private void buyD(int cost, int qt)
        {
            qtC += qt;
            money -= (cost * qt);
        }
        private void sellA(int cost, int qt)
        {
            qtA -= qt;
            money += (cost * qt);
        }
        private void sellB(int cost, int qt)
        {
            qtB -= qt;
            money += (cost * qt);
        }
        private void sellC(int cost, int qt)
        {
            qtC -= qt;
            money += (cost * qt);
        }
        private void sellD(int cost, int qt)
        {
            qtD -= qt;
            money += (cost * qt);
        }
        public String getTraderData()//метод вернет массив строк со значениями полей, нужно для вывода итоговых значений
        {
            String data = id + "\t" + money.ToString() + "\t" + qtA.ToString() + "\t" + qtB.ToString() + "\t" + qtC.ToString() + "\t" + qtD.ToString();
            return data;
        }
    }
}
