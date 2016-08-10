using ShoppingCart.App.Models;
using System.Diagnostics;
using System.Linq;

namespace ShoppingCart.App.Processors
{
    public abstract class Processor
    {
        protected Processor successor;

        public void SetSucessor(Processor successor)
        {
            this.successor = successor;
        }

        protected abstract void Process(Basket basket);

        public virtual void Execute(Basket basket)
        {
            Process(basket);
            if(successor != null)
                successor.Execute(basket);
        }

        protected void PrintItemInfo(IBasketItem item)
        {
           Trace.WriteLine(item.PrintInfo());
        }

        
        protected void PrintTerminator()
        {
           Trace.WriteLine("-------");
        }

        

    }
}
