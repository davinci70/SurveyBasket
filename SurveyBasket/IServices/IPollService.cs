namespace SurveyBasket.IServices;

public interface IPollService
{
    IEnumerable<Poll> GetAll();
    Poll Get(int id);
}
