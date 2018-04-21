using System;
using System.IO;
using System.Collections.Generic;
using Trader = MatchingReq.Trader;
using Request = MatchingReq.Request;

namespace Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, Trader> Traders = new Dictionary<String, Trader>();
            //чтобы удобнее было обращаться к данным о пользователях, разместим их в словаре
            List<Request> Requests = new List<Request>();
            //к запросам мы не будем часто обращаться, поэтому поместим их в список, еще можно использовать коллекцию Queue
            String clientsFL = @"C:\SBT\clients.txt"; // файл с клиентами
            String requestsFL = @"C:\SBT\orders.txt"; // файл с заявками
            String export = @"C:\SBT\export.txt";
            int counter = 0;
            String line;
            System.IO.StreamReader file;
            try
            {
                file = new System.IO.StreamReader(clientsFL);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"Ошибка. Файл C:\SBT\clients.txt не найден");
                Console.ReadLine();
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Ошибка. Файл C:\SBT\clients.txt не найден");
                Console.ReadLine();
                return;
            }
            try
            {
                while ((line = file.ReadLine()) != null) //В этом цикле получаем данные о клиентах
                {
                    String[] vals = line.Split("\t");
                    Traders.Add(vals[0], Trader.createNewTrader(vals));
                    counter++;
                }
                file.Close();
                Console.WriteLine("There were {0} Traders.", counter);
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка на этапе чтения файла с информацией о клиентах");
                Console.ReadLine();
                return;
            }
            

            counter = 0;
            bool condition = false;
            Request deltaRequest;
            try
            {
                file = new System.IO.StreamReader(requestsFL);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"Ошибка. Файл C:\SBT\orders.txt не найден");
                Console.ReadLine();
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Ошибка. Файл C:\SBT\orders.txt не найден");
                Console.ReadLine();
                return;
            }
            while ((line = file.ReadLine()) != null) //В этом цикле получаем данные о заявках
            {
                String[] vals = line.Split("\t");
                foreach (Request req in Requests)
                {
                    if (Requests.Count != 0 & req.TName != vals[0] & req.reqType != vals[1] & req.psType == vals[2] & req.cost.ToString() == vals[3] & req.qt.ToString() == vals[4])
                    //
                    {

                        /*Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine(line);
                        Console.WriteLine(req.TName+"\t"+ req.reqType+ "\t" + req.psType+ "\t" + req.cost.ToString()+ "\t" + req.qt.ToString());
                        Console.WriteLine("Req removed");
                        Console.WriteLine("");
                        Console.WriteLine("");

                        Console.WriteLine("Old values");
                        Console.WriteLine(Traders[vals[0]].getTraderData());
                        Console.WriteLine(Traders[req.TName].getTraderData());*/
                        Traders[vals[0]].buyOrSellPS(vals[1], vals[2], Int32.Parse(vals[3]), Int32.Parse(vals[4]));
                        Traders[req.TName].buyOrSellPS(req.reqType, req.psType, req.cost, req.qt);
                        /*Console.WriteLine("New values");
                        Console.WriteLine(Traders[vals[0]].getTraderData());
                        Console.WriteLine(Traders[req.TName].getTraderData());
                        Console.WriteLine("");
                        Console.WriteLine("");*/
                        Requests.Remove(req);
                        condition = true; // помечаем, что текущую строку в очередь добавлять не нужно
                        break; //выходим из цикла foreach, иначе возникнет ошибка об изменении списка
                    }
                    else
                    {
                        condition = false; 
                    }
                }
                if (!condition)//если совпадений не найдено, то текущий запрос нужно поместить в очередь
                {
                    deltaRequest = new Request(vals[0], vals[1], vals[2], Int32.Parse(vals[3]), Int32.Parse(vals[4]));
                    Requests.Add(deltaRequest);
                    /*Console.WriteLine(line + "\t" + counter.ToString());
                    Console.WriteLine("Req added");
                    Console.WriteLine("");
                    condition = false;*/
                }
                counter++;
            }
            file.Close();
            Console.WriteLine("There were {0} Requests.", counter);
            Console.WriteLine("There were {0} Requests didnt processed.", Requests.Count);
            try
            {
                StreamWriter fileExport = new StreamWriter(export);
                foreach (String key in Traders.Keys)
                {
                    fileExport.WriteLine(Traders[key].getTraderData());
                    Console.WriteLine(Traders[key].getTraderData());
                }
                fileExport.Close();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(@"Ошибка экспорта. Директория C:\SBT\ не найдена");
                Console.ReadLine();
                return;
            }
            Console.ReadLine();
        }
    }
}
