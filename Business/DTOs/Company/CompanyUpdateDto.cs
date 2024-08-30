namespace Business.DTOs.Company;

public class CompanyUpdateDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string ContactInformation { get; set; }
    public string TaxNumber { get; set; }
    public string Sector { get; set; }
    public List<int> TenderIds { get; set; }

    public List<int> UserIds { get; set; } = new List<int>();

}
