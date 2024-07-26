using Business.DTOs.Tender;

namespace Business.DTOs.TenderStatus;

public class TenderStatusGetDto
{
    public int Id { get; set; }
    public string StatusName { get; set; }
    public string Description { get; set; }
    
    public ICollection<TenderGetDto> Tenders { get; set; }
}