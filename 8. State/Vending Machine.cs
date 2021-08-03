using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class VendingMachine
    {
        private Product product = new Product();
        internal decimal Money { get; set; }

        internal VMState ReadyState { get; private set; }
        internal VMState HasMoneyState { get; private set; }
        internal VMState DispenseItemState { get; private set; }
        internal VMState DispenseChangeState { get; private set; }
        internal VMState State { get; set; }

        #region 클라이언트가 사용하는 public 메서드
        public VendingMachine()
        {
            Money = 0;
            ReadyState = new ReadyState(this);
            HasMoneyState = new HasMoneyState(this);
            DispenseItemState = new DispenseItemState(this);
            DispenseChangeState = new DispenseChangeState(this);
            State = ReadyState;
        }

        public void AddMoney(decimal money)
        {
            State.AddMoney(money);
        }
        public void SelectItem(int itemId)
        {
            State.SelectItem(itemId);
        }
        #endregion

        internal decimal? GetPrice(int itemId)
        {
            return product.GetPrice(itemId);
        }
    }

    internal abstract class VMState
    {
        protected VendingMachine vendingMachine;
        public abstract void AddMoney(decimal money);
        public abstract void SelectItem(int itemId);
        public abstract void ReturnChange(decimal money);
    }

    internal class ReadyState : VMState
    {
        public ReadyState(VendingMachine context)
        {
            vendingMachine = context;
        }

        public override void AddMoney(decimal money)
        {
            vendingMachine.State = vendingMachine.HasMoneyState;
            vendingMachine.State.AddMoney(money);
        }

        public override void SelectItem(int itemId)
        {
            throw new ApplicationException();
        }

        public override void ReturnChange(decimal money)
        {
            throw new ApplicationException();
        }
    }

    internal class HasMoneyState : VMState
    {
        public HasMoneyState(VendingMachine context)
        {
            vendingMachine = context;
        }

        public override void AddMoney(decimal money)
        {
            vendingMachine.Money += money;
            Console.WriteLine($"Add ${money}, Balance: ${vendingMachine.Money}");
        }

        public override void SelectItem(int itemId)
        {
            decimal? price = vendingMachine.GetPrice(itemId).Value;

            if (!price.HasValue)
            {
                Console.WriteLine($"{itemId} not found");
                return;
            }
            if (vendingMachine.Money < price.Value)
            {
                Console.WriteLine("Insufficient money");
                return;
            }

            vendingMachine.State = vendingMachine.DispenseItemState;
            vendingMachine.State.SelectItem(itemId);
        }

        public override void ReturnChange(decimal money)
        {
            throw new ApplicationException();
        }
    }

    internal class DispenseItemState : VMState
    {
        public DispenseItemState(VendingMachine context)
        {
            vendingMachine = context;
        }

        public override void AddMoney(decimal money)
        {
            throw new ApplicationException();
        }

        public override void SelectItem(int itemId)
        {
            decimal? price = vendingMachine.GetPrice(itemId).Value;

            Console.WriteLine($"Dispense Item#{itemId} $({price.Value})");

            vendingMachine.Money -= price.Value;

            vendingMachine.State = vendingMachine.DispenseChangeState;

            vendingMachine.State.ReturnChange(vendingMachine.Money);
        }

        public override void ReturnChange(decimal money)
        {
            throw new ApplicationException();
        }
    }

    internal class DispenseChangeState : VMState
    {
        public DispenseChangeState(VendingMachine context)
        {
            vendingMachine = context;
        }

        public override void AddMoney(decimal money)
        {
            throw new ApplicationException();
        }

        public override void SelectItem(int itemId)
        {
            throw new ApplicationException();
        }

        public override void ReturnChange(decimal money)
        {
            if (vendingMachine.Money > 0)
            {
                Console.WriteLine($"Return change ${money}...");
                vendingMachine.Money -= money;
            }

            vendingMachine.State = vendingMachine.ReadyState;
        }
    }

    internal class Product
    {
        private List<Item> items;

        public Product()
        {
            items = new List<Item>();

            items.Add(new Item { Id = 101, Price = 3.50M });
            items.Add(new Item { Id = 201, Price = 4.00M });
            items.Add(new Item { Id = 301, Price = 4.50M });
        }

        public decimal? GetPrice(int itemId)
        {
            var item = items.SingleOrDefault(p => p.Id == itemId);

            return (item == null) ? null : (decimal?)item.Price;
        }
        private class Item
        {
            public int Id { get; set; }
            public decimal Price { get; set; }
        }
    }

    class Clent
    {
        static void Main(string[] args)
        {
            var vm = new VendingMachine();
            vm.AddMoney(1);
            vm.AddMoney(1);
            vm.AddMoney(1);
            vm.AddMoney(1);
            vm.SelectItem(101);
        }
    }
}
