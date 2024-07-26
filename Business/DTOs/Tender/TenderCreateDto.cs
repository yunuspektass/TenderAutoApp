using Business.DTOs.TenderProductListGetDto;

namespace Business.DTOs.Tender;

public class TenderCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int UnitId { get; set; }
    public string TenderType { get; set; }
    public decimal Budget { get; set; }
    public int StatusId { get; set; }
    public List<int> ProductIds { get; set; }
    
    public List<TenderProductListCreateDto>? TenderProductLists { get; set; }
    
}