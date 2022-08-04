using ECommerce.API.Dtos;

public class AddCustomerDto : BaseDto
{

    public string Email { get; set; }

    public string Passwrod { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public IFormFile Image { get; set; }

}