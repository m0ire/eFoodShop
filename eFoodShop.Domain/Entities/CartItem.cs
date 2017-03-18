using System;

namespace eFoodShop.Domain.Entities
{
    public class CartItem
    {
        public int CartId { get; private set; }
        public Cart Cart { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Count {
            get { return _count; }
            private set
            {
                if(value <= 0)
                    throw new Exception();

                _count = value;
            }
        }

        private int _count;

        [Obsolete("Only for model binders and EF, don\'t use it in your code", true)]
        public CartItem() { }

        public CartItem(Cart cart, Product product, int count = 1)
        {
            CartId = cart.Id;
            Cart = cart;
            ProductId = product.Id;
            Product = product;
            Count = count;
        }

        public void SetCount(int count)
        {
            Count = count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var cartItemObj = (CartItem)obj;
            return cartItemObj.CartId == CartId && cartItemObj.ProductId == ProductId;
        }

        public override int GetHashCode()
        {
            return CartId.GetHashCode() + ProductId.GetHashCode();
        }
    }
}