using System;

namespace Practice2
{

/* Order contains a list of products and a customer. Can calculate the total cost of the order
and can return a string for the packing albel, and can return a string for the shipping label.
The total price is calculated as the sum of the prices of each product plus a one-time shipping cost.
This company is based in the USA. If the customer lives in the USA , then the shipping cost is $5.
If the customer does not live in the USA, then the shipping is $35.
A packing label should list the name and product ID of each product in the order.
A shipping label should list the names and address of the customer. */

public class Order
{
    private string _newLine = Environment.NewLine;
    private static string _dividingLine = "*********************************";
    private static decimal _localShippingCost = 5.00M;

    private static decimal _internationalShippingCost = 35.00M;

    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(string customerName, string customerStreetAddress, string customerCity, string customerStateOrProvince, string customerCountry)
    {
        _customer = new Customer(customerName, customerStreetAddress, customerCity, customerStateOrProvince, customerCountry);

    }

    ///<summary>
    ///Add a product
    ///<param name="inputProduct"> An input product instance</param>
    ///</summary>
    public void AddProduct(Product inputProduct)
    {
        _products.Add(inputProduct);
    }

    ///<summary>
    /// Calculate the total cost of the order
    ///</summary>
    public decimal CalculateCost()
    {
        decimal _cost = 0.00M;

        // Get the total cost of all products
        foreach (Product product in _products)
        {
            _cost += product.CalculateTotalPrice();
        }

        //Add the shipping cost based on the
        //Customer's country
        if (_customer.LivesInUSA())
        {
            _cost += _localShippingCost;
        }
        else
        {
            _cost += _internationalShippingCost;
            
        }
        return _cost;

    }
    ///<summary>
    /// Gets the packing label for the order
    ///</summary>
    public void GetPackingLabel()
    {
        string _packingLabel;

        _packingLabel = $"Packing Label: {_newLine}{_dividingLine}{_newLine}";

        foreach (Product product in _products)
        {
            _packingLabel += $"{_newLine}Product Name: {product.GetProductName()}{_newLine}Product ID: {product.GetProductID()}{_newLine}{_dividingLine}";
        } 
        
        Console.WriteLine(_packingLabel);
    }
    ///<summary>
    /// Gets the shippling label for the order
    ///</summary>
    public void GetShippingLabel()
    {
        string _shippingLabel = String.Empty;

        _shippingLabel= $"Shipping Label: {_newLine}{_dividingLine}{_newLine}";

        _shippingLabel += $"{_newLine}{_customer.GetCustomerName()}{_newLine}{_customer.GetCustomerAddress()}{_newLine}{_dividingLine}{_newLine}";

        Console.WriteLine(_shippingLabel);
    }

}
}