using ECommerce.API.Models;

public class Customer : BaseEntity
{

    public IEnumerable<InvoiceDetails> InovicesDetails { get; set; }

    public IEnumerable<Review> Reviews { get; set; }


    public string Email { get; set; }

    public string Passwrod { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string ImagePath { get; set; }


}