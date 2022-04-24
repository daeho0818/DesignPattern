using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class User
    {
        private List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void AddCommand(StockBroker broker, string symbol, TxType txType, int qty)
        {
            ICommand command = new StockCommand(broker, symbol, txType, qty);
            commands.Add(command);
        }

        public void ExcuteAll()
        {
            foreach (ICommand cmd in commands)
            {
                cmd.Excute();
            }
        }
    }

    interface ICommand
    {
        void Excute();
    }

    class StockCommand : ICommand
    {
        private StockBroker _broker;
        private string symbol;
        private TxType txType;
        private int qty;

        public StockCommand(StockBroker broker, string symbol, TxType txType, int qty)
        {
            this._broker = broker;
            this.symbol = symbol;
            this.txType = txType;
            this.qty = qty;
        }
        public void Excute()
        {
            _broker.Process(symbol, txType, qty);
        }
    }

    enum TxType { Buy, Sell }

    class StockBroker
    {
        public void Process(string stockSymbol, TxType txType, int qty)
        {
            Console.WriteLine($"{txType.ToString()}, {stockSymbol}, {qty}");
        }
    }

    class Clent
    {
        public static void _Main(string[] args)
        {
            var broker = new StockBroker();

            User user = new User();

            ICommand c = new StockCommand(broker, "MSFT", TxType.Buy, 150);

            for (int i = 0; i < 5; i++)
            {
                user.AddCommand(c);
            }
            user.AddCommand(broker, "AMZN", TxType.Sell, 2000);

            user.ExcuteAll();
        }
    }
}
