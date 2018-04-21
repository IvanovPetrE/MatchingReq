﻿using System;
using System.Collections.Generic;
using Trader = MatchingReq.Trader;

namespace Matching
{
    struct Request //структура, которая будет содержать информацию о заявке
    {
        public String TName, reqType, psType;
        public int cost, qt;
        public Request(String TName, String reqType, String psType, int cost, int qt)
        {
            this.TName = TName;
            this.reqType = reqType;
            this.psType = psType;
            this.cost = cost;
            this.qt = qt;
        }
    }

    class Program
    {
        static Trader getNewTrader(String[] vals)
        {
            String id;
            int money, qtA, qtB, qtC, qtD;
            id = vals[0];
            Int32.TryParse(vals[1], out money);
            Int32.TryParse(vals[2], out qtA);
            Int32.TryParse(vals[3], out qtB);
            Int32.TryParse(vals[4], out qtC);
            Int32.TryParse(vals[5], out qtD);
            Trader item = new Trader(id, money, qtA, qtB, qtC, qtD);
            return item;
        }

        static void Main(string[] args)
        {
            Dictionary<String, Trader> Traders = new Dictionary<String, Trader>();
            //чтобы удобнее было обращаться к данным о пользователях, разместим их в словаре
            List<Request> Requests = new List<Request>();
            //к запросам мы не будем часто обращаться, поэтому поместим их в список
            String clientsFL = @"C:\SBT\clients.txt"; // файл с клиентами
            String requestsFL = @"C:\SBT\orders.txt"; // файл с заявками
            int counter = 0;
            String line;
            System.IO.StreamReader file = new System.IO.StreamReader(clientsFL);
            while ((line = file.ReadLine()) != null) //В этом цикле получаем данные о клиентах
            {
                String[] vals = line.Split("\t");
                Traders.Add(vals[0], getNewTrader(vals));
                counter++;
            }
            file.Close();
            Console.WriteLine("There were {0} Traders.", counter);


            counter = 0;
            bool condition = false;
            Request deltaRequest;
            file = new System.IO.StreamReader(requestsFL);
            while ((line = file.ReadLine()) != null) //В этом цикле получаем данные о заявках
            {
                String[] vals = line.Split("\t");
                foreach (Request req in Requests)
                {
                    if (Requests.Count != 0 & req.TName != vals[0] & req.reqType != vals[1] & req.psType == vals[2] & req.cost.ToString() == vals[3] & req.qt.ToString() == vals[4])
                    {
                        Requests.Remove(req);
                        /*Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine(line);
                        Console.WriteLine(req.TName+"\t"+ req.reqType+ "\t" + req.psType+ "\t" + req.cost.ToString()+ "\t" + req.qt.ToString());
                        Console.WriteLine("Req removed");
                        Console.WriteLine("");
                        Console.WriteLine("");*/
                        condition = true; // помечаем, что данную строку в список добавлять не нужно
                        break; //выходим из цикла foreach, иначе возникнет ошибка об изменении списка
                    }
                    else
                    {
                        condition = false; //если совпадений не найдено, то данный запрос нужно поместить в очередь
                    }
                }
                if (!condition)
                {
                    deltaRequest = new Request(vals[0], vals[1], vals[2], Int32.Parse(vals[3]), Int32.Parse(vals[4]));
                    Requests.Add(deltaRequest);
                    /*Console.WriteLine(line + "\t" + counter.ToString());
                    Console.WriteLine("Req added");
                    Console.WriteLine("");*/
                    condition = false;
                }
                counter++;
            }

            file.Close();
            Console.WriteLine("There were {0} Requests.", counter);
            Console.WriteLine("There were {0} Requests didnt processed.", Requests.Count);
            Console.ReadLine();
        }
    }
}
