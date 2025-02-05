namespace SurveyBasket.IServices;

public interface IPollService
{
    IEnumerable<Poll> GetAll();
    Poll? Get(int id);
    Poll Add(Poll poll);
    bool Update(int Id,  Poll poll);
    bool Delete(int Id);
}
