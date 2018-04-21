using System;
using System.Collections.Generic;
using System.Text;

namespace MatchingReq
{
    class Trader
    {
        //private String name;
        private String id;
        private int money;
        private int qtA, qtB, qtC, qtD;
        public Trader(String id, int money, int qtA, int qtB, int qtC, int qtD)
        {
            this.id = id;
            this.money = money;
            this.qtA = qtA;
            this.qtB = qtB;
            this.qtC = qtC;
            this.qtD = qtD;
        }
        public void buyA(int cost, int qt)
        {
            qtA += qt;
            money -= (cost * qt);
        }
        public void buyB(int cost, int qt)
        {
            qtB += qt;
            money -= (cost * qt);
        }
        public void buyC(int cost, int qt)
        {
            qtB += qt;
            money -= (cost * qt);
        }
        public void buyD(int cost, int qt)
        {
            qtC += qt;
            money -= (cost * qt);
        }
        public void sellA(int cost, int qt)
        {
            qtA -= qt;
            money += (cost * qt);
        }
        public void sellB(int cost, int qt)
        {
            qtB -= qt;
            money += (cost * qt);
        }
        public void sellC(int cost, int qt)
        {
            qtC -= qt;
            money += (cost * qt);
        }
        public void sellD(int cost, int qt)
        {
            qtD -= qt;
            money += (cost * qt);
        }
        public String[] getTraderData()
        {
            String[] data = { id, money.ToString(), qtA.ToString(), qtB.ToString(), qtC.ToString(), qtD.ToString() };
            return data;
        }//метод вернет массив строк со значениями полей, нужно для вывода итоговых значений

    }
}
