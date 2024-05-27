using assembly.ViewModel;
namespace assembly.Dto;

public class ResultMessageDto
{
    public MessageTypeViewModel Type { get; set; }
    public string Message { get; set; }

    public void ToMessageTypeViewModel()
    {
        
    }

}
