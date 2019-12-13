<Query Kind="Program" />

public class Sale
{
public String Item { get; set; }
public String Customer { get; set; }
public double PricePerItem { get; set; }
public int Quantity { get; set; }
public String Address { get; set; }
public bool ExpeditedShipping { get; set; }
}
void Main()
{
	Sale[] Sales = { new Sale(){Item ="Item 1", Customer="Cust 1 LLC",PricePerItem= 44.5,Quantity= 5,Address= "Brooklyn", ExpeditedShipping=false},
	 new Sale(){Item ="Item 2", Customer="Cust 2",PricePerItem= 10.0,Quantity= 56,Address= "Brooklyn", ExpeditedShipping=false},
	 new Sale(){Item ="Item 3", Customer="Cust 3",PricePerItem= 4.4,Quantity= 2,Address= "Hollywood", ExpeditedShipping=true},
	 new Sale(){Item ="Tea", Customer="Cust 4 LLC",PricePerItem= 1.5,Quantity= 10,Address= "St. Petesbourg", ExpeditedShipping=true}
	 };


/*1. Get a collection of all Sale objects where the PricePerItem is over 10.0.*/
var t1 = from s in Sales
			where s.PricePerItem > 10.0
			select s;

/*2. Get a collection of all Sale objects where the Quantity is 1 and get the results in descending order of PricePerItem.*/			
var t2 = from s in Sales
			where s.Quantity == 1 
			orderby s.PricePerItem descending
			select s;

/*3. Get a collection of Sale objects where the Item is “Tea” and ExpeditedShipping is false.*/
var t3 = from g in Sales
				where g.Item == "Tea" && g.ExpeditedShipping == false
				select g;


/*4. Get a collection of all addresses of all Sale objects where the cost of the total order (PricePerItem * Quantity) is over 100.0.*/
//I assume that each Sale should be summed separately
//Here would make more sense to use Distinct() in order not to include same Addresses more than once. 
var t4d = (from s in Sales
				where (s.PricePerItem * s.Quantity) > 100.0
				select s.Address).Distinct() ;
//However, this is a regular simple query:
var t4 = from s in Sales
				where (s.PricePerItem * s.Quantity) > 100.0
				select s.Address;

/*5. Get a collection of a new (anonymous) object type that has an Item property (same as Item in the Sale object), \
a TotalPrice property (a double that is the product of PricePerItem and Quantity), 
and a String called Shipping which is the Address concatenated with the word “EXPEDITE” if ExpeditedShipping is true. 
The collection should only include sales where Customer includes the string “LLC” (insensitive to case)
and it should be ordered by the new TotalPrice property.
*/
var t5 = from s in Sales
			where s.Customer.ToUpper().Contains(" LLC") && s.ExpeditedShipping == true
			orderby s.PricePerItem * s.Quantity
		select new { Item = s.Item, TotalPrice = s.PricePerItem * s.Quantity, Shipping = "EXPEDITE "+s.Address };

// Here is another version - with using extesions "=>" and ordering at the end
var t5e = (from s in Sales
			where s.Customer.Any(x=>s.Customer.ToUpper().Contains(" LLC")) && s.ExpeditedShipping == true
		select new { s.Item, TotalPrice = s.PricePerItem * s.Quantity, Shipping = "EXPEDITE "+s.Address }).OrderBy(z=>z.TotalPrice);
			
foreach (var el in t5){
Console.WriteLine(el);
}
}