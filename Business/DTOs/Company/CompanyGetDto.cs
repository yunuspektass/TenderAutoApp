using Business.DTOs.CompanyTender;
using Business.DTOs.Offer;
using Business.DTOs.User;

namespace Business.DTOs.Company;
using Domain.Models;

public class CompanyGetDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string ContactInformation { get; set; }
    public string TaxNumber { get; set; }
    public string Sector { get; set; }



}
